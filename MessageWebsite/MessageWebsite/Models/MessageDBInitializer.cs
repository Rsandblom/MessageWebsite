using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MessageWebsite.Models
{
    /// <summary>
    /// Initializer, drops and recreates the database if the model changes and seeds it with 3 messages.
    /// </summary>
    public class MessageDBInitializer : DropCreateDatabaseIfModelChanges<MessageContext>
    {
        protected override void Seed(MessageContext context)
        {
            IList<Message> startupMessages = new List<Message>();

            startupMessages.Add(new Message() { MessageStr = "First message.", TimeStamp = DateTime.Now.AddMinutes(1) });
            startupMessages.Add(new Message() { MessageStr = "Second message.", TimeStamp = DateTime.Now.AddMinutes(2) });
            startupMessages.Add(new Message() { MessageStr = "Third message.", TimeStamp = DateTime.Now.AddMinutes(3) });

            foreach (Message m in startupMessages)
                context.Messages.Add(m);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}