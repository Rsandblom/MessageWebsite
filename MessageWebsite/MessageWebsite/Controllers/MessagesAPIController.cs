using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MessageWebsite.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MessageWebsite.Controllers
{
    /// <summary>
    /// API Controller with a POST action for receiving a string and
    /// relaying it forward to the BusinessLogicLayer. Returns a
    /// HttpResponseMessage back to the caller.
    /// </summary>
    public class MessagesAPIController : ApiController
    {
        BusinessLogicLayer bLLayer;

        public MessagesAPIController()
        {
            bLLayer = new BusinessLogicLayer();
        }

        // POST: api/MessagesAPI/Post
        public async Task<HttpResponseMessage> Post()
        {
            string messageStr = await Request.Content.ReadAsStringAsync();
            HttpResponseMessage resp;
            
            if (string.IsNullOrEmpty(messageStr))
            {
                return resp = new HttpResponseMessage(HttpStatusCode.NoContent) { ReasonPhrase = "Message was empty." };      
            }

            if (bLLayer.CreateNewWebMessage(messageStr) != true)
            {
                return resp = new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = bLLayer.AddMessageResultStr };
            }
            else
            {
                return resp = new HttpResponseMessage() { ReasonPhrase = "Message was sent." }; ;   
            }
            
        }

    }
}