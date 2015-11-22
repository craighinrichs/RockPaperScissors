using System;

class RockPaperScissors {

	static RPSView view = new RPSView();

	public static void Main (string[] args) {

		RPSModel.Instance.AddNewPlayer(RPSModel.Instance.LIVEPLAYER);
		RPSModel.Instance.AddNewPlayer(RPSModel.Instance.COMPUTER_PLAYER,true);

		string answer = "";
		do {

			view.DisplayGreeting();

			view.DisplayPlayerScores();

			RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER).ChooseWeapon();

			view.PrintWeaponChoice();

			RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER).ChooseWeapon();


			Player playerOne = RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER);
			Player playerTwo = RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER);

			if(playerOne == playerTwo) {
				view.DisplayDraw();
				RPSModel.Instance.DrawScore();
			} else {
				Player winner = playerOne * playerTwo;
				if(winner.name.Equals(RPSModel.Instance.LIVEPLAYER)) {
					view.DisplayWin();
					RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER).Scored();
				} else if(winner.name.Equals(RPSModel.Instance.COMPUTER_PLAYER)) {
					view.DisplayLose();
					RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER).Scored();
				}
			}

			view.QuestionPlayAgain();
			answer = Console.ReadLine();

			view.ClearScreen();

		} while(answer.ToLower() == "y" || answer.ToLower() == "yes");
	}
}