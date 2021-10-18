using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PawnTest
{

    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("SandBox/General");
    }

    [UnityTest]
    public IEnumerator PredictNextAvailablePositions1()
    {
        Pawn pawn = GameObject.Find("Pawn").GetComponent<Pawn>();
        yield return null;
        Assert.IsTrue(pawn.IsPosAvailable(new Vector2(3.5f, 1.5f)));
        Assert.IsFalse(pawn.IsPosAvailable(new Vector2(4.5f, 1.5f)));
    }
}
