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
        public bool onGameStartWasCalled = false;
        public void StartNewGame() {
            onGameStartWasCalled = true;
        }

        public bool recordComputerMoveWasCalled = false;
        public int observedRecordComputerMoveCoordinate;
        public void RecordComputerMove(int coordinate) {
            recordComputerMoveWasCalled = true;

            observedRecordComputerMoveCoordinate = coordinate;
        }

        public bool recordPlayerMoveWasCalled = false;
        public int observedRecordPlayerMoveCoordinate;
        public void RecordPlayerMove(int coordinate) {
            recordPlayerMoveWasCalled = true;

            observedRecordPlayerMoveCoordinate = coordinate;
        }

        public bool recordMoveWasCalled = false;
        public int observedRecordMoveCoordinate;
        public void RecordMove(int playerId, int coordinate) {
            recordMoveWasCalled = true;

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
        var presenterSpy = new PresenterSpy();

        var sut = new View();

        sut.iPresenter = presenterSpy;

        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Player,
            Model.Move.Computer, Model.Move.Player, Model.Move.Empty,
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty};
        var model = new Model(moves);

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
        var presenterSpy = new PresenterSpy();

        var sut = new View();

        sut.iPresenter = presenterSpy;

        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Player,
            Model.Move.Computer, Model.Move.Player, Model.Move.Empty,
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty};
        var model = new Model(moves);

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayIllegalMove(0);

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
    public void TestDisplayGameWonDisplaysAnCongratulationsMessage()
    {
        // Given
        var presenterSpy = new PresenterSpy();

        var sut = new View();

        sut.iPresenter = presenterSpy;

        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Player,
            Model.Move.Computer, Model.Move.Player, Model.Move.Empty,
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty};
        var model = new Model(moves);

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayGameOver();

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
    public void TestDisplayWhoseTurnDisplaysAMessage()
    {
        // Given
        var presenterSpy = new PresenterSpy();

        var sut = new View();

        sut.iPresenter = presenterSpy;

        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Player,
            Model.Move.Computer, Model.Move.Player, Model.Move.Empty,
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty};
        var model = new Model(moves);

        var originalConsoleOut = Console.Out; // preserve the original stream
        var writer = new StringWriter();
        Console.SetOut(writer);

        // When
        sut.DisplayWhoseTurn(true);

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