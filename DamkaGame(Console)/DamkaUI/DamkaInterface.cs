using System;
namespace DvirFriedler_DamkaGame
{
    public class DamkaInterface
    {
        internal static void ShowInstractions()
        {
            System.Console.WriteLine("Instructions:");
            System.Console.WriteLine("In each itration each player will need to deside between 2 options:");
            System.Console.WriteLine("1. Play a game move.");
            System.Console.WriteLine("2. Finish the game.");
            System.Console.WriteLine("If you want to finsh the game please write Q and then press Enter");
            System.Console.WriteLine("For example if you want to move your piece from Af to Ae, write Af>Ae and then press enter");
            System.Console.WriteLine("When you ready to play press enter");
            Console.ReadLine();
        }

        internal static string SelectUserName()
        {
            System.Console.WriteLine("Hello welcome to the Checkers.");
            System.Console.WriteLine("Please enter your name and press enter.");
            System.Console.WriteLine("Your name cannot include spaces, and cannot be more then 10 characters");
            string io_firstUserName = System.Console.ReadLine();
            Console.Clear();

            while (!InputValidate.UserNameIsValid(io_firstUserName))
            {
                System.Console.WriteLine("Please enter a valid name and press enter.");
                io_firstUserName = System.Console.ReadLine();
            }
            return io_firstUserName;
        }

        internal static int SelectBoardSize()
        {
            System.Console.WriteLine("Please choose the the size of your bord: 6, 8, 10 and press enter.");
            string o_stringBordSize = System.Console.ReadLine();
            Console.Clear();

            while (!InputValidate.BoardSizeIsValid(o_stringBordSize))
            {
                System.Console.WriteLine("Please enter valid bord size (6, 8 10) and press enter.");
                o_stringBordSize = System.Console.ReadLine();
                Console.Clear();
            }
             return int.Parse(o_stringBordSize);
        }

        internal static int SelectGameMode()
        {
            System.Console.WriteLine("Selcet Game Mode:");
            System.Console.WriteLine("Press 1 for playing against PC.");
            System.Console.WriteLine("Press 2 for playing against a friend");
            string o_stringGameMode = System.Console.ReadLine();
            Console.Clear();

            while (!InputValidate.GameModeIsValid(o_stringGameMode))
            {
                System.Console.WriteLine("Please enter valid input.");
                System.Console.WriteLine("(For computer press 1.)");
                System.Console.WriteLine("(For friend press 2.)");

                o_stringGameMode = System.Console.ReadLine();
                Console.Clear();
            }

            return int.Parse(o_stringGameMode);
        }

        internal static void ShowGameDetails(Player i_playerOne , Player i_playerTow, int i_boradSize)
        {
            System.Console.WriteLine(string.Format("Hello {0} you play against {1} .", i_playerOne.m_Name ,i_playerTow.m_Name));
            System.Console.WriteLine(string.Format("Your board size is: {0}.", i_boradSize));
        }

        internal static void ShowLastMove(Player playerTurn ,Board o_gameBorad, int turnCounter)
        {
            if (turnCounter == 0)
            {
                Console.WriteLine(string.Format("{0}'s Turn ({1}):", playerTurn.m_Name, playerTurn.m_Tools));
            }
            else
            {
                Console.WriteLine(string.Format("{0}'s move was ({1}): {2}", playerTurn.m_Opponent.m_Name, playerTurn.m_Opponent.m_Tools, o_gameBorad.m_LastMove));
                Console.WriteLine(string.Format("{0}'s Turn ({1}):", playerTurn.m_Name, playerTurn.m_Tools));
            }
        }

        internal static string GetCurrentMove(Player playerTurn,Board o_gameBorad)
        {
            string curentMove;
            if (!playerTurn.m_Name.Equals("PC"))
            {

                curentMove = Console.ReadLine();
                while ((!InputValidate.IsALegalMove(o_gameBorad.m_Size, curentMove)) && curentMove != "Q")
                {
                    Console.WriteLine("Ilegal Move. Try again");
                    curentMove = Console.ReadLine();
                }
            }
            else
            {
                curentMove = o_gameBorad.PCTurn();

            }

            return curentMove;
        }

        internal static int ShowPoints(Player playerTurn, Board o_gameBorad)
        {
            Console.WriteLine(string.Format("{0} won the game!!!", playerTurn.m_Opponent.m_Name));
            o_gameBorad.UpdatePoints(playerTurn, playerTurn.m_Opponent, playerTurn.m_Opponent.m_Id);
            int gameOver = playerTurn.m_Id % 2 + 1;
            return gameOver;
        }

        internal static string GetSecondTurn(Board o_gameBorad)
        {
            Console.WriteLine("You have another turn, please enter a new move");
            string curentMove = Console.ReadLine();
            bool vaildMove = InputValidate.IsALegalMove(o_gameBorad.m_Size, curentMove);

            while (!vaildMove)
            {
                Console.WriteLine("Ilegal Move. Try again");
                curentMove = Console.ReadLine();
                vaildMove = InputValidate.IsALegalMove(o_gameBorad.m_Size, curentMove);
            }
            return curentMove;
        }

        internal static void ShowDetailsForGameOver(Player playerTurn, int gameOver)
        {
            switch (gameOver)
            {
                case 0:
                    Console.WriteLine("There is a draw");
                    break;
                case 1:
                    Console.WriteLine(string.Format("{0} won the game!!!", playerTurn.m_Opponent.m_Name));
                    break;
                case 2:
                    Console.WriteLine(string.Format("{0} won the game!!!", playerTurn.m_Name));
                    break;
                case -1:
                    break;
            }

        }

        internal static void ShowResults(Player playerOne,Player playerTwo)
        {
            Console.WriteLine(string.Format("The results are: \n {0} have {1} points. \n {2} have {3} points. ", playerOne.m_Name, playerOne.m_Points, playerTwo.m_Name, playerTwo.m_Points));
        }

        internal static bool CheckForEndMatch()
        {
            bool i_endMatch = false;
            Console.WriteLine("Press Q for Quit, press any other key for another round");
            if (Console.ReadLine().Equals("Q"))
            {
                i_endMatch = true;
            }
            return i_endMatch;
        }
        

    }
}
