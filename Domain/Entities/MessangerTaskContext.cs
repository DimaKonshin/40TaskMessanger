namespace Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MessangerTaskContext : DbContext
    {
        public MessangerTaskContext()
            : base("name=MessangerTaskContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersMessage> UsersMessages { get; set; }
        public virtual DbSet<UsersTask> UsersTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Message>()
                .HasMany(e => e.UsersMessages)
                .WithRequired(e => e.Message)
                .HasForeignKey(e => e.MessagesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.UsersTasks)
                .WithRequired(e => e.Task)
                .HasForeignKey(e => e.TasksId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UsersMessages)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UsersTasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
