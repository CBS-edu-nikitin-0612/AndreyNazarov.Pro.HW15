using System;
using System.Threading;
using System.Threading.Tasks;
using Task2;

namespace Task3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new MySynchronizationContext());

            Task2.Program.Info();
            int result = await Task2.Program. GetFactorial(6).ConfigureAwait(false);
            Console.WriteLine("Факториал: " + result);
            Task2.Program.Info();
        }
    }
}
