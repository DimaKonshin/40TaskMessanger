using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Repository
{
    public class MSSQLEFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        DbContext context;
        DbSet<TEntity> dbSet;

        public MSSQLEFRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public IQueryable<TEntity> Get()
        {
            return dbSet;
        }

        /// <summary>
        /// Get the number of events that satisfy the filter.
        /// </summary>
        /// <param name="category">Filter category by which the filter is implemented</param>
        /// <param name="name">Name of the participant by which the filter is implemented</param>
        /// <param name="skip">Number of elements to be skipped (the number of elements that we already have)</param>
        /// <param name="take">number of elements to be taken (in our case 15)</param>
        public IEnumerable<TaskVM> GetByCategoryAndName(string category, string name, int skip, int take)
        {
            // id from which we begin to take events
            int first = 0;
            // id after which we finish taking events
            int last = 0;
            // Number of events satisfying the filter
            int count = 0;

            if (category == "All")
                category = null;
            if (name == "All")
                name = null;

            // Call the method that will return to us the first and last element, as well as the number of elements.
            GetFirstLastEventId(category, name, (skip > 0 ? skip : 0), (take > 0 ? take : 0), ref first, ref last,ref count);

            // If we do not have events for this filter, then we skip the query
            if (count > 0)
            {
                // Send the database query to the PartEvent table. Filter by category, name and range between the first and last events Id.
                var list = from p in (this.dbSet as DbSet<UsersTask>)
                           where category == null || p.Task.Category.Name == category
                           where name == null || ((p.User.FirstName + " " + p.User.LastName) == name)
                           where (first == last) ? (p.TasksId == first) : (p.TasksId >= first && p.TasksId <= last)
                           // Make a selection in an anonymous type. We take: Id events. The date of the event. Description of the event. 
                           //The name of the event. The name of the event participant.
                           select new
                           {
                               Id = p.TasksId,
                               Date = p.Task.Date,
                               Desription = p.Task.Description,
                               EventName = p.Task.Name,
                               Part = p.User.FirstName + " " + p.User.LastName
                           };

                var list2 = list.ToList().OrderBy(x => x.Id);

                // List of events that we will send to the client
                List<TaskVM> list3 = new List<TaskVM>();

                // Group the resulting list by the event Id
                var list4 = from m in list2
                            group m by new { Id = m.Id };

                var list5 = list4.OrderBy(x => x.Key.Id);

                foreach (var group in list5)
                {
                    int index = 0;

                    TaskVM a = new TaskVM();

                    foreach (var i in group.OrderBy(x=>x.Part))
                    {
                        if(index<=0)
                        {
                            a.TaskName = i.EventName;
                            a.Date = i.Date.ToLocalTime();
                            a.Description = i.Desription;
                            a.Name = i.Part;
                            index++;
                        }
                        else
                        {
                            a.Name += ", " + i.Part;
                        }      
                    }

                    list3.Add(a);
                }

                return list3;
            }

            return new List<TaskVM>();
        }

        /// <summary>
        /// Get the first and last id of the events that satisfy the filter. Get the number of events that satisfy the filter.
        /// </summary>
        /// <param name="category">Filter category by which the filter is implemented</param>
        /// <param name="name">Name of the participant by which the filter is implemented</param>
        /// <param name="skip">Number of elements to be skipped (the number of elements that we already have)</param>
        /// <param name="take">number of elements to be taken (in our case 15)</param>
        /// <param name="first">Id of the element from which the list of events begins</param>
        /// <param name="last">Id of the element on which the list of events ends</param>
        /// <param name="count">Number of events satisfying the filter</param>
        void GetFirstLastEventId(string category, string name, int skip, int take, ref int first, ref int last,ref int count)
        {
            // Send the database query to the PartEvent table. Filter by category and name
            var list = from p in (this.dbSet as DbSet<UsersTask>)
                       where category == null || p.Task.Category.Name == category
                       where name == null || ((p.User.FirstName + " " + p.User.LastName) == name)
                       select new
                       {
                           Id = p.TasksId,
                       };

            // Get the list of events. Skip the number of elements equal to skip. And take the number of elements equal to take.
            var number = list.Distinct().OrderBy(p => p.Id).Skip(skip).Take(take).ToList();

            count = number.Count;

            if (count > 0)
            {
                first = number.First().Id;
                last = number.Last().Id; 
            }
        }

        public int Count()
        {
            return dbSet.Count();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
