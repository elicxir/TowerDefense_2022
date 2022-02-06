using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grid_Terrain : MonoBehaviour
{
    [SerializeField] Tilemap terrain;

    [SerializeField] TileBase[] tiles;

    public bool isWall(Vector2Int position)
    {
        Vector3Int P=(Vector3Int)position;
        
        if (terrain.HasTile(P))
        {
            TileBase tile = terrain.GetTile(P);

            if (tile == tiles[0])
            {
                return false;

            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }

        return true;
    }

}
