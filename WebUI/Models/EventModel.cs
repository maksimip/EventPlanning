using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class EventModel
    {
        public int IdEvent { get; set; }
        public string TitleEvent { get; set; }
        public DateTime StartDateTime { get; set; }
        public IEnumerable<FieldEvent> Fields { get; set; }
    }
}