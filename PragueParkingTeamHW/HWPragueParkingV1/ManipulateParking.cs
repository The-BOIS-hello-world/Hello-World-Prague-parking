using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HWPragueParkingV1
{
    internal class ManipulateParking
    {
        public static void AddCar()
        {
            Console.Clear();
            Console.Write("Enter your registration number: ");                                           // while loop for correct input of reg number 
            string Reg = Console.ReadLine().ToUpper();
            while (Reg.Length > 10 || Reg.Length < 4 || Reg.Contains(" "))
            {
                Console.WriteLine("Reg is invalid please retry again");
                Console.Write("Enter your registration number: ");
                Reg = Console.ReadLine().ToUpper();
            }

            int index = Array.IndexOf(InfoArray.ArrayParking, "0");                                      // searching for first empty spot

            if (index != -1)                                                                             // save in array if space found
            {
                InfoArray.ArrayParking[index] = Reg;
                Console.WriteLine($"Your car has been parked at spot {index}");
            }
            else
            {
                Console.WriteLine("Theres no available spots");                                         // no available sports claus 
            }
            Console.WriteLine("Press any key to return to menu:");
            Console.ReadKey(true);
            Console.Clear();
        }

        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void AddMC()
        {
            Console.Clear();
            string substring = "#";

            Console.Write("Enter your registration number: ");
            string Reg = Console.ReadLine().ToUpper();
            while (Reg.Length > 10 || Reg.Length < 4 || Reg.Contains(" "))                                                                   // while loop for correct input of reg number 
            {
                Console.WriteLine("Reg is invalid please retry again");
                Console.Write("Enter your registration number: ");
                Reg = Console.ReadLine().ToUpper();
            }

            for (int row = 0; row < 101; row++)
            {
                
                if (InfoArray.ArrayParking[row].Contains(substring))
                {

                    InfoArray.ArrayParking[row] = InfoArray.ArrayParking[row].Replace("#", Reg);                        // replace the desierd string in empty 1/2 MC space (2 Mc parked in same space)
                    Console.WriteLine($"Your MC is parked in space {row} with another motorcycle");
                    break;
                }
                else if (InfoArray.ArrayParking[row] == "0")
                {
                    int index = Array.IndexOf(InfoArray.ArrayParking, "0");                                             // searching for first empty spot

                    if (index != -1)                                                                                    // save in array if space found
                    {
                        InfoArray.ArrayParking[index] = Reg + (" * #");                                                 // adds our search icon to find for later MC parking
                        Console.WriteLine($"Your MC has been parked at spot {index}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Theres no available spots");                                                 // only option left is that there arent any spots to park a motorcycle 
                        break;
                    }
                }
            }
            Console.WriteLine("Press any key to return to the menu:");
            Console.ReadKey(true);
            Console.Clear();
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void OptimizeParkingMC()
        {
            int firstSoloMCSpot = -1; // WE use this to save the spot of the first solo MC
            int secondSoloMCSpot = -1; // WE use this to save the spot of the second solo MC

            for (int i = 1; i < InfoArray.ArrayParking.Length; i++) // Loop through all the parking spots to find solo MCs (Reg * #)
            {
                string parkingSpot = InfoArray.ArrayParking[i];

                if (parkingSpot.Contains("*") && parkingSpot.Contains("#")) // Check if the parking spot contains one motorcycle (Reg * #)
                {
                    if (firstSoloMCSpot == -1)
                    {
                        firstSoloMCSpot = i;
                    }
                    else
                    {
                        secondSoloMCSpot = i;
                        break;
                    }
                }
            }

            if (firstSoloMCSpot != -1 && secondSoloMCSpot != -1) // If both the first solo MC and second MC was found, we make the switch
            {
                string secondMCReg = InfoArray.ArrayParking[secondSoloMCSpot].Replace("*", "").Replace("#", "").Trim(); // to make sure we ONLY save the reg

                Console.WriteLine($"Moving motorcycle with registration {secondMCReg} from parking {secondSoloMCSpot} to parking {firstSoloMCSpot}.");
                InfoArray.ArrayParking[firstSoloMCSpot] = InfoArray.ArrayParking[firstSoloMCSpot].Replace("#", secondMCReg); // move the second MC to the solo MC spot

                InfoArray.ArrayParking[secondSoloMCSpot] = "0"; // We make sure the spot we moved it from is now empty
                Console.WriteLine($"parkingspot {secondSoloMCSpot} is now empty.");
            }
            else
            {
                Console.WriteLine("No optimization needed. Either no solo motorcycles found or not enoug to optimize.");
            }
            Console.WriteLine("Press any key to return to menu.");
            Console.ReadKey(true);
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveCar()
        {
            string inputCarReg = "";
            bool backToMainMenu = false;

            Console.WriteLine("Please enter the Vehicle registration number");      
            inputCarReg = Console.ReadLine().ToUpper();


            while (!backToMainMenu)
            {

                if (inputCarReg == "RETURN")                                                                                             // Exit claus
                {
                    backToMainMenu = true;
                }

                else
                {

                    int index = Array.IndexOf(InfoArray.ArrayParking, inputCarReg);                                                     // index Arraycheck instead of for loop as cars can only park in empty spaces 
                    if (index == -1)
                    {
                        Console.Write(@"Reg is invalid please try again, Type ""Return"" if you wish to go to the menu:  ");
                        inputCarReg = Console.ReadLine().ToUpper();                                                                     // if index Arraycheck cant find anything it gives the value -1 
                    }

                    else
                    {
                        Console.WriteLine($"Your vehicle is parked in spot number: {index}");

                        Console.WriteLine("Enter the parking space you would like to move to: ");
                        int newSpace = int.Parse(Console.ReadLine());

                        while (InfoArray.ArrayParking[newSpace] != "0")                                                                 //  checks if the new space slected is free or not to place car
                        {
                            Console.WriteLine("This space is already taken, please choose another: ");
                            newSpace = int.Parse(Console.ReadLine());
                            
                        }

                        
                        Console.WriteLine($"We have moved your vehicle from {index} to parking spot {newSpace}");                       // Flytta bilen
                        InfoArray.ArrayParking[newSpace] = inputCarReg;
                        InfoArray.ArrayParking[index] = "0";                                                                            // Sätt gamla platsen som tom
                        Console.ReadKey(true);


                                                                                                                                        // Avsluta loopen efter flytt
                        break;
                    }
                }
            }
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void MoveMC()
        {
            string inputMCReg = "";
            bool backToMainMenu = false;
            string substring = "*";
            string substring2 = "#";
            string substring3 = "0";

            Console.WriteLine("Please enter the Vehicle registration number");
            inputMCReg = Console.ReadLine().ToUpper();

            while (!backToMainMenu)                                                                                      // start by setting the while loop to our return bool 
            {

                if (inputMCReg == "RETURN")                                                                              // input check to return bool
                {
                    backToMainMenu = true;
                    break;
                }

                else
                {

                    bool MCFound = false;
                    int row = 1;

                    for (row = 1; row < InfoArray.ArrayParking.Length; row++)                                             
                    {
                        string ArrayParkingPlace = InfoArray.ArrayParking[row];                                        

                        if (ArrayParkingPlace.Contains(inputMCReg) && ArrayParkingPlace.Contains(substring))              // changes current array point to a string to use .Contains and searches after Mc identifier '*'
                        {
                            MCFound = true;

                            if (ArrayParkingPlace.Contains(substring2))                                                  // check to see if there is 1 or 2 motorcycles parked n the parking space by the uce of .Contains searching after '#' 
                            {                                                                                            // if # is present only 1 mc parked in that parking spot 
                                Console.WriteLine($"Your vehicle is parked in spot number: {row}");                      // so it replaces with a "0" to show that the space is now empty 
                                InfoArray.ArrayParking[row] = "0";
                            }

                            else
                            {
                                Console.WriteLine($"Your vehicle is parked in spot number: {row}");                      // if no # is present there is another motorcycle parked in the same spot to we replace the given reg number with a '#'
                                string currentParkedMC = InfoArray.ArrayParking[row];                                    // to show that there is space for another motorcycle to park there.
                                InfoArray.ArrayParking[row] = currentParkedMC.Replace(inputMCReg, "#");
                            }
                            break;
                        }
                    }

                    if (!MCFound)
                    {
                        Console.WriteLine(@"Your registration is INVALID, Try again. Type ""Return"" to go back to main menu");    // this is our if statement for if the registration typed in cannot be found 
                        inputMCReg = Console.ReadLine().ToUpper();                                                                 // where you are given the choice to retype or return to menu 
                        if (inputMCReg == "RETURN")
                        {
                            backToMainMenu = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }

                    Console.WriteLine(@"Enter the parking space you would like to move to or type ""0"" to return to main menu: ");      // new space input 
                    int newSpace = int.Parse(Console.ReadLine());
                    if (newSpace == 0)
                    {
                        backToMainMenu = true;
                        break;
                    }

                    while (!backToMainMenu)
                    {

                        string ArrayParkingNewSpace = InfoArray.ArrayParking[newSpace];                                                               // converts to string so it can be maipulated and checked 

                        if (ArrayParkingNewSpace.Contains(substring2))                                                                                // checks if the newspace has a '#' to show that the mc can park there next to another Mc
                        {
                            string newParkingSpace = InfoArray.ArrayParking[newSpace];                                                                // if true we replace the '#' with the moved vehicles reg number 
                            InfoArray.ArrayParking[newSpace] = newParkingSpace.Replace(substring2, inputMCReg);
                            Console.WriteLine($"We have moved your vehicle from {row} to parking spot {newSpace} and its parked with another MC");    
                            Console.ReadKey(true);
                            backToMainMenu = true;                                                                                                    // breaks back to menu 
                            break;
                        }

                        else if (InfoArray.ArrayParking[newSpace].Contains("0"))                                                                      // checks if the new space is completely empty 
                        {
                            string newParkingSpace = InfoArray.ArrayParking[newSpace];                                                                // then replaces the "0" with the reg number 
                            InfoArray.ArrayParking[newSpace] = newParkingSpace.Replace(substring3, inputMCReg);
                            InfoArray.ArrayParking[newSpace] = inputMCReg + " * #";
                            Console.WriteLine($"We have moved your vehicle from {row} to parking spot {newSpace}");
                            Console.ReadKey(true);
                            backToMainMenu = true;                                                                                                    // breaks back to menu 
                            break;
                        }

                        else if (!InfoArray.ArrayParking[newSpace].Contains("#") && !InfoArray.ArrayParking[newSpace].Contains("0"))                  // if the new parking spot cannot fit a motorcycle the for loop breaks row is reset to 1 
                        {                                                                                                                             // and you can either input a reg number again or break to menu with "0"
                            Console.WriteLine(@"This space is already occupied, please choose another space. Type ""0"" to go back to main menu");
                            newSpace = int.Parse(Console.ReadLine());
                            if (newSpace == 0)
                            {
                                backToMainMenu = true;
                                break;
                            }
                        }
                    }

                }
            }
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RemoveCar()
        {
            bool carRemove = true;

            Console.Clear();
            Console.Write("Enter your registration number: ");                                  //Input for Reg converted to upper
            string Reg = Console.ReadLine().ToUpper();
            while (Reg.Length > 10 || Reg.Length < 4)
            {
                Console.WriteLine("Reg is invalid please retry again");
                Console.Write("Enter your registration number: ");
                Reg = Console.ReadLine().ToUpper();
            }

            while (carRemove)
            {
                int index = Array.IndexOf(InfoArray.ArrayParking, Reg);                         //Variable of the whole array, looking for Reg
                if (index != -1)                                                                //If-loop activated when we are not getting -1
                {
                    InfoArray.ArrayParking[index] = "0";                                        //Replaced with empyty lot 
                    Console.WriteLine($"Your car was removed from spot {index}");
                    Console.ReadKey(true);
                    carRemove = false;
                    break;
                }
                else if (index == -1)                                                       //Incase we get -1 (no reg found)
                {
                    Console.WriteLine("The registration number was not found.");
                    Console.WriteLine("Please enter your registration number or type Return to return to main menu: ");
                    Reg = Console.ReadLine().ToUpper();
                    if (Reg == "RETURN")
                    {
                        carRemove = false;                                                  //Type return to get back
                        break;
                    }
                }
            }
            
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void RemoveMC()
        {
            string substring = "#";                                                                         //Variable for search-object
            bool mcFound = false;

            Console.Clear();
            Console.Write("Enter your registration number: ");
            string Reg = Console.ReadLine().ToUpper();
            while (Reg.Length > 10 || Reg.Length < 4)
            {
                Console.Write("Reg is invalid please retry again");
                Console.Write("Enter your registration number: ");
                Reg = Console.ReadLine().ToUpper();
            }




            while (!mcFound)
            {

                for (int row = 1; row < InfoArray.ArrayParking.Length; row++)                                               //Searching array
                {
                    string currentIndex = InfoArray.ArrayParking[row];
                    if (currentIndex.Contains(Reg))                                                                         //Searching for inputed Reg
                    {
                        if (currentIndex.Contains("*"))                                                                     //Searching for MC-lots
                        {
                            if (currentIndex.Contains("#"))                                                                 //Finding mc-lot with only one MC
                            {
                                Console.Write($"Your motorcycle was removed from parking spot: {row}");                     //Replace with 0, breaks
                                InfoArray.ArrayParking[row] = "0";
                                Console.ReadKey(true);
                                mcFound = true;
                                break;
                            }
                            else
                            {
                                Console.Write($"Your MC was removed from parking spot: {row}");                             //Lots with only *, replace one reg with #
                                InfoArray.ArrayParking[row] = currentIndex.Replace(Reg, substring);
                                Console.ReadKey(true);

                                mcFound = true;
                                break;
                            }
                        }
                        else
                        {
                            Console.Write($"The registration number {Reg} does not exist, please input another registration number: ");         //Invalid Reg
                            Console.WriteLine(@"Or type ""Return"" to go back to menu: ");
                            Reg = Console.ReadLine().ToUpper();

                            if (Reg == "RETURN")
                            {

                                mcFound = true;
                                break;
                            }
                            else
                            {                                                                                                                   //Resetting to start of array
                                row = 1;
                            }

                        }
                    }
                    else if (row == InfoArray.ArrayParking.Length - 1)
                    {
                        Console.WriteLine($"The registration number {Reg} does not exist, please input another registration number: ");         //Failsafe to cover different cases of invalid Reg
                        Console.Write(@"Or type ""Return"" to go back to menu: ");
                        Reg = Console.ReadLine().ToUpper();
                        if (Reg == "RETURN")
                        {

                            mcFound = true;
                            break;
                        }
                        else
                        {
                            row = 1;
                        }
                    }
                }

            }
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void CarSearch()
        {
            bool isFound = false;

            while (!isFound)
            {

                Console.Write("Enter in the Car Registration: ");                                   
                string inputCarReg = Console.ReadLine().ToUpper();

                for (int i = 1; i < InfoArray.ArrayParking.Length; i++)                                       // for loop to search for the car through the parking array 
                {
                    if (inputCarReg == "RETURN")
                    {
                        isFound = true;                                                               
                    }
                    else if (inputCarReg == InfoArray.ArrayParking[i])
                    {
                        isFound = true;                                                                        // has found the car so bool is changed to true to break the loop 
                        Console.WriteLine($"Your vehicle is parked in spot number: {i}");                      // loop breaks and position is printed 
                        Console.WriteLine();
                        Console.ReadKey(true);
                    }
                }

                if (!isFound)                                                                                  // if the car is not found the for loop restarts and you are given the option to 
                {                                                                                              // search aftera new reg number or return to menu  
                    Console.WriteLine("Registration number not found. Please try again.");  
                    Console.WriteLine(@"Type ""Return"" to go back to menu");
                }
            }
        }
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void McSearch()
        {
            bool isFound = false;

            while (!isFound)
            {

                Console.Write("Enter in the motorcycle Registration: ");
                string inputMcReg = Console.ReadLine().ToUpper();

                for (int i = 1; i < InfoArray.ArrayParking.Length; i++)                                // for loop to search for the motorcycl through the parking array 
                {
                    if (inputMcReg == "RETURN")
                    {
                        isFound = true;                                                               // Set flag to true when registration number is found, 'returnn' to break and return to main menu
                    }
                    else if (InfoArray.ArrayParking[i].Contains(inputMcReg))                          // search using our identifier '*'  
                    {
                        Console.WriteLine($"Your motorcycle is parked in space number {i}");
                        isFound = true;                                                               // Set flag to true when registration number is found
                        Console.ReadKey(true);                                                     
                    }
                }
                  
                if (!isFound)                                                                         // if the motorcycle is not found the for loop restarts and you are given the option to
                {                                                                                     // search aftera new reg number or return to menu
                    Console.WriteLine("Registration number not found. Please try again.");         
                    Console.WriteLine(@"Type ""Return"" to go back to menu");
                }
            }
        }
        
        ///--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void ViewParking()
        {
            Console.Write("Cars will appear in: ");                                      // idex for colour scheme
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Blue");
            Console.ResetColor();
            Console.Write("Motorcykles will apear in: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Red");
            Console.ResetColor();
            Console.Write("Empty spaces will appear as: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"""0""");
            Console.WriteLine();


            string[] unwantedSymbols = { "*", "#" };                         // Create and array of the unwanted char but in string format

            for (int i = 1; i < InfoArray.ArrayParking.Length; i++)
            {
                string currentString = InfoArray.ArrayParking[i];

                foreach (string symbol in unwantedSymbols)                            // Removes all symbols from currentstring first i each i 
                {
                    currentString = currentString.Replace(symbol, "").Trim();         // Trim removes all dead space before/after a string
                }

                currentString = currentString.Replace("  ", " & ").Trim();              // Removes dead space between 2 MC (Was ugly without)

                if (InfoArray.ArrayParking[i].Contains("*"))                          // If it contained the chosen symbol for mc print red 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (InfoArray.ArrayParking[i] != "0")                            // if its a car show blue
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;                     // empty space = white
                }
                Console.Write($"|{currentString}");                                   // put reset here so i dont have to write everything x2
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu:");
            Console.ReadKey(true);
        }
    }
}
