using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private BoxCollider playerCollider;

    private bool _damageable = true;

    public static Action finishCellTouched;
    public static Action deadCellTouched;

    public void SetDamageable(bool dam)
    {
        _damageable = dam;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("waypoint"))
        {
            if (other.gameObject.CompareTag("FinishCell"))
            {
                finishCellTouched?.Invoke();
            }
            else if (other.gameObject.CompareTag("DeadCell") && _damageable)
            {
                deadCellTouched?.Invoke();
            }
        }
    }
}
