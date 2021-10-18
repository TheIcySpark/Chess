using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public PieceSettings Settings;
    public List<Vector2> NextAvailablePositions;
    public virtual void GenerateNextAvailablePositions()
    {
        throw new NotImplementedException();
    }

    protected virtual void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Settings.sprite;
    }

    public bool IsPosAvailable(Vector2 pos)
    {
        if(!( pos.x >= 1.5 && pos.x <= 8.5 && pos.y >= 1.5 && pos.y <= 8.5 ))
        {
            return false;
        }
        Collider2D collider = Physics2D.OverlapCircle(pos, 0.5f);
        if (collider)
        {
            if(PieceToEatInPos(pos))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public bool PieceToEatInPos(Vector2 pos)
    {
        Collider2D collider = Physics2D.OverlapCircle(pos, 0.5f);
        if (collider)
        {
            if (collider.gameObject.GetComponent<Piece>().Settings.Color != Settings.Color)
            {
                return true;
            }
        }
        return false;
    }

    public void MovePos(Vector2 pos)
    {
        transform.position = pos;
    }
}
