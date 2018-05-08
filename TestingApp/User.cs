using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    class Task
    {

        public bool Completion { get; set; }
        public  DateTime DueDate { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public int TaskNumber { get;  set; }


        public Task(int taskNumber, bool completion, string name, string description, DateTime dueDate)
        {
            TaskNumber = taskNumber;
            Completion = completion;
            Name = name;
            Description = description;
            DueDate = dueDate;

           // Console.WriteLine($"{Completion} \t {name} \t {description}");
        }
    }
}
