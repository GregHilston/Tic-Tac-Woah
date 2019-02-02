using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class PresenterTests {
    public class ModelSpy : IModel {
        public bool hasComputerWonWasCalled = false;
        public bool HasComputerWonInjectableValue;
        public bool HasComputerWon() {
            hasComputerWonWasCalled = true;

            return HasComputerWonInjectableValue;
        }

        public bool hasPlayerWonWasCalled = false;
        public bool hasPlayerWonInjectableValue;
        public bool HasPlayerWon() {
            hasPlayerWonWasCalled = true;

            return hasPlayerWonInjectableValue;
        }

        public bool isGameOverWasCalled = false;
        public bool isGameOverInjectableValue;
        public bool IsGameOver() {
            isGameOverWasCalled = true;

            return isGameOverInjectableValue;
        }

        public bool isPlayersTurnWasCalled = false;
        public bool isPlayersTurnInjectableValue;
        public bool IsPlayersTurn() {
            isPlayersTurnWasCalled = true;

            return isPlayersTurnInjectableValue;
        }

        public bool recordComputerMoveWasCalled = false;
        public bool recordComputerMoveInjectableValue;
        public bool RecordComputerMove(int coordinate) {
            recordComputerMoveWasCalled = true;

            return recordComputerMoveInjectableValue;
        }

        public bool recordPlayerMoveWasCalled = false;
        public bool recordPlayerMoveInjectableValue;
        public bool RecordPlayerMove(int coordinate) {
            recordPlayerMoveWasCalled = true;

            return recordPlayerMoveInjectableValue;
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
