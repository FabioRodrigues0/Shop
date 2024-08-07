﻿using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.Server.Services.AuthService;

public class AuthService : IAuthService
{
	private readonly DataContext _context;
	private readonly IConfiguration _configuration;

	public AuthService(DataContext context, IConfiguration configuration)
	{
		_context = context;
		_configuration = configuration;
	}
	public async Task<ServiceResponse<int>> Register(User user, string password)
	{
		if(await UserExists(user.Email))
		{
			return new ServiceResponse<int>
			{
				Success = false,
				Message = "User already exists."
			};
		}
		CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

		user.PasswordHash = passwordHash;
		user.PasswordSalt = passwordSalt;

		_context.Users.Add(user);
		await _context.SaveChangesAsync();

		return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
	}
	public async Task<ServiceResponse<string>> Login(string email, string password)
	{
		var response = new ServiceResponse<string>();
		var user = await _context.Users
			.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
		if(user == null)
		{
			response.Success = false;
			response.Message = "User not found.";
		}
		else if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
		{
			response.Success = false;
			response.Message = "Wrong password.";
		}
		else
		{
			response.Data = CreateToken(user);
		}

		return response;
	}
	public Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
	{
		throw new NotImplementedException();
	}
	public int GetUserId()
	{
		throw new NotImplementedException();
	}
	public string GetUserEmail()
	{
		throw new NotImplementedException();
	}
	public Task<User> GetUserByEmail(string email)
	{
		throw new NotImplementedException();
	}
	public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
	{
		using(var hmac = new HMACSHA512())
		{
			passwordSalt = hmac.Key;
			passwordHash = hmac
				.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
		}
	}
	public async Task<bool> UserExists(string email)
	{
		if(await _context.Users.AnyAsync(user => user.Email.ToLower()
			   .Equals(email.ToLower())))
		{
			return true;
		}
		return false;
	}
	private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
	{
		using(var hmac = new HMACSHA512(passwordSalt))
		{
			var computedHash =
				hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			return computedHash.SequenceEqual(passwordHash);
		}
	}
	private string CreateToken(User user)
	{
		List<Claim> claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new Claim(ClaimTypes.Name, user.Email),
			new Claim(ClaimTypes.Role, user.Role)
		};

		var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
			.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: creds);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}
}