using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    private static int MAZE_SIZE = 11;
    GeneratorCell[,] cells = new GeneratorCell[MAZE_SIZE, MAZE_SIZE];

    public GeneratorCell[,] FillMaze()
    {

        for(int i = 0; i < MAZE_SIZE; i++)
        {
            for(int j = 0; j < MAZE_SIZE; j++)
            {
                cells[i, j] = new GeneratorCell(i, j);
            }
        }
        for(int i = 0;i < MAZE_SIZE; i++)
        {
            cells[i, MAZE_SIZE - 1].leftWall = false;
        }

        for (int i = 0; i < MAZE_SIZE; i++)
        {
            cells[MAZE_SIZE, i].bottomWall = false;
        }

        return cells;
    }

    private void RemoveWalls(GeneratorCell[,] maze)
    {
        GeneratorCell current = maze[0, 0];
        current.visited = true;
        Stack<GeneratorCell> stack = new Stack<GeneratorCell>();
        do
        {
            List<GeneratorCell> unvisitedNeighbours = new List<GeneratorCell>();

            int x = (int)current.pos.x;
            int y = (int)current.pos.y;

            if (x > 0 && !maze[x - 1, y].visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < MAZE_SIZE - 2 && !maze[x + 1, y].visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < MAZE_SIZE - 2 && !maze[x, y + 1].visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0)
            {
                GeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.visited = true;
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
        if (a.pos.x == b.pos.x)
        {
            if (a.pos.y > b.pos.y) a.bottomWall = false;
            else b.bottomWall = false;
        }
        else
        {
            if (a.pos.x > b.pos.x) a.leftWall = false;
            else b.leftWall = false;
        }
    }
}
