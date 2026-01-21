using UnityEngine;
using UnityEngine.Events;

public class TouchBox : MonoBehaviour
{
    [SerializeField] private bool oneShot = true;
    [SerializeField] private UnityEvent touchEvent;

    bool activated = false;

    void OnTriggerEnter(Collider other)
    {
        if (!oneShot || (oneShot && !activated))
        {
            touchEvent.Invoke();
            activated = true;
        }
    }
}
