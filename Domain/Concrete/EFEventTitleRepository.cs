using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFEventTitleRepository : IEventTitleRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<EventTitle> EventTitles { get { return context.EventTitles; } }

        public void AddEventTitle(EventTitle eventTitle)
        {
            context.EventTitles.Add(eventTitle);
            context.SaveChanges();
        }
    }
}
