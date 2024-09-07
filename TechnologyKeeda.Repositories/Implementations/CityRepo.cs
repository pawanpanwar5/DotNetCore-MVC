using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyKeeda.Entities;
using TechnologyKeeda.Repositories.Interfaces;

namespace TechnologyKeeda.Repositories.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDBContext _dbContext;

        public CityRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Edit(City city)
        {
            _dbContext.Cities.Update(city);
            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var cities = await _dbContext.Cities.Include(x=>x.State).ThenInclude(y=>y.Country).ToListAsync();
            return cities;
        }

        public async Task<City> GetById(int id)
        {
            return await _dbContext.Cities.FindAsync(id);
        }

        public async Task RemoveData(City city)
        {
            _dbContext.Cities.Remove(city);
           await _dbContext.SaveChangesAsync();
        }

        public async Task Save(City city)
        {
            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();   
        }
    }
}
