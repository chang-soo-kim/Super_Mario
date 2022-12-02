using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Wall : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    public Player player;
  




    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void MakeDot (Vector3 Pos)
    {
       
        
        Vector3Int cellPosition = tilemap.WorldToCell(Pos);
        tilemap.SetTile(cellPosition, null);
        Debug.Log(cellPosition);
    }

    // Update is called once per frame
    void Update()
    { 
      
    }
}
