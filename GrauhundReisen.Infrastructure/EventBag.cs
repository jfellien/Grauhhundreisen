namespace GrauhundReisen.Infrastructure
{
  public class EventBag
  {
    public string Type { get; set; }
    public string EventData { get; set; }
    public string TimeStamp { get; set; }
    public string EntityId { get; set; }
    public string EventId { get; set; }
  }
}