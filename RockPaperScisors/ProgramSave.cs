using System;



class RockPaperScissors {

	public static void Main (string[] args) {

		int ROCK = 0;
		int PAPER = 1;
		int SCISSORS = 2;

		int DRAW = 0;
		int LOSE = -1;
		int WIN = 1;


		int[,] winTable = new int[3,3];

		winTable [ROCK, ROCK] = DRAW;
		winTable [ROCK, PAPER] = LOSE;
		winTable [ROCK, SCISSORS] = WIN;

		int playerChoice = ROCK;
		int computerChoice = ROCK;

		if(winTable[playerChoice,computerChoice] == DRAW) {
			Console.WriteLine("It's a Draw");
		} else if(winTable[playerChoice,computerChoice] == LOSE) {
			Console.WriteLine("It's a LOSE");
		} else if(winTable[playerChoice,computerChoice] == WIN) {
			Console.WriteLine("It's a WIN");
		}

	}
}
