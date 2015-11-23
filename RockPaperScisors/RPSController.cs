using System;


public class RPSController {

    private RPSView view;
    public RPSController (RPSView view) {
        this.view = view;
        // just to suppress the warning
        this.view.ClearScreen();
    }

    public void StartGame() {
        AddPlayers();
        GameLoop();
    }

    public void AddPlayers() {
        RPSModel.Instance.AddNewPlayer(RPSModel.Instance.LIVEPLAYER);
        RPSModel.Instance.AddNewPlayer(RPSModel.Instance.COMPUTER_PLAYER,true);
    }

    public void GameLoop() {
        string answer = "";
        do {

            RPSModel.Instance.GameStart();

            RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER).ChooseWeapon();

            RPSModel.Instance.PlayerChooseWeapon();

            RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER).ChooseWeapon();


            Player playerOne = RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER);
            Player playerTwo = RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER);

            if(playerOne == playerTwo) {
                RPSModel.Instance.PlayerDraw();
                RPSModel.Instance.DrawScore();
            } else {
                Player winner = playerOne * playerTwo;
                if(winner.name.Equals(RPSModel.Instance.LIVEPLAYER)) {
                    RPSModel.Instance.PlayerWon();
                    //RPSModel.Instance.GetPlayer(RPSModel.Instance.LIVEPLAYER).Scored();
                } else if(winner.name.Equals(RPSModel.Instance.COMPUTER_PLAYER)) {
                    RPSModel.Instance.PlayerLost();
                    //RPSModel.Instance.GetPlayer(RPSModel.Instance.COMPUTER_PLAYER).Scored();
                }
                winner.Scored();
            }

            RPSModel.Instance.PlayAgainQuestion();
            answer = Console.ReadLine();

        } while(answer.ToLower() == "y" || answer.ToLower() == "yes");
    }
}

