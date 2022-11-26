using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulator
{
    public class Menu
    {
         #region:Fields
        public static bool programIsActive = false;
        private enum Options { Run = 1, Manual, Exit }
        #endregion
        public static void Run()
        {
            programIsActive = true;
            
            while (programIsActive)
            {
                Console.Clear();
                Menu.ShowTheSummary();
                ShowTheOptionsDialog();
                OptionsManager();
            }
            Console.WriteLine();
            Console.WriteLine("\t"+ "\t" + "GoodBye!");
        }

        #region:OptionsManager
        public static void OptionsManager()
        {

            Console.Write("\t" + "Your choice: ");

            int temp = 0;
            while (temp > 3 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case (int)Options.Run:

                    break;

                case (int)Options.Manual:
                    ShowTheManual();
                    break;

                case (int)Options.Exit:
                    Console.WriteLine("\t"+"You chose to exit");
                    programIsActive = false;
                    break;
            }

        }
        public static int GetTheUserChoice(string? input)
        {
            int temp;
            while (!int.TryParse(input, out temp) || input == null)
            {
                input = Console.ReadLine();
            }
            return temp;
        }
        #endregion

        #region:MethodsForDisplayingText
        public static void ShowTheManual()
        {
            Console.WriteLine("***This is the Manual***");
            Console.WriteLine("\t" + "[PRESS 1] Get back to menu");
            Console.WriteLine("\t" + "[PRESS 2] Exit\n");
            Console.Write("\t" + "Your choice: ");

            int temp = 0;
            while (temp > 2 || temp < 1)
            {
                temp = GetTheUserChoice(Console.ReadLine());
            }
            switch (temp)
            {
                case 1:
                    programIsActive = true;
                    break;
                case 2:
                    Console.WriteLine("\t" + "you chose to exit");
                    programIsActive = false;
                    break;
            }
        }
        public static void ShowTheSummary()
        {
            System.Console.WriteLine("****************************************************************");
            System.Console.WriteLine("\t" + "\t" + "      This is the summary\n" + "\t" + "     Developed by Daniel Ibrahimi 22/11-22");
            System.Console.WriteLine("****************************************************************");
        }
        public static void ShowTheOptionsDialog()
        {
            Console.WriteLine("\t" + "[PRESS 1] Simulator");
            Console.WriteLine("\t" + "[PRESS 2] Manual");
            Console.WriteLine("\t" + "[PRESS 3] Exit\n");



        }
        #endregion
    }
}
