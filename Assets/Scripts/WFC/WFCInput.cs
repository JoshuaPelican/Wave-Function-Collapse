using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFCInput : MonoBehaviour
{
    [SerializeField] Texture2D TextureInput;
    [SerializeField] int N = 3;

    List<Color[][]> patterns = new List<Color[][]>();

    void GetAllPatternsFromInput()
    {
        var pixelData = TextureInput.GetRawTextureData<Color>();
        int index = 0;

        for (int x = 0; x < TextureInput.width; x++)
        {
            for (int y = 0; y < TextureInput.height; y++)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {

                    }
                }
            }
        }
    }
}
