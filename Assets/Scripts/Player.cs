using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private MazeSpawner _mazeSpawn;
    [SerializeField] private PlayerMoving _playerMoving;
    [SerializeField] private CubeExplotion _cube;
    [SerializeField] private Animations _animations;
    [SerializeField] private PlayerCollision _playerCollision;

    private void Awake()
    {
        _playerMoving.enabled = false;
        _animations = GetComponent<Animations>();
    }

    private void OnEnable()
    {
        _playerCollision.deadCellTouched += Die;
        _playerCollision.finishCellTouched += Finish;
        _mazeSpawn.mazeIsMade += StartMove;
    }

    private void OnDisable()
    {
        _playerCollision.deadCellTouched -= Die;
        _playerCollision.finishCellTouched -= Finish;
        _mazeSpawn.mazeIsMade -= StartMove;
    }

    private void Die()
    {
        Debug.Log("Dead");
        _playerMoving.enabled = false;
        _cube.Explode();
        _cube.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Finish()
    {
        _animations = GetComponent<Animations>();
        _animations.StartConfetti();
    }

    public void StartUnDamageable()
    {
        StartCoroutine(UnDamageable());
    }

    private IEnumerator UnDamageable()
    {
        _collision.SetDamageable(false);
        _animations.SetUndamageableMaterial();
        yield return new WaitForSeconds(2);
        _collision.SetDamageable(true);
        _animations.SetDefaultMaterial();
    }


    public void Damageable()
    {
        _collision.SetDamageable(true);
        _animations.SetDefaultMaterial();
    }

    private void StartMove()
    {
        _playerMoving.enabled = true;
    }
}
