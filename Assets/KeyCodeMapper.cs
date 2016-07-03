using UnityEngine;

public class KeyCodeMapper{
	static string[] keyMap = {
		"A",
		"B",
		"C",
		"D",
		"E",
		"F",
		"G",
		"H",
		"I",
		"J",
		"K",
		"L",
		"M",
		"N",
		"O",
		"P",
		"Q",
		"R",
		"S",
		"T",
		"U",
		"V",
		"W",
		"X",
		"Y",
		"Z",
		};

	public static string KeyCodeToString(KeyCode keyCode){
		string returnStr = "";
		switch (keyCode) {
			case KeyCode.A:
				returnStr = "A";
				break;
			case KeyCode.B:
				returnStr = "B";
				break;
			case KeyCode.C:
				returnStr = "C";
				break;
			case KeyCode.D:
				returnStr = "D";
				break;
			case KeyCode.E:
				returnStr = "E";
				break;
			case KeyCode.F:
				returnStr = "F";
				break;
			case KeyCode.G:
				returnStr = "G";
				break;
			case KeyCode.H:
				returnStr = "H";
				break;
			case KeyCode.I:
				returnStr = "I";
				break;
			case KeyCode.J:
				returnStr = "J";
				break;
			case KeyCode.K:
				returnStr = "K";
				break;
			case KeyCode.L:
				returnStr = "L";
				break;
			case KeyCode.M:
				returnStr = "M";
				break;
			case KeyCode.N:
				returnStr = "N";
				break;
			case KeyCode.O:
				returnStr = "O";
				break;
			case KeyCode.P:
				returnStr = "P";
				break;
			case KeyCode.Q:
				returnStr = "Q";
				break;
			case KeyCode.R:
				returnStr = "R";
				break;
			case KeyCode.S:
				returnStr = "S";
				break;
			case KeyCode.T:
				returnStr = "T";
				break;
			case KeyCode.U:
				returnStr = "U";
				break;
			case KeyCode.V:
				returnStr = "V";
				break;
			case KeyCode.W:
				returnStr = "W";
				break;
			case KeyCode.X:
				returnStr = "X";
				break;
			case KeyCode.Y:
				returnStr = "Y";
				break;
			case KeyCode.Z:
				returnStr = "Z";
				break;
			default:
				returnStr = " ";
				break;
		}
		return returnStr;
	}
}
