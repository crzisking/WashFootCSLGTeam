using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace XJDD.Api;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase(
    ) : ControllerBase
{
}