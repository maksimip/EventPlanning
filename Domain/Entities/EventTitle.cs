using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("EventTitles")]
    public class EventTitle
    {
        [Key]
        public int IdEvent { get; set; }
        public string Title { get; set; } //наименование мероприятия
        public DateTime StartDateTime { get; set; } // начало мероприятия
    }
}
