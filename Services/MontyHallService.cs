using MontyHall_Backend.Models;

namespace MontyHall_Backend.Services
{
    public class MontyHallService
    {

        public MontyHallResult SimulateGame(int numSimulations, bool changeDoor)
        {
            // Implement the game simulation logic here
            // Return the simulation results

            Random random = new Random();
            int wins = 0;
            int losses = 0;

            for (int i = 0; i < numSimulations; i++)
            {
                // Randomly place the car behind one of the three doors
                int carPosition = random.Next(3);

                // Player randomly selects a door this represents the initialize choice
                int playerChoice = random.Next(3);

                // Determine which door the presenter will open
                int presenterOpen;
                do
                {
                    presenterOpen = random.Next(3);
                } while (presenterOpen == carPosition || presenterOpen == playerChoice);

                // If the player chooses to change the door, they switch to a different door
                if (changeDoor)
                {
                    int newChoice;
                    do
                    {
                        newChoice = random.Next(3);
                    } while (newChoice == playerChoice || newChoice == presenterOpen);
                    playerChoice = newChoice;
                }

                // Check if the player's final choice matches the car position
                if (playerChoice == carPosition)
                {
                    wins++;
                }
                else
                {
                    losses++;
                }
            }

            return new MontyHallResult
            {
                TotalSimulations = numSimulations,
                Wins = wins,
                Losses = losses
            };
        }
    }

}
