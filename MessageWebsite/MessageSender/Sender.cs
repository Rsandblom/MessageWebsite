using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MessageSender
{
    /// <summary>
    /// Sender object, responsible for sending the message with HttpClient 
    /// and recieving the HttpResponseMessage and returning it back to the caller.
    /// </summary>
    class Sender
    {
        public string Message { get; set; }
        public string ResultStr { get; set; }

        public Sender(string message)
        {
            Message = message;
            ResultStr = string.Empty;
        }

        public string SendMessage()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18188/");

            var content = new StringContent(Message, UnicodeEncoding.UTF8, "application/json");
            var response = client.PostAsync("api/MessagesAPI/Post", content).Result;
            
            ResultStr = "Result: " + response.StatusCode.ToString() + " " + response.ReasonPhrase;
            return ResultStr;
        }
    }
}
