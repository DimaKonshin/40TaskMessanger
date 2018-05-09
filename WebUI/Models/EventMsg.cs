using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Repository;

namespace WebUI.Models
{
    public class EventMsg
    {
        public IEnumerable<TaskVM> List { get; set; }
        public string Msg { get; set; }
    }
}