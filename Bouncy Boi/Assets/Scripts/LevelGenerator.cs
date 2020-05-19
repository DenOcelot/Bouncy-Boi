using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public Vector3 StartPos;
    public int MinTileSetLength;
    public int MaxTileSetLength;
    public float MinTileSetDistance;
    public float MaxTileSetDistance;
    public int MaxTileSetAmount;
    int TileSetLength;

    Vector3 PreviousTileTransform;
    Vector3 TileTransform;
    GameObject NextTile;
    // Start is called before the first frame update
    void Start()
    {
        PreviousTileTransform = StartPos;
        int i = 0;
        while (i < MaxTileSetAmount)
        {
            int s = 0;      
            TileSetLength = Random.Range(MinTileSetLength, MaxTileSetLength);
            float SetDistanceX = Random.Range(MinTileSetDistance, MaxTileSetDistance);
            float SetDistanceY = Random.Range(-MaxTileSetDistance * 2, MaxTileSetDistance*1.3f);
            while (s <= TileSetLength)
            {               
                TileTransform = new Vector3(PreviousTileTransform.x + 0.8f, PreviousTileTransform.y);
                NextTile = Instantiate(tiles[0], TileTransform,Quaternion.identity);
                PreviousTileTransform = TileTransform;
                s++;
            }
            PreviousTileTransform = new Vector3(PreviousTileTransform.x + SetDistanceX, PreviousTileTransform.y + SetDistanceY);
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
