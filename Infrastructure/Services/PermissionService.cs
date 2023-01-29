using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Infrastructure.ServiceProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

public class PermissionService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public PermissionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<PermissionDto>>> GetPermissions()
    {
        var mapped = _mapper.Map<List<PermissionDto>>(_context.Permissions.ToList());
        return new Response<List<PermissionDto>>(mapped);
    }

    public async Task<Response<PermissionDto>> AddPermission(PermissionDto permission)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(permission);
            await _context.Permissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            permission.Id = mapped.Id;
            return new Response<PermissionDto>(permission);

        }
        catch (System.Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto permission)
    {
        try
        {
            var find = await _context.Permissions.Where(x => x.Id == permission.Id).AsNoTracking().FirstOrDefaultAsync();
            if(find == null) return new Response<PermissionDto>(HttpStatusCode.BadRequest,"RolePermissionId NotFound");
            var mapped = _mapper.Map<Permission>(permission);
            _context.Permissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(permission);

        }
        catch (System.Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> DeletePermission(int id)
    {
        var find = await _context.Permissions.FindAsync(id);
        if(find == null) return new Response<string>(HttpStatusCode.BadRequest, "Not Found");

        _context.Permissions.Remove(find);
        _context.SaveChanges();

        return new Response<string>("Deleted");
    }
}