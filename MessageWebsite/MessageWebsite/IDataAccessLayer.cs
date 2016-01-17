using MessageWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageWebsite
{
    /// <summary>
    /// Interface for the data access layer.
    /// </summary>
    public interface IDataAccessLayer
    {
        string AddMessage(Message webMessage);
        List<Message> GetWebMessages();
        void DeleteWebMessage(int id);
    }
}