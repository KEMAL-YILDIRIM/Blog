using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Logic.Common.Interfaces;
using Blog.Logic.Common.Models;

namespace Blog.Identity.Common.Services
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
