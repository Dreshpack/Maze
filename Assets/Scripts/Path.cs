using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public MazeSpawner mazeSpaw;
    [SerializeField] private LineRenderer _lineRenderer;

    private Vector3Int _pathBegin = new Vector3Int(9, 0, 9);
    public List<Vector3> positions = new List<Vector3>();

    public void DrawPath()
    {
        Maze maze = mazeSpaw.Maze;
        int x = _pathBegin.x;
        int z = _pathBegin.z;

        while ((x != 0 || z != 0) && positions.Count < 100)
        {
            positions.Add(new Vector3(x * mazeSpaw.CellSize.x, 1, z * mazeSpaw.CellSize.z));
            GeneratorCell currentCell = maze.cells[x, z];
            mazeSpaw.Maze.cellsOnWay.Add(currentCell);
            if (x > 0 &&
            !currentCell.leftWall &&
            maze.cells[x - 1, z].distanceFromStart < currentCell.distanceFromStart)
            {
                x--;
            }
            else if (z > 0 &&
                !currentCell.bottomWall &&
                maze.cells[x, z - 1].distanceFromStart < currentCell.distanceFromStart)
            {
                z--;
            }
            else if (x < maze.cells.GetLength(0) - 1 &&
                !maze.cells[x + 1, z].leftWall &&
                maze.cells[x + 1, z].distanceFromStart < currentCell.distanceFromStart)
            {
                x++;
            }
            else if (z < maze.cells.GetLength(1) - 1 &&
                !maze.cells[x, z + 1].bottomWall &&
                maze.cells[x, z + 1].distanceFromStart < currentCell.distanceFromStart)
            {
                z++;
            }
        }
        positions.Add(Vector3.zero);
        _lineRenderer.positionCount = positions.Count;
        _lineRenderer.SetPositions(positions.ToArray());

    }

   // private 

    private void Start()
    {
    }
}
