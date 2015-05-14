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
        //   private List<Pair> m_listOfCoins;

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

        public eSymbolOfPlayer Coin
        {
            get
            {
                return m_Coin;
            }
        }
        /* public List<Pair> listOfCoins
         {
             get
             {
                 return m_listOfCoins;
             }
         }*/

        public Player(eSymbolOfPlayer i_Coin, string i_Name)
        {
            m_PlayerName = i_Name;
            m_Coin = i_Coin;
            m_NumOfCoins = 2;
        }
    }

}