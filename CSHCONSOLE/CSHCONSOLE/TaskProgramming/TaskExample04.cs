using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSHCONSOLE.TaskProgramming
{
    /// <summary>
    /// Return a value from Task
    /// </summary>
    public class TaskExample04
    {
        public void Execute()
        {
            Task<int> task = Task.Run(() => { return CalculateSum(10); });
            Console.WriteLine(task.Result);
        }

        private int CalculateSum(int input)
        {
            int sum = 0;
            for (int i = 1; i <= input; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
