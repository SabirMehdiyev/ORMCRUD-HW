using ORM_CRUD.Models;
using ORM_CRUD.Services;

CategoryService categoryService = new CategoryService();
ProductService productService = new ProductService();
Category category = new Category
{
    Name = "Category1"
};
//await categoryService.CreateCategoryAsync(category);
var cat = await categoryService.GetCategoryByIdAsync(3);
Console.WriteLine(cat.Name);
var categories = await categoryService.GetAllCategoriesAsync();
//await categoryService.RemoveAsync(5);
foreach (var item in categories)
{
    Console.WriteLine(item.Name);
}

Category updatedCategory = new Category
{
    Id = 3,
    Name = "UpdatedCategory"
};
await categoryService.UpdateAsync(updatedCategory);
Console.WriteLine((await categoryService.GetCategoryByIdAsync(3)).Name);


//Product part

Product product = new Product
{
    Name = "Product4",
    Price = 51,
    CategoryId = 3,
};
//await productService.CreateProductAsync(product);
var dbProduct = await categoryService.GetCategoryByIdAsync(1);
Console.WriteLine(dbProduct.Name);
var products = await productService.GetAllProductsAsync();
await categoryService.RemoveAsync(5);
foreach (var item in products)
{
    Console.WriteLine(item.Name);
}

Product updatedProduct = new Product
{
    Id = 1,
    Price = 10,
    Name = "UpdatedProduct"
};
await productService.UpdateAsync(updatedProduct, 1);
Console.WriteLine((await productService.GetProductAsync(3)).Name);
