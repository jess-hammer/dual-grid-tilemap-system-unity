using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Tilemaps;
using static TileType;

public class DualGridTilemap : MonoBehaviour {
    public Tilemap placeholderTilemap;
    public Tilemap displayTilemap;
    protected static Vector3Int[] NEIGHBOURS = new Vector3Int[] {
        new Vector3Int(0, 0, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 1, 0)
    };

    public Tile grassPlaceholderTile;
    public Tile dirtPlaceholderTile;

    // Provide the 16 tiles in the inspector
    public Tile[] tiles;

    protected static Dictionary<Tuple<TileType, TileType, TileType, TileType>, Tile> neighbourTupleToAtlasCoord;

    void Start() {
        neighbourTupleToAtlasCoord = new() {
            {new (Grass, Grass, Grass, Grass), tiles[6]},
            {new (Dirt, Dirt, Dirt, Grass), tiles[13]}, // OUTER_BOTTOM_RIGHT
            {new (Dirt, Dirt, Grass, Dirt), tiles[0]}, // OUTER_BOTTOM_LEFT
            {new (Dirt, Grass, Dirt, Dirt), tiles[8]}, // OUTER_TOP_RIGHT
            {new (Grass, Dirt, Dirt, Dirt), tiles[15]}, // OUTER_TOP_LEFT
            {new (Dirt, Grass, Dirt, Grass), tiles[1]}, // EDGE_RIGHT
            {new (Grass, Dirt, Grass, Dirt), tiles[11]}, // EDGE_LEFT
            {new (Dirt, Dirt, Grass, Grass), tiles[3]}, // EDGE_BOTTOM
            {new (Grass, Grass, Dirt, Dirt), tiles[9]}, // EDGE_TOP
            {new (Dirt, Grass, Grass, Grass), tiles[5]}, // INNER_BOTTOM_RIGHT
            {new (Grass, Dirt, Grass, Grass), tiles[2]}, // INNER_BOTTOM_LEFT
            {new (Grass, Grass, Dirt, Grass), tiles[10]}, // INNER_TOP_RIGHT
            {new (Grass, Grass, Grass, Dirt), tiles[7]}, // INNER_TOP_LEFT
            {new (Dirt, Grass, Grass, Dirt), tiles[14]}, // DUAL_UP_RIGHT
            {new (Grass, Dirt, Dirt, Grass), tiles[4]}, // DUAL_DOWN_RIGHT
            {new (Dirt, Dirt, Dirt, Dirt), tiles[12]},
        };
        RefreshDisplayLayer();
    }

    private TileType getTileTypeAt(Vector3Int coords) {
        if (placeholderTilemap.GetTile(coords) == grassPlaceholderTile)
            return Grass;
        else
            return Dirt;
    }

    protected Tile calculateTile(Vector3Int coords) {
        // 4 neighbours
        TileType topLeft = getTileTypeAt(coords + new Vector3Int(0, 1, 0));
        TileType topRight = getTileTypeAt(coords + new Vector3Int(1, 1, 0));
        TileType botLeft = getTileTypeAt(coords + new Vector3Int(0, 0, 0));
        TileType botRight = getTileTypeAt(coords + new Vector3Int(1, 0, 0));

        Tuple<TileType, TileType, TileType, TileType> neighbourTuple = new(topLeft, topRight, botLeft, botRight);

        return neighbourTupleToAtlasCoord[neighbourTuple];
    }

    protected void setDisplayTile(Vector3Int pos) {
        for (int i = 0; i < NEIGHBOURS.Length; i++) {
            Vector3Int newPos = pos + NEIGHBOURS[i];
            displayTilemap.SetTile(newPos, calculateTile(newPos));
        }
    }

    public void RefreshDisplayLayer() {
        for (int i = -50; i < 50; i++) {
            for (int j = -50; j < 50; j++) {
                setDisplayTile(new Vector3Int(i, j, 0));
            }
        }
    }
}

public enum TileType {
    None,
    Grass,
    Dirt
}
