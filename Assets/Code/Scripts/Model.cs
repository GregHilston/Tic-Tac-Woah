using System; // required for NotImplementedException
using UnityEngine;

namespace TicTacWoah {
    /// <summary>
    /// Represents all our state and business logic.
    /// 
    /// Uses a one dimensional representation of a three by three
    /// two dimensional tic tac toe board
    /// the indices are mapped as follows
    /// 0 1 2
    /// 3 4 5
    /// 6 7 8
    /// </summary>
    public interface IModel {
        /// <summary>
        /// Records a move made. Updates internal state of whose 
        /// turn it is
        /// </summary>
        /// <param name="playerId">Which player has moved</param>
        /// <param name="coordinate">Where the player has moved</param>
        /// <returns>True if the move was valid else False</returns>
        bool RecordMove(int playerId, int coordinate);

        /// <summary>
        /// Determines whose turn it is.
        /// </summary>
        /// <returns>player id representing whose turn it is.</returns>
        int WhoseTurn();

        /// <summary>
        /// Determines if the game is over.
        /// </summary>
        /// <returns>-1 for the game is not over, otherwise returns the player id of who won.</returns>
        int IsGameOver();
    }

    public enum Move { Empty, Player, Computer };

    public class Model : IModel {
        enum PlayerId { HumanPlayer, Computer };

        Move[] board = new Move[9]; // our game board
        Move[] initialBoard = {
            Move.Empty, Move.Empty, Move.Empty,
            Move.Empty, Move.Empty, Move.Empty,
            Move.Empty, Move.Empty, Move.Empty
        };
        PlayerId whoseTurn = PlayerId.HumanPlayer;

        public Model() {
            this.board = initialBoard;
        }

        bool RecordMove(int playerId, int coordinate) {
            throw new NotImplementedException();
        }

        public int WhoseTurn() {
            throw new NotImplementedException();
        }

        public int IsGameOver() {
            throw new NotImplementedException();
        }
    }
}