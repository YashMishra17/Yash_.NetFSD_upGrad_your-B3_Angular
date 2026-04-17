namespace CategoryService.Repositories;

using CategoryService.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<Category> Add(Category category);
    Task<Category> Update(int id, Category category);
    Task<bool> Delete(int id);
}
