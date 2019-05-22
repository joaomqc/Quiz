namespace UserManagement.RPC
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            await new HostBuilder()
                .ConfigureServices((context, services) =>
                {

                    services.AddHostedService<Service>();
                })
                .RunConsoleAsync();
        }
    }
}
