using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class PresenterTests {
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
        var modelSpy = new ModelSpy();
        var sut = new Presenter();
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
        var modelSpy = new ModelSpy();

        var sut = new Presenter();
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
        var modelSpy = new ModelSpy();

        var sut = new Presenter();
        sut.model = modelSpy;

        sut.StartNewGame();

        // When
        sut.RecordComputerMove(0);

        // Then
        Assert.IsTrue(modelSpy.recordComputerMoveWasCalled, "The presenter being " +
            "asked to record a computer move, should call the same on the model");
    }
}
