using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class PresenterTests {
    public class ModelSpy : IModel {
        bool hasComputerWonWasCalled = false;
        bool HasComputerWonInjectableValue;
        public bool HasComputerWon() {
            hasComputerWonWasCalled = true;

            return HasComputerWonInjectableValue;
        }

        bool hasPlayerWonWasCalled = false;
        bool hasPlayerWonInjectableValue;
        public bool HasPlayerWon() {
            hasPlayerWonWasCalled = true;

            return hasPlayerWonInjectableValue;
        }

        bool isGameOverWasCalled = false;
        bool isGameOverInjectableValue;
        public bool IsGameOver() {
            isGameOverWasCalled = true;

            return isGameOverInjectableValue;
        }

        bool isPlayersTurnWasCalled = false;
        bool isPlayersTurnInjectableValue;
        public bool IsPlayersTurn() {
            isPlayersTurnWasCalled = true;

            return isPlayersTurnInjectableValue;
        }

        bool recordComputerMoveWasCalled = false;
        bool recordComputerMoveInjectableValue;
        public bool RecordComputerMove(int coordinate) {
            recordComputerMoveWasCalled = true;

            return recordComputerMoveInjectableValue;
        }

        bool recordPlayerMoveWasCalled = false;
        bool recordPlayerMoveInjectableValue;
        public bool RecordPlayerMove(int coordinate) {
            recordPlayerMoveWasCalled = true;

            return recordPlayerMoveInjectableValue;
        }
    }

    [Test]
    public void PresenterTestsSimplePasses() {
        // Use the Assert class to test conditions.
    }
}
