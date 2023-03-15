using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollision _collision;
    [SerializeField] private MazeSpawner _mazeSpawn;
    [SerializeField] private PlayerMoving _playerMoving;
    [SerializeField] private Material _defaultmaterial;
    [SerializeField] private Material _undamageableMaterial;
    [SerializeField] private MeshRenderer _meshRender;
    [SerializeField] private CubeExplotion _cube;

    private void Awake()
    {
        _playerMoving.enabled = false;
    }

    private void OnEnable()
    {
        PlayerCollision.deadCellTouched += Die;
        _mazeSpawn.mazeIsMade += StartMove;
    }

    private void OnDisable()
    {
        PlayerCollision.deadCellTouched -= Die;
        _mazeSpawn.mazeIsMade += StartMove;
    }

    private void Die()
    {
        Debug.Log("Dead");
        _playerMoving.enabled = false;
        _cube.Explode();
    }
    public void StartUnDamageable()
    {
        StartCoroutine(UnDamageable());
    }

    private IEnumerator UnDamageable()
    {
        _collision.SetDamageable(false);
        _meshRender.material = _undamageableMaterial;
        yield return new WaitForSeconds(2);
        _collision.SetDamageable(true);
        _meshRender.material = _defaultmaterial;
    }


    public void Damageable()
    {
        _collision.SetDamageable(true);
        _meshRender.material = _defaultmaterial;
    }

    private void StartMove()
    {
        _playerMoving.enabled = true;
    }
}
