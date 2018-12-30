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
    public void TestRecordPlayerMoveIsLegalReturnsTrue() {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        bool returnValue = sut.RecordPlayerMove(0);

        // Then
        Assert.IsTrue(returnValue);
    }
}