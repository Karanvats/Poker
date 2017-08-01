using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;

namespace PokerKata
{
    internal class GameEntry
    {
        private static int _noOfPlayers;
        private static bool _startGame;
        

        public static void Main()
        {
            var quit = false;
            while (!quit)
            {
               quit= StartGame();
            }
        }

        public static bool StartGame()
        {
            Clear();
            WriteLine("Welcome To Poker");
            WriteLine("Please Read the Instructions before proceeding with the game");
            WriteLine("Please make sure no space is between inputs or else the table round will be cancelled");
            WriteLine("Suit Values Are needed in the following format :");
            WriteLine();
            WriteLine("Card has one of 4 suits: clubs, diamonds, hearts, or"
                      + "spades(denoted C, D, H, and S in the input data).");
            WriteLine("Each card also has a value(from lowest to"+ " highest): 2, 3, 4, 5, 6, 7, 8, 9, 10, jack, queen, king, ace");
             WriteLine("Denoted as 2, 3, 4, 5, 6, 7, 8, 9, T, J, Q,"
            +"K, A in the input data");
            WriteLine();
            WriteLine("Example input:");
            WriteLine("2H 3D 5S 9C KD");
            WriteLine();
            WriteLine("How Many Player are at the Table ?");
            var poker = new Game();
            if (!PlayercountStartGame()) return false;
            var playernames = AddPlayerNames();
            
            AddPlayers(playernames, poker);
            var playerhands = new string[6][];
            if (poker.players.Where((t, i) => t.PlayerName != null && PlayerCardsStartGame(poker, i, playerhands)).Any())
            {
                return true;
            }

            FindWinner(poker);

            ReadLine();
            WriteLine("Do you want to play another round ?(Enter Y to continue)");


            _startGame = ReadLine() != "Y";
            if (_startGame)
            {
                poker = Reset(poker);
            }
            return _startGame;
        }
        /// <summary>
        /// reset the game 
        /// </summary>
        /// <param name="poker"></param>
        /// <returns></returns>
        private static Game Reset(Game poker)
        {
            poker = new Game();
            return poker;
        }
        /// <summary>
        /// add player names to player objects by taking input from user
        /// </summary>
        /// <returns></returns>
        private static string[] AddPlayerNames()
        {
            var playernames = new string[_noOfPlayers];
            for (var i = 0; i < _noOfPlayers; i++)
            {
                WriteLine("Please enter the name of the " + i + " player:");
                playernames[i] = ReadLine();
            }

            return playernames;
        }

        private static void AddPlayers(string[] playernames, Game poker)
        {
            foreach (var name in playernames)
            {
                var player = new Player{
                    PlayerName = name
                };
                poker.AddPlayer(player);
            }
        }

        /// <summary>
        /// Collect input from user for various players with the following format of valueof the cardand suit number
        /// </summary>
        /// <param name="poker"></param>
        /// <param name="i"></param>
        /// <param name="playerhands"></param>
        /// <returns></returns>
        private static bool PlayerCardsStartGame(Game poker, int i, string[][] playerhands)
        {
            WriteLine("Please enter the card suit for " + poker.players[i].PlayerName);
            try
            {
                playerhands[i]=new string[5];
                var readLine = ReadLine();
                if (readLine != null)
                {
                    
                    
                    readLine= String.Join("", readLine.Where(c => !char.IsWhiteSpace(c)));
                    if (!CheckSpecialChar(readLine))
                    {
                        
                        if (readLine.Length == 10)
                        {
                            for (int j = 0; j < 10; j=j+2)
                            {
                                playerhands[i][Convert.ToInt32(j/2)] = readLine.Trim().Substring(j, 2);
                            }
                        }
                        

                    }
                    else
                    {
                        Console.WriteLine("Invalid character in input schequence");
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
           

            for (var j = 0; j < 5; j++)
            {
                if (DrawPlayerCardsStartGame(poker, i, playerhands, j)) return true;
            }
            return false;
        }
        /// <summary>
        /// check for speacial characters in the input string 
        /// </summary>
        /// <param name="readLine"></param>
        /// <returns></returns>
        private static bool CheckSpecialChar(string readLine)
        {
           return readLine.Any(ch => !char.IsLetterOrDigit(c: ch));
        }

        /// <summary>
        /// Draws and places cards for a player based on input .Checks the input against the enums.
        /// </summary>
        /// <param name="poker"></param>
        /// <param name="i"></param>
        /// <param name="playerhands"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private static bool DrawPlayerCardsStartGame(Game poker, int i, IReadOnlyList<string[]> playerhands, int j)
        {
            try
            {
                if (playerhands[i][j].Length > 2 &&
                    Enum.TryParse(playerhands[i][j].Substring(0, 1).ToUpper(), out CardValue _ )&& Enum.TryParse(playerhands[i][j].Substring(1,1).ToUpper(),out Suit __))
                {
                   return true;
                }
                var playerCard = new Card(playerhands[i][j].Substring(1, 1).ToUpper(),
                    Convert.ToInt16(Enum.Parse(typeof(CardValue), playerhands[i][j].Substring(0, 1).ToUpper())));
                poker.players[i].TakeCard(playerCard);
                return false;
            }
            catch (Exception)
            {
                Clear();
                WriteLine("Error Detected in Input Current round has been cancelled.Please try again");
                ReadLine();
                return false;
            }
            
        }
        /// <summary>
        /// Takes input from user for no of player for a single round
        /// </summary>
        /// <returns></returns>
        private static bool PlayercountStartGame()
        {
            try
            {
                _noOfPlayers = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
                WriteLine("Invalid Input");
                ReadLine();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Calculate winner from the poker class 
        /// </summary>
        /// <param name="poker"></param>
        private static void FindWinner(Game poker)
        {
            var winner = poker.Winner();
            
            if (winner.Hand() == "high card")
                WriteLine("winner is :" + winner.PlayerName + "- with High Card " + ((CardValue)(winner.winningCard.value)).ToString());
            else
                WriteLine("Winner is :" + winner.PlayerName + "- with " + winner.Hand() + "- with High Card " +
                          ((CardValue)(winner.winningCard.value)).ToString());
        }
    }
}