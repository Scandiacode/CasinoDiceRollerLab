using System;

namespace CasinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            while (playAgain)
            {
                int userRolled = DiceSides();

                int dice1 = RandomNumberGen(userRolled);
                int dice2 = RandomNumberGen(userRolled);

                Console.WriteLine($"You rolled a {dice1} and a {dice2} ({dice1 + dice2} Total)");
                Console.WriteLine(DiceCombos(dice1, dice2));

                
                Console.Write("Roll again? (y/n)");
                while (true)
                {
                    string roolAgain = Console.ReadLine();
                    if (roolAgain.Equals("y"))
                    {
                        Console.Clear();
                        break;
                    }
                    else if (roolAgain.Equals("n"))
                    {
                        playAgain = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please choose (y/n)");
                    }
                }
            }
        }

        static int RandomNumberGen(int userRolled)
        {
            Random getRandNum = new Random();
            int rolls = getRandNum.Next(1, userRolled);

            return rolls;
        }
        static string DiceCombos(int dice1, int dice2)
        {
            int total = dice1 + dice2;

            if (dice1.Equals(1) && dice2.Equals(1))
            {
                return "Snake Eyes";
            }
            else if (dice1.Equals(1) && dice2.Equals(2) || (dice1.Equals(2) && dice2.Equals(1)))
            {
                return "Ace Deuce";
            }
            else if (dice1.Equals(6) && dice2.Equals(6))
            {
                return "Box Cars";
            }
            else if (total.Equals(7) || total.Equals(11))
            {
                return "Win";
            }
            if (total.Equals(2) || total.Equals(3) || total.Equals(12))
            {
                return "Craps";
            }
            else
            {
                return null;
            }

        }
        static int DiceSides()
        {
            Console.WriteLine("Enter the number of sides for your pair of dice");
            int userInputDice;
            while (true)
            {
                try
                {
                    userInputDice = int.Parse(Console.ReadLine());
                    if (userInputDice < 1)
                    {
                        throw new Exception("Invalid number for range");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid, need a number");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return userInputDice;
        }
    }
}
