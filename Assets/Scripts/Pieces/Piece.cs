using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public PieceSettings Settings;
    public List<Vector2> NextAvailablePositions;
    public abstract void GenerateNextAvailablePositions();

    protected virtual void Start()
    {
        GetComponent<SpriteRenderer>().sprite = Settings.sprite;
        print(Settings.sprite);
    }

    public bool IsPosAvailable(Vector2 pos)
    {
        if(!( pos.x >= 1.5 && pos.x <= 8.5 && pos.y >= 1.5 && pos.y <= 8.5 ))
        {
            return false;
        }
        Collider2D collider = Physics2D.OverlapCircle(pos, 1f);
        if (collider)
        {
            if(collider.gameObject.GetComponent<Piece>().Settings.Color == Settings.Color)
            {
                return false;
            }
        }
        return true;
    }

    public void MovePos(Vector2 pos)
    {
        transform.position = pos;
    }
}
