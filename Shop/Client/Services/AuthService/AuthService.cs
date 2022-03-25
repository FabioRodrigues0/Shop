namespace Shop.Client.Services.AuthService;

public class AuthService : IAuthService
{
	public Task<ServiceResponse<int>> Register(UserRegistration request)
	{
		throw new NotImplementedException();
	}

	public Task<ServiceResponse<string>> Login(UserLogin request)
	{
		throw new NotImplementedException();
	}

	public Task<bool> IsUserAuthenticated()
	{
		throw new NotImplementedException();
	}
}