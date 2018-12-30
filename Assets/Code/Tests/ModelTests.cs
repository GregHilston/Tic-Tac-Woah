using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class ModelTests {
    // Model sut;

    [SetUp]
    public void Setup() {
        // sut = Model();
    }

    [Test]
    public void TestRecordPlayerMoveWhenLegalReturnsTrue() {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        bool returnValue = sut.RecordPlayerMove(0);

        // Then
        Assert.IsTrue(returnValue, "A player should be able to make a move on " +
        	"an empty space");
    }

    [Test]
    public void TestRecordPlayerMoveWhereTheyAlreadyMovedReturnsFalse()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Player, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        bool returnValue = sut.RecordPlayerMove(0);

        // Then
        Assert.IsFalse(returnValue, "A player should not be able to make a " +
        	"move where they have already moved");
    }

    [Test]
    public void TestRecordPlayerMoveWhereComputerAlreadyMovedReturnsFalse()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        bool returnValue = sut.RecordPlayerMove(0);

        // Then
        Assert.IsFalse(returnValue, "A player should not be able to make a " +
            "move where a computer has already moved");
    }
}