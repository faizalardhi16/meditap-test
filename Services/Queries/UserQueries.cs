
using Meditaps.Contracts.Response;
using Meditaps.Entities;
using Meditaps.Infrastructure;
using Meditaps.Services.Business;
using Microsoft.EntityFrameworkCore;

namespace Meditaps.Services.Queries;

public class UserQueries : IUserQueries
{
    private readonly UserDbContext _dbContext;
    public UserQueries(UserDbContext userDbContext){
        _dbContext = userDbContext;
    }

    public async Task<List<User>> GetAllUsers(){
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<IResponse<User>> GetUserById(string id){
        var toNumber = int.Parse(id);

        var data = await _dbContext.Users.FirstOrDefaultAsync(Q => Q.Id == toNumber);

        if(data == null){
            return new IResponse<User>{
                StatusCode = 404,
                Message="User Not Found",
                Data = new User{
                    Id=0,
                    FirstName="",
                    LastName="",
                    Email="",
                    CreationDate=DateTime.Now
                }
            };
        }
    
        return new IResponse<User>{
            StatusCode = 200,
            Message = "Success to Load User",
            Data = data
        };
    }

}