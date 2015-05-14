using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
    class gameEngine
    {
        private Player m_player1;
        public Player player1
        {
            get
            {
                return m_player1;
            }
        }

        private Player m_player2;
        public Player player2 
        {
            get
            {
                return m_player2;
            }
        }

        private gameBoard m_board;
        public gameBoard board
        {   
            get 
            {
                return m_board;  
            }
        }

        public gameEngine(string i_player1, string i_player2, int i_boardSize)
        {
            m_player1 = new Player(eSymbolOfPlayer.O, i_player1);
            m_player2 = new Player(eSymbolOfPlayer.X, i_player2);
            m_board = new gameBoard(i_boardSize);
        }

        public bool getPlayerTurn(ref Player playerTurn, Player playerNextTurn) {
            bool thereIsValidMove = false;
            List<Pair> playerTurnValidMoves = board.GetValidMoves(playerTurn.Coin);
            List<Pair> playerNextTurnValidMoves = board.GetValidMoves(playerNextTurn.Coin);

            if (playerTurnValidMoves.Count != 0)
            {
                thereIsValidMove = true;
            }
            else if (playerNextTurnValidMoves.Count != 0)
            {
                thereIsValidMove = true;
                playerTurn = playerNextTurn;
            }

            return thereIsValidMove;
        
        }

        public string winnerOfGame()
        {
            string winner = (m_board.coinsOfPlayer1.Count > m_board.coinsOfPlayer2.Count) ? m_player1.PlayerName : m_player2.PlayerName;

            return winner;
        }

        public bool isValidMove(Player playerTurn, Pair i_nextMove)
        {
            // Retrun true if new pair is member of the valid moves list
            return m_board.GetValidMoves(playerTurn.Coin).Contains(i_nextMove);
        }

        public void makeAMove(Pair i_nextMove, Player i_playerTurn)
        {
            m_board.SetCell(i_nextMove, i_playerTurn.Coin);
        }
    }
}
