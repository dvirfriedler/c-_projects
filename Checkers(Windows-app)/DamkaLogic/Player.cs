namespace Checkers_Logic
{
    using System;

    public class Player
    {
        public string m_Name { get; set; }

        public char m_Tools { get; set; }

        public Player m_Opponent { get; set; }

        public int m_Points { get; set; }

        public int m_Id { get; set; }

        public bool m_SecondTurn { get; set; }

        public Piece m_SecondTurnPice { get; set; }

        public Player(string name, char tools, int id)
        {
            this.m_Name = name;
            this.m_Tools = tools;
            this.m_Opponent = null;
            this.m_Points = 0;
            this.m_Id = id;
            this.m_SecondTurn = false;
            this.m_SecondTurnPice = new Piece();
        }
    }
}
