namespace CheckersMenu
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using CheckersMenu.Properties;
    using Checkers_Logic;

    public partial class FormGame : Form
    {
        private int m_BoardSize = 0;
        private Player m_PlayerOne;
        private Player m_PlayerTwo;
        private Player m_CurrentPlayer;
        private Board m_Board;
        private Button[,] buttonMatrix;
        private Label ScoreOneLabel;
        private Label ScoreTwoLabel;
        private Piece m_ExtraJumpPiece;

        public FormGame(int i_BoardSize, string i_Player1Str, string i_Player2Str)
        {
            InitializeComponent();
            this.m_BoardSize = i_BoardSize;
            this.m_PlayerOne = new Player(i_Player1Str, 'O', 1);
            this.m_PlayerTwo = new Player(i_Player2Str, 'X', 2);
            m_PlayerOne.m_Opponent = m_PlayerTwo;
            m_PlayerTwo.m_Opponent = m_PlayerOne;
            buttonMatrix = new Button[this.m_BoardSize, this.m_BoardSize];
            ScoreOneLabel = new Label();
            ScoreOneLabel.Text = "0";
            ScoreTwoLabel = new Label();
            ScoreTwoLabel.Text = "0";
            m_ExtraJumpPiece = null;
        }

        public void BoardReBuild()
        {
            foreach (Button button in this.buttonMatrix)
            {
                if (button.BackColor == Color.LightBlue)
                {
                    button.BackColor = Color.White;
                }
            }
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            CreateBoard();
            StartGame();
        }

        private void StartGame()
        {
            this.m_Board = new Board(this.m_BoardSize, m_PlayerOne, m_PlayerTwo);
            m_Board.InitilaizeBoard();
            this.m_CurrentPlayer = m_PlayerOne;
            char [,] boardPieces = m_Board.m_Board;
            UpdateBoard();
        }

        private void CreateBoard()
        {
            for (int i = 0; i < this.m_BoardSize; i++)
            {
                for (int j = 0;  j < this.m_BoardSize; j++)
                {
                    StringBuilder nameSqaure = new StringBuilder();
                    nameSqaure.Append((char)('A' + i));
                    nameSqaure.Append((char)('a' + j));
                    buttonMatrix[i, j] = new Button();
                    buttonMatrix[i, j].Name = nameSqaure.ToString();
                    buttonMatrix[i, j].Size = new Size(50, 50);
                    buttonMatrix[i, j].Location = new Point(55 * (i + 1), 55 * (j + 1));
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        buttonMatrix[i, j].BackColor = Color.Black;
                        buttonMatrix[i, j].Enabled = false;
                    }
                    else if (i % 2 != 0 && j % 2 != 0)
                    {
                        buttonMatrix[i, j].BackColor = Color.Black;
                        buttonMatrix[i, j].Enabled = false;
                    }
                    else
                    {
                        buttonMatrix[i, j].BackColor = Color.White;
                    }

                    buttonMatrix[i, j].Click += new System.EventHandler(this.button_Click);
                    this.Controls.Add(buttonMatrix[i, j]);
                    Label playerOneLabel = new Label();
                    playerOneLabel.Text = "Player 1:";
                    playerOneLabel.Size = new Size(50, 20);
                    playerOneLabel.Location = new Point(40, 15);
                    this.Controls.Add(playerOneLabel);
                    ScoreOneLabel.Location = new Point(100, 15);
                    ScoreOneLabel.Size = new Size(30, 20);
                    this.Controls.Add(ScoreOneLabel);
                    Label playerTwoLabel = new Label();
                    playerTwoLabel.Text = "Player 2:";
                    playerTwoLabel.Location = new Point(180, 15);
                    playerTwoLabel.Size = new Size(50, 20);
                    this.Controls.Add(playerTwoLabel);
                    ScoreTwoLabel.Location = new Point(240, 15);
                    ScoreTwoLabel.Size = new Size(30, 20);
                    this.Controls.Add(ScoreTwoLabel);
                }
            }
        }

        private void UpdateBoard()
        {
            m_Board.UpdateBoard();
            for (int i = 0; i < this.m_BoardSize; i++)
            {
                for (int j = 0; j < this.m_BoardSize; j++)
                {
                    char piece = this.m_Board.m_Board[i, j];
                    foreach (Control item in this.Controls)
                    {
                        if (item.Name == m_Board.LocationToString(i,j))
                        {
                            string piesceSymbol = piece.ToString();
                            if (piesceSymbol == "X")
                            {
                                (item as Button).BackgroundImage = (Image)Resources.ResourceManager.GetObject("black");
                            }
                            else if (piesceSymbol == "Z")
                            {
                                (item as Button).BackgroundImage = (Image)Resources.ResourceManager.GetObject("Black_King");
                            }
                            else if (piesceSymbol == "O")
                            {
                                (item as Button).BackgroundImage = (Image)Resources.ResourceManager.GetObject("white");
                            }
                            else if (piesceSymbol == "Q")
                            {
                                (item as Button).BackgroundImage = (Image)Resources.ResourceManager.GetObject("white_king");
                            }
                            else
                            {
                                (item as Button).BackgroundImage = null;
                            }

                            (item as Button).BackgroundImageLayout = ImageLayout.Stretch;
                        }
                    }
                }
            }
        }

        private void WhiteBackColourAll()
        {
            for (int i = 0; i < this.m_BoardSize; i++)
            {
                for (int j = 0; j < this.m_BoardSize; j++)
                {
                    Button button = buttonMatrix[i, j];
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            Piece piece = null;
            bool check = false;
            string buttonName = btnSender.Name;
            bool firstClick = true;
            List<string> avilableMoves = null;
            if (btnSender.Text == m_CurrentPlayer.m_Opponent.m_Tools.ToString())
            {
                if (m_CurrentPlayer.m_SecondTurn == false)
                {
                    MessageBox.Show("Illegal Move");
                    btnSender.BackColor = Color.White;
                }
            }
            else
            {
                foreach (Button markedButton in this.buttonMatrix)
                {
                    if (markedButton.BackColor == Color.LightBlue)
                    {
                        firstClick = false;
                        piece = m_Board.PieceByPosition(m_CurrentPlayer, markedButton.Name);
                        if (m_ExtraJumpPiece != null && piece != m_ExtraJumpPiece && m_ExtraJumpPiece.m_Team == m_CurrentPlayer.m_Tools)
                        {
                            MessageBox.Show("Illegal Move");
                            markedButton.BackColor = Color.White;
                            break;
                        }

                        int numberOfPieces = m_Board.m_Xpieces.Count + m_Board.m_Opieces.Count;
                        if (piece == null)
                        {
                            MessageBox.Show("Illegal Move");
                            btnSender.BackColor = Color.White;
                            markedButton.BackColor = Color.White;
                            break;
                        }

                        avilableMoves = piece.m_AvilableMoves;
                        if (avilableMoves.Contains(btnSender.Name))
                        {
                            check = m_Board.TurnSucceed(m_CurrentPlayer, (markedButton.Name + ">" + btnSender.Name));
                            markedButton.BackColor = Color.White;
                            if (check == true)
                            {
                                UpdateBoard();

                                if (numberOfPieces != m_Board.m_Xpieces.Count + m_Board.m_Opieces.Count)
                                {
                                    if (piece.m_AvilableJumps.Count == 0)
                                    {
                                        m_CurrentPlayer = m_CurrentPlayer.m_Opponent;
                                        m_ExtraJumpPiece = null;
                                    }
                                    else
                                    {
                                        m_ExtraJumpPiece = piece;
                                    }
                                }
                                else
                                {
                                    m_CurrentPlayer = m_CurrentPlayer.m_Opponent;
                                }

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Illegal Move");
                                markedButton.BackColor = Color.White;
                                break;
                            }
                        }
                        else if (markedButton == btnSender)
                        {
                            markedButton.BackColor = Color.White;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Illegal Move");
                            markedButton.BackColor = Color.White;
                            break;
                        }
                    }
                }
            }

            int wincheck = m_Board.CheckifGameOver(m_PlayerOne, m_PlayerTwo);

            if (wincheck != -1)
            {
                EndGame(wincheck);
                btnSender.BackColor = Color.White;
            }
            else
            {
                if (firstClick == true)
                {
                    btnSender.BackColor = Color.LightBlue;
                }

                if (m_PlayerTwo.m_Name == "PC" && firstClick == false && check == true && m_ExtraJumpPiece == null)
                {
                    while (true)
                    {
                        string pcTurn = m_Board.PCTurn();
                        bool checkPC = m_Board.TurnSucceed(m_CurrentPlayer, pcTurn);
                        if (checkPC)
                        {
                            UpdateBoard();
                            m_CurrentPlayer = m_PlayerOne;
                            break;
                        }
                    }

                    wincheck = m_Board.CheckifGameOver(m_PlayerOne, m_PlayerTwo);
                    if (wincheck != -1)
                    {
                        EndGame(wincheck);
                        btnSender.BackColor = Color.White;
                    }
                }
                return;
            }
        }

        private void EndGame(int i_Player)
        {
            string endGameMsg;
            if (i_Player > 0)
            {
                endGameMsg = string.Format("Player {0} won! \n Another Round?", i_Player);
            }
            else
            {
                endGameMsg = "It's A Tie! \n Another Round?";
            }

            DialogResult dialogResult = MessageBox.Show(endGameMsg, "Game Over", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                m_Board.UpdatePoints(m_PlayerOne, m_PlayerTwo, i_Player);
                int pointsOne = m_PlayerOne.m_Points;
                int pointsTwo = m_PlayerTwo.m_Points;
                ScoreOneLabel.Text = pointsOne.ToString();
                ScoreTwoLabel.Text = pointsTwo.ToString();
                BoardReBuild();
                StartGame();
                return;
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}