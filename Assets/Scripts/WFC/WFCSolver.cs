using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WFCSolver : MonoBehaviour
{
    [Header("WFC Settings")]
    [SerializeField] int Width;
    [SerializeField] int Height;
    [SerializeField] List<Prototype2D> AllPrototypes = new List<Prototype2D>();
    [SerializeField] Transform TileContainer;

    WFCTile[][] grid;

    Stack<Vector2Int> stack = new Stack<Vector2Int>();

    bool IsCollapsed => grid.All(x => x.All(x => x.IsCollapsed));

    readonly static Vector2Int[] validDirections = new Vector2Int[4]
    {
        new Vector2Int(-1, 0),
        new Vector2Int(1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
    };


    private void Start()
    {
        Init();
        Solve();
        Test();
    }

    void Init()
    {
        grid = new WFCTile[Width][];

        for (int x = 0; x < Width; x++)
        {
            grid[x] = new WFCTile[Height];

            for (int y = 0; y < Height; y++)
            {
                grid[x][y] = new WFCTile(x, y, AllPrototypes);
            }
        }
    }

    void Solve()
    {
        while (!IsCollapsed)
            Iterate();
    }

    void Iterate()
    {
        Vector2Int coords = GetMinEntropyCoords();
        CollapseAt(coords);
        Propogate(coords);
    }

    Vector2Int GetMinEntropyCoords()
    {
        int minEntropy = AllPrototypes.Count;

        List<WFCTile> minTiles = new List<WFCTile>();

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (grid[x][y].Entropy < minEntropy && !grid[x][y].IsCollapsed)
                {
                    minEntropy = grid[x][y].Entropy;
                }
            }
        }

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (grid[x][y].Entropy == minEntropy)
                {
                    minTiles.Add(grid[x][y]);
                }
            }
        }

        WFCTile minTile = minTiles[Random.Range(0, minTiles.Count)];

        return new Vector2Int(minTile.X, minTile.Y);
    }

    void CollapseAt(Vector2Int coords)
    {
        Debug.Log(coords);
        grid[coords.x][coords.y].CollapseRandomly();
    }

    void Propogate(Vector2Int coords)
    {
        stack.Push(coords);

        List<Vector2Int> propogatedCoords = new List<Vector2Int>();

        while(stack.Count > 0)
        {
            Vector2Int currentCoords = stack.Pop();
            WFCTile currentTile = grid[currentCoords.x][currentCoords.y];

            for (int i = 0; i < validDirections.Length; i++)
            {
                Vector2Int otherCoords = currentCoords + validDirections[i];

                if (otherCoords.x >= Width || otherCoords.x < 0 || otherCoords.y >= Height || otherCoords.y < 0)
                    continue;

                WFCTile otherTile = grid[otherCoords.x][otherCoords.y];
                bool changed = false;

                foreach (Prototype2D prototype in currentTile.ValidPrototypes)
                {
                    if (otherTile.Constrain(i, prototype) > 0)
                    {
                        changed = true;
                    }
                }

                propogatedCoords.Add(currentCoords);

                if (changed && !stack.Contains(otherCoords) && !propogatedCoords.Contains(otherCoords)) stack.Push(otherCoords);
            }
        }
    }

    void Test()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Instantiate(grid[x][y].ValidPrototypes[0].GameObject, new Vector2(x - (Width / 2f) + 0.5f, y - (Height / 2f) + 0.5f), Quaternion.identity, TileContainer);
            }
        }
    }
}
