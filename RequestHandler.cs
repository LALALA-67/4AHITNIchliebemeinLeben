using System;
namespace HelloConnectedWorld.Server
{
    public class RequestHandler
    {
        string _request;

        public RequestHandler(string request)
        {
            _request = request;
        }

        public string GetResponse()
        {
 
            return HandleEchoRequest();

        }
        private string HandleEchoRequest()
        {
            // request: 2 4AHITN 4AHITN
            // response:
            // 4AHITN 4AHITN 4AHITN 4AHITN
            if(_request.ToLower().StartsWith("echo"))    
            {   
            _request = _request.Replace("echo", "");
            string[] args = _request.Trim().Split(" ");
            int amount = int.Parse(args[0]);
            args[0] = "";
            string resPart = String.Join(' ', args).Trim();
            string res = String.Empty;
            for (int i = 0; i < amount; i++)
            {
                res += resPart + " ";
            }
            return res.Trim();
            }
            else return "unknown  request";
        }
    }
}
