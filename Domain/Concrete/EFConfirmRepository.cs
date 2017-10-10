using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    /// <summary>
    /// преднозначен для работы с таблицей RegistrationConfirmed в БД EventPlanning
    /// </summary>
    public class EFConfirmRepository : IConfirmsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<RegistrationConfirmed> Confirms { get { return context.Confirms; } }

        public void AddConfirm(RegistrationConfirmed confirm)
        {
            context.Confirms.Add(confirm);
            context.SaveChanges();
        }

        public void UpdateConfirm(int id)
        {
            RegistrationConfirmed dbEntry = context.Confirms.Find(id);

            if (dbEntry != null)
            {
                dbEntry.EmailConfirmed = true;
            }

            context.SaveChanges();
        }
    }
}
