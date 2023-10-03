using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();
        
        //función Lista de tareas
        public static void ShowListTask()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask=0;
            TaskList.ForEach(p=> Console.WriteLine(($"{++indexTask} . {p}")));
 
            Console.WriteLine("----------------------------------------");
        }

        static void Main(string[] args)
        {
            
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string readLine = Console.ReadLine();
            return Convert.ToInt32(readLine);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowListTask();

                string readLine = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(readLine) - 1;

                if (indexToRemove > (TaskList.Count -1) || indexToRemove< 0 )
                    Console.WriteLine("la tarea seleccionada no existe");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {

                            string deletetask = TaskList[indexToRemove];
                            TaskList.RemoveAt(indexToRemove);
                            Console.WriteLine($"Tarea {deletetask} eliminada");

                    }
                }
                

            }
            catch (Exception )
            {
                Console.WriteLine("ocurrio un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {


                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string nametask = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(nametask))
                    Console.WriteLine("No ingresaste el nombre de la tarea");
                else
                {
                    TaskList.Add(nametask);
                    Console.WriteLine("Tarea registrada");     
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("ocurrio un error no controlado",ex);
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count >0)
            {
                ShowListTask();
                            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");

            }
        }
    }

    public enum Menu{

        Add = 1,

        Remove = 2,

        List = 3,

        Exit = 4
    }
}
