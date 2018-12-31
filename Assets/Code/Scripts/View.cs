using System; // required for NotImplementedException
using UnityEngine;

namespace TicTacWoah {
    /// <summary>
    /// Represents our user interface and hooks into user interactions.
    /// </summary>
    interface IView {
        /// <summary>
        /// Visually displays the state of the board.
        /// </summary>
        /// <param name="model">the current state of the board</param>
        void DisplayBoard(Model model);

        /// <summary>
        /// Displays that an illegal move was attempted to be made.
        /// </summary>
        /// <param name="coordinate">corodinate of illegal move</param>
        void DisplayIllegalMove(int coordinate);

        /// <summary>
        /// Displays to the human player that they won the game.
        /// </summary>
        void DisplayGameWon();

        /// <summary>
        /// Displays whose turn it is.
        /// </summary>
        /// <param name="isPlayersTurn">If it is the human player's turn</param>
        void DisplayWhoseTurn(bool isPlayersTurn);
    }

    /// <summary>
    /// Handles all the user input handling and display logic.
    /// </summary>
    public class View : IView {
        public IPresenter iPresenter;

        public View() {
            iPresenter = new Presenter();
        }

        public void DisplayBoard(Model model) {
            throw new NotImplementedException();
        }

        public void DisplayGameWon() {
            throw new NotImplementedException();
        }

        public void DisplayIllegalMove(int coordinate) {
            throw new NotImplementedException();
        }

        public void DisplayWhoseTurn(bool isPlayersTurn) {
            throw new NotImplementedException();
        }
    }
}