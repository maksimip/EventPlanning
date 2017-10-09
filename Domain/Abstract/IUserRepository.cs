﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser(User user);

    }
}
