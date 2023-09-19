using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Services
{
    public class TicketServices
    {
        public readonly NAFSupportDBContext DbContext;

        public TicketServices(NAFSupportDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public async Task<ActionResult<IEnumerable<Ticket>>> getTicket() {
            List<Ticket> res;
            try
            {
            res = await DbContext.tickets.ToListAsync();
            } catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        public async Task<ActionResult<Ticket>> postTicket(Ticket newTicket)
        {
            var lastValue = (from tickets in DbContext.tickets orderby tickets.Id descending select tickets.Id).FirstOrDefault();

            Console.WriteLine(lastValue);
            newTicket.ticketId = $"TCK_{lastValue+1}";
            try
            {
                await DbContext.tickets.AddAsync(newTicket);
                await DbContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                return null;
            }
            return newTicket;
        }

        public async Task<ActionResult<Ticket>> putTicket(Ticket newTicket)
        {
            Ticket toUpdateTicket;
            try
            {

            toUpdateTicket = DbContext.tickets.First(x => x.Id == newTicket.Id);
            } catch (Exception e)
            {
                return null;
            }

            if (toUpdateTicket != null)
            {
                toUpdateTicket.severity = newTicket.severity;
                toUpdateTicket.endDate = newTicket.endDate;
                toUpdateTicket.startDate = newTicket.startDate;
                toUpdateTicket.priority = newTicket.priority;
                toUpdateTicket.createdBy = newTicket.createdBy;
                toUpdateTicket.startDate = toUpdateTicket.startDate;
                toUpdateTicket.status = newTicket.status;

                try
                {
                DbContext.tickets.Update(toUpdateTicket);
                await DbContext.SaveChangesAsync();
                    return toUpdateTicket;
                } catch (Exception ex)
                {
                    return null;
                }

            }

            return null;
        }


        public async Task<ActionResult<Ticket>> deleteTicket(string ticketId)
        {
            Ticket toBeDeletedTicket = await DbContext.tickets.FirstOrDefaultAsync(x => x.ticketId == ticketId);

            if (toBeDeletedTicket != null)
            {
                try
                {
                    DbContext.Remove(toBeDeletedTicket);
                    await DbContext.SaveChangesAsync();
                } catch (Exception ex)
                {
                    return null;
                }
                return toBeDeletedTicket;
            }

            return null;
        }

        public async Task<ActionResult<Ticket>> deleteTicket(int Id)
        {
            Ticket toBeDeletedTicket = await DbContext.tickets.FirstOrDefaultAsync(x => x.Id == Id);

            if (toBeDeletedTicket != null)
            {
                try
                {
                    DbContext.Remove(toBeDeletedTicket);
                    await DbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
                return toBeDeletedTicket;
            }

            return null;
        }
    }
}
