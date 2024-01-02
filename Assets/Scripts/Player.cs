using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private MazeSpawner _mazeSpawn;
    [SerializeField] private PlayerMoving _playerMoving;
    [SerializeField] private Animations _animations;
    [SerializeField] private PlayerCollision _playerCollision;

    private float fuel;


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
       //UIController.Start += StartMove;
        //StartMove();
    }

    private void OnDisable()
    {
        _playerCollision.deadCellTouched -= Die;
        _playerCollision.finishCellTouched -= Finish;
        _mazeSpawn.mazeIsMade -= StartMove;
        //UIController.Start -= StartMove;
    }

    private void Die()
    {
        Debug.Log("Dead");
        _playerMoving.enabled = false;
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
        _playerMoving.UpPlane(true);
        yield return new WaitForSeconds(2);
        _playerMoving.UpPlane(false);
    }


    public void Damageable()
    {
        _collision.SetDamageable(true);
        _playerMoving.UpPlane(false);
        _animations.SetDefaultMaterial();
    }

    private void StartMove()
    {
        _playerMoving.enabled = true;
    }
}
