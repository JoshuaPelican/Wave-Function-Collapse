using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WFCSolver : MonoBehaviour
{
    [Header("WFC Settings")]
    [SerializeField] int Width;
    [SerializeField] int Height;

    [SerializeField] WFCTile[,] grid;

    Stack<Vector2Int> stack = new Stack<Vector2Int>();
}
