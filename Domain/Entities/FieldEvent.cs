using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("EventFields")]
    public class FieldEvent
    {
        [Key]
        public int IdField { get; set; }
        public string Title { get; set; }//наименование поля
        public string Description { get; set; }//описание поля
        public int IdEvent { get; set; }
    }
}
