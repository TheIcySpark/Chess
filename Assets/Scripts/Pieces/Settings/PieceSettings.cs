using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Piece", menuName = "Piece")]
public class PieceSettings : ScriptableObject
{
    public enum Colors { Black, White}
    public Colors Color;
    public Sprite sprite;
}
