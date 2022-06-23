namespace Checkers_Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Board
    {
        public List<Piece> m_Opieces;

        public List<Piece> m_Xpieces;

        public int m_Size { get; }

        public int m_NumOfO { get; set; }

        public int m_NumOfX { get; set; }

        public char[,] m_Board { get; set; }

        public Player m_FirstPlayer;

        public Player m_SecondPlayer;

        public string m_LastMove { get; set; }

        public Board(int i_size, Player i_firstPlayer, Player i_secondplayer)
        {
            this.m_Board = new char[i_size, i_size];
            this.m_Size = i_size;
            this.m_NumOfO = 0;
            this.m_NumOfX = 0;
            this.m_FirstPlayer = i_firstPlayer;
            this.m_SecondPlayer = i_secondplayer;
            this.m_Opieces = new List<Piece>();
            this.m_Xpieces = new List<Piece>();
            this.m_LastMove = string.Empty;
        }

        public void InitilaizeBoard()
        {
            for (int i = 0; i < (this.m_Size / 2) - 1; i++)
            {
                for (int j = 0; j < this.m_Size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 != 0)
                        {
                            this.m_Board[i, j] = 'O';
                            this.m_Opieces.Add(new Piece('O', this.LocationToString(i, j)));
                            this.m_NumOfO = this.m_NumOfO + 1;
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            this.m_Board[i, j] = 'O';
                            this.m_Opieces.Add(new Piece('O', this.LocationToString(i, j)));
                            this.m_NumOfO += 1;
                        }
                    }

                    if ((this.m_Size - 1 - i) % 2 != 0)
                    {
                        if (j % 2 == 0)
                        {
                            this.m_Board[this.m_Size - 1 - i, j] = 'X';
                            this.m_Xpieces.Add(new Piece('X', this.LocationToString(this.m_Size - 1 - i, j)));
                            this.m_NumOfX++;
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            this.m_Board[this.m_Size - 1 - i, j] = 'X';
                            this.m_Xpieces.Add(new Piece('X', this.LocationToString(this.m_Size - 1 - i, j)));
                            this.m_NumOfX++;
                        }
                    }
                }
            }
        }

        public char GetFromPosition(char i_row, char i_col)
        {
            int row = 0, col = 0;
            if (i_row > 'a' && i_row < this.m_Size + 97)
            {
                row = (int)(i_row - 97);
            }

            if (i_col > 'A' && i_col < this.m_Size + 65)
            {
                col = (int)(i_col - 65);
            }

            return this.m_Board[row, col];
        }

        public void SetFromPosition(char i_row, char i_col, char i_set)
        {
            int row = 0, col = 0;
            if (i_row > 'a' && i_row < this.m_Size + 97)
            {
                row = (int)(i_row - 97);
            }

            if (i_col > 'A' && i_col < this.m_Size + 65)
            {
                col = (int)(i_col - 65);
            }

            this.m_Board[row, col] = i_set;
        }

        public string LocationToString(int i_row, int i_col)
        {
            char col = (char)(i_col + 65);
            char row = (char)(i_row + 97);
            StringBuilder sb = new StringBuilder();
            sb.Append(col);
            sb.Append(row);
            return sb.ToString();
        }

        public int GetRow(string i_location)
        {
            char row = i_location[1];
            int i_row = (int)(row - 97);
            return i_row;
        }

        public int GetCol(string i_location)
        {
            char col = i_location[0];
            int j_col = (int)(col - 65);
            return j_col;
        }

        public bool MakeMove(Player io_player, string io_move)
        {
            string o_currentPosition = io_move.Substring(0, 2);
            bool moveMave = false;
            string io_nextPosition = io_move.Substring(3, 2);
            char io_currentRow = o_currentPosition[1];
            bool i_anyjump = false;
            bool i_anyNewMove = true;
            char o_currentCol = o_currentPosition[0];
            Piece io_piece = this.PieceByPosition(io_player, o_currentPosition);
            List<Piece> o_tools;
            if (io_player.m_Tools == 'O')
            {
                o_tools = this.m_Opieces;
            }
            else
            {
                o_tools = this.m_Xpieces;
            }

            foreach (Piece checkJump in o_tools)
            {
                if (checkJump.m_AvilableJumps.Count() > 0)
                {
                    i_anyjump = true;
                    break;
                }
            }

            if (io_piece != null)
            {
                if (io_piece.m_AvilableJumps.Contains(io_nextPosition))
                {
                    this.JumpMove(io_player, io_piece, io_currentRow, o_currentCol, io_nextPosition[0], io_nextPosition[1]);
                    this.UpdateBoard();
                    while (io_piece.m_AvilableJumps.Count > 0)
                    {
                        if (i_anyNewMove)
                        {
                            if (io_player.m_Name.Equals("PC"))
                            {
                                string move = this.PCTurn();
                                while (!this.AnotherMoveAfterEating(io_player, io_piece, move))
                                {
                                    move = this.PCTurn();
                                }

                                moveMave = true;
                                break;
                            }

                            io_player.m_SecondTurn = true;
                            io_player.m_SecondTurnPice = io_piece;

                            this.UpdateBoard();
                            moveMave = true;
                            break;
                        }

                        this.UpdateBoard();
                    }

                    moveMave = true;
                }
                else if (i_anyjump == true)
                {
                    moveMave = false;
                }
                else if (io_piece.m_AvilableMoves.Contains(io_nextPosition))
                {
                    io_piece.m_CurrentLocation = io_nextPosition;
                    this.SetFromPosition(io_currentRow, o_currentCol, '\0');
                    this.UpdateBoard();
                    moveMave = true;
                }
            }

            return moveMave;
        }

        public Piece PieceByPosition(Player io_player, string i_poistion)
        {
            Piece piecefound = null;
            List<Piece> tools;
            if (io_player.m_Tools == 'O')
            {
                tools = this.m_Opieces;
            }
            else
            {
                tools = this.m_Xpieces;
            }

            foreach (Piece piece in tools)
            {
                if (piece.m_CurrentLocation.Equals(i_poistion))
                {
                    piecefound = piece;
                }
            }

            return piecefound;
        }

        public void UpdateBoard()
        {
            foreach (Piece piece in this.m_Xpieces)
            {
                string piecePosition = piece.m_CurrentLocation;
                char row = piecePosition[1];
                char col = piecePosition[0];
                if (piece.m_IsKing == false)
                {
                    this.SetFromPosition(row, col, 'X');
                }
                else
                {
                    this.SetFromPosition(row, col, 'Z');
                }
            }

            foreach (Piece piece in this.m_Opieces)
            {
                string piecePosition = piece.m_CurrentLocation;
                char row = piecePosition[1];
                char col = piecePosition[0];
                if (piece.m_IsKing == false)
                {
                    this.SetFromPosition(row, col, 'O');
                }
                else
                {
                    this.SetFromPosition(row, col, 'Q');
                }
            }

            this.UpdatePossibleMoves();
        }

        public bool AnotherMoveAfterEating(Player player, Piece piece, string anotherMove)
        {
            bool moveExist = false;
            UpdateBoard();
            string currentPosition = anotherMove.Substring(0, 2);
            string nextPosition = anotherMove.Substring(3, 2);

            if (piece.m_CurrentLocation == currentPosition)
            {
                if (piece.m_AvilableJumps.Contains(nextPosition))
                {
                    this.JumpMove(player, piece, currentPosition[1], currentPosition[0], nextPosition[0], nextPosition[1]);
                    player.m_SecondTurn = false;
                    this.UpdateBoard();

                    moveExist = true;
                }
            }

            return moveExist;
        }

        public int CheckifGameOver(Player playerOne, Player playerTwo)
        {
            int endStatus = -1;
            int legalmovesX = 0;
            int legalmovesO = 0;
            foreach (Piece piece in this.m_Xpieces)
            {
                if (piece.m_AvilableMoves.Count > 0)
                {
                    legalmovesX++;
                }
            }

            foreach (Piece piece in this.m_Opieces)
            {
                if (piece.m_AvilableMoves.Count > 0)
                {
                    legalmovesO++;
                }
            }

            if (legalmovesO == 0 && legalmovesX == 0)
            {
                this.UpdatePoints(playerOne, playerTwo, 0);
                endStatus = 0;
            }
            else if (this.m_Opieces.Count() == 0 || legalmovesO == 0)
            {
                this.UpdatePoints(playerOne, playerTwo, 2);
                endStatus = 2;
            }
            else if (this.m_Xpieces.Count() == 0 || legalmovesX == 0)
            {
                this.UpdatePoints(playerOne, playerTwo, 1);
                endStatus = 1;
            }

            return endStatus;
        }

        public void UpdatePoints(Player playerOne, Player playerTwo, int win)
        {
            int countPlayerOne = 0;
            int countPlayerTwo = 0;
            foreach (Piece piece in this.m_Xpieces.Union(this.m_Opieces))
            {
                if (piece.m_Team == 'O' || piece.m_Team == 'Q')
                {
                    if (piece.m_IsKing)
                    {
                        countPlayerOne += 4;
                    }
                    else
                    {
                        countPlayerOne++;
                    }
                }

                if (piece.m_Team == 'X' || piece.m_Team == 'Z')
                {
                    if (piece.m_IsKing)
                    {
                        countPlayerTwo += 4;
                    }
                    else
                    {
                        countPlayerTwo++;
                    }
                }
            }

            if (win == playerOne.m_Id)
            {
               playerOne.m_Points += Math.Abs(countPlayerOne - countPlayerTwo);
            }
            else if (win == playerTwo.m_Id)
            {
               playerTwo.m_Points += Math.Abs(countPlayerTwo - countPlayerOne);
            }
        }

        public bool TurnSucceed(Player playerTurn, string currentMove)
        {
            bool isSucceed = true;
            this.UpdatePossibleMoves();
            if (!this.MakeMove(playerTurn, currentMove))
            {
                isSucceed = false;
            }

            this.m_LastMove = currentMove;
            this.CheckMakeAking();
            this.UpdateBoard();
            return isSucceed;
        }

        public string PCTurn()
        {
            int availbleMove = 0;
            int randomIndexMove = 0;
            string currentPosition = string.Empty;
            Piece piece = null;
            StringBuilder move = new StringBuilder();
            int piecesNum = this.m_Xpieces.Count();
            Random randomNum = new Random();
            while (availbleMove == 0)
            {
                int randomPieceIndex = randomNum.Next(piecesNum);
                piece = this.m_Xpieces[randomPieceIndex];
                currentPosition = piece.m_CurrentLocation;
                availbleMove = piece.m_AvilableMoves.Count();
                randomIndexMove = randomNum.Next(availbleMove);
            }

            string nextPosition = piece.m_AvilableMoves[randomIndexMove];
            move.Append(currentPosition);
            move.Append(">");
            move.Append(nextPosition);
            return move.ToString();
        }

        internal void CheckMakeAking()
        {
            foreach (Piece piece in this.m_Xpieces)
            {
                if (piece.m_CurrentLocation[1] == 'a' && piece.m_IsKing == false)
                {
                    piece.m_IsKing = true;
                    this.UpdateBoard();
                }
            }

            foreach (Piece piece in this.m_Opieces)
            {
                if (piece.m_CurrentLocation[1] == (this.m_Size - 1) + 97 && piece.m_IsKing == false)
                {
                    piece.m_IsKing = true;
                    this.UpdateBoard();
                }
            }
        }

        internal void UpdateKingMoves(Piece piece, char currentRow, char currentCol, char nextRow, char optionOneCol, char optionTwoCol)
        {
            bool checkJumpOne = false;
            char previousRow;
            bool checkJumpTwo = false;
            char checkPosOne = '1';
            char checkPosTwo = '1';
            if (piece.m_Team == 'O')
            {
                previousRow = (char)(currentRow - 1);
            }
            else
            {
                previousRow = (char)(currentRow + 1);
            }

            StringBuilder optionOne = new StringBuilder();
            optionOne.Append(optionOneCol);
            StringBuilder optionTwo = new StringBuilder();
            optionTwo.Append(optionTwoCol);
            optionOne.Append(previousRow);
            optionTwo.Append(previousRow);
            string optionOneStr = optionOne.ToString();
            string optionTwoStr = optionTwo.ToString();
            if (previousRow >= 'a' && previousRow < this.m_Size + 97)
            {
                if (optionOneCol >= 'A' && optionOneCol < this.m_Size + 65)
                {
                    checkPosOne = this.GetFromPosition(previousRow, optionOneCol);
                    checkJumpOne = this.CheckJump(piece, previousRow, optionOneCol, checkPosOne);
                }

                if (optionTwoCol >= 'A' && optionTwoCol < this.m_Size + 65)
                {
                    checkPosTwo = this.GetFromPosition(previousRow, optionTwoCol);
                    checkJumpTwo = this.CheckJump(piece, previousRow, optionTwoCol, checkPosTwo);
                }

                if (checkJumpOne == true || checkJumpTwo == true)
                {
                    return;
                }
            }

            if (checkPosOne == 0)
            {
                piece.m_AvilableMoves.Add(optionOneStr);
            }

            if (checkPosTwo == 0)
            {
                piece.m_AvilableMoves.Add(optionTwoStr);
            }
        }

        internal void JumpMove(Player player, Piece jumper, char jumperRow, char jumperCol, char jumpCol, char jumpRow)
        {
            StringBuilder losePosition = new StringBuilder();
            StringBuilder newPosition = new StringBuilder();
            char loseCol = (char)(((int)jumpCol + (int)jumperCol) / 2);
            char loseRow = (char)(((int)jumpRow + (int)jumperRow) / 2);
            losePosition.Append(loseCol);
            losePosition.Append(loseRow);
            newPosition.Append(jumpCol);
            newPosition.Append(jumpRow);
            Piece lose = this.PieceByPosition(player.m_Opponent, losePosition.ToString());
            this.SetFromPosition(loseRow, loseCol, '\0');
            this.SetFromPosition(jumpRow, jumpCol, jumper.m_Team);
            this.SetFromPosition(jumperRow, jumperCol, '\0');
            jumper.m_CurrentLocation = newPosition.ToString();
            if (jumper.m_Team == 'O')
            {
                this.m_Xpieces.Remove(lose);
            }
            else
            {
                this.m_Opieces.Remove(lose);
            }
        }

        internal bool CheckJump(Piece io_piece, char io_nextRow, char io_nextCol, char io_checkPos)
        {
            bool i_isAJump = false;
            char i_nextJumpCol;
            char i_nextJumpRow;

            if (io_piece.m_Team == 'O')
            {
                i_nextJumpRow = (char)(io_nextRow + 1);
                if ((char)(io_nextRow - 1) != io_piece.m_CurrentLocation[1])
                {
                    i_nextJumpRow = (char)(io_nextRow - 1);
                }
            }
            else
            {
                i_nextJumpRow = (char)(io_nextRow - 1);
                if ((char)(io_nextRow + 1) != io_piece.m_CurrentLocation[1])
                {
                    i_nextJumpRow = (char)(io_nextRow + 1);
                }
            }

            StringBuilder o_jump = new StringBuilder();
            if (io_checkPos != '\0' && io_checkPos != io_piece.m_Team && io_checkPos != io_piece.m_TeamKing)
            {
                if (io_nextCol == (char)(io_piece.m_CurrentLocation[0] - 1))
                {
                    i_nextJumpCol = (char)(io_nextCol - 1);
                }
                else
                {
                    i_nextJumpCol = (char)(io_nextCol + 1);
                }

                if (i_nextJumpRow >= 'a' && i_nextJumpRow < (this.m_Size + 97) && i_nextJumpCol >= 'A' && i_nextJumpCol < (this.m_Size + 65))
                {
                    char checkJump = this.GetFromPosition(i_nextJumpRow, i_nextJumpCol);

                    if (checkJump == '\0')
                    {
                        o_jump.Append(i_nextJumpCol);
                        o_jump.Append(i_nextJumpRow);
                        io_piece.m_AvilableJumps.Add(o_jump.ToString());
                        io_piece.m_AvilableMoves.Add(o_jump.ToString());
                        i_isAJump = true;
                    }
                }
            }

            return i_isAJump;
        }

        internal void UpdatePossibleMoves()
        {
            List<Piece> io_tools;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    io_tools = this.m_Opieces;
                }
                else
                {
                    io_tools = this.m_Xpieces;
                }

                foreach (Piece io_piece in io_tools)
                {
                    string i_currentLocation = io_piece.m_CurrentLocation;
                    bool i_checkJumpOne = false;
                    bool io_checkJumpTwo = false;
                    char io_checkPosOne = '1';
                    char io_checkPosTwo = '1';
                    io_piece.m_AvilableMoves = new List<string>();
                    io_piece.m_AvilableJumps = new List<string>();
                    char o_currentRow = i_currentLocation[1];
                    char o_currentCol = i_currentLocation[0];
                    char io_nextRow;
                    if (io_piece.m_Team == 'O')
                    {
                        io_nextRow = (char)(o_currentRow + 1);
                    }
                    else
                    {
                        io_nextRow = (char)(o_currentRow - 1);
                    }

                    char io_optionOneCol = (char)(o_currentCol + 1);
                    char io_optionTwoCol = (char)(o_currentCol - 1);
                    StringBuilder io_optionOne = new StringBuilder();
                    io_optionOne.Append(io_optionOneCol);
                    StringBuilder io_optionTwo = new StringBuilder();
                    io_optionTwo.Append(io_optionTwoCol);
                    io_optionOne.Append(io_nextRow);
                    io_optionTwo.Append(io_nextRow);
                    string io_optionOneStr = io_optionOne.ToString();
                    string io_optionTwoStr = io_optionTwo.ToString();
                    if (io_piece.m_IsKing == true)
                    {
                        this.UpdateKingMoves(io_piece, o_currentRow, o_currentCol, io_nextRow, io_optionOneCol, io_optionTwoCol);
                    }

                    if (io_nextRow >= 'a' && io_nextRow < this.m_Size + 97)
                    {
                        if (io_optionOneCol >= 'A' && io_optionOneCol < this.m_Size + 65)
                        {
                            io_checkPosOne = this.GetFromPosition(io_nextRow, io_optionOneCol);
                            i_checkJumpOne = this.CheckJump(io_piece, io_nextRow, io_optionOneCol, io_checkPosOne);
                        }

                        if (io_optionTwoCol >= 'A' && io_optionTwoCol < this.m_Size + 65)
                        {
                            io_checkPosTwo = this.GetFromPosition(io_nextRow, io_optionTwoCol);
                            io_checkJumpTwo = this.CheckJump(io_piece, io_nextRow, io_optionTwoCol, io_checkPosTwo);
                        }

                        if (i_checkJumpOne == true || io_checkJumpTwo == true)
                        {
                            continue;
                        }
                    }

                    if (io_checkPosOne == 0)
                    {
                        io_piece.m_AvilableMoves.Add(io_optionOneStr);
                    }

                    if (io_checkPosTwo == 0)
                    {
                        io_piece.m_AvilableMoves.Add(io_optionTwoStr);
                    }
                }
            }
        }
    }
}