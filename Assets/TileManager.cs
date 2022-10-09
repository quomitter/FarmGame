using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tileMap;
    public TileBase tileBase;
    public TileBase selectedTile;
    public Tile tile;
    public Vector3Int location;
    public TileBase[] tileArray;
    public int selector; 
    public GameObject fruitPrefab; 



    // Start is called before the first frame update
    void Start()
    {
        selector = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location = tileMap.WorldToCell(mousePoint);
        
        if (Input.GetMouseButtonDown(0))
        {
            tileMap.SetTile(location, selectedTile);
        }
        if (Input.GetMouseButtonDown(1) && tileMap.GetTile(location) == tileArray[2])
        {
            tileMap.SetTile(location, tileArray[0]);
            Instantiate(fruitPrefab, tileMap.CellToWorld(location), Quaternion.identity);
            
        }
        if(Input.mouseScrollDelta.y > 0){
            selector++; 
                if(selector > tileArray.Length - 1){
                    selector = 0; 
                }
        }
        if(Input.mouseScrollDelta.y < 0){
            selector--;
            if(selector < 0){
                selector = tileArray.Length - 1; 

            }
        }
        switch(selector){
            case 0: 
                selectedTile = tileArray[0]; 
                break; 
            case 1: 
                selectedTile = tileArray[1]; 
                break; 
            case 2: 
                selectedTile = tileArray[2]; 
                break; 
        }

    }
    

}



