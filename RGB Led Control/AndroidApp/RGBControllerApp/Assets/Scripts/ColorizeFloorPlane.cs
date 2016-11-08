using UnityEngine;
using System.Collections;

public class ColorizeFloorPlane : MonoBehaviour
{

    [SerializeField]
    private Color[] colors;

    private bool applied = false;
    private Texture2D texture2D;
    // Use this for initialization
    void Start () {
	    texture2D = new Texture2D(30, 30);
        GetTextureWithRandomColors(ref texture2D, colors);
        texture2D.filterMode= FilterMode.Point;
        texture2D.Apply();

        GetComponent<Renderer>().material.SetTexture("_MainTex", texture2D);

    }
    void GetTextureWithRandomColors(ref Texture2D texture, Color[] colors)
    {
        for (int x  = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                texture.SetPixel(x, y, colors[Random.Range(0, colors.Length)]);
            }
        }
    }
}
