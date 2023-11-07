namespace MontyHall_Backend.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int CarPosition { get; set; }
        public int PlayerChoice { get; set; }
        public int PresenterOpen { get; set; }
        public bool PlayerWins { get; set; }
    }
}
