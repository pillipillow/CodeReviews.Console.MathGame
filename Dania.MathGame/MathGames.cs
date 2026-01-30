namespace MathGame
{
    internal enum GameType
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    internal enum Difficulty
    { 
        Easy,
        Medium,
        Hard
    }

    internal class MathGames
    {
        internal void MathGame(GameType gameType, Difficulty difficulty)
        {
            int firstNumber;
            int secondNumber;
            int result;
            int score = 0;
            string time = "00:00";

            Console.Clear();
            Helpers.StartTimer();

            //switch expressions
            string message = gameType switch
            {
                GameType.Addition => "Add the numbers!",
                GameType.Subtraction => "Subtract the numbers!",
                GameType.Multiplication => "Multiply the numbers!",
                GameType.Division => "Divide the numbers!",
                _ => "Unknown"
            };
            Console.WriteLine(message);

            string symbol = gameType switch
            {
                GameType.Addition => "+",
                GameType.Subtraction => "-",
                GameType.Multiplication => "*",
                GameType.Division => "/",
                _ => throw new ArgumentException("Invalid game type")
            };

            for (int i = 0; i < 5; i++)
            {
                var numbers = Helpers.GetNumbers(gameType, difficulty);
                firstNumber = numbers[0];
                secondNumber = numbers[1];

                result = gameType switch
                {
                    GameType.Addition => firstNumber + secondNumber,
                    GameType.Subtraction => firstNumber - secondNumber,
                    GameType.Multiplication => firstNumber * secondNumber,
                    GameType.Division => firstNumber / secondNumber,
                    _ => throw new ArgumentException("Invalid operation")
                };
                Console.Write($"{i + 1}. {firstNumber} {symbol} {secondNumber} = ");


                if (Helpers.CheckIfInputIsNumber() == result)
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                    Console.WriteLine($"Wrong! The answer is {result}");

                Console.WriteLine();

            }

            time = Helpers.StopTimer();
            Console.WriteLine($"Time completed: {time}");
            Console.WriteLine($"Game Over! Your final score is {score} pts. Press the Enter key to go back to the menu.");
            
            Helpers.AddToRecordGameList(gameType, difficulty, score, time);
            Console.ReadLine();
        }

    }
}
