namespace DvirFriedler_DamkaGame
{
    using System;
    using System.Collections.Generic;

    public class Piece
    {
        internal string m_CurrentLocation { get; set; }
        internal List<string> m_AvilableMoves { get; set; }
        internal List<string> m_AvilableJumps { get; set; }
        internal bool m_IsKing { get; set; }
        internal char m_Team { get; set; }
        internal char m_TeamKing { get; set; }

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