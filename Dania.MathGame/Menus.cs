namespace MathGame
{
    internal class Menus
    {
        MathGames mathGames = new MathGames();

        internal void ShowMainMenu(string name, DateTime date)
        {
            var menuSelected = "";
            bool isGameOn = true;

            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Math Game, {name}! It's {date.DayOfWeek}.");
                Console.WriteLine("Which math would you like to play today?");
                Console.WriteLine("A - Addition\r\nS - Subtraction\r\nM - Multiplication\r\nD - Division\r\nV - Show Game Records\r\nQ - Quit the program");

                Console.Write("Choose from the options above: ");
                menuSelected = Console.ReadLine();

                if (menuSelected != null)
                    menuSelected = menuSelected.Trim().ToLower();

                switch (menuSelected)
                {
                    case "a":
                        GetDifficulty(GameType.Addition);
                        break;
                    case "s":
                        GetDifficulty(GameType.Subtraction);
                        break;
                    case "m":
                        GetDifficulty(GameType.Multiplication);
                        break;
                    case "d":
                        GetDifficulty(GameType.Division);
                        break;
                    case "v":
                        ShowGameRecords();
                        break;
                    case "q":
                        isGameOn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press the Enter key to try again. ");
                        Console.ReadLine();
                        break;
                }

            } while (isGameOn);
        }

        internal string GetName()
        {
            Console.WriteLine("Please type in your name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
                name = "Player";

            return name;
        }

        internal void GetDifficulty(GameType gameType)
        {
            Difficulty difficulty = Difficulty.Medium;
            bool isValid = false;

            do 
            {
                Console.Clear();
                Console.WriteLine($"{gameType}");
                Console.WriteLine("1 - Easy\n2 - Medium\n3 - Hard");
                Console.WriteLine("Which difficulty would you choose above: ");
                var menuSelected = Console.ReadLine();

                if (menuSelected != null)
                    menuSelected = menuSelected.Trim().ToLower();

                switch (menuSelected)
                {
                    case "1":
                        difficulty = Difficulty.Easy;
                        isValid = true;
                        break;
                    case "2":
                        difficulty = Difficulty.Medium;
                        isValid = true;
                        break;
                    case "3":
                        difficulty= Difficulty.Hard;
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter the key to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (!isValid);

            mathGames.MathGame(gameType ,difficulty);
        }

        internal void ShowGameRecords()
        {
            Console.Clear();
            Console.WriteLine("Time\t\t\tGame\t\tDifficulty\tScore\t\tTime Completion");

            if (Helpers.recordGameList.Count <= 0)
                Console.WriteLine("No game recorded");
            else
            {
                foreach (var record in Helpers.recordGameList)
                {
                    Console.WriteLine($"{record.Date}\t{record.GameType}\t{record.Difficulty}\t\t{record.Score} pts\t\t{record.TimeElapsed}");
                }
            }
            Console.WriteLine("\nPress the Enter key to go back to the menu.");
            Console.ReadLine();
        }
    }
}
