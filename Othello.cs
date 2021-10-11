#nullable enable
using System;
using static System.Console;

namespace Othello
{
    static partial class Program
    {
		
		static bool gameContinue (string[,] board)
		{
			for (int i = 0; i<8; i++)
			{
				for (int j = 0; j<8; j++)
				{
					if (validMove(1, i, j, board))
					{
						return true;
					} else if (validMove(2, i, j, board))
					{
						return true;
					}
				}
			}
			
			return false;
		}
		
		static int getScore (string[,] board)
		{
			int x = 0;
			int o = 0;
			
			for (int i = 0; i<8; i++)
			{
				for (int j = 0; j<8; j++)
				{
					if (board[i,j]=="X")
					{
						x++;
					} else if (board[i,j] == "O")
					{
						o++;
					}
					
				}
			}
			
			return o-x;
		}
		
		static string[,] placeToken(string[,] board, int y,int x,int player)
		{
			string token ="";
			string opp = "";
			string[] tempArray = new string[8];
			if (player == 1)
			{
				token = "O";
				opp = "X";
			} else if (player == 2)
			{
				token = "X";
				opp = "O";
			}
			string[,] placed = board;
			placed[x,y] = token;
			
			
			//left 
			if (x-1 >= 0 && placed[x-1,y] == opp)
			{
				for (int check = x-1; check>=0; check--)
				{
					if (placed[check,y] == token)
					{
						for (int a = x; a>=check; a--)
						{
							placed[a,y]=token;
						}
					}
				}				
			}
			
			//right
			if (x+1 <8 && placed[x+1,y] == opp)
			{
				for (int check = x+1; check<8; check++)
				{
					if (placed[check,y] == token)
					{
						for (int a = x; a<=check; a++)
						{
							placed[a,y]=token;
						}
					}
				}				
			}
			
			//up
			if (y-1 >= 0 && placed[x,y-1] == opp)
			{
				for (int check = y-1; check>=0; check--)
				{
					if (placed[x,check] == token)
					{
						for (int a = y; a>=check; a--)
						{
							placed[x,a]=token;
						}
					}
				}				
			}
			
			//down
			if (y+1 <8 && placed[x,y+1] == opp)
			{
				for (int check = y+1; check<8; check++)
				{
					if (placed[x,check] == token)
					{
						for (int a = y; a<=check; a++)
						{
							placed[x,a]=token;
						}
						break;
					}
				}				
			}
			
			//diagonal up left
			if (x-1 >=0 && y-1>=0 && board[x-1,y-1] == opp)
			{
				for (int check = 1; x-check>=0 && y-check>=0; check++)
				{
					WriteLine("ERROR: " + LetterAtIndex(x-check) + "," +LetterAtIndex(y-check));
					if (placed[x-check,y-check] == token)
					{
						for (int a = 0; a<=check; a++)
						{
							placed[x-a,y-a]=token;
						}
						break;
					}
					
				}
			}
			
			//diagonal down left
			if (x-1 >=0 && y+1 <8 && board[x-1,y+1] == opp)
			{
				for (int check = 1; x-check>=0 && y+check<8; check++)
				{
					if (placed[x-check,y+check] == token)
					{
						for (int a = 0; a<=check; a++)
						{
							placed[x-a,y+a]=token;
						}
						break;
					}
					
				}
			}
			
			//diagonal up right
			if (x+1 <8 && y-1 >=0 && board[x+1,y-1] == opp)
			{
				for (int check = 1; x+check<8 && y-check<8; check++)
				{
					if (placed[x+check,y-check] == token)
					{
						for (int a = 0; a<=check; a++)
						{
							placed[x+a,y-a]=token;
						}
						break;
					}
					
				}
			}
			
			//diagonal down right
			if (x+1 <8 && y+1 <8 && board[x+1,y+1] == opp)
			{
				for (int check = 1; x+check<8 && y+check<8; check++)
				{
					if (placed[x+check,y+check] == token)
					{
						for (int a = 0; a<=check; a++)
						{
							placed[x+a,y+a]=token;
						}
						break;
					}
					
				}
			}
			
			return placed;
		}
		
