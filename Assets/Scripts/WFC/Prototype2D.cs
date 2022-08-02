using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Prototype", menuName = "WFC/Prototype")]
public class Prototype : ScriptableObject
{
    public GameObject GameObject;
    public List<Prototype> LeftNeighbors;
    public List<Prototype> RightNeighbors;
    public List<Prototype> TopNeighbors;
    public List<Prototype> BottomNeighbors;
}
