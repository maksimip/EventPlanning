using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<EventTitle> EventTitles { get; set; }

        public DbSet<FieldEvent> EventFields { get; set; }
    }
}
