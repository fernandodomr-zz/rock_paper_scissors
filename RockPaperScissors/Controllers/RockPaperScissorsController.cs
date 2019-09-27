using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RockPaperScissorsController : ControllerBase
    {   
        /// <summary>
        /// Returns a winner from the game
        /// <para>POST api/rockpaperscissors/rps_game_winner</para>
        /// </summary>
        /// <param name="players">Player array</param>
        /// <returns>RPSPlayer object</returns>
        [HttpPost("rps_game_winner")]
        public ActionResult<RPSPlayer> rps_game_winner(IEnumerable<RPSPlayer> players)
        {
            try
            {
                var game = new RPSGame(players);

                return game.GetWinner();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a winner from the tournament series
        /// <para>POST api/rockpaperscissors/rps_tournament_winner</para>
        /// </summary>
        /// <param name="tournamentStruct">Game arrays</param>
        /// <returns>RPSPlayer object</returns>
        [HttpPost("rps_tournament_winner")]
        public ActionResult<RPSPlayer> rps_tournament_winner(dynamic tournamentStruct)
        {
            try
            {
                var tournament = new RPSTournament(tournamentStruct);
                
                return tournament.GetWinner();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}