using Microsoft.EntityFrameworkCore;
using Student.Web.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.Web.Api.Data
{
    public class GradingRepository : IGradingRepository
    {
        private readonly StudentDataContext _gradingContext;

    public GradingRepository(StudentDataContext gradingContext)
        {
            _gradingContext = gradingContext;
        }

        public void Add(Grading newGrading)
        {
            _gradingContext.Grading.Add(newGrading);
        }

        public void Delete(Grading grading)
        {
        _gradingContext.Grading.Remove(grading);
        }

        public async Task<List<Grading>> GetAllAsync()
        {
            return await _gradingContext.Grading.ToListAsync();
        }

        public async Task<Grading> GetById(string id)
        {
            return await _gradingContext.Grading.FirstOrDefaultAsync(x => x.GradingId == id);
        }

        public async Task<bool> SaveAllChangesAsync()
        {
            return await _gradingContext.SaveChangesAsync() > 0;
        }
    }
}