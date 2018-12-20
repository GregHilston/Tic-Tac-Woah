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
    public void TestRecordPlayerMoveUpdatesInternalState() {
        // Given
        TicTacWoah.Model.Move[] moves = {
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty,
            Model.Move.Empty, Model.Move.Empty, Model.Move.Empty};
        var sut = new Model(moves);

        // When
        sut.RecordPlayerMove(0);

        // Then

    }
}