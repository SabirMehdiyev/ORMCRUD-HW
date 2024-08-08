using Microsoft.EntityFrameworkCore;
using ORM_CRUD.Contexts;
using ORM_CRUD.Models;

namespace ORM_CRUD.Services;

public class ProductService
{
    public async Task CreateProductAsync(Product product)
    {
        AppDbContext appDbContext = new AppDbContext();
        await appDbContext.Products.AddAsync(product);
        await appDbContext.SaveChangesAsync();
    }

    public async Task<Product> GetProductAsync(int id)
    {
        AppDbContext appDbContext = new AppDbContext();
        var product = await appDbContext.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (product == null) 
        {
            Console.WriteLine("Product tapilmadi");
        }
        return product;
    }

    public async Task RemoveAsync(int id)
    {
        AppDbContext appDbContext = new AppDbContext();
        var product = await GetProductAsync(id);
        if (product != null)
        {
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Product product, int id)
    {
        AppDbContext appDbContext = new AppDbContext();
        var dbProduct = await GetProductAsync(id);
        if (dbProduct != null)
        {
            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.CategoryId = product.CategoryId;
            appDbContext.Products.Update(dbProduct);
            await appDbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        AppDbContext appDbContext = new AppDbContext();
        var products = await appDbContext.Products
                                 .Include(p => p.Category)
                                 .ToListAsync();
        return products;

    }
}
