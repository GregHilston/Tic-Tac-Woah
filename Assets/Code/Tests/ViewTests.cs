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
public class ViewTests
{
    public class PresenterSpy : IPresenter
    {
        public bool OnGameStartWasCalled = false;
        public void OnGameStart()
        {
            OnGameStartWasCalled = true;
        }

        public bool RecordComputerMoveWasCalled = false;
        public int RecordComputerMoveCoordinate;
        public void RecordComputerMove(int coordinate)
        {
            RecordComputerMoveWasCalled = true;

            RecordComputerMoveCoordinate = coordinate;
        }

        public bool RecordPlayerMoveWasCalled = false;
        public int RecordPlayerMoveCoordinate;
        public void RecordPlayerMove(int coordinate)
        {
            RecordPlayerMoveWasCalled = true;

            RecordPlayerMoveCoordinate = coordinate;
        }
    }

    [Test]
    public void TestDisplayBoardDisplaysAnEmptyBoardCorrectly()
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
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
        }
        
        // When
        sut.DisplayBoard(model);

        // Then
        using (var writer = new StringWriter())
        {
            Console.WriteLine("some stuff"); // or make your DLL calls :)

            writer.Flush(); // when you're done, make sure everything is written out

            var printedString = writer.GetStringBuilder().ToString();

            Console.SetOut(originalConsoleOut); // restore Console.Out

            Assert.IsNotNull(printedString, "Displaying Board should cause " +
            "something to be printed");
        }
    }
}
