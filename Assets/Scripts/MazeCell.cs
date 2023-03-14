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

    public void RemoveComponents(GeneratorCell cell)
    {
        if (!cell.leftWall)
            _leftWall.SetActive(false);
        if (!cell.bottomWall)
            _bottomWall.SetActive(false);
        if (!cell.floor)
            _floor.SetActive(false);
    }

}
