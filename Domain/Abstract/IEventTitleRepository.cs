using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IEventTitleRepository
    {
        IQueryable<EventTitle> EventTitles { get; }
        void AddEventTitle(EventTitle eventTitle);
    }
}
