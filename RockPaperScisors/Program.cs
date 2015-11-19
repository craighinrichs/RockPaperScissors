using System;

class RockPaperScissors {

	public static void Main (string[] args) {

//		int ROCK = 0;
//		int PAPER = 1;
//		int SCISSORS = 2;

		int DRAW = 0;
		int LOSE = -1;
		int WIN = 1;


		int[,] winTable = new int[3,3] { 
			// ROCK
			{ 
				// ROCK
				DRAW, 
				// PAPER
				LOSE, 
				// SCISSOR
				WIN 
			}, 
			// PAPER
			{ // ROCK
				WIN, 
				// PAPER
				DRAW, 
				// SCISSOR
				LOSE  
			}, 
			// SCISSORS
			{ // ROCK
				LOSE, 
				// PAPER
				WIN, 
				// SCISSOR
				DRAW  
			}
		};

		int playerScore = 0;
		int computerScore = 0;
		int drawScore = 0;

		Random rand = new Random ();

		string answer = "";
		do {

			Console.WriteLine("-- Rock, Paper, Scissors --");

			int computerChoice = rand.Next(0,3);

			Console.WriteLine("Choose your weapon. Computer has already Choosen!\n\n");

			Console.WriteLine("Player Score: " + playerScore + " Computer Score: " + computerScore + " Draws: " + drawScore + "\n\n");

			Console.Write("1] Rock\n2] Paper\n3] Scissors\n\n::--> ");

			int playerChoice = Convert.ToInt32(Console.ReadLine());
			playerChoice = playerChoice - 1;

			if(winTable[playerChoice,computerChoice] == DRAW) {
				Console.WriteLine("It's a Draw");
				drawScore = drawScore + 1;
			} else if(winTable[playerChoice,computerChoice] == LOSE) {
				Console.WriteLine("It's a LOSE");
				computerScore = computerScore + 1;
			} else if(winTable[playerChoice,computerChoice] == WIN) {
				Console.WriteLine("It's a WIN");
				playerScore = playerScore + 1;
			}

			Console.WriteLine("Would you like to play again? [y/n]");
			answer = Console.ReadLine();

			Console.Clear();

		} while(answer.ToLower() == "y" || answer.ToLower() == "yes");
	}
}