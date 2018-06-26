using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SimplCommerce.WebHost
{
    public class ChatHub : Hub
    {
        private static readonly List<Users> userList = new List<Users>();

        public async Task SendMessage(string user, string message, string indentedUser)
        {
            string id = Context.ConnectionId;

            if (userList.Count(x => x.ConnectionId == id) == 0)
            {
                userList.Add(new Users { ConnectionId = id, UserName = user });

            }


            //Clients.Client().

            await Clients.All.SendAsync("ReceiveMessage", user, message);



            //await Clients.Client("tes").SendAsync()
        }


        public async Task SendList()
        {
            

            string conId =userList.Find(x => x.UserName == "Doctor").ConnectionId;

            //await Clients.All.SendAsync("ReceiveList", Newtonsoft.Json.JsonConvert.SerializeObject(userList));
            await Clients.Client(conId).SendAsync("ReceiveList", Newtonsoft.Json.JsonConvert.SerializeObject(userList));


        }
    }


    public class Users
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }
}
