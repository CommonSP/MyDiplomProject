using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDiplomProject.Controllers
{
    public class ChatController : Controller
    {
        private IHubContext _chat;
        public ChatController(IHubContext chat)
        {
            _chat = chat;
        }

    }
}