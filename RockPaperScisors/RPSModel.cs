using System;
using System.Collections.Generic;

public class RPSModel {

	public readonly string LIVEPLAYER = "You";
	public readonly string COMPUTER_PLAYER = "Computer";

    public event ModelChangeHandler Change;
    public EventArgs e = null;
    public delegate void ModelChangeHandler(GameState state, EventArgs e);

    public enum GameState {
        StartGame,
        PlayerCanChoose,
        PlayerWon,
        PlayerLost,
        Draw,
        PlayAgain
    }

	public enum WinState {
		LOSE = -1,
		DRAW = 0,
		WIN = 1
	}
	private int _drawScore;
	public int drawScore {
		get {
			return _drawScore;
		}
	}

	private List<Player> players =  new List<Player>();

	private WinState[,] winTable = new WinState[3,3] { {WinState.DRAW, WinState.LOSE, WinState.WIN} , 
		{ WinState.WIN, WinState.DRAW, WinState.LOSE }, {WinState.LOSE, WinState.WIN, WinState.DRAW} };

	private static RPSModel instance = null;

	public static RPSModel Instance {
		
		get {
			if(instance==null) {
				instance = new RPSModel ();
			}
			return instance;
		}
	}

	private RPSModel () {
        
	}

    public void PlayAgainQuestion() {
        Change(GameState.PlayAgain,e);
    }

    public void GameStart() {
        Change(GameState.StartGame,e);    
    }

    public void PlayerChooseWeapon() {
        Change(GameState.PlayerCanChoose,e);
    }

    public void PlayerWon() {
        Change(GameState.PlayerWon,e);
    }

    public void PlayerLost() {
        Change(GameState.PlayerLost,e);
    }

    public void PlayerDraw() {
        Change(GameState.Draw,e);
    }

	public void DrawScore() {
		_drawScore = _drawScore + 1;
	}

	public void AddNewPlayer(string playerName, bool computerOpponent = false) {
		players.Add(new Player (playerName, computerOpponent));
	}

	public Player GetPlayer(string name) {
		foreach(Player player in players) {
			if(name.Equals(player.name)) {
				return player;
			}
		}
		return null;
	}

	public WinState WinTableResult(Player.Weapon playerOne, Player.Weapon playerTwo) {
		return winTable [(int)playerOne, (int)playerTwo];
	}
}


