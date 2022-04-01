using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.SignalR;

namespace Cowrk_Space_Mangment_System.Hubs
{
    public class CatringNotificationHub : Hub
    {
        ICartRepository cartRepository;
        public CatringNotificationHub(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public void ClientNotify()
        {
            //string RevicerNAme) {
            //Context.User.Identity.Name
            //logic C#
            //ConnectionID[RevicerNAme]
            int all = cartRepository.GetUnpaidCount();
            int client = cartRepository.GetAllUnpaidCountClientsCart();
            Clients.All.SendAsync("ClientNotify", all.ToString(),
            client.ToString());//notifuication "Push"
        }
        public void VisitorsNotify()
        {
            //string RevicerNAme) {
            //Context.User.Identity.Name
            //logic C#
            //ConnectionID[RevicerNAme]
            int all = cartRepository.GetUnpaidCount();
            int visitor = cartRepository.GetAllUnpaidCountVistorsCart();
            Clients.All.SendAsync("VisitorsNotify", all.ToString(),
          visitor.ToString());//notifuication "Push"
        }
    }
}
