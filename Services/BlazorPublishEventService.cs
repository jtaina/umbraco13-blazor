using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Services
{
  public class BlazorPublishEventService : IBlazorPublishEventService
  {
      public List<PublishEventModel> PublishEventList { get; set; }
      public void AddEvent(PublishEventModel eventModel)
      {
          Console.WriteLine("BlazorPublishEventService: AddEvent");
          PublishEventList.Add(eventModel);
          Console.WriteLine("PublishEventList.Count()");
          Console.WriteLine(PublishEventList.Count());
          NotifyPropertyChanged();
      }

      public BlazorPublishEventService()
      {
          PublishEventList = new List<PublishEventModel>()
          {
              new PublishEventModel()
              {
                  PublishDate = DateTime.Now,
                  ModelAlias = "Launch of application"
              }
          };
      }

        // event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        // {
        //     add
        //     {
        //       Console.WriteLine("Not implemented...");
        //       AddEvent(new PublishEventModel()
        //       {
        //           PublishDate = DateTime.Now,
        //           ModelAlias = "Just another event"
        //       });
        //         // throw new NotImplementedException();
        //     }

        //     remove
        //     {
        //       Console.WriteLine("Not implemented...");
        //         // throw new NotImplementedException();
        //     }
        // }

        public event PropertyChangedEventHandler? PropertyChanged;

      protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
      {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

  }
}
