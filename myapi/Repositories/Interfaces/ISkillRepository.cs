using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myapi.Models;

namespace myapi.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task<IEnumerable<Skill>> GetSkillsByIdsAsync(IEnumerable<int> ids);
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
        Task SaveChangeAsync();
    }
}