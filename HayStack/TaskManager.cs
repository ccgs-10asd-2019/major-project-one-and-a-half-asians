using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayStack
{
    [Serializable]
    public class TaskManager
    {
        public string task { get; set; }

        public TaskManager(string taskText)
        {
            task = taskText;
        }
    }
}
