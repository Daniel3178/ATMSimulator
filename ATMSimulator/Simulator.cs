using System;


namespace ATMSimulator
{
    public class Simulator
    {
        public static void Initializer(){
            // DataHandler.ReadFromDatabase();
            Console.SetCursorPosition(5,5);

            for (int i = 0; i <= 100; i++){
                for(int j = 0; j<= i; j++) {
                    string icone = "\u2551";
                    Console.Write(icone);
                }
                Console.Write(i + "/100");
                Console.SetCursorPosition(5,5);
                System.Threading.Thread.Sleep(100);
            }
            Console.ReadLine();
        }

    }
}
