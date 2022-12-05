using System;


namespace ATMSimulator
{
    public class Simulator
    {
        private static bool simulatorOptionIsActive = false;
        private enum Options { SignUp = 1, BankServices, Back }

        public static void Run()
        {

            Menu.ShowTheSummary();
            Initializer();
            OptionsManager();


        }
        public static void OptionsManager()
        {
            simulatorOptionIsActive = true;
            while (simulatorOptionIsActive)
            {

                Console.WriteLine("\t" + "[PRESS 1] Sign Up");
                Console.WriteLine("\t" + "[PRESS 2] Bank Services");

                Console.WriteLine("\t" + "[PRESS 3] Get back to Menu");

                int temp = 0;
                while (temp > 2 || temp < 1)
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
        public static void Initializer()
        {
            DataHandler.ReadFromDatabase();
            Console.WriteLine();
            //Console.SetCursorPosition(5, 5);

            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string icone = "\u2551";
                    Console.Write(icone);
                }
                Console.Write(i + "/100");
                Console.SetCursorPosition(5, 5);
                System.Threading.Thread.Sleep(100);
            }
            Console.ReadLine();
        }

    }
}
