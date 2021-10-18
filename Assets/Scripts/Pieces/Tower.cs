using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Piece
{
    public override void GenerateNextAvailablePositions()
    {
        NextAvailablePositions.Clear();
        Vector2 nextPos = transform.position;
        List<Vector2> directions = new List<Vector2>();
        directions.Add(new Vector2(0, -1));
        directions.Add(new Vector2(1, 0));
        directions.Add(new Vector2(0, 1));
        directions.Add(new Vector2(-1, 0));
        for(int i = 0; i < 4; i++)
        {
            nextPos = new Vector2(transform.position.x + directions[i].x,
                                  transform.position.y + directions[i].y);
            while (IsPosAvailable(nextPos))
            {
                NextAvailablePositions.Add(nextPos);
                if (PieceToEatInPos(nextPos))
                {
                    break;
                }
                nextPos.x += directions[i].x;
                nextPos.y += directions[i].y;
            }
        }
    }
}
