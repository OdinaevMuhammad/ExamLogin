using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserRoleServiceController
{
    private readonly UserRoleService _UserRoleService;

    public UserRoleServiceController(UserRoleService userService)
    {
        _UserRoleService = userService;
    }
    
    [HttpGet]
    public async Task<Response<List<UserRoleDto>>> GetUsers()
    {
        return  await _UserRoleService.GetUserRoles();
    }
    [HttpPost("ADD")]
    public async Task<Response<UserRoleDto>> Add(UserRoleDto register)
    {
        return await _UserRoleService.AddUserRole(register);
    }
    [HttpPut("Update")]
    public async Task<Response<UserRoleDto>> Update(UserRoleDto userRoleDto)
    {
        return await _UserRoleService.UpdateUserRole(userRoleDto);
    }

   
    
}