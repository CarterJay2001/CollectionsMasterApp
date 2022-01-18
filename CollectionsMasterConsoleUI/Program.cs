using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DONE: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50
            var randNums = new int[50];

            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            randNums = Populater(randNums);

            //Print the first number of the array
            Console.WriteLine(randNums[0]);

            //Print the last number of the array            
            Console.WriteLine(randNums[randNums.Length - 1]);

            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists
            NumberPrinter(randNums);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*     Hint: Array._____(); Create a custom method     */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(randNums);
            NumberPrinter(randNums);
            Array.Reverse(randNums);

            Console.WriteLine("---------REVERSE CUSTOM------------");
            NumberPrinter(ReverseArray(randNums));

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            NumberPrinter(ThreeKiller(randNums));

            Console.WriteLine("-------------------");

            //Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(randNums);
            NumberPrinter(randNums);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List
            var randList = new List<int>();

            //Print the capacity of the list to the console
            Console.WriteLine(randList.Count);

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            randList = Populater(randList);

            //Print the new capacity
            Console.WriteLine(randList.Count);

            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            string userNum = "";
            bool success = false;
            var newNum = 0;
            while (!success)
            {
                userNum = Console.ReadLine();
                success = int.TryParse(userNum, out newNum);
                if (!success)
                {
                    Console.WriteLine("That's not a number, try again.");
                }
            }
            Console.WriteLine(NumberChecker(randList, newNum) ? "It's in there!" : "It's not in there");

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list
            NumberPrinter(randList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            NumberPrinter(OddKiller(randList));
            
            Console.WriteLine("------------------");

            //Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            randList = OddKiller(randList);
            randList.Sort();
            NumberPrinter(randList);
            
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable
            var randListAsArray = randList.ToArray();

            //Clear the list
            randList.Clear();

            #endregion
        }

        private static int[] ThreeKiller(int[] numbers)
        {
            var numbs = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbs[i] = 0;
                }
                else
                {
                    numbs[i] = numbers[i];
                }
            }
            return numbs;
        }

        private static List<int> OddKiller(List<int> numberList)
        {
            var numbs = new List<int>();
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 == 0)
                {
                    numbs.Add(numberList[i]);
                }
            }
            return numbs;
        }

        private static bool NumberChecker(List<int> numberList, int searchNumber)
        {
            foreach(int number in numberList)
            {
                if (number == searchNumber)
                {
                    return true;
                }
            }
            return false;
        }

        private static List<int> Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(51));
            }
            return numberList;
        }

        private static int[] Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(51);
            }
            return numbers;
        }        

        private static int[] ReverseArray(int[] array)
        {
            var revArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                revArray[i] = array[array.Length - 1 - i];
            }
            return revArray;
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
