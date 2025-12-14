namespace Observability.ConsoleApp
{
    public class ServiceHelper
    {
        internal async Task Work1()
        {
            using (var activity = ActivitySourceProvider.Source.StartActivity())
            {
                var serviceOne = new ServiceOne();

                Console.WriteLine($"google response length : {await serviceOne.MakeRequestToGoogle()}");
                Console.WriteLine("complacated work1");

            }
        }
    }
}
