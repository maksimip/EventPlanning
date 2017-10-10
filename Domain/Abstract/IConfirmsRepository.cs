using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IConfirmsRepository
    {
        IQueryable<RegistrationConfirmed> Confirms { get; }
        void AddConfirm(RegistrationConfirmed confirm);
        void UpdateConfirm(int id);
    }
}
