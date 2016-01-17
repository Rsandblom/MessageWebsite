using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MessageWebsite.Models;

namespace MessageWebsite.Controllers
{
    /// <summary>
    /// Messages Controller, Action for listing of messages, 
    /// asending and descending. And an action for delete message.
    /// Both actions make use of the BusinessLogicLayer
    /// </summary>
    public class MessagesController : Controller
    {
        BusinessLogicLayer bLLayer;

        public MessagesController()
        {
            bLLayer = new BusinessLogicLayer();
        }

        // GET: Messages
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "time_desc" : "";
            return View(bLLayer.GetWebMessagesAndSort(sortOrder));
        }
        
        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bLLayer.DeleteWebMessage(id);
            return RedirectToAction("Index");
        }
        
    }
}
