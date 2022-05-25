using System;
namespace DvirFriedler_DamkaGame
{
    public class Game
    {
        public static void StartGame(Player playerOne, Player playerTwo, int boardSize)
        {
            Board o_gameBorad = new Board(boardSize, playerOne, playerTwo);
            Player playerTurn = playerOne;
            string curentMove = string.Empty;
            bool vaildMove = false;
            playerTurn = playerOne;
            int countGame = 0;
            bool i_endMatch = false;
            int io_countTurn = 0;



            while (!i_endMatch)
            {
                Console.Clear();
                int gameOver = -1;
                if (countGame == 0)
                {
                    DamkaInterface.ShowInstractions();
                }

                Console.Clear();
                playerOne.m_Opponent = playerTwo;
                playerTwo.m_Opponent = playerOne;
                o_gameBorad = new Board(boardSize, playerOne, playerTwo);
                o_gameBorad.InitilaizeBoard();
                o_gameBorad.Show();

                while (gameOver == -1)
                {
                    if (!playerTurn.m_Name.Equals("PC"))
                    {

                        DamkaInterface.ShowLastMove(playerTurn, o_gameBorad, io_countTurn);
                        curentMove = DamkaInterface.GetCurrentMove(playerTurn ,o_gameBorad);
                    }
                    else
                    {
                        curentMove = DamkaInterface.GetCurrentMove(playerTurn, o_gameBorad);
                    }

                    if (curentMove == "Q")
                    {
                        gameOver =DamkaInterface.ShowPoints(playerTurn, o_gameBorad);
                        break;
                    }
                    else
                    {
                        while (!vaildMove || playerTurn.m_SecondTurn)
                        {
                            if (playerTurn.m_Name.Equals("PC"))
                            {
                                while (!vaildMove || playerTurn.m_SecondTurn)
                                {
                                    vaildMove = o_gameBorad.TurnSucceed(playerTurn, curentMove);
                                    curentMove = o_gameBorad.PCTurn();
                                    if (playerTurn.m_SecondTurn)
                                    {
                                        while (!o_gameBorad.AnotherMoveAfterEating(playerTurn, playerTurn.m_SecondTurnPice, curentMove))
                                        {
                                            curentMove = o_gameBorad.PCTurn();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                vaildMove = o_gameBorad.TurnSucceed(playerTurn, curentMove);
                                while (!vaildMove)
                                {
                                    if (curentMove == "Q")
                                    {
                                        gameOver = DamkaInterface.ShowPoints(playerTurn, o_gameBorad);
                                        break;
                                    }

                                    ///Console.WriteLine("Ilegal Move. Try again");   maybe stay
                                    curentMove = DamkaInterface.GetCurrentMove(playerTurn, o_gameBorad);

                                }

                                if (playerTurn.m_SecondTurn)
                                {
                                 curentMove = DamkaInterface.GetSecondTurn(o_gameBorad);
                                }
                            }
                        }
                    }

                    vaildMove = false;
                    gameOver = o_gameBorad.CheckifGameOver(playerTurn, playerTurn.m_Opponent);

                    DamkaInterface.ShowDetailsForGameOver(playerTurn, gameOver);

                    playerTurn = playerTurn.m_Opponent;
                    io_countTurn++;
                }

                io_countTurn = 0;
                DamkaInterface.ShowResults(playerOne, playerTwo);

                i_endMatch = DamkaInterface.CheckForEndMatch();

                countGame++;
            }

            return;
        }
    }
 }

