using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XJDD.Repository.Entity;
using XJDD.Repository.IRepository;

namespace XJDD.Repository.Repository;

public class MenuRepository : IMenu
{
    private readonly Repository<Menu> _repository;
    private readonly ILogger _logger;

    public MenuRepository(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<Repository<Menu>>();
        _logger = serviceProvider.GetRequiredService<ILogger>();
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
            _logger.Log(LogLevel.Error,e.Message);
            throw;
        }
        
    }
}