using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public MazeSpawner mazeSpaw;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform player;

    private Vector3Int _pathBegin = new Vector3Int(9, 0, 9);
    List<Vector3> positions = new List<Vector3>();
    private float speed = 1f;

    private void OnEnable()
    {
        mazeSpaw.mazeIsMade += FollowPath;
    }

    private void OnDisable()
    {
        mazeSpaw.mazeIsMade -= FollowPath;
    }

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

    public void FollowPath()
    {
        player.position = positions[positions.Count - 1];
        player.position = Vector3.MoveTowards(player.position, positions[positions.Count - 1], Time.deltaTime * speed);
        //StartCoroutine(MovingCoroutine)
    }
   /* private IEnumerator MovingCoroutine()
    {
        yield return Wait
    }*/

    private void Start()
    {
    }
}
