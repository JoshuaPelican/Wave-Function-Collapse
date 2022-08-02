using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prototype", menuName = "WFC/Prototype")]
public class Prototype2D : ScriptableObject
{
    public GameObject GameObject;
    public List<Prototype2D> LeftNeighbors;
    public List<Prototype2D> RightNeighbors;
    public List<Prototype2D> TopNeighbors;
    public List<Prototype2D> BottomNeighbors;
}
