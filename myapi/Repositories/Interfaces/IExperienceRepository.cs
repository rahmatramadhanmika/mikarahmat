using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAllAsync();
        Task<Experience?> GetByIdAsync(int id);
        Task AddAsync(Experience experience);
        Task UpdateAsync(Experience experience);
        Task DeleteAsync(Experience experience);
        Task SaveChangeAsync();
    }
}