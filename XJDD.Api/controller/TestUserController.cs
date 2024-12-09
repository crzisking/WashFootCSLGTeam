using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace XJDD.Api.controller;

[ApiController]
public class TestUserController(
    IMapper mapper,
    IConfiguration configuration,
    IHttpContextAccessor contextAccessor
        ) : ApiControllerBase(mapper, configuration, contextAccessor)
{
    
}
