using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{

    public enum Directions { Up = 1, Down = -1};

    [SerializeField] public Directions direction;


    public override void GenerateNextAvailablePositions()
    {
        NextAvailablePositions.Clear();
        Vector2 nextPos = transform.position;
        nextPos.y += (float)direction * grid.cellSize.x;
        if (IsPosAvailable(nextPos))
        {
            NextAvailablePositions.Add(nextPos);
        }
        Vector2 posToEat1 = new Vector2(nextPos.x + grid.cellSize.x, nextPos.y);
        Vector2 posToEat2 = new Vector2(nextPos.x + grid.cellSize.x, nextPos.y);
        if (IsPosAvailable(posToEat1))
        {
            NextAvailablePositions.Add(posToEat1);
        }
        if (IsPosAvailable(posToEat2))
        {
            NextAvailablePositions.Add(posToEat2);
        }
        foreach(var x in NextAvailablePositions)
        {
            print(x);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
