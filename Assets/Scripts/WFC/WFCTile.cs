using System.Collections.Generic;
using System.Linq;
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
        ValidPrototypes.RemoveAll(x => x != prototype);
    }

    public void CollapseRandomly()
    {
        Prototype2D randPrototype = ValidPrototypes[Random.Range(0, ValidPrototypes.Count)];
        CollapseTo(randPrototype);
    }

    public void Constrain(Prototype2D prototype)
    {
        ValidPrototypes.Remove(prototype);
    }

    public List<Prototype2D> ValidNeighbors(int direction)
    {
        List<Prototype2D> validNeighbors = new List<Prototype2D>();

        foreach (Prototype2D prototype in ValidPrototypes)
        {
            List<Prototype2D> directionalList = new List<Prototype2D>();

            switch (direction)
            {
                case 0:
                    directionalList = new List<Prototype2D>(prototype.LeftNeighbors);
                    break;
                case 1:
                    directionalList = new List<Prototype2D>(prototype.RightNeighbors);
                    break;
                case 2:
                    directionalList = new List<Prototype2D>(prototype.TopNeighbors);
                    break;
                case 3:
                    directionalList = new List<Prototype2D>(prototype.BottomNeighbors);
                    break;
            }

            validNeighbors = validNeighbors.Union(directionalList).ToList();
        }

        return validNeighbors;
    }
}