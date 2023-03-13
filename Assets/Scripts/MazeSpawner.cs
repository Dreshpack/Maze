using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField]private GameObject _cellPrefab;

    private static int _height = 11;
    private static int _width = 11;


    private MazeCell[,] _maze = new MazeCell[_height, _width];
    public void FillMaze()
    {
        MazeGenerator mazeGenerator = new MazeGenerator();
        _maze = mazeGenerator;
        for(int i = 0; i < _width; i++)
        {
            for(int j = 0; j < _height; j++)
            {
                _maze[i, j] = new MazeCell(i, j);
                Instantiate(_cellPrefab, new Vector3(i,0, j), Quaternion.identity);
            }
        }

    }

    private void Start()
    {
        FillMaze();
    }
}
