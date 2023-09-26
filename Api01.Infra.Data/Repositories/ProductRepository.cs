using Api01.Domain.Entities;
using Api01.Domain.Repositories;
using Api01.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api01.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly ApplicationDbContext _db;

    public ProductRepository(ApplicationDbContext db)
    {
        _db = db;         
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _db.Add(product);
        await _db.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Product product)
    {
        _db.Remove(product);
        await _db.SaveChangesAsync();
    }

    public async Task EditAsync(Product product)
    {
        _db.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(p => p.Id == id); 
    }

    public async Task<ICollection<Product>> GetProductsAsync()
    {
        return await _db.Products.ToListAsync();
    }
}
