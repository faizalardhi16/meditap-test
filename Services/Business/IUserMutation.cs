using Meditaps.Contracts;
using Meditaps.Contracts.Response;
using Meditaps.Entities;

public interface IUserMutation{
    public Task<User> AddUser(UserDto user);
    public Task<IResponse<User>> UpdateUser(UpdateUserDto user);
    public Task<IResponse<User>> DeleteUser(string id);
}