using Microsoft.EntityFrameworkCore;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Shared.Models;

namespace NAFSupport.Server.Services
{
    public class TicketStatusServices
    {
        public readonly NAFSupportDBContext DbContext;

        public TicketStatusServices(NAFSupportDBContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public async Task<IEnumerable<TicketStatus>> getAllTicketStatus() {
            List<TicketStatus> res;
            try
            {
            res = await DbContext.ticketStatus.ToListAsync();

            }catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        public async Task<TicketStatus> getTicketStatusWithId (int Id) {
            TicketStatus? res;

            try
            {
                res = await DbContext.ticketStatus.FindAsync(Id);
                if(res == null)
                {
                    return null;
                }
            } catch (Exception ex)
            {
                return null;
            }
            return res;

        }

        public async Task<TicketStatus> postTicketStatus(TicketStatus newTicketStatus)
        {
            try
            {
                await DbContext.ticketStatus.AddAsync(newTicketStatus);
                await DbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                return null;
            }
            return newTicketStatus;
        }

        public async Task<TicketStatus> putTicketStatus(TicketStatus updatedTicket)
        {
            try
            {
                var res = await DbContext.ticketStatus.FindAsync(updatedTicket.Id);
                if(res != null)
                {
                    res.status = updatedTicket.status;
                    try {
                        DbContext.ticketStatus.Update(res);
                        await DbContext.SaveChangesAsync();
                    } catch (Exception ex)
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }
            } catch (Exception ex)
            {
                return null;
            }
            return updatedTicket;
        }

        public async Task<TicketStatus> deleteTicketStatus(TicketStatus ticketToBeDeleted)
        {
            try
            {
                var res = await DbContext.ticketStatus.FindAsync(ticketToBeDeleted.Id);
                if(res != null)
                {
                    try
                    {
                        DbContext.ticketStatus.Remove(res);
                        await DbContext.SaveChangesAsync();
                    } catch(Exception e)
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }
            }catch (Exception e)
            {
                return null;
            }
            return ticketToBeDeleted;
        }

    }
}
