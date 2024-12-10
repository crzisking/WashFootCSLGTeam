using Microsoft.Extensions.DependencyInjection;
using XJDD.Repository.Entity;
using XJDD.Repository.IRepository;

namespace XJDD.Repository.Repository;

public class MenuRepository : IMenu
{
    private readonly Repository<Menu> _repository;

    public MenuRepository(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<Repository<Menu>>();
    }
    public  Task<dynamic> GetMenuList()
    {
        try
        {
            var menusList = _repository.Context.Queryable<Menu>().ToList();
            return Task.FromResult<dynamic>(menusList);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}