using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using BotApplication1.Data;
using BotApplication1.Data.Models;

namespace Bot_Application1.Tools
{
    public class EntityFrameworkActivityLogger : IActivityLogger
    {
        Task IActivityLogger.LogAsync(IActivity activity)
        {
            IMessageActivity msg = activity.AsMessageActivity();
            using (UserLogDataContext dataContext = new UserLogDataContext())
            {
                var newActivity = Mapper.Map<IMessageActivity, UserLog>(msg);
                if (string.IsNullOrEmpty(newActivity.Id))
                    newActivity.Id = Guid.NewGuid().ToString();
                dataContext.UserLogs.Add(newActivity);
                dataContext.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}