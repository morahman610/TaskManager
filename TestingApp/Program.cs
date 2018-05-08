using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Task manager.");

            List< Task > TaskList = new List<Task>();

            while (true)
            {
                Console.WriteLine("What would you like to do? \n1: List tasks \n2: Add task \n3: Delete task \n4: Mark task complete \n5: Quit \n");
                string UserInput = Console.ReadLine();

                if (UserInput == "1")
                {

                    Console.WriteLine("Completion\tDue Date\t\tTeam Member\t\tDescription \n");
                    foreach (Task o in TaskList)
                    {


                        Console.WriteLine( o.TaskNumber + ". " + o.Completion + "\t" + o.DueDate + "\t\t" + o.Name + "\t\t" + o.Description + "\n");
                    }

                    Console.WriteLine("Enter Date to check tasks before a certain date or enter a team member's name to " +
                        "check tasks for that person. \n Enter any other key to return to the main menu. \n");
                   // Console.WriteLine("Enter the name of a team member if you would like to check the tasks for that person OR enter Q to return to the main menu.");
                    string teamMember = Console.ReadLine();

                    foreach (Task o in TaskList)
                    {
                        if (o.Name == teamMember)
                        {
                            Console.WriteLine(o.TaskNumber + ". " + o.Completion + "\t" + o.DueDate + "\t\t" + o.Name + "\t\t" + o.Description + "\n");
                        }
                    }

                    if (DateTime.TryParse(teamMember, out DateTime dateTo))
                    {
                        foreach (Task o in TaskList)
                        {
                            if (o.DueDate < dateTo)
                            {
                                Console.WriteLine(o.TaskNumber + ". " + o.Completion + "\t" + o.DueDate + "\t\t" + o.Name + "\t\t" + o.Description + "\n");
                            }
                        }
                    }


                }
                else if (UserInput == "2")
                {
                    Console.WriteLine("ADD TASK \n Please enter the name of a team member to be assigned to this task. \n");
                    string name = Console.ReadLine();

                    bool completion = false;

                    Console.WriteLine("Please give a description of the task.");
                    string description = Console.ReadLine();

                    DateTime dueDate = ConvertToDate();

                    int taskNumber = TaskList.Count()+1;

                    TaskList.Add(new Task(taskNumber, completion, name, description, dueDate));
                }
                else if (UserInput == "3")
                {
                    bool validate = true;
                    int deletedtask = 0;

                    while (validate)
                    {
                        Console.WriteLine("Which task on the list would you like to delete?");
                        string deletingTask = Console.ReadLine();
                        ConvertToInt(deletingTask);

                        if (!(int.TryParse(deletingTask, out deletedtask)))
                        {
                            Console.WriteLine("That was not a number. Please try again.");
                        }
                        else if ((deletedtask-1 >= TaskList.Count()) || (deletedtask-1 < 0))
                        {
                            Console.WriteLine("The number you entered was not in range. Please try again.");
                        } 
                        else
                        {
                            bool confirmQuit = true;
                            while (confirmQuit)
                            {
                                Console.WriteLine(TaskList[deletedtask - 1].TaskNumber + ". " + TaskList[deletedtask - 1].Completion + "\t" + TaskList[deletedtask - 1].DueDate + "\t\t" + TaskList[deletedtask - 1].Name + "\t\t" + TaskList[deletedtask - 1].Description);
                                //Console.WriteLine(TaskList[deletedtask]);
                                Console.WriteLine("Are you sure you want to delete this task? (Y/N)");
                                string checkQuit = Console.ReadLine();

                                if (checkQuit.ToLower() == "y")
                                {
                                    TaskList.RemoveAt(deletedtask - 1);
                                    Console.WriteLine("Task has been removed.");

                                    confirmQuit = false;

                                }
                                else if (checkQuit.ToLower() == "n")
                                {
                                    confirmQuit = false;
                                }
                                else
                                {
                                    Console.WriteLine("That was not Y or N");
                                } 
                            }
                            validate = false;


                        }
                    }


                }
                else if (UserInput == "4")
                {
                    Console.WriteLine("Which task would you like to mark as complete?");
                    string taskChosen = Console.ReadLine();
                    int i = ConvertToInt(taskChosen);

                    bool confirmQuit = true;
                    while (confirmQuit)
                    {
                        //Console.WriteLine(TaskList[i -1].Name);
                        Console.WriteLine(TaskList[i - 1].TaskNumber + ". " + TaskList[i - 1].Completion + "\t" + TaskList[i - 1].DueDate + "\t\t" + TaskList[i - 1].Name + "\t\t" + TaskList[i - 1].Description);
                        Console.WriteLine("Are you sure you want to mark task as complete? (Y/N)");
                        string checkQuit = Console.ReadLine();

                        if (checkQuit.ToLower() == "y")
                        {
                            TaskList[i - 1].Completion = true;

                            Console.WriteLine("Task has been marked as complete.");

                            confirmQuit = false;

                        }
                        else if (checkQuit.ToLower() == "n")
                        {
                            confirmQuit = false;
                        }
                        else
                        {
                            Console.WriteLine("That was not Y or N");
                        }
                    }
                }
                else if (UserInput == "5")
                {
                    Console.WriteLine("Are you sure you want to quit Task Manager? (Y/N)");
                    string quit = Console.ReadLine();
                    if (quit.ToLower() == "y")
                    {
                        return;
                    }
                    else if (quit.ToLower() == "n")
                    {
                        continue;
                    }
                } 

                // WORK FOR LAST EXTENDED CHALLENGE. STILL IN PROGRESS.
                //else if (UserInput == "6")
                //{
                //    bool editing = true;
                //    int i = 0;
                //    while (editing)
                //    {
                //        Console.WriteLine("Please enter the number of the task you want to edit");
                //        i = ConvertToInt(Console.ReadLine())-1;
                //        if ((i - 1 >= TaskList.Count()) || (i - 1 < 0))
                //        {
                //            Console.WriteLine("That number was out of range.");
                //        }
                //    }

                //    Console.WriteLine("Enter the number of the part you would like to edit:\n 1. Completion\n 2. Due Date\n 3. Name\n 4. Description\n");
                //    string editingPart = Console.ReadLine();

                //    if (editingPart == "1")
                //    {
                //        Console.WriteLine("What would you like to set this to? (true/false)");

                //        TaskList[i].Completion = Console.ReadLine();
                //    }


                //}
            }
        }

        static int ConvertToInt (string number)
        {
            while (true)
            {
                if (!(int.TryParse(number, out int converted)))
                {
                    Console.WriteLine("That was not a number. Please try again.");
                }
                else
                {
                    return converted;
                }
            }
        }

        static DateTime ConvertToDate ()
        {
            while (true)
            {
                Console.WriteLine("Please enter the due date for this task.");
                string date = Console.ReadLine();

                if (!(DateTime.TryParse(date, out DateTime dateDue)))
                {
                    Console.WriteLine("That was not a date in the proper format. Please try again");
                }
                else
                {
                    return dateDue;
                }

            }

        }
    }
}
