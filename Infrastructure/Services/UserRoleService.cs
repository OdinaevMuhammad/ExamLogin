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

public class UserRoleService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserRoleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<UserRoleDto>>> GetUserRoles()
    {
        var mapped = _mapper.Map<List<UserRoleDto>>(_context.UserRoles.ToList());
        return new Response<List<UserRoleDto>>(mapped);
    }
    public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto role)
    {
        try
        {
            var mapped = _mapper.Map<UserRole>(role);
            await _context.UserRoles.AddAsync(mapped);
            await _context.SaveChangesAsync();
            role.Id = mapped.Id;
            return new Response<UserRoleDto>(role);

        }
        catch (System.Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto roleDto)
    {
        try
        {
            var find = await _context.UserRoles.Where(x => x.Id == roleDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (find == null) return new Response<UserRoleDto>(HttpStatusCode.BadRequest, "UserRoleId NotFound");
            var mapped = _mapper.Map<UserRole>(roleDto);
            _context.UserRoles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(roleDto);

        }
        catch (System.Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}