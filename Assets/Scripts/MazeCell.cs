using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Usual,
    Finish,
    Dead
}

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _bottomWall;
    [SerializeField] private List<Transform> buildings;

    public void RemoveComponents(GeneratorCell cell)
    {
        if (!cell.leftWall)
            _leftWall.SetActive(false);
        if (!cell.bottomWall)
            _bottomWall.SetActive(false);
        if (!cell.floor)
            _floor.SetActive(false);
        if (cell.cellType == CellType.Dead)
        {
            buildings[Random.Range(0, buildings.Count)].gameObject.SetActive(true);
        }
    }

}
