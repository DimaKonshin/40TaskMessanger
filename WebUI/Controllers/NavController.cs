using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Domain.Repository;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        IRepository<Category> categories;
        IRepository<User> users;

        public NavController(IRepository<Category> categories, IRepository<User> users)
        {
            this.categories = categories;
            this.users = users;
        }

        [ChildActionOnly]
        public PartialViewResult Categories()
        {
            return PartialView(categories.Get().Select(x => x.Name).OrderBy(x=>x).Distinct().ToList());
        }

        [ChildActionOnly]
        public PartialViewResult Users()
        {
            return PartialView(users.Get().Select(x => x.FirstName + " " + x.LastName).OrderBy(x => x).Distinct().ToList());
        }
    }
}