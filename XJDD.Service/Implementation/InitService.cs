using Microsoft.Extensions.DependencyInjection;
using XJDD.Repository.Entity;
using XJDD.Repository.IRepository;
using XJDD.Service.Contract;

namespace XJDD.Service.Implementation;

public class InitService : IInitInterface
{
    private readonly IMenu _menu;
    public InitService(IServiceProvider serviceProvider)
    {
        _menu = serviceProvider.GetRequiredService<IMenu>();
    }

    public  Task<dynamic> GetMenuList()
    {
        return  _menu.GetMenuList();
    }
}