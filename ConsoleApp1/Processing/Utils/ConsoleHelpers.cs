namespace ConsoleApp1.Processing.Utils
{
    public static class ConsoleHelpers
    {
        private static readonly List<ConsoleColor> consoleColors = new List<ConsoleColor>() { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };
        private static int consoleColorIndex = 0;

        public static void PrintArray<T>(List<T> array)
        {
            if (array != null)
            {
                foreach (var item in array)
                {
                    Console.WriteLine(item);
                    SwitchConsoleColors();
                }
            }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("Velkommen til RestaurantX");
            Console.WriteLine("Vælg hvilken handling du vil foretage dig ved at indtaste tallet der står ud fra menupunktet:");
            Console.WriteLine("");
            Console.WriteLine("1 - Se ansatte");
            Console.WriteLine("2 - Book et bord");
            Console.WriteLine("3 - Se all bookninger i fremtiden");
            Console.WriteLine("4 - Se bookninger for en enkelt dato");
            Console.WriteLine("5 - Se kunder");
        }

        public static void ShowReturnToMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Klik en vilkårlig knap for at komme tilbage til hovedmenuen");
            Console.ReadKey();
        }

        private static void SwitchConsoleColors()
        {
            switch (consoleColorIndex)
            {
                case 0:
                    Console.ForegroundColor = consoleColors[0];
                    consoleColorIndex++;
                    break;
                case 1:
                    Console.ForegroundColor = consoleColors[1];
                    consoleColorIndex++;
                    break;
                case 2:
                    Console.ForegroundColor = consoleColors[2];
                    consoleColorIndex = 0;
                    break;
            }
        }
    }
}
