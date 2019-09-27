using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockPaperScissors.CustomExceptions
{
    public class WrongNumberOfPlayersError : Exception
    {

        public WrongNumberOfPlayersError() : base("WrongNumberOfPlayersError")
        {
        }
    }

    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base("NoSuchStrategyError")
        {
        }
    }

    public class MalformedPlayerException : Exception
    {
        public MalformedPlayerException() : base("MalformedPlayerException")
        {
        }
    }
}
