﻿using System; // required for NotImplementedException
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
    interface IModel {
        /// <summary>
        /// Records a move made by the player. Updates internal state of whose 
        /// turn it is
        /// </summary>
        /// <param name="coordinate">Where the player has moved</param>
        /// <returns>True if the move was valid else False</returns>
        bool RecordPlayerMove(int coordinate);

        /// <summary>
        /// Records a move made by the computer. Updates internal state of whose 
        /// turn it is
        /// </summary>
        /// <param name="coordinate">Where the computer has moved</param>
        /// <returns>True if the move was valid else False</returns>
        bool RecordComputerMove(int coordinate);

        /// <summary>
        /// Determines if it is the players turn
        /// </summary>
        /// <returns>True if it is the player's turn else False</returns>
        bool IsPlayersTurn();

        /// <summary>
        /// Determines if the game is over
        /// </summary>
        /// <returns>True if the game is over else False</returns>
        bool IsGameOver();

        /// <summary>
        /// Determines if the player has won
        /// </summary>
        /// <returns>True if the player has won else False</returns>
        bool HasPlayerWon();

        /// <summary>
        /// Determines if the computer has won
        /// </summary>
        /// <returns>True if the computer has won else False</returns>
        bool HasComputerWon();
    }

    public class Model : IModel {
        public enum Move { Empty, Player, Computer };

        Move[] board = new Move[9]; // our game board

        public Model(Move[] boardState) {
            const int expectedBoardLength = 9;

            if (boardState.Length != expectedBoardLength) {
                throw new ArgumentException("Expected a boardState.Length of " + expectedBoardLength + " but received a length of " + boardState.Length);
            }
        }

        public bool RecordPlayerMove(int coordinate) {
            throw new NotImplementedException();
        }

        public bool RecordComputerMove(int coordinate) {
            throw new NotImplementedException();
        }

        public bool IsPlayersTurn() {
            throw new NotImplementedException();
        }

        public bool IsGameOver() {
            throw new NotImplementedException();
        }

        public bool HasPlayerWon() {
            throw new NotImplementedException();
        }

        public bool HasComputerWon() {
            throw new NotImplementedException();
        }
    }
}