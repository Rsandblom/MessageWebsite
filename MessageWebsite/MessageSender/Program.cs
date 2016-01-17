using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSender
{
    /// <summary>
    /// Small application for sending a string message via HttpClient to a
    /// websites web API and storage in the website database.
    /// Console prompts for message to be sent with a Sender object
    /// and after the message has been sent a status/result message is displayed.
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            Sender sender;
            string message;
            string resultStr = string.Empty; ;

            Console.Write("Enter a message to send: ");
            message = Console.ReadLine();
            sender = new Sender(message);
            try
            {
                resultStr = sender.SendMessage();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(resultStr);
            Console.ReadLine();
                
        }
    }
}
