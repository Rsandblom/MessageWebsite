using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageWebsite.Models
{
    /// <summary>
    /// The Message class, contains fields for ID, the message itself 
    /// and a timestamp.
    /// </summary>
    public class Message
    {
        public int MessageID { get; set; }
        [Display(Name= "Message")]
        public string MessageStr { get; set; }
        [Display(Name = "Time stamp")]
        public DateTime TimeStamp { get; set; }
        
    }
}