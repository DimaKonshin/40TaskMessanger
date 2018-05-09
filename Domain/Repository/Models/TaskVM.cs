using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Repository
{
    public class TaskVM
    {
        public string TaskName { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}