using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] Enemies;
    public Vector3 StartPos;
    public int MinTileSetLength;
    public int MaxTileSetLength;
    public float MinTileSetDistance;
    public float MaxTileSetDistance;
    public int MaxTileSetAmount;
    int TileSetLength;

    Vector3 PreviousTileTransform;
    Vector3 TileTransform;
    Vector3 ThreatTransform;
    Vector3 ThreatTarget;
    GameObject NextTile;
    GameObject CurrentTile;
    // Start is called before the first frame update
    void Start()
    {
        PreviousTileTransform = StartPos;
        int i = 0;
        while (i < MaxTileSetAmount)
        {
            TileSetLength = Random.Range(MinTileSetLength, MaxTileSetLength);
            int s = 0;
            float SetDistanceX = Random.Range(MinTileSetDistance, MaxTileSetDistance);
            float SetDistanceY = Random.Range(-MaxTileSetDistance, MaxTileSetDistance);
            GameObject CurrentTile = tiles[0];
            int tileSelect = Random.Range(0, tiles.Length * 4);
            if (tileSelect == 0)
            {
                CurrentTile = tiles[1];
                SetDistanceY = Random.Range(MaxTileSetDistance*1.5f, MaxTileSetDistance*1.9f);
            }
            while (s <= TileSetLength)
            {
                tileSelect = Random.Range(0, tiles.Length * 4);
                TileTransform = new Vector3(PreviousTileTransform.x + 0.8f, PreviousTileTransform.y);
                NextTile = Instantiate(CurrentTile, TileTransform, Quaternion.identity);
                if (tileSelect == 0 && s != 0 && s != TileSetLength)
                {
                    ThreatTransform = new Vector3(TileTransform.x + Random.Range(0.2f,0.4f), TileTransform.y + 1);
                    Instantiate(tiles[2], ThreatTransform, Quaternion.identity);
                }
                if (s == 0)
                {
                    ThreatTarget = new Vector3(TileTransform.x, TileTransform.y + 3.5f);
                }
                if (s == TileSetLength)
                {
                    if (tileSelect == 1)
                    {
                        GameObject Threat = Instantiate(Enemies[0], ThreatTarget, Quaternion.identity);
                        ThreatTarget = new Vector3(TileTransform.x, TileTransform.y + 3.5f);
                        Threat.GetComponent<Dagger>().Target2 = ThreatTarget;
                    }
                }
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
