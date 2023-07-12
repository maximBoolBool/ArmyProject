namespace ArmyProjectSecond.Services.UserServices;

public interface IUserService
{
    public Task<bool> Registrate();
    public Task<bool> Authorize();
    public Task<bool> ChangeLogin();
    public Task<bool> ChangePassword();
}