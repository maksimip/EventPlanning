using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// отображает связь пользователей и мероприятий
    /// </summary>
    [Table("RegistrationConfirmed")]
    public class RegistrationConfirmed
    {
        [Key]
        public int Id { get; set; }
        public int IdEvent { get; set; }
        public int IdUser { get; set; }
        public bool EmailConfirmed { get; set; } // показывает подтверждение регистрации по email
    }
}
