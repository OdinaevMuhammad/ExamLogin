using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Infrastructure.ServiceProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

public class RolePermissionService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public RolePermissionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<RolePermissionDto>>> GetRolePermissions()
    {
        var mapped = _mapper.Map<List<RolePermissionDto>>(_context.RolePermissions.ToList());
        return new Response<List<RolePermissionDto>>(mapped);
    }

    public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto rolePermission)
    {
        try
        {
            var mapped = _mapper.Map<RolePermission>(rolePermission);
            await _context.RolePermissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            rolePermission.Id = mapped.Id;
            return new Response<RolePermissionDto>(rolePermission);

        }
        catch (System.Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto rolePermission)
    {
        try
        {
            var find = await _context.RolePermissions.Where(x => x.Id == rolePermission.Id).AsNoTracking().FirstOrDefaultAsync();
            if(find == null) return new Response<RolePermissionDto>(HttpStatusCode.BadRequest,"RolePermissionId NotFound");
            var mapped = _mapper.Map<RolePermission>(rolePermission);
            _context.RolePermissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(rolePermission);

        }
        catch (System.Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}