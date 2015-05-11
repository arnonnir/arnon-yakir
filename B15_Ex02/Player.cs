using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
    class Player
    {
        private int m_NumOfCoins;
        private string m_PlayerName;
        private eSymbolOfPlayer m_Coin;

        public int NumOfCoins
        {
            get
            {
                return m_NumOfCoins;
            }
            set
            {
                m_NumOfCoins = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }
        }

        public Player(eSymbolOfPlayer i_Coin, string i_Name)
        {
            m_PlayerName = i_Name;
            m_Coin = i_Coin;
            m_NumOfCoins = 2;
        }

        /*
        public List<userInterface.Pair> GetValidMoves(gameBoard i_Board, eSymbolOfPlayer i_Symbol)
        {
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
            list.Add(new KeyValuePair<int, int>(1, 2));
            return list;
        }

        public bool IsValidMoves(int i_Row, int i_Col, List<KeyValuePair<int, int>> i_ListOfValidMoves)
        {
            // Create the new cell
            KeyValuePair<int, int> cell = new KeyValuePair<int, int>(i_Row, i_Col);

            // Retrun true if new cell is member of the valid moves list
            return i_ListOfValidMoves.Contains(cell);
        }
         */
    }
}
