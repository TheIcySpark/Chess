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
            nextPos = new Vector2(transform.position.x + directions[i].x * grid.cellSize.x,
                                  transform.position.y + directions[i].y * grid.cellSize.x);
            while (IsPosAvailable(nextPos))
            {
                NextAvailablePositions.Add(nextPos);
                nextPos.x += directions[i].x * grid.cellSize.x;
                nextPos.y += directions[i].y * grid.cellSize.y;
            }
        }
    }

    private void Start()
    {
        GenerateNextAvailablePositions();
    }
}
