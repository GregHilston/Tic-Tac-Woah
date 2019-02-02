using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class PresenterTests {
    public class ViewSpy : IView {
        public bool wasDisplayBoardCalled = false;
        public Move[] observedDisplayBoardBoard;
        public void DisplayBoard(Move[] board) {
            wasDisplayBoardCalled = true;

            observedDisplayBoardBoard = board;
        }

        public bool wasDisplayGameOverAndWinnerCalled = false;
        public int observedDisplayGameOverAndWinnerPlayerId;
        public void DisplayGameOverAndWinner(int playerId) {
            wasDisplayGameOverAndWinnerCalled = true;

            observedDisplayGameOverAndWinnerPlayerId = playerId;
        }

        public bool wasDisplayIllegalMoveCalled = false;
        public void DisplayIllegalMove() {
            wasDisplayIllegalMoveCalled = true;
        }

        public bool wasDisplayWhoseTurnCalled = false;
        public int observedDisplayWhoseTurnPlayerId;
        public void DisplayWhoseTurn(int playerId) {
            wasDisplayWhoseTurnCalled = true;

            observedDisplayWhoseTurnPlayerId = playerId;
        }
    }

    public class ModelSpy : IModel {
        public bool wasRecordMoveCalled = false;
        public int observedRecordMovePlayerId;
        public int observedRecordMoveCoordinate;
        public bool injectableRecordMove;
        public bool RecordMove(int playerId, int coordinate) {
            wasRecordMoveCalled = true;

            observedRecordMovePlayerId = playerId;
            observedRecordMoveCoordinate = coordinate;

            return injectableRecordMove;
        }

        public bool wasWhoseTurnCalled = false;
        public int injectableWhoseTurn;
        public int WhoseTurn() {
            wasWhoseTurnCalled = true;

            return injectableWhoseTurn;
        }

        public bool wasIsGameOverCalled = false;
        public int injectableIsGameOver;
        public int IsGameOver() {
            wasIsGameOverCalled = true;

            return injectableIsGameOver;
        }
    }

    // Tests OnGameStarts
    [Test]
    public void TestOnGameStartCallsIsPlayersTurn() {
        // Given
        var viewSpy = new ViewSpy();
        var sut = new Presenter(viewSpy);
        var modelSpy = new ModelSpy();
        sut.model = modelSpy;

        // When
        sut.StartNewGame();

        // Then
        Assert.IsTrue(modelSpy.isPlayersTurnWasCalled, "Starting a new game " +
        	"should check whose turn it is");
    }

    // Tests RecordPlayerMove
    [Test]
    public void TestRecordPlayerMoveCallsRecordPlayerMove() {
        // Given
        var viewSpy = new ViewSpy();
        var sut = new Presenter(viewSpy);
        var modelSpy = new ModelSpy();
        sut.model = modelSpy;

        sut.StartNewGame();

        // When
        sut.RecordPlayerMove(0);

        // Then
        Assert.IsTrue(modelSpy.recordPlayerMoveWasCalled, "The presenter being " +
            "asked to record a player move, should call the same on the model");
    }

    //Tests RecordComputerMove
    [Test]
    public void TestRecordComputerMoveCallsRecordComputerMove() {
        // Given
        var viewSpy = new ViewSpy();
        var sut = new Presenter(viewSpy);
        var modelSpy = new ModelSpy();
        sut.model = modelSpy;

        sut.StartNewGame();

        // When
        sut.RecordComputerMove(0);

        // Then
        Assert.IsTrue(modelSpy.recordComputerMoveWasCalled, "The presenter being " +
            "asked to record a computer move, should call the same on the model");
    }
}
