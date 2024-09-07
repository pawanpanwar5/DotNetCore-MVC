using Microsoft.EntityFrameworkCore;
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

        public async Task Edit(Country country)
        {
            _dbContext.Countries.Update(country);
            await _dbContext.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            var countries = await _dbContext.Countries.ToListAsync();
            return countries;
        }

        public async Task<Country> GetById(int id)
        {
            var country = await _dbContext.Countries.FindAsync(id);
            return country;
        }

        public async Task RemoveData(Country country)  
        {
            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Save(Country country)
        {
            await _dbContext.Countries.AddAsync(country);
            await _dbContext.SaveChangesAsync();
        }
    }
}
