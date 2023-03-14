using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator 
{
    private static int MAZE_SIZE = 11;

    public Maze FillMaze()
    {
       // GeneratorCell[,] cells = new GeneratorCell[MAZE_SIZE, MAZE_SIZE];
        Maze maze = new Maze(MAZE_SIZE);

        for (int i = 0; i < MAZE_SIZE; i++)
        {
            for(int j = 0; j < MAZE_SIZE; j++)
            {
                maze.cells[i, j] = new GeneratorCell(i, j);
            }
        }
        for(int i = 0;i < MAZE_SIZE; i++)
        {
            maze.cells[i, MAZE_SIZE - 1].leftWall = false;
            maze.cells[i, MAZE_SIZE - 1].floor = false;
        }

        for (int i = 0; i < MAZE_SIZE; i++)
        {
            maze.cells[MAZE_SIZE - 1, i].bottomWall = false;
            maze.cells[MAZE_SIZE - 1, i].floor = false;
        }
        maze.cells[9, 9].SetType(CellType.Finish);
        RemoveWalls(maze.cells);
        return maze;
    }

    private void RemoveWalls(GeneratorCell[,] maze)
    {
        GeneratorCell current = maze[0, 0];
        current.visited = true;

        Stack<GeneratorCell> stack = new Stack<GeneratorCell>();
        do
        {
            List<GeneratorCell> unvisitedNeighbours = new List<GeneratorCell>();

            int x = current.x;
            int z = current.z;

            if (x > 0 && !maze[x - 1, z].visited) 
                unvisitedNeighbours.Add(maze[x - 1, z]);
            if (z > 0 && !maze[x, z - 1].visited)
                unvisitedNeighbours.Add(maze[x, z - 1]);
            if (x < MAZE_SIZE - 2 && !maze[x + 1, z].visited)
                unvisitedNeighbours.Add(maze[x + 1, z]);
            if (z < MAZE_SIZE - 2 && !maze[x, z + 1].visited)
                unvisitedNeighbours.Add(maze[x, z + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                GeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.visited = true;
                chosen.distanceFromStart = current.distanceFromStart + 1;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }
        }
        while (stack.Count > 0);
    }

    private void RemoveWall(GeneratorCell a, GeneratorCell b)
    {
        if (a.x == b.x)
        {
            if (a.z > b.z) 
                a.bottomWall = false;
            else b.bottomWall = false;
        }
        else
        {
            if (a.x > b.x)
                a.leftWall = false;
            else b.leftWall = false;
        }
    }
}
