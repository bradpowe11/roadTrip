using System;

namespace roadTrip
{
    class versionOne
    {
        static void Main(string[] args)
        {
            int parts = 0, fuel = 0, miles = 0, direction = 0, hour = 0;
            Random r = new Random();
            bool win = false;
            Console.Write("What is your CB handle? ");
            string name = Console.ReadLine();
            initValues(ref parts, ref fuel, ref miles, r);
            while (parts > 0 && fuel > 0 && miles > 0 && win == false)
            {
                direction = chooseDirection();
                /* the direction impacts the number passed to the actions method
                 * if they choose left, they will only receive bad outcomes
                 * if they choose right, they have a better chance of receiving 
                 * good outcomes along with the bad outcomes */
                if (direction == 1)
                    actions(r.Next(4), ref parts, ref fuel, ref miles);
                else
                    actions(r.Next(10), ref parts, ref fuel, ref miles);
                checkResults(ref hour, ref parts, ref fuel, ref miles, ref win);
            }
            if (win)
                Console.WriteLine("Congratulations on successfully completing your road trip!");
            else if (parts <= 0)
                Console.WriteLine("Your vehicle broke down and you did not complete your road trip");
            else if (fuel <= 0)
                Console.WriteLine("You don't have any fuel left and cannot complete your road trip");
            else
                Console.WriteLine("You have made to many wrong turns. The miles of backtracking has exceeded miles traveled");

        }

        private static void checkResults(ref int hour, ref int parts, ref int fuel, ref int miles, ref bool win)
        {
            hour = hour + 1;
            Console.WriteLine($"~~~~~~~~ Hour {hour} ~~~~~~~~");
            Console.WriteLine($"Parts:{parts} Fuel:{fuel} Miles:{miles}");
            if (hour >= 16)
                win = true;
            return;
        }

        private static void actions(int v, ref int parts, ref int fuel, ref int miles)
        {
            Random rnd = new Random();
            int num = rnd.Next(10);
            switch (num)
            {
                case 0:
                    Console.WriteLine("You were caught in a speed trap");
                    Console.WriteLine("You lose 10 miles and 1 gallon of fuel");
                    miles -= 10;
                    fuel -= 1;
                    break;
                case 1:
                    Console.WriteLine("You hit a Deer");
                    Console.WriteLine("You lost 20 miles, 2 gallons of fuel and 1 part");
                    miles -= 20;
                    fuel -= 2;
                    parts -= 1;
                    break;
                case 2:
                    Console.WriteLine("The Road you are on is closed. Please turn around");
                    Console.WriteLine("You lost 2 gallons of fuel and 30 miles");
                    miles -= 30;
                    fuel -= 2;
                    break;
                case 3:
                    Console.WriteLine("You get a flat tire");
                    Console.WriteLine("You lost 1 part and 15 miles");
                    miles -= 15;
                    parts -= 1;
                    break;
                case 4:
                    Console.WriteLine("You end up on a dirt road and get stuck in the mud");
                    Console.WriteLine("You lost 1 part, 40 miles and 3 gallons of fuel");
                    miles -= 40;
                    fuel -= 3;
                    parts -= 1;
                    break;
                case 5:
                    Console.WriteLine("You stop traffic to allow ducks to cross the road");
                    Console.WriteLine("You gained 20 miles, 2 gallons of fuel and 2 parts");
                    miles += 2;
                    fuel += 2;
                    parts += 2;
                    break;
                case 6:
                    Console.WriteLine("You pick up a hitchhiker");
                    Console.WriteLine("You gain 30 miles and 3 gallons of fuel");
                    miles += 30;
                    fuel += 3;
                    break;
                case 7:
                    Console.WriteLine("You join a Trucker convoy and stop at the best diner on Route 66");
                    Console.WriteLine("You gain 40 miles, 5 gallons of fuel and 1 part");
                    miles += 40;
                    fuel += 5;
                    parts += 1;
                    break;
                case 8:
                    Console.WriteLine("You stop at a travel center to streach your legs");
                    Console.WriteLine("You lost 5 miles but gained 10 gallons of fuel");
                    miles -= 5;
                    fuel += 10;
                    break;
                case 9:
                    Console.WriteLine("GPS short cut leads to a stop at a store. Your lotto ticket hits big!");
                    Console.WriteLine("You gain 50 miles, 5 gallons of fuel and 1 part");
                    miles += 50;
                    fuel += 5;
                    parts += 1;
                    break;
                default:
                    Console.WriteLine("You stopped to help a stranded travler");
                    Console.WriteLine("You gain 2 parts and 2 gallons of fuel");
                    fuel += 2;
                    parts += 2;
                    break;
            }
            return;
        }

        private static int chooseDirection()
        {

            Console.WriteLine("You have come to a crossroad, enter 1 to travel left and a 2 to travel right");
            int direction = int.Parse(Console.ReadLine());
            while (direction != 1 && direction != 2)
            {
                Console.WriteLine("You entered an invalid number, please enter a 1 for left or a 2 for right");
                direction = int.Parse(Console.ReadLine());
            }
            return direction;
        }

        private static void initValues(ref int parts, ref int fuel, ref int miles, Random r)
        {
            parts = r.Next(5) + 1;
            fuel = r.Next(20) + 5;
            miles = r.Next(100) + 10;
            return;
        }
    }
}
