namespace QuizManagement.Rpc
{
    using Topshelf;

    public class Program
    {
        public static int Main(string[] args)
        {
            return (int) HostFactory.Run(x => x.Service<Service>());
        }
    }
}
