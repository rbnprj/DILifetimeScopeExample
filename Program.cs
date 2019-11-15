using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DILifetimeScopesExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
            .AddTransient<ITransientServices, TransientServices>()
                .AddScoped<IScopedServices, ScopedServices>()
                .AddSingleton<ISingletonServices, SingletonServices>()
                .BuildServiceProvider();
            Console.WriteLine($"==================Counter == 1 means instances is created everytime since for every new instance counter resets to zero ==================");
            Console.WriteLine($"==================Counter > 1 means no new instances and  values is added to preivous instances============================================");



            Console.WriteLine("========== Request 1 ============");
            
            serviceProvider.GetService<ITransientServices>().Info();
            serviceProvider.GetService<IScopedServices>().Info();
            serviceProvider.GetService<ISingletonServices>().Info();
            Console.WriteLine("========== ========= ============");

            Console.WriteLine("========== Request 2 ============");
            serviceProvider.GetService<ITransientServices>().Info();
            serviceProvider.GetService<IScopedServices>().Info();
            serviceProvider.GetService<ISingletonServices>().Info();
            Console.WriteLine("========== ========= ============");


            using (var scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 3 ============");
                serviceProvider.GetService<ITransientServices>().Info();
                scope.ServiceProvider.GetService<IScopedServices>().Info();
                serviceProvider.GetService<ISingletonServices>().Info();
                Console.WriteLine("========== ========= ============");

                Console.WriteLine("========== Request 4 ============");
                serviceProvider.GetService<ITransientServices>().Info();
                scope.ServiceProvider.GetService<IScopedServices>().Info();
                serviceProvider.GetService<ISingletonServices>().Info();
                Console.WriteLine("========== ========= ============");
            }

            using (var scope = serviceProvider.CreateScope())
            {
                Console.WriteLine("========== Request 5 ============");
                serviceProvider.GetService<ITransientServices>().Info();
                scope.ServiceProvider.GetService<IScopedServices>().Info();
                serviceProvider.GetService<ISingletonServices>().Info();
                Console.WriteLine("========== ========= ============");
            }


            Console.WriteLine("========== Request 6 ============");
            serviceProvider.GetService<ISingletonServices>().Info();
            Console.WriteLine("========== ========= ============");

            Console.ReadKey();
        }


    }
}
