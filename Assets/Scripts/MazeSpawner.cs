using UnityEngine;
using System;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _deadCellPrefab;
    [SerializeField] private GameObject _finishCellPrefab;
    [SerializeField] private Path _path;

    private static int _MAZE_SIZE = 11;
    public Vector3 CellSize = new Vector3(10, 0, 10);
    public Maze _maze;
    public Action mazeIsMade;

    public Maze Maze
    {
        get
        {
            return _maze;
        }
    }

    public void SelectDeathCells()
    {
        var rand = new System.Random();
        for (int i = 0; i < _maze.cellsOnWay.Count / 6; i++)
        {
            int index = rand.Next(_maze.cellsOnWay.Count - 2);
            _maze.cellsOnWay[index].SetType(CellType.Dead);
        }
        _maze.cellsOnWay[0].SetType(CellType.Finish);
    }

    public void CreateMaze()
    {
        MazeGenerator mazeGenerator = new MazeGenerator();
        _maze = mazeGenerator.FillMaze();
        _path.FindPath(this);
        SelectDeathCells();
        for (int i = 0; i < _MAZE_SIZE; i++)
        {
            for (int j = 0; j < _MAZE_SIZE; j++)
            {
                MazeCell cell;
                if (_maze.cells[i, j].GetCellType() == CellType.Finish)
                {
                    cell = Instantiate(_finishCellPrefab, new Vector3(i * CellSize.x, j * CellSize.y, j * CellSize.z), Quaternion.identity).GetComponent<MazeCell>();
                }
                else if (_maze.cells[i, j].GetCellType() == CellType.Dead)
                {

                    cell = Instantiate(_deadCellPrefab, new Vector3(i * CellSize.x, j * CellSize.y, j * CellSize.z), Quaternion.identity).GetComponent<MazeCell>();
                }
                else
                {
                    cell = Instantiate(_cellPrefab, new Vector3(i * CellSize.x, j * CellSize.y, j * CellSize.z), Quaternion.identity).GetComponent<MazeCell>();
                }
                cell.RemoveComponents(_maze.cells[i, j]);
            }
        }
        mazeIsMade?.Invoke();

    }

    private void Start()
    {
        CreateMaze();
    }
}
