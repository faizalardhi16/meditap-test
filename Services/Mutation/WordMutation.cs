
using Meditaps.Contracts.Response;
using Meditaps.Services.Business;

namespace Meditaps.Services.Mutation;

public class WordMutation : IWordMutation{

    private bool IsPrimary(int number){
        if(number <= 1){
            return false;
        }

        for(int i=2; i<=Math.Sqrt(number); i++){
            if((number % i) == 0){
                return false;
            }
        }

        return true;
    }  

    public string ReverseWord(string word){
        char[] kalimat = word.ToCharArray();
        var lenth = kalimat.Length;
        int idx = lenth - 1;
        string reverse = "";
        do{
            reverse += kalimat[idx];
            idx--;
            Console.WriteLine(idx);
        }while(idx>=0);

        return reverse;
    }

    public IResponse<string> Palyndrome(string word){
        char[] kalimat = word.ToCharArray();
        string reverse = "";
        int idx = kalimat.Length - 1;

        do{ 
            reverse += kalimat[idx];
            idx--;
        }while(idx>=0);

        if(reverse == word){
            return new IResponse<string>{
                StatusCode=200,
                Message="It's Palyndrome",
                Data=reverse
            };
        }
    
        return new IResponse<string>{
            StatusCode=400,
            Message="it's not a palyndrome",
            Data=reverse
        };
    }

    public IResponse<List<int>> GenerateNumber(){
        var idx = 0;
        List<int> data = [];

        do{
            if(IsPrimary(idx) == true){
                Console.WriteLine("MASUK KONDISI");
                data.Add(idx);
            }
            Console.WriteLine(idx);
            idx++;
        }while(idx <= 100);

        return new IResponse<List<int>>{
            StatusCode=200,
            Message="this is primary number",
            Data=data
        };
    }
}
