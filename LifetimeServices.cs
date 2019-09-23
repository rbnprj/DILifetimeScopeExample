using System;
using System.Collections.Generic;
using System.Text;

namespace DILifetimeScopesExample
{
    public class SingletonServices: ISingletonServices
    {
        public int counter;
        public SingletonServices(){
            
        }
        public  void Info()
        {
            counter++;
            Console.WriteLine($" new instance of Singleton is created:{counter==1} ,counter={counter}");
        }
    }
    public class ScopedServices : IScopedServices
    {
        public int counter;
        public ScopedServices()
        {
            
        }
        public void Info()
        {
            counter++;
            Console.WriteLine($" new instance of Scoped is created:{counter == 1} ,counter={counter}");
        }
    }
    public class TransientServices : ITransientServices
    {
        public int counter;
        public TransientServices()
        {
            
        }
        public void Info()
        {
            counter++;
            Console.WriteLine($" new instance of Transient is created:{counter == 1} ,counter={counter}");
        }
    }
}
