using MessageWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MessageWebsite
{
    /// <summary>
    /// Handles all of the application interaction with the 
    /// database using the entity framework. Methods for adding deleting and 
    /// retreiving the messages.
    /// </summary>
    public class DataAccessLayer : IDataAccessLayer
    {
        private MessageContext db;

        public DataAccessLayer()
        {
            db = new MessageContext();
        } 

        public string AddMessage(Message webMessage)
        {
            string errorStr = null;
            try
            {
                db.Messages.Add(webMessage);
                db.SaveChanges();
                
            }
            catch (DbEntityValidationException ex)
            {
                return errorStr = "Error in DataAccessLayer: " + ex.EntityValidationErrors.ToString();
                
            }
            catch (EntityException ex)
            {
                return errorStr = "Error in DataAccessLayer: " + ex.ToString();

            }

            return null;
        }


        public List<Message> GetWebMessages()
        {
            return db.Messages.ToList();
        }

        public void DeleteWebMessage(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
        }
    }
}