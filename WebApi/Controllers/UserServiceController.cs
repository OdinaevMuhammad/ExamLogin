using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserServiceController
{
    private readonly UserService _UserService;

    public UserServiceController(UserService userService)
    {
        _UserService = userService;
    }
    
    [HttpGet]
    public async Task<Response<List<UserDto>>> GetUsers()
    {
        return  await _UserService.GetUsers();
    }
    [HttpPost("Register")]
    public async Task<Response<UserDto>> Register(UserDto register)
    {
        return await _UserService.Register(register);
    }
    [HttpGet("LogIn")]
    public async Task<Response<string>> LogIn(string phoneNumber, string password)
    {
        return await _UserService.LogIn(phoneNumber,password);
    }
       [HttpGet("Logout")]
    public async Task<Response<string>> LogOut(string phoneNumber, string password)
    {
        return await _UserService.LogOut(phoneNumber,password);
    }

    [HttpPut]
    public async Task<Response<UserDto>> Update(UserDto user)
    {
        return await _UserService.UpdateUser(user);
    }
 
   
    
}