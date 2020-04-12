using WebWindows.Blazor;

namespace Blazor.Corona.Native
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentsDesktop.Run<Startup>("미추홀 코로나19 대응현황", "wwwroot/index.html");
        }
    }
}
