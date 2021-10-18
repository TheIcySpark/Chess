using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PieceTest
{
    string _whitePieceName = "WhitePiece";
    string _blackPieceName = "BlackPiece";

    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("SandBox/Tests/Piece");
    }

    [UnityTest]
    public IEnumerator OutBoardLimits()
    {
        Piece whitePiece = GameObject.Find(_whitePieceName).GetComponent<Piece>();
        Piece blackPiece = GameObject.Find(_blackPieceName).GetComponent<Piece>();
        GameObject outBoardPositions = GameObject.Find("OutBoardPositions");
        yield return null;
        for (int i = 0; i < outBoardPositions.transform.childCount; i++)
        {
            Transform availablePosition = outBoardPositions.transform.GetChild(i);
            Assert.IsFalse(whitePiece.IsPosAvailable(availablePosition.transform.position));
            Assert.IsFalse(blackPiece.IsPosAvailable(availablePosition.transform.position));
        }
    }

    [UnityTest]
    public IEnumerator AvailablePositions()
    {
        Piece whitePiece = GameObject.Find(_whitePieceName).GetComponent<Piece>();
        Piece blackPiece = GameObject.Find(_blackPieceName).GetComponent<Piece>();
        GameObject availablePositions = GameObject.Find("AvailablePositions");
        yield return null;
        for(int i = 0; i < availablePositions.transform.childCount; i++)
        {
            Transform availablePosition = availablePositions.transform.GetChild(i);
            //Assert.IsTrue(whitePiece.IsPosAvailable(availablePosition.transform.position));
            Assert.IsTrue(blackPiece.IsPosAvailable(availablePosition.transform.position));
        }

    }

    [UnityTest]
    public IEnumerator WhiteDetection()
    {
        Piece whitePiece = GameObject.Find(_whitePieceName).GetComponent<Piece>();
        Piece blackPiece = GameObject.Find(_blackPieceName).GetComponent<Piece>();
        GameObject whitePieces= GameObject.Find("WhitePieces");
        yield return null;
        for (int i = 0; i < whitePieces.transform.childCount; i++)
        {
            Transform piecePos = whitePieces.transform.GetChild(i);
            Assert.IsFalse(whitePiece.IsPosAvailable(piecePos.transform.position));
            Assert.IsFalse(whitePiece.PieceToEatInPos(piecePos.transform.position));
            Assert.IsTrue(blackPiece.IsPosAvailable(piecePos.transform.position));
            Assert.IsTrue(blackPiece.PieceToEatInPos(piecePos.transform.position));
        }
    }

    [UnityTest]
    public IEnumerator BlackDetection()
    {
        Piece whitePiece = GameObject.Find(_whitePieceName).GetComponent<Piece>();
        Piece blackPiece = GameObject.Find(_blackPieceName).GetComponent<Piece>();
        GameObject blackPieces = GameObject.Find("BlackPieces");
        yield return null;
        for (int i = 0; i < blackPieces.transform.childCount; i++)
        {
            Transform piecePos = blackPieces.transform.GetChild(i);
            Assert.IsTrue(whitePiece.IsPosAvailable(piecePos.transform.position));
            Assert.IsTrue(whitePiece.PieceToEatInPos(piecePos.transform.position));
            Assert.IsFalse(blackPiece.IsPosAvailable(piecePos.transform.position));
            Assert.IsFalse(blackPiece.PieceToEatInPos(piecePos.transform.position));
        }
    }

}
