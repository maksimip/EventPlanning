using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    /// <summary>
    /// создание доступа к БД EventPlanning
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<EventTitle> EventTitles { get; set; }

        public DbSet<FieldEvent> EventFields { get; set; }

        public DbSet<RegistrationConfirmed> Confirms { get; set; }
    }
}
