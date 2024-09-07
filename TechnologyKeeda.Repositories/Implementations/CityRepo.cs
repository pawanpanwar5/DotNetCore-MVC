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

        public void Edit(City city)
        {
            _dbContext.Cities.Update(city);
            _dbContext.SaveChanges(); 
        }

        public IEnumerable<City> GetAll()
        {
            var cities = _dbContext.Cities.Include(x=>x.State).ThenInclude(y=>y.Country).ToList();
            return cities;
        }

        public City GetById(int id)
        {
            return _dbContext.Cities.Find(id);
        }

        public void RemoveData(City city)
        {
            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
        }

        public void Save(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();   
        }
    }
}
