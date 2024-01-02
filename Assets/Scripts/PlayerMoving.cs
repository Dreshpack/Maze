using System.Collections;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _waypoint;
    [SerializeField] private GameObject plane;

    private int _index;
    private Vector3[] _pathDots;
    private bool _isPaused = false;

    private bool upPlane = false;

    private void OnEnable()
    {
        
        UIController.IsPaused += PauseMovement;
        UIController.IsContinued += UnpauseMovement;
    }

    private void OnDisable()
    {
        UIController.IsPaused -= PauseMovement;
        UIController.IsContinued -= UnpauseMovement;
    }

    private void Start()
    {
        _pathDots = _path.positions.ToArray();
        _index = _pathDots.Length - 1;
        NextPoint();
    }

    public void UpPlane(bool flag)
    {
        upPlane = flag;
        if (flag)
        {
            _waypoint.position = new Vector3(_waypoint.position.x, 11, _waypoint.position.z);
        }
        else
        {
            _waypoint.position = new Vector3(_waypoint.position.x, 1.1f, _waypoint.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("waypoint"))
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        if (_index > 0)
        {
            _index--;
            _waypoint.position = _pathDots[_index];
        }
        if (upPlane)
        {
            _waypoint.position = new Vector3(_waypoint.position.x, 11, _waypoint.position.z);
        }

    }

    private void PauseMovement()
    {
        _isPaused = true;
    }

    private void UnpauseMovement()
    {
        _isPaused = false;
    }
    

    private void FollowPath()
    {
        if (!_isPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(_waypoint.position - transform.position), Time.deltaTime * 5);
        }
    }

    private void FixedUpdate()
    {
        FollowPath();
        if (upPlane)
        {
        }
    }
}
