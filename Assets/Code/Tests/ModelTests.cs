using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class ModelTests { 
    // Tests RecordPlayerMove
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
        Assert.IsTrue(returnValue, "A player should be able to make a move " +
        	"on an empty space");
        Assert.IsFalse(sut.IsPlayersTurn(), "It should not be the player's " +
        	"turn just after they made a move");
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
        Assert.IsFalse(sut.IsPlayersTurn(), "It should not be the player's " +
            "turn just after they made a move");
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
        Assert.IsFalse(sut.IsPlayersTurn(), "It should not be the player's " +
            "turn just after they made a move");
    }

    // Tests RecordComputerMove
    [Test]
    public void TestRecordComputerMoveWhenLegalReturnsTrue()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        bool returnValue = sut.RecordPlayerMove(0);

        // Then
        Assert.IsTrue(returnValue, "A computer should be able to make a move on " +
            "an empty space");
        Assert.IsTrue(sut.IsPlayersTurn(), "It should be the player's " +
            "turn just after the computer made a move");
    }

    [Test]
    public void TestRecordComputerMoveWhereTheyAlreadyMovedReturnsFalse()
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
        Assert.IsFalse(returnValue, "A computer should not be able to make a " +
            "move where they have already moved");
        Assert.IsTrue(sut.IsPlayersTurn(), "It should be the player's " +
           "turn just after the computer made a move");
    }

    [Test]
    public void TestRecordComputerMoveWherePlayerAlreadyMovedReturnsFalse()
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
        Assert.IsFalse(returnValue, "A computer should not be able to make a " +
            "move where a player has already moved");
        Assert.IsTrue(sut.IsPlayersTurn(), "It should be the player's " +
           "turn just after the computer made a move");
    }
}