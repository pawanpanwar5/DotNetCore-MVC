using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDBContext _dbContext;

        public CountryRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Edit(Country country)
        {
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();  
        }

        public IEnumerable<Country> GetAll()
        {
            var countries = _dbContext.Countries.ToList();
            return countries;
        }

        public Country GetById(int id)
        {
            var country = _dbContext.Countries.Find(id);
            return country;
        }

        public void RemoveData(Country country)  
        {
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
        }

        public void Save(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }
    }
}
