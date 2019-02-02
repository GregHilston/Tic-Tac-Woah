using System; // required for NotImplementedException
using UnityEngine;
using TicTacWoah;

namespace TicTacWoah {
    /// <summary>
    /// Glues the User Interactions to the state and business logic, calling display functions when needed.
    /// </summary>
    public interface IPresenter {
        /// <summary>
        /// Signifies that a new game should be started.
        /// </summary>
        void StartNewGame();

        /// <summary>
        /// Records a move made by the player
        /// </summary>
        /// <param name="coordinate">Where the player has moved</param>
        void RecordMove(int playerId, int coordinate);

        /// <summary>
        /// Prepares information for the About screen.
        /// </summary>
        void OnAboutClicked();
    }

    public class Presenter : IPresenter {
        /// <summary>
        /// Reference to our IView. Note we only maintain a reference to the interface.
        /// </summary>
        IView view;

        /// <summary>
        /// Reference to our IModel. Note we only maintain a reference to the interface.
        /// </summary>
        IModel model;

        public Presenter(IView view) {
            this.view = view;

            model = new Model();
        }

        public void StartNewGame() {
            throw new NotImplementedException();
        }

        public void RecordMove(int playerId, int coordinate) { 
            throw new NotImplementedException();
        }

        public void OnAboutClicked() {
            throw new NotImplementedException();
        }
    }
}