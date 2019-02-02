using System; // required for NotImplementedException
using UnityEngine;

namespace TicTacWoah {
    /// <summary>
    /// Represents our user interface and hooks into user interactions.
    /// </summary>
    public interface IView {
        /// <summary>
        /// Visually displays the state of the board.
        /// </summary>
        /// <param name="model">the current state of the board</param>
        void DisplayBoard(Model model);

        /// <summary>
        /// Displays that an illegal move was attempted to be made.
        /// </summary>
        void DisplayIllegalMove();

        /// <summary>
        /// Displays that the game is over and who has won the game.
        /// </summary>
        /// <param name="playerId">Indicates which player we're talking about.</param>
        void DisplayGameOverAndWinner(int playerId);

        /// <summary>
        /// Displays whose turn it is.
        /// </summary>
        /// <param name="playerId">Indicates which player we're talking about.</param>
        void DisplayWhoseTurn(int playerId);
    }

    /// <summary>
    /// Handles all the user input handling and display logic.
    /// </summary>
    public class View : IView {
        /// <summary>
        /// Reference to our IPresenter. Note we only maintain a reference to the interface.
        /// </summary>
        IPresenter iPresenter;

        public View() {
            iPresenter = new Presenter(this);
        }

        public void DisplayBoard(Model model) {
            throw new NotImplementedException();
        }

        public void DisplayIllegalMove() {
            throw new NotImplementedException();
        }

        public void DisplayGameOverAndWinner(int playerId) {
            throw new NotImplementedException();
        }

        public void DisplayWhoseTurn(int playerId) {
            throw new NotImplementedException();
        }
    }
}