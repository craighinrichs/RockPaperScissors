using System;


public class Player {

	public enum Weapon {
		ROCK = 0,
		PAPER = 1,
		SCISSORS = 2
	}

	private Random rand = new Random ();

	public bool _isComputerOpponent;
	public bool IsComputerOpponent {
		get  {
			return _isComputerOpponent;
		}
	}

	private int _score;
	public int score {
		get {
			return _score;
		}	
	}

	private Weapon _chosenWeapon;
	public Weapon chosenWeapon {
		get {
			return _chosenWeapon;
		}
	}

	private string _name;
	public string name {
		get {
			return _name;
		}
	}

	public Player (string name, bool computerOpponent = false) {
		this._name = name;
		_isComputerOpponent = computerOpponent;
	}

	public void ChooseWeapon() {
		if(IsComputerOpponent) {
			_chosenWeapon = (Player.Weapon)rand.Next(0,3);
		} else {
			_chosenWeapon = (Player.Weapon)(Convert.ToInt32(Console.ReadLine()) - 1);	
		}
	}

	public void Scored() {
		_score = _score + 1;
	}

	public static bool operator ==(Player p1, Player p2) {
		bool isDraw = p1.chosenWeapon == p2.chosenWeapon;
		return isDraw;
	}

	public static bool operator !=(Player p1, Player p2) {
		bool isDraw = p1.chosenWeapon != p2.chosenWeapon;
		return isDraw;
	}

	public override bool Equals (object obj) {
		return base.Equals(obj);
	}

	public override int GetHashCode () {
		return base.GetHashCode();
	}

	public static Player operator *(Player p1, Player p2) {
		if(RPSModel.Instance.WinTableResult(p1.chosenWeapon,p2.chosenWeapon) == RPSModel.WinState.WIN) {
			return p1;
		} else {
			return p2;
		}
	}
}


