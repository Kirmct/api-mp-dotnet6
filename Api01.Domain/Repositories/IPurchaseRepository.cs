using Api01.Domain.Entities;

namespace Api01.Domain.Repositories;

public interface IPurchaseRepository
{
    Task<Purchase> GetByIdAsync(int id);
    Task<ICollection<Purchase>> GetPurchasesAsync();
    Task<ICollection<Purchase>> GetByPersonIdAsync(int personId);
    Task<ICollection<Purchase>> GetByProductIdAsync(int productId);
    Task<Purchase> CreateAsync(Purchase purchase);
    Task EditAsync(Purchase purchase);
    Task DeleteAsync(Purchase purchase);
}
