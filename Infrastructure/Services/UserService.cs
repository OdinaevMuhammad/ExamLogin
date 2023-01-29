using System.ComponentModel;
using System.IO.Enumeration;
namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Infrastructure.ServiceProfile;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

public class UserService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<UserDto>>> GetUsers()
    {
        var mapped = _mapper.Map<List<UserDto>>(_context.Users.ToList());
        return new Response<List<UserDto>>(mapped);
    }
    public async Task<Response<UserDto>> Register(UserDto user)
    {
        try
        {
            var mapped = _mapper.Map<User>(user);
            await _context.Users.AddAsync(mapped);
            await _context.SaveChangesAsync();
            user.Id = mapped.Id;
            return new Response<UserDto>(user);
        }
        catch (System.Exception ex)
        {
            return new Response<UserDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> LogIn(string phoneNumber, string password)
    {
        try
        {
            var check =  _context.Users.Where(x => x.PhoneNumber == phoneNumber && x.Password == password).AsNoTracking().FirstOrDefault();
            if (check == null) return new Response<string>(System.Net.HttpStatusCode.BadRequest, "PhoneNumber or Password is incorrect");
            var userLogin = new UserLogin()
            {
                Id =0,
                LoginDate = DateTime.UtcNow
            };
            var find = _context.UserLogins.Add(userLogin);
            _context.SaveChanges();

            return new Response<string>("You are Login");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<string>> LogOut(string phoneNumber, string password)
    {
        try
        {
            var check = _context.Users.Where(x => x.PhoneNumber == phoneNumber && x.Password == password).AsNoTracking().FirstOrDefaultAsync();
            if (check == null) return new Response<string>(HttpStatusCode.BadRequest, "Not Found");
      
            var find = _context.UserLogins.FirstOrDefault();
            find.LogoutDate = DateTime.UtcNow;
            _context.SaveChanges();

            return new Response<string>("You are Logout");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    public async Task<Response<UserDto>> UpdateUser(UserDto userDto)
    {
        try
        {
            var find = await _context.Users.Where(x => x.Id == userDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (find == null) return new Response<UserDto>(HttpStatusCode.BadRequest, "UserId NotFound");
            var mapped = _mapper.Map<User>(userDto);
            _context.Users.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserDto>(userDto);

        }
        catch (System.Exception ex)
        {
            return new Response<UserDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

}