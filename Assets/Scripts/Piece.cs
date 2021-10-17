using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public enum Colors { Black, White};
    [SerializeField] public Colors Color;

    [SerializeField] public Grid grid;

    public List<Vector2> NextAvailablePositions;

    public abstract void GenerateNextAvailablePositions();

    void Start()
    {

    }

    void Update()
    {
        
    }

    public bool IsPosAvailable(Vector2 pos)
    {
        if(!( pos.x >= 1 && pos.x <= 15 && pos.y >= 1 && pos.y <= 15 ))
        {
            return false;
        }
        Collider2D collider = Physics2D.OverlapCircle(pos, 1f);
        if (collider)
        {
            if(collider.gameObject.GetComponent<Piece>().Color == Color)
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

    public void HasBeenEaten()
    {
        Destroy(gameObject);
    }

}
