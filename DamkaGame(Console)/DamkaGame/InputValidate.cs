namespace DvirFriedler_DamkaGame
{
    using System;

    public class InputValidate
    {
        public static bool UserNameIsValid(string i_name)
        {
            if (i_name.Contains(" "))
            {
                return false;
            }

            if (i_name.Length > 10 || i_name.Length == 0)
            {
                return false;
            }

            return true;
        }

        public static bool BoardSizeIsValid(string i_size)
        {
            if (i_size == "6" || i_size == "8" || i_size == "10")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GameModeIsValid(string i_type)
        {
            if (i_type == "1" || i_type == "2")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTwoPlayers(string i_mode)
        {
            if (i_mode == "2")
            {
                return true;
            }

            return false;
        }

        public static bool IsALegalMove(int size, string i_move)
        {
            if (i_move == "Q")
            {
                return true;
            }

            if (i_move.Length != 5)
            {
                return false;
            }

            if (i_move[2] != '>')
            {
                return false;
            }

            if (i_move[0] < 'A' && i_move[0] > size + 64 && i_move[3] < 'A' && i_move[3] > size + 64)
            {
                return false;
            }

            if (i_move[1] < 'a' && i_move[0] > size + 96 && i_move[3] < 'A' && i_move[4] > size + 96)
            {
                return false;
            }

            return true;
        }
    }
}
