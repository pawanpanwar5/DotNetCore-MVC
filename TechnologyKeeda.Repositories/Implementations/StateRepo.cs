using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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

        public async Task Edit(State state)
        {
            _dbContext.States.Update(state);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var states = await _dbContext.States.Include(x=> x.Country).ToListAsync(); 
            return states;
        }

        public async Task<State> GetById(int id)
        {
            var state = await _dbContext.States.FindAsync(id);
            return state;
        }

        public async Task RemoveData(State state)
        {
            _dbContext.States.Remove(state);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Save(State state)
        {
            await _dbContext.States.AddAsync(state);
            await _dbContext.SaveChangesAsync();
        }
    }
}
