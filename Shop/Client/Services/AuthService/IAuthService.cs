﻿namespace Shop.Client.Services.AuthService;

public interface IAuthService
{
	Task<ServiceResponse<int>> Register(UserRegistration request);
	Task<ServiceResponse<string>> Login(UserLogin request);
	Task<bool> IsUserAuthenticated();
}