using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze 
{
    public GeneratorCell[,] cells;
    public List<GeneratorCell> cellsOnWay = new List<GeneratorCell>();
    public Maze(int size)
    {
        cells = new GeneratorCell[size, size];
    }

}
