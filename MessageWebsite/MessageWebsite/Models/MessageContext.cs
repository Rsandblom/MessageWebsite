using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MessageWebsite.Models
{

    /// <summary>
    /// Message context, set to initalize database with MessaageDBInitilaizer 
    /// if model changes.
    /// </summary>
    public class MessageContext : DbContext
    {
        public MessageContext()
        {
            Database.SetInitializer<MessageContext>(new MessageDBInitializer());
        }

        public DbSet<Message> Messages { get; set; }
    }
}