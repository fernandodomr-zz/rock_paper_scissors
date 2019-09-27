using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    /// <summary>
    /// Class for Game representation
    /// </summary>
    public class RPSGame : List<RPSPlayer>
    {
        #region Properties
        
        /// <summary>
        /// Contains all allowed moves for the game
        /// </summary>
        private readonly string[] AllowedMoves = new string[]
        {
            "R", "P", "S"
        };

        /// <summary>
        /// Returns the index of the winner in the player list
        /// </summary>
        private readonly Dictionary<string, int> WinMap = new Dictionary<string, int>()
        {
            { "RR", 0 }, { "RP", 1 }, { "RS", 0 },  // Result index from Rock vs All
            { "PR", 0 }, { "PP", 0 }, { "PS", 1 },  // Result index from Paper vs All
            { "SR", 1 }, { "SP", 0 }, { "SS", 0 }   // Result index from Scissor vs All
        };

        #endregion

        /// <summary>
        /// Get the movement by player index
        /// </summary>
        /// <param name="idx">Player index</param>
        /// <returns>Movement name</returns>
        private string MoveFrom(int idx)
        {
            return this[idx].Move;
        }

        /// <summary>
        /// Validate movements from both players
        /// </summary>
        /// <returns>Validation result</returns>
        private bool ValidateMoves()
        {
            return AllowedMoves.Contains(MoveFrom(0)) && AllowedMoves.Contains(MoveFrom(1));
        }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the class that is
        /// empty and has the default initial capacity.
        /// </summary>
        public RPSGame() : base()
        {
        }

        /// <summary>
        ///  Initializes a new instance of the class that is
        ///  empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public RPSGame(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class that contains
        /// two elements copied from the specified objects
        /// </summary>
        /// <param name="playerA">Object A</param>
        /// <param name="playerB">Object B</param>
        public RPSGame(RPSPlayer playerA, RPSPlayer playerB)
            : this(new List<RPSPlayer> { playerA, playerB })
        {
        }

        /// <summary>
        /// Initializes a new instance of the class that contains
        /// elements copied from the specified collection and has
        /// sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="players">The collection whose elements are copied to the new list.</param>
        public RPSGame(IEnumerable<RPSPlayer> players) : base(players)
        {
            try
            {
                if (players == null || players.Count() != 2)
                {
                    throw new CustomExceptions.WrongNumberOfPlayersError();
                }

                if (!ValidateMoves())
                {
                    throw new CustomExceptions.NoSuchStrategyError();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check the player moves to return the winner
        /// </summary>
        /// <returns>Player object</returns>
        public RPSPlayer GetWinner()
        {
            int idxWinner = WinMap[MoveFrom(0) + MoveFrom(1)];

            return this[idxWinner];//.ToString();
        }

        #endregion
    }
}
