using System.Reflection;
using Services;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

public class OnContentPublishNotification : INotificationHandler<ContentPublishedNotification>
    {
        private readonly IBlazorPublishEventService _blazorPublishEventService;

        public OnContentPublishNotification(IBlazorPublishEventService blazorPublishEventService)
        {
            _blazorPublishEventService = blazorPublishEventService;
        }

        public void Handle(ContentPublishedNotification notification)
        {
          Console.WriteLine("OnContentPublishNotification: Handle");
          Console.WriteLine("notification");
          Console.WriteLine(notification);

        Type type = notification.PublishedEntities.GetType();
        Console.WriteLine("type");
        Console.WriteLine(type);
        Console.WriteLine(notification.PublishedEntities.Count());
        // PropertyInfo[] properties = type.GetProperties();

        // foreach (var property in properties)
        // {
        //     var propertyName = property.Name;
        //     var propertyValue = property.GetValue(notification);
        //     Console.WriteLine($"{propertyName}: {propertyValue}");
        // }


            foreach (var node in notification.PublishedEntities)
            {
              Console.WriteLine("node");
               Console.WriteLine(node);
                _blazorPublishEventService.AddEvent(new PublishEventModel()
                {
                    PublishDate = DateTime.Now,
                    ModelAlias = node.ContentType.Alias
                });

            }
        }
    }
