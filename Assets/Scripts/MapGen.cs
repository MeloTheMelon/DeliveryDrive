using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{

    List<GameObject> mapTilePrefabs = new List<GameObject>();
    List<GameObject> obstaclePrefabs = new List<GameObject>();

    float mapTilePosCounter;
    List<GameObject> mapTiles;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        Object[] prefabs = Resources.LoadAll("Prefabs/MapTiles/FinishedTiles");
        foreach(Object o in prefabs)
        {
            mapTilePrefabs.Add((GameObject)o);
        }
        Debug.Log("MapTiles found: "+mapTilePrefabs.Count);

        mapTiles = new List<GameObject>();
        mapTilePosCounter = this.transform.position.x;

        player = GameObject.FindGameObjectWithTag("Player");

        for(int i = 0; i<10; i++)
        {
            spawnRandomTile();
        }

        prefabs = Resources.LoadAll("Prefabs/Obstacles");
        foreach(Object o in prefabs)
        {
            obstaclePrefabs.Add((GameObject)o);
        }
        Debug.Log("Obstacles Found: " + obstaclePrefabs.Count);
        spawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            spawnRandomTile();

        if(mapTiles[Mathf.Max(0, mapTiles.Count - 5)].transform.position.x - player.transform.position.x < 10)
        {
            spawnRandomTile();
        }


    }

    private void spawnRandomTile()
    {
        int randNum = Random.Range(0, mapTilePrefabs.Count);
        GameObject pickedTile = mapTilePrefabs[randNum];
        float pickedTileSize = pickedTile.transform.Find("Tile").localScale.x;
        GameObject newTile = Instantiate(pickedTile, new Vector3(mapTilePosCounter+(pickedTileSize/2f), 0, 0), Quaternion.identity);
        mapTiles.Add(newTile);
        newTile.transform.parent = this.transform;
        mapTilePosCounter += pickedTileSize;

        if (mapTiles.Count % 10 == 1)
        {
            removeTilesBeforePos(player.transform.position.x - mapTiles[mapTiles.Count-1].transform.Find("Tile").localScale.x, mapTiles);
        }

    }

    private void removeTilesBeforePos(float xPos, List<GameObject> tileList)
    {

        int removedTileCounter = 0;
        foreach (GameObject tile in tileList)
        {
            if(tile.transform.position.x < xPos)
            {
                Destroy(tile);
                removedTileCounter++;
            }
        }

        for(int i = 0; i<removedTileCounter; i++)
        {
            tileList.RemoveAt(0);
        }
    }

    public void spawnObstacles()
    {
        Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)], new Vector3(mapTiles[mapTiles.Count-1].transform.position.x, -2f, player.GetComponent<PlayerController>().getEndZValue()), Quaternion.identity);
    }

    public float getLastMapTilePosX()
    {
        return mapTiles[0].transform.position.x;
    }

}
