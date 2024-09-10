using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyKeeda.Repositories.Interfaces
{
    public interface IUtilityRepo
    {
        Task<string> SaveImage(string containerName, IFormFile file);
        Task<string> EditImage(string containerName, IFormFile file, string dbPath);
        Task DeleteImage(string containerName, string dbPath);
    }
}
