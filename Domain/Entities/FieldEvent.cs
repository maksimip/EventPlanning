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
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdEvent { get; set; }
    }
}
