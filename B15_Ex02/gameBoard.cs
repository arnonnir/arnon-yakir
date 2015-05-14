using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
    public struct Pair
    {
        public int m_row;
        public int m_col;

        public Pair(int i_Row, int i_Col)
        {
            m_row = i_Row;
            m_col = i_Col;
        }

        public string toString()
        {
            string temp = string.Format("({0},{1})", m_row, m_col);
            return temp;

        }
    }

    public enum eSymbolOfPlayer
    {
        O = 1,
        X = 2
    }

    class gameBoard
    {
        private eSymbolOfPlayer[,] m_Board;
        private int m_Size;
        private List<Pair> m_coinsOfPlayer1;
        private List<Pair> m_coinsOfPlayer2;

        public int Size
        {
            get
            {
                return m_Size;
            }
        }
        public List<Pair> coinsOfPlayer1
        {
            get
            {
                return m_coinsOfPlayer1;
            }
        }

        public List<Pair> coinsOfPlayer2
        {
            get
            {
                return m_coinsOfPlayer2;
            }
        }

        public gameBoard(int i_BoardSize)
        {
            m_Size = i_BoardSize;
            // Initialize starting board
            m_Board = new eSymbolOfPlayer[i_BoardSize, i_BoardSize];
            m_coinsOfPlayer1 = new List<Pair>();
            m_coinsOfPlayer2 = new List<Pair>();
            int middleOfBoard = (i_BoardSize / 2) - 1;

            for (int i = middleOfBoard; i < middleOfBoard + 2; i++)
            {
                for (int j = middleOfBoard; j < middleOfBoard + 2; j++)
                {
                    if (i == j)
                    {
                        m_Board[i, j] = eSymbolOfPlayer.O;
                        m_coinsOfPlayer1.Add(new Pair(i, j));
                    }
                    else
                    {
                        m_Board[i, j] = eSymbolOfPlayer.X;
                        m_coinsOfPlayer2.Add(new Pair(i, j));
                    }
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

        public void SetCell(Pair nextMove, eSymbolOfPlayer i_Coin)
        {
            List<Pair> temp;
            m_Board[nextMove.m_row, nextMove.m_col] = i_Coin;
            if (i_Coin == eSymbolOfPlayer.O)
            {
                m_coinsOfPlayer1.Add(nextMove);
            }
            else
            {
                m_coinsOfPlayer2.Add(nextMove);
            }

            int row;
            int col;
            int rowLowerBound = (nextMove.m_row == 0) ? 0 : nextMove.m_row - 1;
            int rowUpperBound = (nextMove.m_row == Size - 1) ? Size - 1 : nextMove.m_row + 1;
            int colLowerBound = (nextMove.m_col == 0) ? 0 : nextMove.m_col - 1;
            int colUpperBound = (nextMove.m_col == Size - 1) ? Size - 1 : nextMove.m_col + 1;

            for (int i = rowLowerBound; i <= rowUpperBound; i++)
            {
                for (int j = colLowerBound; j <= colUpperBound; j++)
                {
                    if ((m_Board[i, j] != i_Coin) && (m_Board[i, j] != 0) && (i != nextMove.m_row || j != nextMove.m_col))
                    {
                        temp = new List<Pair>();
                        temp.Add(new Pair(i, j));
                        int a = i - nextMove.m_row;
                        int b = j - nextMove.m_col;
                        row = i + a;
                        col = j + b;
                        while (row > -1 && col > -1 && row < Size && col < Size)
                        {
                            if (m_Board[row, col] == i_Coin)
                            {
                                foreach (Pair pair in temp)
                                {
                                    if (i_Coin == eSymbolOfPlayer.O)
                                    {
                                        m_coinsOfPlayer1.Add(pair);
                                    }
                                    else
                                    {
                                        m_coinsOfPlayer2.Add(pair);
                                    }

                                    m_Board[pair.m_row, pair.m_col] = i_Coin;
                                }
                                temp = new List<Pair>();
                                break;
                            }
                            else if (m_Board[row, col] == 0)
                            {
                                temp = new List<Pair>();
                                break;
                            }
                            else if (m_Board[row, col] != i_Coin)
                            {
                                temp.Add(new Pair(row, col));
                            }
                            row += a;
                            col += b;
                        }
                    }
                }
            }
        }

        public List<Pair> GetValidMoves(eSymbolOfPlayer i_Coin)
        {
            List<Pair> listOfValidMoves = new List<Pair>();
            int row;
            int col;
            int rowLowerBound;
            int rowUpperBound;
            int colLowerBound;
            int colUpperBound;

            List<Pair> listOfCurrentPlayerCoins = (i_Coin == eSymbolOfPlayer.O) ? coinsOfPlayer1 : coinsOfPlayer2;

            foreach (Pair pair in listOfCurrentPlayerCoins)
            {
                rowLowerBound = (pair.m_row == 0) ? 0 : pair.m_row - 1;
                rowUpperBound = (pair.m_row == this.Size - 1) ? this.Size - 1 : pair.m_row + 1;
                colLowerBound = (pair.m_col == 0) ? 0 : pair.m_col - 1;
                colUpperBound = (pair.m_col == this.Size - 1) ? this.Size - 1 : pair.m_col + 1;

                for (int i = rowLowerBound; i <= rowUpperBound; i++)
                {
                    for (int j = colLowerBound; j <= colUpperBound; j++)
                    {

                        if ((m_Board[i, j] != i_Coin) && (m_Board[i, j] != 0) && (i != pair.m_row || j != pair.m_col))
                        {
                            int a = i - pair.m_row;
                            int b = j - pair.m_col;
                            row = i + a;
                            col = j + b;
                            while (row > -1 && col > -1 && row < Size && col < Size)
                            {
                                if (m_Board[row, col] == i_Coin)
                                {
                                    break;
                                }
                                if (m_Board[row, col] == 0)
                                {
                                    listOfValidMoves.Add(new Pair(row, col));
                                    break;
                                }
                                row += a;
                                col += b;
                            }
                        }
                    }
                }
            }

            return listOfValidMoves;
        }

    }
}
