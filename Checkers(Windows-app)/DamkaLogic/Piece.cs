namespace Checkers_Logic
{
    using System;
    using System.Collections.Generic;

    public class Piece
    {
        public string m_CurrentLocation { get; set; }

        public List<string> m_AvilableMoves { get; set; }

        public List<string> m_AvilableJumps { get; set; }

        public bool m_IsKing { get; set; }

        public char m_Team { get; set; }

        public char m_TeamKing { get; set; }

        public Piece(char team = 'o', string currentLocation = "")
        {
            this.m_Team = team;
            this.m_CurrentLocation = currentLocation;
            this.m_AvilableJumps = new List<string>();
            this.m_AvilableMoves = new List<string>();
            this.m_IsKing = false;
            if (team == 'O')
            {
                this.m_TeamKing = 'Q';
            }
            else
            {
                this.m_TeamKing = 'Z';
            }
        }
    }
}