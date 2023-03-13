using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCell : MonoBehaviour
{
    public Vector2 pos;

    public bool leftWall;
    public bool bottomWall;

    public bool visited;

    public GeneratorCell(int x, int y)
    {
        pos = new Vector2(x, y);
    }    

}
