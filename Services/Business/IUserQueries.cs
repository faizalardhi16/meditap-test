using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meditaps.Contracts.Response;
using Meditaps.Entities;

namespace Meditaps.Services.Business
{
    public interface IUserQueries
    {
        public Task<List<User>> GetAllUsers();

        public Task<IResponse<User>> GetUserById(string id);
    }
}