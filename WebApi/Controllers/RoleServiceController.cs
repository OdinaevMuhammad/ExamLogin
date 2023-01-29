using System.Web;
using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RoleServiceController
{
    private readonly RoleService _RoleService;

    public RoleServiceController(RoleService roleService)
    {
        _RoleService = roleService;
    }
    
    [HttpGet]
    public async Task<Response<List<RoleDto>>> GetUsers()
    {
        return  await _RoleService.GetRoles();
    }
    [HttpPost("AddRole")]
    public async Task<Response<RoleDto>> AddRole(RoleDto register)
    {
        return await _RoleService.AddRole(register);
    }
    [HttpPut("UpdateRole")]
    public async Task<Response<RoleDto>> UpdateRole(RoleDto role)
    {
        return await _RoleService.UpdateRole(role);
    }

   
   
    
}