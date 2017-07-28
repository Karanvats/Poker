using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata
{
    class GameEntry
    {
        
        public static void Main()
        {
            bool  _quit = false;
            while (!_quit)
            {
                StartGame();
            }
        }

        public static bool StartGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome To Poker");
            Console.WriteLine("Please Read the Instructions before proceeding with the game");
            Console.WriteLine("Please make sure no space is between inputs or else the table round will be cancelled");
            Console.WriteLine("How Many Player are at the Table ?");
            int noOfPlayers = Convert.ToInt32(Console.ReadLine());
            string[] playernames = new string[noOfPlayers];
            for (int i = 0; i < noOfPlayers; i++)
            {
                Console.WriteLine("Please enter the name of the " + i.ToString() + " player:");
                playernames[i] = Console.ReadLine();
            }
            Game poker = new Game();
            foreach (string name in playernames)
            {
                Player player = new Player();
                player.PlayerName = name;
                poker.AddPlayer(player);
            }
            string[][] playerhands = new string[6][];
            for (int i = 0; i < poker.players.Count; i++)
            {
                if (poker.players[i].PlayerName != null)
                {
                    Console.WriteLine("Please enter the card suit for " + poker.players[i].PlayerName + " choose from 2-A followed by H,D,C,S for suit with space in between cards input");
                    playerhands[i] = Console.ReadLine().ToString().Trim().Split(' ');

                    for (int j = 0; j < 5; j++)
                    {
                        CardValue userValue;
                        if (playerhands[i][j].Length > 2 && Enum.TryParse<CardValue>(playerhands[i][j].Substring(0, 1).ToUpper(), out userValue))
                        {
                            Console.Clear();
                            Console.WriteLine("Error Detected in Input Current round has been cancelled.Please try again");
                            Console.ReadLine();
                            return true;

                        }
                        Card playerCard = new Card(playerhands[i][j].Substring(1, 1).ToUpper(), Convert.ToInt16(Enum.Parse(typeof(CardValue), playerhands[i][j].Substring(0, 1).ToUpper())));
                        poker.players[i].TakeCard(playerCard);
                    }
                }
            }

            FindWinner(poker);

            Console.ReadLine();
            Console.WriteLine("Do you want to play another round ?(Enter Y to continue)");


            return Console.ReadLine() == "Y" ? false : true;
        }

        private static void FindWinner(Game poker)
        {
            Player winner = poker.Winner();
            if (winner.TieClause)
            {
                Console.WriteLine("Tie");
                return;
            }
            if (winner.Hand() == "high card")
            {
                Console.WriteLine("winner is :" + winner.PlayerName + "- with High Card " + winner.winningCard.value);
                return;
            }
            else
            {
                Console.WriteLine("Winner is :" + winner.PlayerName + "- with " + winner.Hand() + "- with High Card " + winner.winningCard.value);
                return;
            }
        }
    }
}
