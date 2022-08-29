using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isWalkable;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;

    public int gridPosX;
    public int gridPosY;

    public Node parent;

    public Node(bool _isWalkable, Vector3 _worldPos, int _gridPosX, int _gridPosY)
    {
        isWalkable = _isWalkable;
        worldPosition = _worldPos;
        gridPosX = _gridPosX;
        gridPosY = _gridPosY;
    }

    public int fCost
    {
        get { return gCost + hCost; }
    }
}
