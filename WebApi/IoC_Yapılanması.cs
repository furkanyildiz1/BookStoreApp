using WebApi.Services;

namespace WebApi
{
    public class IoC_Yapılanması
    {
        public IoC_Yapılanması()
        {
            IServiceCollection services= new ServiceCollection();
            services.Add(new ServiceDescriptor(typeof(ConsoleLog),new ConsoleLog()));
            services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog()));

            ServiceProvider provider=services.BuildServiceProvider();
            provider.GetService<ConsoleLog>();
            provider.GetService<TextLog>();

        }
    }
}