		static bool validMove(int player, int y, int x, string[,] board)
		{
			string[] tempArray = new string[8];
			string token = "";
			string opp = "";
			if (board[x,y]!= " ")
			{
				return false;
			}
			if (player == 1)
			{
				token = "O";
				opp = "X";
			} else if (player == 2)
			{
				token = "X";
				opp = "O";
			}
			
			//horizontal
			for (int i = 0; i<8; i++)
			{
				tempArray[i] = board[i,y];
				tempArray[x] = token;
			}
			//horizontal left
			if (x-1 >= 0 && tempArray[x-1] == opp)
			{
				for (int check = x-1; check>=0; check--)
				{
					if (tempArray[check] == " ")
					{
						break;
					}
					else if (tempArray[check] == token)
					{
						return true;
					}
				}				}
			//horizontal right
			if (x+1 < 8 && tempArray[x+1] == opp)
			{
				for (int check = x+1; check<8; check++)
				{
					if (tempArray[check] == " ")
					{
						break;
					}
					else if (tempArray[check] == token)
					{
						return true;
					}
				}
			}
				
			
			//Vertical
			for (int j = 0; j<8; j++)
			{
				tempArray[j] = board[x,j];
				tempArray[y] = token;
			}
			//vertical up
			if (y-1 >= 0 && tempArray[y-1] == opp)
			{
				for (int check = y-1; check>=0; check--)
				{
					if (tempArray[check] == " ")
					{
						break;
					}
					else if (tempArray[check] == token)
					{
						return true;
					}
				}				}
			//Vertical down
			if (y+1 < 8 && tempArray[y+1] == opp)
			{
				for (int check = y+1; check<8; check++)
				{
					if (tempArray[check] == " ")
					{
						break;
					}
					else if (tempArray[check] == token)
					{
						return true;
					}
				}
			}
			
			//diagonal up left
			
			if (x-1 >=0 && y-1 >=0 && board[x-1,y-1] == opp)
			{
				for (int check = 1; x-check>=0 && y-check>=0; check++)
				{
					if (board[x-check,y-check] == " ")
					{
						break;
					}
					else if (board[x-check,y-check] == token)
					{
						return true;
					}
				}
			}
			
			//diagonal down left
			if (x-1 >=0 && y+1 <8 && board[x-1,y+1] == opp)
			{
				//WriteLine("TEST");
				for (int check = 1; x-check>=0 && y+check<8; check++)
				{
					if (board[x-check,y+check] == " ")
					{
						break;
					}
					else if (board[x-check,y+check] == token)
					{
						return true;
					}
				}
			}
			
			//diagonal up right
			if (x+1 <8 && y-1 >=0 && board[x+1,y-1] == opp)
			{
				for (int check = 1; x+check<8 && y-check>=0; check++)
				{
					if (board[x+check,y-check] == " ")
					{
						break;
					}
					else if (board[x+check,y-check] == token)
					{
						return true;
					}
				}
			}
			
			//diagonal down right
			if (x+1 <8 && y+1 <8 && board[x+1,y+1] == opp)
			{
				for (int check = 1; x+check<8 && y+check<8; check++)
				{
					if (board[x+check,y+check] == " ")
					{
						break;
					}
					else if (board[x+check,y+check] == token)
					{
						return true;
					}
				}
			}
			return false;	
		}
		
		
        static void Main( )
        {
			int player = 1;
            string[ , ] game = NewBoard( rows: 8, cols: 8 );
            string posY = "";
            string posX = "";
            string[] names = new string[2];
            Console.Clear( );
            WriteLine( );
            WriteLine( " Welcome to Othello!" );
            WriteLine( );
            DisplayBoard( game );
            WriteLine( );
            
            for (int i = 0; i<2; i++)
            {
				Write("Enter Player "+ i +" Name: ");
				names[i] = ReadLine();
			}
			
			WriteLine(names[0] + " You are \"O\"");
			WriteLine(names[1] + " You are \"X\"");
            
            while (posX != "quit" && gameContinue (game))
            {
				
				WriteLine("Player " + names[player-1] +" choose a position: ");
				WriteLine("Enter column: (or skip/quit)" );
				posX = ReadLine();
				if (posX != "quit" && posX != "skip")
				{
					WriteLine("Enter row: " );
					posY = ReadLine();
					while (!validMove(player, IndexAtLetter(posX), IndexAtLetter(posY), game))
					{
						WriteLine("INVALID INPUT PLEASE SELECT DIFFERENT COORDINATES");
						WriteLine("Player " + names[player-1] + " choose a position: ");
						WriteLine("Enter column: " );
						posX = ReadLine();
						
						WriteLine("Enter row: " );
						posY = ReadLine();
						
						//WriteLine(IndexAtLetter(posX)+" " + " "+ IndexAtLetter(posY));
						//WriteLine(game[IndexAtLetter(posX), IndexAtLetter(posY)]);
					
					}
					game = placeToken(game, IndexAtLetter(posX), IndexAtLetter(posY), player);
				}
				
				//WriteLine(validMove(player, IndexAtLetter(posX), IndexAtLetter(posY), game));
				
				
				DisplayBoard( game );
				
				if (getScore(game) > 0)
				{
					WriteLine(names[0]+ " (O)is in the lead with " + getScore(game) + " points");
				} else if (getScore(game) < 0)
				{
					WriteLine(names[1]+" (X) is in the lead with " + getScore(game)*(-1) + " points");
				} else 
				{
					WriteLine("It is Currently a tie");
				}
				
				if (player == 1)
				{
					player = 2;
				}
				else if (player == 2)
				{
					player = 1;
				}
			}
			
			WriteLine("Game ended");
			if (getScore(game) > 0)
			{
				WriteLine(names[0]+" (O) won with " + getScore(game) + " points");
			} else if (getScore(game) < 0)
			{
				WriteLine(names[1]+" (X) won with " + getScore(game)*(-1) + " points");
			} else 
			{
				WriteLine("It is a tie");
			}
			
        }
    }
}
















 
