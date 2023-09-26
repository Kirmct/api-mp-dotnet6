using Api01.Domain.Entities;
using Api01.Domain.Repositories;
using Api01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api01.Infra.Data.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ApplicationDbContext _db;

    public PurchaseRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Purchase> CreateAsync(Purchase purchase)
    {
        _db.Add(purchase);
        await _db.SaveChangesAsync();
        return purchase;
    }

    public async Task DeleteAsync(Purchase purchase)
    {
        _db.Remove(purchase);
        await _db.SaveChangesAsync();
    }

    public async Task EditAsync(Purchase purchase)
    {
        _db.Update(purchase);
        await _db.SaveChangesAsync();
    }

    public Task<Purchase> GetByIdAsync(int id)
    {
        return _db.Purchases.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<ICollection<Purchase>> GetByPersonIdAsync(int personId)
    {
        var purchase = await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .Where(x => x.PersonId == personId)
            .ToListAsync();

        return purchase;
    }

    public async Task<ICollection<Purchase>> GetByProductIdAsync(int productId)
    {
        return await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .Where(x => x.ProductId == productId).ToListAsync();
    }

    public async Task<ICollection<Purchase>> GetPurchasesAsync()
    {
        return await _db.Purchases
            .Include(x => x.Product)
            .Include(x => x.Person)
            .ToListAsync();
    }
}
