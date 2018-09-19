using Autofac;
using Bot_Application1.Dialogs;
using Bot_Application1.Services.Implementations;
using Bot_Application1.Services.Interfaces;
using Bot_Application1.Tools;
using BotApplication1.Data.Models;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;

namespace Bot_Application1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            UnityConfig.RegisterComponents();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Microsoft.Bot.Connector.IMessageActivity, UserLog>()
                    .ForMember(dest => dest.FromId, opt => opt.MapFrom(src => src.From.Id))
                    .ForMember(dest => dest.RecipientId, opt => opt.MapFrom(src => src.Recipient.Id))
                    .ForMember(dest => dest.FromName, opt => opt.MapFrom(src => src.From.Name))
                    .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp.Value))
                    .ForMember(dest => dest.RecipientName, opt => opt.MapFrom(src => src.Recipient.Name));
            });

            var builder = new ContainerBuilder();
            builder.RegisterType<EntityFrameworkActivityLogger>().AsImplementedInterfaces().InstancePerDependency();
            builder.Update(Conversation.Container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
