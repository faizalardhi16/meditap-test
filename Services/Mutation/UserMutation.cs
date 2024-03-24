
using Meditaps.Contracts;
using Meditaps.Contracts.Response;
using Meditaps.Entities;
using Meditaps.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Meditaps.Services.Mutation;

public class UserMutation : IUserMutation{
    
    private readonly UserDbContext _dbContext;

    public UserMutation(UserDbContext userDbContext){
        _dbContext = userDbContext;
    }

    public async Task<User> AddUser(UserDto user){

        var payload = new User{
            FirstName=user.FirstName,
            LastName=user.LastName,
            Email=user.Email
        };

        var data = await _dbContext.Users.AddAsync(payload);

        await _dbContext.SaveChangesAsync();


        return data.Entity;
    }

    public async Task<IResponse<User>> UpdateUser(UpdateUserDto user){
        var isHaveData = await _dbContext.Users.FirstOrDefaultAsync(Q => Q.Id == user.Id);

        if(isHaveData == null){
            return new IResponse<User>{
                StatusCode=404,
                Message="User not found",
                Data=new User{
                    FirstName="",
                    LastName="",
                    Email="",
                    Id=0,
                    CreationDate=DateTime.Now
                }
            };
        }

        isHaveData.FirstName = user.FirstName;
        isHaveData.LastName = user.LastName;
        isHaveData.Email = user.Email;

        await _dbContext.SaveChangesAsync();

        return new IResponse<User>{
            StatusCode = 200,
            Message = "Success to Update Data",
            Data = isHaveData
        };
    }

    public async Task<IResponse<User>> DeleteUser(string id){
        var toNumber = int.Parse(id);

        var data = await _dbContext.Users.FirstOrDefaultAsync(Q => Q.Id == toNumber);


        if(data == null){
             return new IResponse<User>{
                StatusCode=404,
                Message="User not found",
                Data=new User{
                    FirstName="",
                    LastName="",
                    Email="",
                    Id=0,
                    CreationDate=DateTime.Now
                }
            };
        }

        var deletedData = _dbContext.Users.Remove(data);

        await _dbContext.SaveChangesAsync();

        return new IResponse<User>{
            StatusCode = 200,
            Message = "Success to delete data",
            Data = deletedData.Entity
        };
    }


}