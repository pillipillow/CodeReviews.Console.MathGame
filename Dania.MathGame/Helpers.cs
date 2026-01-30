using System.Timers;
using MathGame.Models;

namespace MathGame
{
    internal class Helpers
    {
        internal static List<RecordGame> recordGameList = new List<RecordGame>();

        static Random random = new Random();

        static System.Timers.Timer timer = new System.Timers.Timer(1000);
        static int m, s;

        internal static int[] GetNumbers(GameType gameType, Difficulty difficulty)
        {
            int[] numbers = new int[2];
            int firstNumber = 0;
            int secondNumber = 0;

            if (gameType == GameType.Addition)
            {
                if (difficulty == Difficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == Difficulty.Medium)
                {
                    firstNumber = random.Next(1, 50);
                    secondNumber = random.Next(1, 50);
                }
                else if (difficulty == Difficulty.Hard)
                {
                    firstNumber = random.Next(50, 100);
                    secondNumber = random.Next(50, 100);
                }
            }
            else if (gameType == GameType.Subtraction)
            {
                if (difficulty == Difficulty.Easy)
                {
                    do
                    {
                        firstNumber = random.Next(1, 9);
                        secondNumber = random.Next(1, 9);
                    } while (firstNumber < secondNumber);
                }
                else if (difficulty == Difficulty.Medium)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == Difficulty.Hard)
                {
                    firstNumber = random.Next(1, 50);
                    secondNumber = random.Next(1, 50);
                }
            }
            else if (gameType == GameType.Multiplication)
            {
                if (difficulty == Difficulty.Easy)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 9);
                }
                else if (difficulty == Difficulty.Medium)
                {
                    firstNumber = random.Next(1, 9);
                    secondNumber = random.Next(1, 20);
                }
                else if (difficulty == Difficulty.Hard)
                {
                    firstNumber = random.Next(1, 10);
                    secondNumber = random.Next(1, 100);
                }
            }
            else if (gameType == GameType.Division)
            {
                do
                {
                    if (difficulty == Difficulty.Easy)
                    {
                        firstNumber = random.Next(1, 100);
                        secondNumber = random.Next(1, 9);
                    }
                    else if (difficulty == Difficulty.Medium)
                    {
                        firstNumber = random.Next(1, 1000);
                        secondNumber = random.Next(1, 50);
                    }
                    else if (difficulty == Difficulty.Hard)
                    {
                        firstNumber = random.Next(1, 1000);
                        secondNumber = random.Next(1, 100);
                    }
                } while (firstNumber % secondNumber != 0);
            }

            numbers[0] = firstNumber;
            numbers[1] = secondNumber;

            return numbers;
        }


        internal static int CheckIfInputIsNumber()
        {
            int number = 0;
            bool isValid = false;

            do
            {
                var input = Console.ReadLine();
                input = input.Trim().ToLower();
                isValid = int.TryParse(input, out number);

                if (!isValid)
                    Console.WriteLine("Please input a number!");

            } while (!isValid);

            return number;
        }

        internal static void AddToRecordGameList(GameType gameType, Difficulty difficulty, int gameScore, string time)
        {
            recordGameList.Add(new RecordGame { Date = DateTime.Now, GameType = gameType, Difficulty = difficulty, Score = gameScore, TimeElapsed = time });
        }

        internal static void StartTimer()
        {
            s = 0;
            m = 0;

            timer.Elapsed += OnTimerEvent;
            timer.Start();
        }

        internal static string StopTimer()
        {
            timer.Stop();

            return String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
        }

        private static void OnTimerEvent(object? sender, ElapsedEventArgs e)
        {
            s++;

            if (s == 60)
            {
                s = 0;
                m += 1;
            }
        }
    }
}
