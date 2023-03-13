using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _bottomWall;

    public Vector3 _pos;
    public MazeCell(int xPos, int zPos)
    {
        _pos = new Vector3(xPos, 0, zPos);
    }

}
