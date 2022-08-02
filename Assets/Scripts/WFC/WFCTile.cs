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
        ValidPrototypes.RemoveAll(x => x != prototype);
    }

    public void CollapseRandomly()
    {
        Debug.Log(ValidPrototypes.Count);
        Prototype2D randPrototype = ValidPrototypes[Random.Range(0, ValidPrototypes.Count)];
        CollapseTo(randPrototype);
    }

    public int Constrain(int direction, Prototype2D prototype)
    {
        
        int numRemoved = 0;
        /*
        switch (direction)
        {
            case 0:
                for (int i = ValidPrototypes.Count - 1; i >= 0; i--)
                {
                    if (!prototype.LeftNeighbors.Contains(ValidPrototypes[i]))
                    {
                        ValidPrototypes.RemoveAt(i);
                        numRemoved++;
                    }
                }
                break;
            case 1:
                for (int i = ValidPrototypes.Count - 1; i >= 0; i--)
                {
                    if (!prototype.RightNeighbors.Contains(ValidPrototypes[i]))
                    {
                        ValidPrototypes.RemoveAt(i);
                        numRemoved++;
                    }
                }
                break;
            case 2:
                for (int i = ValidPrototypes.Count - 1; i >= 0; i--)
                {
                    if (!prototype.TopNeighbors.Contains(ValidPrototypes[i]))
                    {
                        ValidPrototypes.RemoveAt(i);
                        numRemoved++;
                    }
                }
                break;
            case 3:
                for (int i = ValidPrototypes.Count - 1; i >= 0; i--)
                {
                    if (!prototype.BottomNeighbors.Contains(ValidPrototypes[i]))
                    {
                        ValidPrototypes.RemoveAt(i);
                        numRemoved++;
                    }
                }
                break;
            default:
                Debug.LogErrorFormat("Direction {0} does not exist.", direction);
                break;
        }

        Debug.Log("Number Removed: " + numRemoved);
        */
        return numRemoved;
        
    }
}