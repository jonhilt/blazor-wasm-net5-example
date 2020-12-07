namespace ExampleApp.Client.Data
{
    public interface IWidget
    {
        string Title { get; }
    }

    public class WidgetA : IWidget
    {
        public string Title => "A Counter!";
    }

    public class WidgetB : IWidget
    {
        public string Title => "All about the weather";
    }
}