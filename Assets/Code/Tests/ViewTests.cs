using System; // for Console
using System.IO; // for StringWriter
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
        public bool startNewGameWasCalled = false;
        public void StartNewGame() {
            startNewGameWasCalled = true;
        }

        public bool recordMoveWasCalled = false;
        public int observedRecordMovePlayerId;
        public int observedRecordMoveCoordinate;
        public void RecordMove(int playerId, int coordinate) {
            recordMoveWasCalled = true;

            observedRecordMovePlayerId = playerId;
            observedRecordMoveCoordinate = coordinate;
        }

        public bool onAboutClickedWasCalled = false;
        public void OnAboutClicked() {
            onAboutClickedWasCalled = true;
        }
    }

    // tests DisplayBoard
    [Test]
    public void TestDisplayBoardDisplaysAnEmptyBoard() {
        // Given
        var sut = new View();
        var presenterSpy = new PresenterSpy();
        sut.presenter = presenterSpy;

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayBoard(model);

        // Then
        using (writer) {
            Console.WriteLine("some stuff"); // or make your DLL calls :)

            writer.Flush(); // when you're done, make sure everything is written out

            var printedString = writer.GetStringBuilder().ToString();

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Assert.IsNotNull(printedString, "Displaying board should cause " +
            "something to be printed");
        }
    }

    // tests DisplayIllegalMove
    [Test]
    public void TestDisplayIllegalMovedDisplaysAnErrorMessage() {
        // Given
        var sut = new View();
        var presenterSpy = new PresenterSpy();
        sut.presenter = presenterSpy;

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayIllegalMove();

        // Then
        using (writer) {
            writer.Flush(); // when you're done, make sure everything is written out

            var printedString = writer.GetStringBuilder().ToString();

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Assert.IsNotNull(printedString, "Displaying an illegal should " +
            	"cause something to be printed");
        }
    }

    // tests DisplayGameWon
    [Test]
    public void TestDisplayGameWonDisplaysAnCongratulationsMessage() {
        // Given
        var sut = new View();
        var presenterSpy = new PresenterSpy();
        sut.presenter = presenterSpy;

        var winnerPlayerId = 1;

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayGameOverAndWinner(winnerPlayerId);

        // Then
        using (writer) {
            writer.Flush(); // when you're done, make sure everything is written out

            var printedString = writer.GetStringBuilder().ToString();

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Assert.IsNotNull(printedString, "Displaying game won should cause " +
            "something to be printed");
        }
    }

    // tests DisplayWhoseTurn
    [Test]
    public void TestDisplayWhoseTurnDisplaysAMessage() {
        // Given
        var sut = new View();
        var presenterSpy = new PresenterSpy();
        sut.presenter = presenterSpy;

        var whoseTurnPlayerId = 1;

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayWhoseTurn(whoseTurnPlayerId);

        // Then
        using (writer) {
            writer.Flush(); // when you're done, make sure everything is written out

            var printedString = writer.GetStringBuilder().ToString();

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Assert.IsNotNull(printedString, "Displaying whose turn should cause " +
            "something to be printed");
        }
    }
}