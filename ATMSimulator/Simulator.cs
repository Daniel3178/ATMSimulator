using System;


namespace ATMSimulator
{
    public class Simulator
    {
        #region Fields
        private static bool simulatorOptionIsActive = false;
        private enum Options { SignUp = 1, BankServices, Back }
        #endregion
        public static void Run()
        {
            Menu.ShowTheSummary();
            Initializer();
            OptionsManager();
        }

        #region Initializer&OptionsManager
        public static void Initializer()
        {
            Console.Clear();
            DataHandler.ReadFromDatabase();
            Console.WriteLine("Loading the database");

            for (int i = 0; i <= 10; i++)
            {
                string icone = ".";
                Console.Write(icone);
                System.Threading.Thread.Sleep(100);
            }
        }
        public static void OptionsManager()
        {
            Console.Clear();

            simulatorOptionIsActive = true;
            while (simulatorOptionIsActive)
            {


                Console.WriteLine("\t" + "[PRESS 1] Sign Up");
                Console.WriteLine("\t" + "[PRESS 2] Bank Services");
                Console.WriteLine("\t" + "[PRESS 3] Get back to Menu");
                Console.Write("\n \t" + "Your choice: ");

                int temp = 0;
                while (temp > 3 || temp < 1)
                {
                    temp = Menu.GetTheUserChoice(Console.ReadLine());
                }
                switch (temp)
                {
                    case (int)Options.SignUp:
                        AccountCreator.Run();
                        break;

                    case (int)Options.BankServices:
                        ServiceManager.Run();
                        break;

                    case (int)Options.Back:
                        simulatorOptionIsActive = false;
                        break;

                }
            }
        }
        #endregion
    }
}
