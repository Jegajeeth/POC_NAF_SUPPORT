using NAFSupport.Shared.Models;

namespace NAFSupport.Client.Api
{
    public interface IApi
    {
        public Task<IEnumerable<Ticket>?> GetTicket();
        public Task<IEnumerable<TicketStatus>?> GetTicketStatus();
        public Task<HttpResponseMessage> DeleteTicket(int ticketId);
        public Task<HttpResponseMessage> DeleteTicket(string ticketId);
        public Task<HttpResponseMessage> PostTicket(Ticket newTicket);

    }
}
