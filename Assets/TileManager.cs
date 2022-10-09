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



    // Start is called before the first frame update
    void Start()
    {
        selector = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tileMap.WorldToCell(mousePoint);
            Debug.Log(location);
            tileMap.SetTile(location, selectedTile);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = tileMap.WorldToCell(mousePoint);
            Debug.Log(location);
            tileBase = tileMap.GetTile(location);
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
        }

    }
    

}



