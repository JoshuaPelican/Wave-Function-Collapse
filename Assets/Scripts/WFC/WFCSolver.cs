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

    Stack<WFCTile> stack = new Stack<WFCTile>();

    bool IsCollapsed => grid.All(x => x.All(x => x.IsCollapsed));


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
        grid[coords.x][coords.y].CollapseRandomly();
    }

    void Propogate(Vector2Int coords)
    {

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
