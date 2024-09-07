﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entities;

namespace TechnologyKeeda.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        IEnumerable<Country> GetAll();
        Country GetById(int id);
        void Save(Country country);
        void Edit(Country country);
        void RemoveData(Country country);
    }
}
