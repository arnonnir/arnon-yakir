using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace B15_Ex02
{
    class userInterface
    {
        public struct Pair 
        {
            public int m_row;
           // public int row { get; set; }
            public int m_col;
           // public int col { get; set; }

            public Pair(int i_Row, int i_Col)
            {
                m_row = i_Row;
                m_col = i_Col;
            }
        }

        public void run()
        {
            string firstPlayerName = getFirstPlayerName();
            string secondPlayerName = getSecondPlayerName(firstPlayerName);
            int sizeOfBoard = getSizeOfBoard();
            gameEngine engine = new gameEngine(firstPlayerName, secondPlayerName, sizeOfBoard);

            Screen.Clear();
            showBoard(engine.board);
            Pair nextMove;
            askForAMove(engine.player1, engine.board, out nextMove);
 
        }

        string getFirstPlayerName()
        {
            string firstPlayerName;

            // Ask the first player for his name 
            Console.WriteLine(
@"Welcome to 'othello' game!
--------------------------

Please enter your name: ");
            // Get the first player name
            firstPlayerName = Console.ReadLine();

            return firstPlayerName;
        }

        string getSecondPlayerName(string i_firstPlayer) 
        {
            string secondPlayerName;
            int numOfPlayers = 0;
            bool isNumber = false;
            bool firstRequestFromPlayer = true;

            // Ask for numbers of player
            Console.WriteLine(string.Format(
@"
Hello {0}!
Please insert number of players:
press '1' to play against the computer
press '2' to play against another player
Than, please press 'enter'", i_firstPlayer));
            do 
            {
                if (!firstRequestFromPlayer)
                {
                    Console.WriteLine(
@"
Invalid input!
Number of players must be '1' or '2'!
Please try again and press 'enter'");
                }
                // Get from the player how many players
                isNumber = int.TryParse(Console.ReadLine(), out numOfPlayers);
                firstRequestFromPlayer = false;
            }while(!isNumber || (numOfPlayers != 1 && numOfPlayers != 2));

            // Check how many players the user decide 
            if (numOfPlayers == 2)
            {
                Console.WriteLine(
@"
You chose to cumpete against another player!
Please enter the second player name: ");
                secondPlayerName = Console.ReadLine();
            }
            else
            {
                secondPlayerName = "computer";
            }

            return secondPlayerName;
        }

        int getSizeOfBoard()
        {
            int sizeOfBoard;
            string getInput;
            bool isNumber;
            bool firstRequestFromPlayer = true;

            Console.WriteLine(
@"
Please determine the size of the board:
Press '6' for board 6X6
Press '8' for board 8X8
(Any other options are not valid!)
Than, press 'enter'");
            do
            {
                if (!firstRequestFromPlayer)
                {
                    Console.WriteLine(
@"
Invalid input!
The size of the board must be '6' or '8'!
Please try again and press 'enter'");
                }

                getInput = Console.ReadLine();
                isNumber = int.TryParse(getInput, out sizeOfBoard);
                firstRequestFromPlayer = false;
            } while (!isNumber || (sizeOfBoard != 6 && sizeOfBoard != 8));

            return sizeOfBoard;
        }


        bool askForAMove(Player i_player, gameBoard i_board, out Pair i_nextMove) 
        {
            string nextMoveAsString;
            //Pair nextMove;
            char col = 'A';
            int row = 0;
            bool rowIsInt = false;
            bool isFirstIteration = true;
            bool toPlay = true;
            bool invalidLengthInput = false;


            Console.WriteLine(string.Format(
@"{0}, it's your turn!
Please choose 'letter'(column) and 'number'(row) for your next move.
The 'letter' must be an appercase and no space between row and col.
For example: 'E2'
<for 'EXIT' please insert 'Q'>", i_player.PlayerName));

            do
            {
                if (!isFirstIteration)
                {
                    Console.WriteLine("Sorry but You inserted invalid input! please try again:");
                }
 
                nextMoveAsString = Console.ReadLine();
                if (nextMoveAsString == "Q")
                {
                    toPlay = false;
                    break;
                }
                if (nextMoveAsString.Length != 2)
                {
                    invalidLengthInput = true;
                    isFirstIteration = false;
                    continue;

                }
                col = nextMoveAsString[0];
                rowIsInt = int.TryParse(nextMoveAsString[1].ToString(), out row);
                isFirstIteration = false;

            } while (invalidLengthInput || !rowIsInt || col < 'A' || col > ('A' + i_board.Size - 1) || row < 1 || row > i_board.Size);

                i_nextMove = new Pair(row - 1, col - 'A');   
            return toPlay;
        }

        void showBoard(gameBoard i_board) 
        {
            StringBuilder finalBoard = new StringBuilder();
            StringBuilder borderOfRow = new StringBuilder();
            StringBuilder rowOfLetters = new StringBuilder();

            char letter = 'A';
            rowOfLetters.Append("    ");
            for (int i = 0; i < i_board.Size; i++)
            {
                if (i == i_board.Size - 1)
                {
                    rowOfLetters.Append(string.Format("{0}  ", letter));
                }
                else
                {
                    rowOfLetters.Append(string.Format("{0}   ", letter));
                }
                letter++;
            }

            finalBoard.Append(rowOfLetters);
            finalBoard.Append(Environment.NewLine);
            
            int numOfEquals = ((i_board.Size * 4) + 1);
            borderOfRow.Append("  ");
            for (int i = 0; i < numOfEquals; i++)
            {
                borderOfRow.Append('=');
            }

            borderOfRow.Append(Environment.NewLine);

            StringBuilder rowWithBoardValues;
            for (int row = 0; row < i_board.Size; row++)
            {
                rowWithBoardValues = new StringBuilder();
                rowWithBoardValues.Append(borderOfRow);
                rowWithBoardValues.Append(string.Format("{0} ", (row + 1)));

                int col = 0;
                int locationOfCoin = 2;
                for (int i = 0; i < numOfEquals; i++)
                {
                    if (i % 4 == 0)
                    {
                        rowWithBoardValues.Append("|");
                    }
                    else if (i == locationOfCoin)
                    {
                        
                        if (i_board[row, col] != 0)
                        {
                            rowWithBoardValues.Append(i_board[row, col]);
                        }
                        else
                        {
                            rowWithBoardValues.Append(" ");
                        }
                        col++;
                        locationOfCoin += 4;  
                    }
                    else
                    {
                        rowWithBoardValues.Append(" ");
                    }
                }
                finalBoard.Append(rowWithBoardValues);
                finalBoard.Append(Environment.NewLine);
            }

            finalBoard.Append(borderOfRow);
            Console.WriteLine(finalBoard);
        }
    }
}

