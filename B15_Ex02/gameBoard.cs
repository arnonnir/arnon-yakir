using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
    public enum eSymbolOfPlayer
    {
        O = 1,
        X
    }

    class gameBoard
    {
        private eSymbolOfPlayer[,] m_Board;
        private int m_Size;
        public int Size
        {
            get
            { 
                return m_Size;
            }
        }

        public gameBoard(int i_BoardSize)
        {
            m_Size = i_BoardSize;
            // Initialize starting board
            m_Board = new eSymbolOfPlayer[i_BoardSize, i_BoardSize];
            int middleOfBoard = (i_BoardSize / 2) - 1;
     
            for (int i = middleOfBoard; i < middleOfBoard + 2; i++)
            {
                for (int j = middleOfBoard; j < middleOfBoard + 2; j++)
                {                   
                    m_Board[i, j] = (i == j) ? eSymbolOfPlayer.O : eSymbolOfPlayer.X;
                } 
            }
        }

        public eSymbolOfPlayer this[int i_Row, int i_Col]
        {
            get
            {
                return m_Board[i_Row, i_Col];
            }

        }

        /*
        public eSymbolOfPlayer GetCell(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }
        */
    /*
        public int SetCell(int i_Row, int i_Col, eSymbolOfPlayer i_Symbol)
        {
            // Insert new coin to the board
            m_Board[i_Row, i_Col] = i_Symbol;
            int countNewCoins = 1;

            // Check if there is a coin of other player around new coin
            for (int i = i_Row - 1; i < i_Row + 1; i++)
            {
                for (int j = i_Col - 1; j < i_Col + 1; j++)
                {
                   // if ((i != i_Row && j != i_Col) && GetCell(i, j) != i_Symbol)
                   // {

                   // }
                }
            }

            return countNewCoins;
        }
     */
    }
}