using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace XJDD.Api;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    public readonly IMapper _Mapper; //autoMapper
    public readonly IConfiguration _Configuration;
    public readonly IHttpContextAccessor _ContextAccessor;

    protected ApiControllerBase(IServiceProvider serviceProvider)
    {
        _Configuration = serviceProvider.GetRequiredService<IConfiguration>();
        _Mapper = serviceProvider.GetRequiredService<IMapper>();
        _ContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    }
}