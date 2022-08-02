using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WFCInput : MonoBehaviour
{
    [SerializeField] int Width, Height;

    Tilemap inputTilemap;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height, 0));
    }

    private void Awake()
    {
        inputTilemap = GetComponentInChildren<Tilemap>();
    }

    void GeneratePrototypes()
    {

    }
}
