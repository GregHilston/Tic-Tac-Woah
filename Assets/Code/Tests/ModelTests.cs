using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using TicTacWoah;

public class ModelTests {
    // Tests RecordPlayerMove and IsPlayersTurn
    [Test]
    public void TestPlayerGoesFirstByDefault()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When

        // Then
        Assert.IsTrue(sut.IsPlayersTurn(), "It should be the player's " +
            "turn first after a default game is started");
    }

    [Test]
    public void TestComputerGoesFirstWhenInitializedSo()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves, false);

        // When

        // Then
        Assert.IsFalse(sut.IsPlayersTurn(), "It should be the computer's " +
            "turn first after a default game is started");
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

    // Tests RecordComputerMove and IsPlayersTurn
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

    // Tests IsGameOver, HasPlayerWon and HasComputerWon
    [Test]
    public void TestsIsGameOverReturnsFalseAtStartOfEmptyGame()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        // purposefully doing nothing, using the intiial state of the board

        // Then
        Assert.IsFalse(sut.IsGameOver(), "The game should not be over when " +
        	"initialzied with empty spaces");
    }

    [Test]
    public void TestsIsGameOverReturnsTrueAtStartOfFinishedGameWithPlayerWinning()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Player, Model.Move.Empty, Model.Move.Computer,
            Model.Move.Player, Model.Move.Computer, Model.Move.Empty,
            Model.Move.Player, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        // purposefully doing nothing, using the intiial state of the board

        // Then
        Assert.IsTrue(sut.IsGameOver(), "The game should be over when " +
            "initialzied with a three in a row player spaces");
        Assert.IsTrue(sut.HasPlayerWon(), "The player should be considered " +
            "the winner");
        Assert.IsFalse(sut.HasComputerWon(), "The computer should be considered " +
            "the loser");
    }

    [Test]
    public void TestsIsGameOverReturnsTrueAtStartOfFinishedGameWithComputerWinning()
    {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Computer, Model.Move.Empty, Model.Move.Player,
            Model.Move.Computer, Model.Move.Player, Model.Move.Empty,
            Model.Move.Computer, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        // purposefully doing nothing, using the intiial state of the board

        // Then
        Assert.IsTrue(sut.IsGameOver(), "The game should be over when " +
            "initialzied with a three in a row computer spaces");
        Assert.IsTrue(sut.HasComputerWon(), "The computer should be considered " +
            "the winner");
        Assert.IsFalse(sut.HasPlayerWon(), "The player should be considered " +
            "the loser");
    }
}