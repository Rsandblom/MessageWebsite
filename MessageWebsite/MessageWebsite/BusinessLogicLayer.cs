using MessageWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageWebsite
{
    /// <summary>
    /// The business logic layer, handles all the calls from the controllers (API as well)
    /// to the data access layer (uses the DataAccessLayer Interface) and back. Method for creating web messages, 
    /// retrieving web messages and sorting by date/time and deleteing of a message.
    /// </summary>
    public class BusinessLogicLayer
    {
        public IDataAccessLayer DataLayer { get; set; }
        public string AddMessageResultStr { get; set; }

        public BusinessLogicLayer()
        {
            DataLayer = new DataAccessLayer();
        }

        public bool CreateNewWebMessage(string messageStr)
        {
            AddMessageResultStr = null;
            Message webMessage = new Message() { MessageStr = messageStr, TimeStamp = DateTime.Now };
            AddMessageResultStr = DataLayer.AddMessage(webMessage);
            if(AddMessageResultStr != null )
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Message> GetWebMessagesAndSort(string sortOrder)
        {
            var messageList = DataLayer.GetWebMessages();
            IEnumerable<Message> sortedList;
            switch (sortOrder)
            {
                case "time_desc":
                    sortedList = messageList.OrderByDescending(m => m.TimeStamp);
                    break;
                default:
                    sortedList = messageList.OrderBy(m => m.TimeStamp);
                    break;
            }
            return sortedList;
        }

        public void DeleteWebMessage(int id)
        {
            DataLayer.DeleteWebMessage(id);
        }
    }
}