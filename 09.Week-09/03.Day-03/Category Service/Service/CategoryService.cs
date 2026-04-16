using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Category>> GetAll() => await _repo.GetAll();

    public async Task<Category> GetById(int id) => await _repo.GetById(id);

    public async Task<Category> Add(Category category) => await _repo.Add(category);

    public async Task<Category> Update(int id, Category category)
        => await _repo.Update(id, category);

    public async Task<bool> Delete(int id) => await _repo.Delete(id);
}