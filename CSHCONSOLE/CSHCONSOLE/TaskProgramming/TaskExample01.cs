using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSHCONSOLE.TaskProgramming
{
    /// <summary>
    /// Using Task class and Start() method
    /// </summary>
    public class TaskExample01
    {
        /// <summary>
        /// Create Task by instantiating the same
        /// </summary>
        public void Execute()
        {
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId} has started");
            Task task = new Task(PrintExample);
            task.Start();
            Console.WriteLine($"Main thread {Thread.CurrentThread.ManagedThreadId} has completed");
        }

        private void PrintExample()
        {
            Console.WriteLine($"Child thread {Thread.CurrentThread.ManagedThreadId} has started");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Counter {i}");
            }
            Console.WriteLine($"Child thread {Thread.CurrentThread.ManagedThreadId} has completed");
        }
    }
}
