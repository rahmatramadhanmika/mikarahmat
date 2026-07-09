using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        Task<List<About>> GetAllAsync();
        Task<About?> GetByIdAsync(int id);
        Task AddAsync(About about);
        Task UpdateAsync(About about);
        Task DeleteAsync(About about);
        Task SaveChangeAsync();
    }
}