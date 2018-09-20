using System;
using UnityEngine;

public class WaterGenerator : MonoBehaviour {

    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetX = 1f;
    public float offsetY = 1f;

    private void Update()
    {
        Terrain water = GetComponent<Terrain>();
        water.terrainData = GenerateWater(water.terrainData);
        offsetX += 0.1f * Time.deltaTime;
        offsetY += 0.2f * Time.deltaTime;
    }

    private TerrainData GenerateWater(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    private float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
