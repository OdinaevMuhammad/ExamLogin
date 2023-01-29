using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PermissonServiceController
{
    private readonly PermissionService _PermissionService;

    public PermissonServiceController(PermissionService permissionService)
    {
        _PermissionService = permissionService;
    }

    [HttpGet("GetPermissions")]
    public async Task<Response<List<PermissionDto>>> GetPermission()
    {
        return await _PermissionService.GetPermissions();
    }
    [HttpPost("AddPermission")]
    public async Task<Response<PermissionDto>> AddPermission(PermissionDto register)
    {
        return await _PermissionService.AddPermission(register);
    }
    [HttpPut("UpdatePermission")]
    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto permissionDto)
    {
        return await _PermissionService.UpdatePermission(permissionDto);
    }
    [HttpDelete("Delete Permission")]
    public async Task<Response<string>> Delete(int id)
    {
        return await _PermissionService.DeletePermission(id);
    }




}