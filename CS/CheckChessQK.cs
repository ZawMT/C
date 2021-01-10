using System;

/* 
	Ref: What I tried for a test from https://coderbyte.com 
	Function: To check the status between one king and one queen (only two pieces on the board) : if the king is capturalbe, if no, then "-1", if yes, then how many possible moves to dodge for the king
*/
class MainClass {

  public static string QueenCheck(string[] strArr) {
    int iX1, iY1, iX2, iY2;
    int iPossibleMoves = 0;
    getCorOr(strArr, out iX1, out iY1, out iX2, out iY2);
    
    if(isCapturable(iX1, iY1, iX2, iY2)) {
      if(!isCapturable(iX1, iY1, iX2 + 1, iY2)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2 - 1, iY2)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2, iY2 + 1)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2, iY2 - 1)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2 + 1, iY2 + 1)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2 + 1, iY2 - 1)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2 - 1, iY2 + 1)) 
        iPossibleMoves++;
      if(!isCapturable(iX1, iY1, iX2 - 1, iY2 - 1)) 
        iPossibleMoves++;
      
      return iPossibleMoves.ToString();
    }

    return "-1";
  }

  public static bool isCapturable(int iX1, int iY1, int iX2, int iY2) {
    //The piece is out of the board, so it will be taken as 'Capturable' (*not to count as a possible move)
    if(iX2 < 1 || iX2 > 8 || iY2 < 1 || iY2 > 8)
      return true;

    //This means that King can capture the Queen, so this will be counted as 'Not Capturalbe' (*to count it as a possible move)
    if(iX1 == iX2 && iY1 == iY2)
      return false;

    if(checkDiagonal(iX1, iY1, iX2, iY2) || checkHorizontal(iY1, iY2) || checkVertical(iX1, iX2)) {
      return true;
    }

    return false;
  }

  public static void getCorOr(string[] strArr, out int iX1, out int iY1, out int iX2, out int iY2){
    iX1 = -1;
    iY1 = -1;
    iX2 = -1;
    iY2 = -1;

    foreach(string str in strArr) {
      string[] strs = str.Substring(1, str.Length - 2).Split(",");
      if(iX1 == -1){
        iX1 = Int32.Parse(strs[0]);
        iY1 = Int32.Parse(strs[1]);
      } else {
        iX2 = Int32.Parse(strs[0]);
        iY2 = Int32.Parse(strs[1]);
      }
    }
  }

  public static bool checkHorizontal(int iY1, int iY2) {
    if(iY1 == iY2)
      return true;

    return false;
  }

  public static bool checkVertical(int iX1, int iX2) {
    if(iX1 == iX2)
      return true;

    return false;
  }

  public static bool checkDiagonal(int iX1, int iY1, int iX2, int iY2) {
    if(iX1 + iY1 == iX2 + iY2)
      return true;
    if(iX1 - iY1 == iX2 - iY2)
      return true;

    return false;
  }

  static void Main() {  
    Console.WriteLine(QueenCheck(Console.ReadLine()));
  } 
}