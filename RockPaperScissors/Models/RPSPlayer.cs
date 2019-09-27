using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    /// <summary>
    /// Class for Player representation
    /// </summary>
    public class RPSPlayer : List<string>
    {
        #region Properties

        /// <summary>
        /// Returns the player name
        /// </summary>
        public string Name
        {
            get { return this[0]; }
            //set { this[0] = value; }
        }

        /// <summary>
        /// Returns the player movement
        /// </summary>
        public string Move
        {
            get { return this[1]; }
            //set { this[1] = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the class that is
        /// empty and has the default initial capacity.
        /// </summary>
        public RPSPlayer() : base()
        {
        }

        /// <summary>
        ///  Initializes a new instance of the class that is
        ///  empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public RPSPlayer(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class that contains
        /// elements copied from the specified collection and has
        /// sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="player">The collection whose elements are copied to the new list.</param>
        public RPSPlayer(IEnumerable<string> player) : base(player)
        {
            if (player == null || player.Count() != 2)
            {
                throw new CustomExceptions.MalformedPlayerException();
            }
        }

        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", this.Name, this.Move);
        }
    }
}
