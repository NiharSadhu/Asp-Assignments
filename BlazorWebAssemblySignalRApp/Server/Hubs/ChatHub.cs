using Microsoft.AspNetCore.SignalR;

namespace BlazorWebAssemblySignalRApp.Server.Hubs
{
    public class ChatHub : Hub
    {
         public async Task SendMessage(string user, string message)
        {

            var encodedMsg = "";
            if (user == "Admin")
            {
                encodedMsg = $"Message from ADMIN: {message}";
            }
            else
            {
                encodedMsg = $"{user}: {message}";
            }

            await Clients.All.SendAsync("ReceiveMessageAllUsers", encodedMsg);
        }

        public async Task typing(string user)
        {

            var encodedMsg = "";
            if (user == "Admin")
            {
                encodedMsg = $"Message from ADMIN: {user}";
            }
            else
            {
                encodedMsg = $"{user}: {user}";
            }

            await Clients.All.SendAsync("ReceiveMessageAllUsers", encodedMsg);

            await Clients.Caller.SendAsync("Typing", $"The server says HI: {user}");

        }

        public async Task AnonymousMessage(string message)
        {


                var encodedMsg = "";
            if (message == "Admin")
            {
                encodedMsg = $"Message from ADMIN: {message}";
            }
            else
            {
                encodedMsg = $"{message}: {message}";
            }

            await Clients.Caller.SendAsync("AnonymousMessage", $"The server says HI: {message}");
            // nothing after this await will run in the method until the await finishes
        }


     }
    


       
}
