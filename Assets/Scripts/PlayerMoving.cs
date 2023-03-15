using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _waypoint;

    private int _index;
    private Vector3[] _pathDots;
    private List<Vector3> _dotsList = new List<Vector3>();

    private void Start()
    {
        _dotsList = _path.positions;
        _pathDots = _dotsList.ToArray();
        _index = _pathDots.Length - 1;
        NexPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("waypoint"))
        {
            NexPoint();
        }
    }

    private void NexPoint()
    {
        if (_index > 0)
        {
            _index--;
            _waypoint.position = _pathDots[_index];
        }

    }

    public void FollowPath()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed);
    }

    private void FixedUpdate()
    {
        FollowPath();
        //_player.position = Vector3.MoveTowards(_player.position, _pathDots[5], Time.deltaTime * speed);
    }
}
