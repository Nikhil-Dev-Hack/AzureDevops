using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSHCONSOLE.TaskProgramming
{
    /// <summary>
    /// Create Task using Run method
    /// </summary>
    public class TaskExample03
    {
        public void Execute()
        {
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId} has started");
            Task task = Task.Run(() =>
            {
                CounterExample();
            });
            task.Wait();
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId} has ended");
        }

        private void CounterExample()
        {
            Console.WriteLine($"Child thread {Thread.CurrentThread.ManagedThreadId} has started");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Counter: {i}");
            }
            Console.WriteLine($"Child thread {Thread.CurrentThread.ManagedThreadId} has ended");
        }
    }
}
