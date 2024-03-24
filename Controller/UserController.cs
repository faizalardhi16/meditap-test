using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meditaps.Contracts;
using Meditaps.Entities;
using Meditaps.Services.Business;
using Meditaps.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Meditaps.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserQueries _userQueries;
        private readonly IUserMutation _userMutation;

        public UserController(IUserQueries userQueries, IUserMutation userMutation){
            _userQueries = userQueries;
            _userMutation = userMutation;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers(){
            var data = await _userQueries.GetAllUsers();
            Console.WriteLine(data);
            return Ok(data);
        }   

        
        [HttpGet("/{id}")]
        public async Task<ActionResult> GetUserById(string id){
            var data = await _userQueries.GetUserById(id);
            if(data.StatusCode == 404){
                return NotFound(data);
            }
            return Ok(data);
        }   

        [HttpPost] 
        [Route("add")]
        public async Task<ActionResult> AddUser(UserDto user){
            try{
                var data = await _userMutation.AddUser(user);
                return Ok(data);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }  

        [HttpPut("update")]
        public async Task<ActionResult> UpdateUser(UpdateUserDto user){
            try{
                var data = await _userMutation.UpdateUser(user);

                if(data.StatusCode == 404){
                    return NotFound(data);
                }

                return Ok(data);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }  

        [HttpDelete("/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try{
                var data = await _userMutation.DeleteUser(id);

                if(data.StatusCode == 404){
                    return NotFound();
                }

                return Ok(data);
            }catch(Exception ex){
                return BadRequest(ex);
            }
        }
    }
}