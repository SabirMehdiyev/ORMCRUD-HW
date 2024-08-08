using Microsoft.EntityFrameworkCore;
using ORM_CRUD.Contexts;
using ORM_CRUD.Models;

namespace ORM_CRUD.Services;

public class CategoryService
{
    private readonly AppDbContext _appDbContext;

    public CategoryService()
    {
        _appDbContext = new AppDbContext();
    }

    public async Task CreateCategoryAsync(Category category)
    {
        await _appDbContext.Categories.AddAsync(category);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        var category = _appDbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (category is null)
        {
            Console.WriteLine("Category tapilmadi");
        }
        return category;
    }

    public async Task RemoveAsync(int id)
    {
        var category = await GetCategoryByIdAsync(id);
        if (category != null)
        {
            _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Category category)
    {
        var dbCategory = await GetCategoryByIdAsync(category.Id);
        if (dbCategory != null)
        {
            dbCategory.Name = category.Name;
            _appDbContext.Categories.Update(dbCategory);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _appDbContext.Categories.AsNoTracking().ToListAsync();
    }
}
