using System;

public class RPSView {

	public RPSView () {
        RPSModel.Instance.Change += new RPSModel.ModelChangeHandler (UpdateView);
	}

    public void UpdateView(RPSModel.GameState state, EventArgs e) {
        switch(state) {
        case RPSModel.GameState.StartGame:
            DisplayGreeting();
            DisplayPlayerScores();
            break;
        case RPSModel.GameState.Draw:
            DisplayDraw();
            break;
        case RPSModel.GameState.PlayerCanChoose:
            PrintWeaponChoice();
            break;
        case RPSModel.GameState.PlayerLost:
            DisplayLose();
            break;
        case RPSModel.GameState.PlayerWon:
            DisplayWin();
            break;
        case RPSModel.GameState.PlayAgain:
            QuestionPlayAgain();
            break;
        }
    }

	public void DisplayGreeting() {
        ClearScreen();
		Console.WriteLine("-- Rock, Paper, Scissors --");
	}

	public void PrintWeaponChoice() {
		Console.WriteLine("Choose your weapon. Computer has already Choosen!\n\n");
		Console.Write("1] Rock\n2] Paper\n3] Scissors\n\n::--> ");
	}

	public void DisplayPlayerScores() {
		Console.WriteLine("Player Score: " + RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER).score + " Computer Score: " + RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER).score + " Draws: " + RPSModel.Instance.drawScore + "\n\n");
	}

	public void DisplayDraw() {
		Console.WriteLine("It's a Draw");
	}

	public void DisplayWin() {
		Console.WriteLine("It's a WIN");
	}

	public void DisplayLose() {
		Console.WriteLine("It's a LOSE");
	}

	public void QuestionPlayAgain() {
		Console.WriteLine("Would you like to play again? [y/n]");
	}

	public void ClearScreen() {
		Console.Clear();
	}
}

