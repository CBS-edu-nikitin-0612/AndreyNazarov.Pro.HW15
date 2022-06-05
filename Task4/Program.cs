using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());
            Test();
            Console.ReadKey();
        }

        private static async void Test()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                throw new Exception("Исключение в Ассинхронном void методе");
            });
        }
    }

    internal class MySynchronizationContext : SynchronizationContext
    {
        public override void OperationStarted()
        {
            Console.WriteLine("OperationStarted");
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine("Post");
            try
            {
                d(state);
                //base.Post(d,state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
