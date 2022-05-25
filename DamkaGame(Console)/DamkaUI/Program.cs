namespace DvirFriedler_DamkaGame
{
    using System;

    class Program
    {
        static void Main()
        {
            string o_secondUserName = string.Empty;
            string o_firstUserName = DamkaInterface.SelectUserName(); 
            Player o_playerOne = new Player(o_firstUserName, 'O', 1);
            Player o_playerTwo = null;

            int boardSize = DamkaInterface.SelectBoardSize();

            int o_GameMode = DamkaInterface.SelectGameMode();

            switch (o_GameMode)
            {
                case 1:
                    o_playerTwo = new Player("PC", 'X', 2);
                    break;

                case 2:
                    o_secondUserName = DamkaInterface.SelectUserName();
                    o_playerTwo = new Player(o_secondUserName, 'X', 2);
                    break;
            }

            DamkaInterface.ShowGameDetails(o_playerOne,o_playerTwo,boardSize);
            
            Game.StartGame(o_playerOne, o_playerTwo, boardSize);
            
            return;
        }
    }
}