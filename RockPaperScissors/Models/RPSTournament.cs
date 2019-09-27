using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    /// <summary>
    /// Class for Tournament representation
    /// </summary>
    public class RPSTournament
    {
        #region Properties

        /// <summary>
        /// Default tournament struct
        /// </summary>
        public dynamic TournamentStruct { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the class that is empty
        /// </summary>
        public RPSTournament()
        {
        }

        /// <summary>
        /// Initializes a new instance of the class that has the struct of rounds specified
        /// </summary>
        /// <param name="tournamentStruct">Struct of rounds</param>
        public RPSTournament(dynamic tournamentStruct)
        {
            this.TournamentStruct = tournamentStruct;
        }

        #endregion

        /// <summary>
        /// Search for the winner recursively
        /// </summary>
        /// <param name="node_top">Top node struct</param>
        /// <returns>Player object</returns>
        private RPSPlayer Search(dynamic node_top)
        {
            RPSPlayer playerWinner = null;

            foreach (var node_middle in node_top)
            {
                if (node_middle is JArray)
                {
                    var node_middle_array = ((JArray)node_middle).ToObject<ArrayList>();

                    var node_bottom = node_middle_array[0];

                    if (node_bottom is string)
                    {
                        var playerA = ((JArray)node_top[0]).ToObject<List<string>>();
                        var playerB = ((JArray)node_top[1]).ToObject<List<string>>(); 

                        playerWinner = new RPSGame(new RPSPlayer(playerA), new RPSPlayer(playerB)).GetWinner();

                        break;
                    }
                    else
                    {
                        RPSPlayer currentWinner = Search(node_middle_array);

                        if (playerWinner == null)
                        {
                            playerWinner = currentWinner;
                        }
                        else
                        {
                            playerWinner = new RPSGame(playerWinner, currentWinner).GetWinner();
                        }
                    }
                }
            }

            return playerWinner;
        }

        /// <summary>
        /// Check the tournament rounds to return the winner
        /// </summary>
        /// <returns>Player object</returns>
        public RPSPlayer GetWinner()
        {
            var winner = Search(TournamentStruct);
            
            return winner;
        }
    }
}
