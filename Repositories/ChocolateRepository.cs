using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public class ChocolateRepository : IChocolateRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ChocolateRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Chocolate>> GetChocolatesAsync()
        {
            return await _applicationDbContext.Chocolates.ToListAsync();
        }

        public async Task<Chocolate> GetChocolateByIdAsync(int id)
        {
            return await _applicationDbContext.Chocolates.FindAsync(id);
        }

        public async Task AddChocolateAsync(Chocolate chocolate)
        {
            _applicationDbContext.Chocolates.Add(chocolate);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateChocolateAsync(Chocolate chocolate)
        {
            _applicationDbContext.Chocolates.Update(chocolate);
            _applicationDbContext.Entry(chocolate).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteChocolateAsync(int id)
        {
            var chocolate = await GetChocolateByIdAsync(id);
            if (chocolate != null)
            {
                _applicationDbContext.Chocolates.Remove(chocolate);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ChocolateExistsAsync(int id)
        {
            return await _applicationDbContext.Chocolates.AnyAsync(e => e.Id == id);
        }
    }
}
