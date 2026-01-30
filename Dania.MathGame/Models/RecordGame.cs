namespace MathGame.Models
{
    internal class RecordGame
    {
        public DateTime Date { get; set; }
        public GameType GameType { get; set; }
        public Difficulty Difficulty { get; set; }
        public int Score { get; set; }
        public string TimeElapsed { get; set; }
    }
}
