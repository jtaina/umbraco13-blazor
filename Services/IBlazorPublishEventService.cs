using System.ComponentModel;

namespace Services{
  public interface IBlazorPublishEventService : INotifyPropertyChanged
  {
      public List<PublishEventModel> PublishEventList { get; set; }

      public void AddEvent(PublishEventModel eventModel);
  }

}
