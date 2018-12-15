using System; // required for NotImplementedException

/// <summary>
/// Glues the User Interactions to the state and business logic, calling display functions when needed.
/// </summary>
interface IPresenter {
    /// <summary>
    /// Signifies that a new game has begun
    /// </summary>
    void OnGameStart();

    /// <summary>
    /// Records a move made by the player
    /// </summary>
    /// <param name="coordinate">Where the player has moved</param>
    void RecordPlayerMove(int coordinate);

    /// <summary>
    /// Records a mvoe made by the computer
    /// </summary>
    /// <param name="coordinate">Where the computer has moved</param>
    void RecordComputerMove(int coordinate);
}

public class Presenter : IPresenter {
    public void OnGameStart() {
        throw new NotImplementedException();
    }

    public void RecordComputerMove(int coordinate) {
        throw new NotImplementedException();
    }

    public void RecordPlayerMove(int coordinate) {
        throw new NotImplementedException();
    }
}