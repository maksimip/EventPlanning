using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFFieldEventRepository : IFieldEventRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<FieldEvent> EventFields { get { return context.EventFields; } }

        public void AddField(FieldEvent fieldEvent)
        {
            context.EventFields.Add(fieldEvent);
            context.SaveChanges();
        }
    }
}
