using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

/// <summary>
/// Tests the View class
/// </summary>
public class ViewTests {
    public class PresenterSpy : IPresenter {
        public bool OnGameStartWasCalled = false;
        public void OnGameStart() {
            OnGameStartWasCalled = true;
        }

        public bool RecordComputerMoveWasCalled = false;
        public int RecordComputerMoveCoordinate;
        public void RecordComputerMove(int coordinate) {
            RecordComputerMoveWasCalled = true;

            RecordComputerMoveCoordinate = coordinate;
        }

        public bool RecordPlayerMoveWasCalled = false;
        public int RecordPlayerMoveCoordinate;
        public void RecordPlayerMove(int coordinate) {
            RecordPlayerMoveWasCalled = true;

            RecordPlayerMoveCoordinate = coordinate;
        }
    }

    [Test]
    public void TestDisplayBoardDisplaysAnEmptyBoardCorrectly() {
        // Given
        // const Model model = new Model(new Move[1]);
    }
}
