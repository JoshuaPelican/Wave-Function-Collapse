using System.Collections.Generic;
using UnityEngine;

public class WFCTile
{
    public int X, Y;

    public int Entropy => ValidPrototypes.Count;
    public bool IsCollapsed => Entropy == 1;

    public List<Prototype2D> ValidPrototypes;

    public WFCTile(int x, int y, List<Prototype2D> prototypes)
    {
        X = x;
        Y = y;

        ValidPrototypes = new List<Prototype2D>(prototypes);
    }

    public void CollapseTo(Prototype2D prototype)
    {
        ValidPrototypes = new List<Prototype2D>() { prototype };
    }

    public void CollapseRandomly()
    {
        Prototype2D randPrototype = ValidPrototypes[Random.Range(0, ValidPrototypes.Count)];
        CollapseTo(randPrototype);
    }
}