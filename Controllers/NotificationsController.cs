﻿using Magnifinance.Data;
using Magnifinance.Hubs;
using Magnifinance.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Magnifinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly MagnifinanceContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;

        public NotificationsController(MagnifinanceContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Notifications/notificationcount  
        [Route("notificationcount")]
        [HttpGet]
        public async Task<ActionResult<NotificationCountResult>> GetNotificationCount()
        {
            var count = (from not in _context.Notification
                         select not).CountAsync();
            NotificationCountResult result = new NotificationCountResult
            {
                Count = await count
            };
            return result;
        }

        // GET: api/Notifications/notificationresult  
        [Route("notificationresult")]
        [HttpGet]
        public async Task<ActionResult<List<NotificationResult>>> GetNotificationMessage()
        {
            var results = from message in _context.Notification
                          orderby message.Id descending
                          select new NotificationResult
                          {
                              EmployeeName = message.EmployeeName,
                              TranType = message.TranType
                          };
            return await results.ToListAsync();
        }

        // DELETE: api/Notifications/deletenotifications  
        [HttpDelete]
        [Route("deletenotifications")]
        public async Task<IActionResult> DeleteNotifications()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Notification");
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();

            return NoContent();
        }
    }
}
