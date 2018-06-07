using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SimplCommerce.WebHost
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            

            await Clients.All.SendAsync("ReceiveMessage", user, message);

            //await Clients.Client("tes").SendAsync()
        }


        public async Task masterChat(string user, string message)
        {

           

        }

    }
}
