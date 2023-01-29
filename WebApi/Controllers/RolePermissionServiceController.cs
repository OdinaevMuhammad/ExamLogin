using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RolePermissionServiceController
{
    private readonly RolePermissionService _RolePermissionService;

    public RolePermissionServiceController(RolePermissionService permissionService)
    {
        _RolePermissionService = permissionService;
    }

    [HttpGet("GetRolePermissons")]
    public async Task<Response<List<RolePermissionDto>>> GetRolePermisson()
    {
        return await _RolePermissionService.GetRolePermissions();
    }
    [HttpPost("AddRolePermisson")]
    public async Task<Response<RolePermissionDto>> AddRolePermisson(RolePermissionDto register)
    {
        return await _RolePermissionService.AddRolePermission(register);
    }
    [HttpPut("UpdateRolePermisson")]
    public async Task<Response<RolePermissionDto>> UpdateRolePermisson(RolePermissionDto RolePermission)
    {
        return await _RolePermissionService.UpdateRolePermission(RolePermission);
    }
 



}