using System.Collections.Generic;
using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Infrastructure.ServiceProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

public class RoleService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public RoleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<RoleDto>>> GetRoles()
    {
        var mapped = _mapper.Map<List<RoleDto>>(_context.Roles.ToList());
        return new Response<List<RoleDto>>(mapped);
    }
    public async Task<Response<RoleDto>> AddRole(RoleDto role)
    {
        try
        {
            var mapped = _mapper.Map<Role>(role);
            await _context.Roles.AddAsync(mapped);
            await _context.SaveChangesAsync();
            role.Id = mapped.Id;
            return new Response<RoleDto>(role);

        }
        catch (System.Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    
        public async Task<Response<RoleDto>> UpdateRole(RoleDto role)
    {
        try
        {
            var find = await _context.Roles.Where(x => x.Id == role.Id).AsNoTracking().FirstOrDefaultAsync();
            if(find == null) return new Response<RoleDto>(HttpStatusCode.BadRequest,"RoleId NotFound");
            var mapped = _mapper.Map<Role>(role);
            _context.Roles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RoleDto>(role);

        }
        catch (System.Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}