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

    [Test]
    public void TestOnGameStartCallsIsPlayersTurn() {
        // Given
        var modelSpy = new ModelSpy();

        var sut = new Presenter();
        sut.model = modelSpy;

        // When
        sut.OnGameStart();

        // Then
        Assert.IsTrue(modelSpy.isPlayersTurnWasCalled, "Starting a new game " +
        	"should check whose turn it is");
    }
}
