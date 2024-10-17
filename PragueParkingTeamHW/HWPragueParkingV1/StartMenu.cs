using HWPragueParkingV1;
using System.Runtime.InteropServices;

namespace HWPragueParkingV1
{
    internal class StartMenu
    {
        static void Main(string[] args)
        {
            InfoArray.CreateParking(); // Create the parkingspots

            ConsoleKeyInfo keyInfo;
            int choice = 0;                                         // To Create and keep track of our menu choice
            VisualMenu.StartingSystem();                      // Vi använder en ny CW vilket är vår egna metod för att centrera 
            
            Console.Clear();
            VisualMenu.HelloWorld();

            string[] menuChoice = { "Park a Vehicle", "Remove a Vehicle", "Search for a vehicle", "View Parking",
                "Move a Vehicle", "Optimize Parking", "Credits", "Exit" };  // Skapar en array för att i min tidigare version där jag använda massa cw flickrade skärmen detta gör det mer smooth
            int maxLength = menuChoice.Max(item => item.Length) + 4;
            while (true)
            {
                Console.SetCursorPosition(0, 4);            // Här börjar positionen av vår Cursor på rad 2 för att 0 - 1 är reserverad för vår rubrik

                for (int i = 0; i < menuChoice.Length; i++)
                {
                    string menuItem = $"{i + 1}. {menuChoice[i]}";
                    string alignedText = menuItem.PadRight(maxLength);

                    string centeredText = VisualMenu.GetCenterText(alignedText);

                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(centeredText);
                        Console.ResetColor();
                    }
                    else
                    {

                        Console.WriteLine(centeredText);
                    }
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)          // Läser in våra keys så att vi kan röra oss upp ner och enter för att gå in
                {
                    if (choice > 0)
                        choice--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (choice < 8)
                        choice++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            VisualMenu.CenterTextLine("park");                //här ska metoden in
                            Console.Clear();
                            VisualMenu.CenterText("Park");
                            CarorMCPark();
                            break;
                        case 1:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Remove a Vehicle");
                            Console.Clear();
                            CarorMCRemove();
                            break;
                        case 2:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Search for a vehicle");
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            CarorMCSearch();
                            break;
                        case 3:
                            Console.Clear();
                            VisualMenu.CenterTextLine("View Parking");
                            Console.Clear();
                            VisualMenu.CenterTextLine("Hello, World Prague Parking");
                            VisualMenu.CenterTextLine("View Parking");
                            ManipulateParking.ViewParking();
                            break;
                        case 4:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Move a Vehicle");
                            Console.Clear();
                            CarorMCMove();
                            break;
                        case 5:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Optimize Parking");                
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            ManipulateParking.OptimizeParkingMC();
                            break;
                            
                        case 6:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Credits");
                            Console.Clear();
                            VisualMenu.EndCretids();
                            Console.Clear();
                            break;
                        case 7:
                            Console.Clear();
                            VisualMenu.CenterTextLine("Exit");
                            VisualMenu.ShuttingDown();
                            Environment.Exit(0);
                            break;
                    }
                    Console.Clear();
                    VisualMenu.HelloWorld();
                }
            }
        }

        public static void CarorMCPark()
        {
            Console.Clear();
            VisualMenu.CenterTextLine("Hello, World Prague Parking");
            VisualMenu.CenterText("Park a Vehicle");
            ConsoleKeyInfo keyInfo;
            int choice = 0;
            string[] carorMC = { "Car", "MC", "Return" };
            int maxLength = carorMC.Max(item => item.Length) + 4;

            while (true)
            {
                Console.SetCursorPosition(0, 4);            // Här börjar positionen av vår Cursor på rad 2 för att 0 - 1 är reserverad för vår rubrik

                for (int i = 0; i < carorMC.Length; i++)
                {
                    string menuItem = $"{i + 1}. {carorMC[i]}";
                    string alignedText = menuItem.PadRight(maxLength);

                    string centeredText = VisualMenu.GetCenterText(alignedText);

                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(centeredText);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(centeredText);
                    }
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)          // Läser in våra keys så att vi kan röra oss upp ner och enter för att gå in
                {
                    if (choice > 0)
                        choice--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (choice < carorMC.Length - 1)
                        choice++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:

                            VisualMenu.CenterText("Car");
                            ManipulateParking.AddCar();
                            return;
                        case 1:
                            VisualMenu.CenterText("MC");
                            ManipulateParking.AddMC();
                            return;
                        case 2:
                            VisualMenu.CenterText("Retrun");
                            return;
                    }
                }
            }
        }

        public static void CarorMCRemove()
        {
            Console.Clear();
            VisualMenu.CenterTextLine("Hello, World Prague Parking");
            VisualMenu.CenterText("Remove a Vehicle");
            ConsoleKeyInfo keyInfo;
            int choice = 0;
            string[] carorMC = { "Car", "MC", "Return" };
            int maxLength = carorMC.Max(item => item.Length) + 4;

            while (true)
            {
                Console.SetCursorPosition(0, 4);            // Här börjar positionen av vår Cursor på rad 2 för att 0 - 1 är reserverad för vår rubrik

                for (int i = 0; i < carorMC.Length; i++)
                {
                    string menuItem = $"{i + 1}. {carorMC[i]}";
                    string alignedText = menuItem.PadRight(maxLength);

                    string centeredText = VisualMenu.GetCenterText(alignedText);

                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(centeredText);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(centeredText);
                    }
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)          // Läser in våra keys så att vi kan röra oss upp ner och enter för att gå in
                {
                    if (choice > 0)
                        choice--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (choice < carorMC.Length - 1)
                        choice++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:

                            VisualMenu.CenterText("Car");
                            ManipulateParking.RemoveCar();
                            return;
                        case 1:
                            VisualMenu.CenterText("MC");
                            ManipulateParking.RemoveMC();
                            return;
                        case 2:
                            VisualMenu.CenterText("Retrun");
                            return;
                    }
                }
            }
        }

        public static void CarorMCSearch()
        {
            Console.Clear();
            VisualMenu.CenterTextLine("Hello, World Prague Parking");
            VisualMenu.CenterText("Search for a vehicle");
            ConsoleKeyInfo keyInfo;
            int choice = 0;
            string[] carorMC = { "Car", "MC", "Return" };
            int maxLength = carorMC.Max(item => item.Length) + 4;

            while (true)
            {
                Console.SetCursorPosition(0, 4);            // Här börjar positionen av vår Cursor på rad 2 för att 0 - 1 är reserverad för vår rubrik

                for (int i = 0; i < carorMC.Length; i++)
                {
                    string menuItem = $"{i + 1}. {carorMC[i]}";
                    string alignedText = menuItem.PadRight(maxLength);

                    string centeredText = VisualMenu.GetCenterText(alignedText);

                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(centeredText);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(centeredText);
                    }
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)          // Läser in våra keys så att vi kan röra oss upp ner och enter för att gå in
                {
                    if (choice > 0)
                        choice--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (choice < carorMC.Length - 1)
                        choice++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:

                            VisualMenu.CenterText("Car");
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            ManipulateParking.CarSearch();
                            return;
                        case 1:
                            VisualMenu.CenterText("MC");
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            ManipulateParking.McSearch();
                            return;
                        case 2:
                            VisualMenu.CenterText("Retrun");
                            return;
                    }
                }
            }
        }

        public static void CarorMCMove()
        {
            Console.Clear();
            VisualMenu.CenterTextLine("Hello, World Prague Parking");
            VisualMenu.CenterText("Move a vehicle");
            ConsoleKeyInfo keyInfo;
            int choice = 0;
            string[] carorMC = { "Car", "MC", "Return" };
            int maxLength = carorMC.Max(item => item.Length) + 4;

            while (true)
            {
                Console.SetCursorPosition(0, 4);            // Här börjar positionen av vår Cursor på rad 2 för att 0 - 1 är reserverad för vår rubrik

                for (int i = 0; i < carorMC.Length; i++)
                {
                    string menuItem = $"{i + 1}. {carorMC[i]}";
                    string alignedText = menuItem.PadRight(maxLength);

                    string centeredText = VisualMenu.GetCenterText(alignedText);

                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(centeredText);
                        Console.ResetColor();
                    }
                    else
                    {

                        Console.WriteLine(centeredText);
                    }

                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)          // Läser in våra keys så att vi kan röra oss upp ner och enter för att gå in
                {
                    if (choice > 0)
                        choice--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (choice < carorMC.Length - 1)
                        choice++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    switch (choice)
                    {
                        case 0:

                            VisualMenu.CenterText("Car");
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            ManipulateParking.MoveCar();
                            return;
                        case 1:
                            VisualMenu.CenterText("MC");
                            Console.Clear();
                            VisualMenu.HelloWorld();
                            ManipulateParking.MoveMC();
                            return;
                        case 2:
                            VisualMenu.CenterText("Retrun");
                            return;
                    }
                }
            }
        }
    }
}