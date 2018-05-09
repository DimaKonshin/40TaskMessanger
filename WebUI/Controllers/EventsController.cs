using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Repository;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class EventsController : ApiController
    {
        // Variable to connect to the database
        IRepository<UsersTask> usersTask;

        // Number of elements that we will send to the client
        int take = 4;

        public EventsController()
        {
            // the variable will be assigned a value using Ninject
            this.usersTask = new MSSQLEFRepository<UsersTask>(new MessangerTaskContext());
        }

        public EventsController(IRepository<UsersTask> usersTask)
        {
            // the variable will be assigned a value using Ninject
            this.usersTask = new MSSQLEFRepository<UsersTask>(new MessangerTaskContext());
        }

        public HttpResponseMessage Get(string category, string name,int skip)
        {
            // List of messages to be sent to the user
            var list3 = usersTask.GetByCategoryAndName(category, name, skip, take);

            // View model
            EventMsg eventMsg = new EventMsg();

            eventMsg.List = list3;

            // Check if there are more events in the database. If yes then return More with status code 200. If there is no "There are no more events" and status code is 404
            if (list3.Count() == 0 || list3.Count() < take)
                eventMsg.Msg = "There are no more events";
            else
                eventMsg.Msg = "More";

            return Request.CreateResponse(HttpStatusCode.OK, eventMsg);

        }
    }
}
