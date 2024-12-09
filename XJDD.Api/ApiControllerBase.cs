using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace XJDD.Api;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase(
    IMapper mapper,
    IConfiguration configuration,
    IHttpContextAccessor contextAccessor
    ) : ControllerBase
{
    protected readonly IMapper _Mapper = mapper;
    protected readonly IConfiguration _Configuration = configuration;
    protected readonly IHttpContextAccessor _ContextAccessor = contextAccessor;
    
}