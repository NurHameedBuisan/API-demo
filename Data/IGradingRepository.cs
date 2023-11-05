using Student.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.Web.Api.Data
{
    public interface IGradingRepository
    {
        Task<List<Grading>> GetAllAsync();
        Task<Grading> GetById(string id);
        Task<bool> SaveAllChangesAsync();
         void Add(Grading newGrading);
        void Delete(Grading grading);
    }
}