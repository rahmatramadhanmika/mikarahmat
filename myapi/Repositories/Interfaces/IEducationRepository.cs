using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetAllAsync();
        Task<Education?> GetByIdAsync(int id);
        Task AddAsync(Education education);
        Task UpdateAsync(Education education);
        Task DeleteAsync(Education education);
        Task SaveChangeAsync();
    }
}