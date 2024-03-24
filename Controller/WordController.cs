
using Meditaps.Contracts.Response;
using Meditaps.Services.Business;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Meditaps.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordController : ControllerBase
    {

        private IWordMutation _word;

        public WordController(IWordMutation word){
            _word = word;
        }


        [HttpPost("/reverse")]
        public ActionResult<string> ReverseWord(string word){
            string data = _word.ReverseWord(word);
            return Ok(data);
        }

        
        [HttpPost("/palyndrome")]
        public ActionResult<IResponse<string>> Palyndrome(string word){
            var data = _word.Palyndrome(word);

            if(data.StatusCode == 400){
                return BadRequest(data);
            }

            return Ok(data);
        }

        [HttpGet("/generate-number")]
        public ActionResult<IResponse<string>> GenerateNumber(){
            var data = _word.GenerateNumber();
            return Ok(data);
        }
    }
}