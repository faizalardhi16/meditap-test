using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meditaps.Contracts.Response;

namespace Meditaps.Services.Business
{
    public interface IWordMutation
    {
        public string ReverseWord(string word);
        public IResponse<string> Palyndrome(string word);

        public IResponse<List<int>> GenerateNumber();
    }
}