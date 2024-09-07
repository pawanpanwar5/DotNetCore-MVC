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
    public class StateRepo : IStateRepo
    {
        private readonly ApplicationDBContext _dbContext;

        public StateRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Edit(State state)
        {
            _dbContext.States.Update(state);
            _dbContext.SaveChanges();
        }

        public IEnumerable<State> GetAll()
        {
            var states = _dbContext.States.Include(x=> x.Country).ToList(); 
            return states;
        }

        public State GetById(int id)
        {
            var state = _dbContext.States.Find(id);
            return state;
        }

        public void RemoveData(State state)
        {
            _dbContext.States.Remove(state);
            _dbContext.SaveChanges();
        }

        public void Save(State state)
        {
            _dbContext.States.Add(state);
            _dbContext.SaveChanges();
        }
    }
}
