using Microsoft.AspNetCore.Mvc;
using XJDD.Repository.Repository;
using XJDD.Service.Contract;
using XJDD.Service.Implementation;

namespace XJDD.Api.controller;

public class InitController : ApiControllerBase
{
    private IInitInterface _initInterface;
    public InitController(IServiceProvider serviceProvider)
    {
        _initInterface = serviceProvider.GetRequiredService<IInitInterface>();
    }
    
    [HttpGet("GetMenuList")]
    public async Task<JsonResult> GetMenuList()
    {
        var menuList = await _initInterface.GetMenuList();
        Json json=new Json(200,"success",menuList);
        return new JsonResult(json);
    }
    
}