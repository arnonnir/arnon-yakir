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
                return player2;
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

    }
}
