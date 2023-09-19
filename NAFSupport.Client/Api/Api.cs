using NAFSupport.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace NAFSupport.Client.Api
{
    public class Api: IApi
    {
        HttpClient http;
        public Api(HttpClient _http) {
            http = _http;
        }

        private string ticketUrl = "/Ticket";

        public async Task<IEnumerable<Ticket>?> GetTicket()
        {
            return await http.GetFromJsonAsync<IEnumerable<Ticket>>(ticketUrl);
        }
        public async Task<HttpResponseMessage> PostTicket(Ticket newTicket)
        {
            var res = await http.PostAsJsonAsync(ticketUrl, newTicket);
            return res;
        }

        public async Task<HttpResponseMessage> DeleteTicket(int ticketId)
        {
            var res = await http.DeleteAsync($"{ticketUrl}/{ticketId}");
            return res;
        }

        public async Task<HttpResponseMessage> DeleteTicket(string ticketId)
        {
            var res = await http.DeleteAsync($"{ticketUrl}/{ticketId}");
            return res;
        }

        public async Task<IEnumerable<TicketStatus>?> GetTicketStatus()
        {
            return await http.GetFromJsonAsync<IEnumerable<TicketStatus>>("/ticketstatus");
        }
    }
}
