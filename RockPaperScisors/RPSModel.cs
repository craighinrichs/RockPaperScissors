using System;
using System.Collections.Generic;

public class RPSModel {

	public readonly string LIVEPLAYER = "You";
	public readonly string COMPUTER_PLAYER = "Computer";

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


