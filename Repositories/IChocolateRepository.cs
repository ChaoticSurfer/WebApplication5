using WebApplication5.Models;

namespace WebApplication5.Repositories
{
    public interface IChocolateRepository
    {
        Task<List<Chocolate>> GetChocolatesAsync();
        Task<Chocolate> GetChocolateByIdAsync(int id);
        Task AddChocolateAsync(Chocolate chocolate);
        Task UpdateChocolateAsync(Chocolate chocolate);
        Task DeleteChocolateAsync(int id);
        Task<bool> ChocolateExistsAsync(int id);
    }
}
