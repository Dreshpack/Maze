using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCell
{
    public int x { get; private set; }
    public int z { get; private set; }
    public int distanceFromStart { get; set; }
    public bool leftWall = true;
    public bool bottomWall = true;
    public bool floor = true;

    private CellType _cellType;

    public void SetType(CellType type)
    {
        _cellType = type;
    }

    public CellType GetCellType()
    {
        return _cellType;
    }

    public bool visited = false;

    public GeneratorCell(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

}
