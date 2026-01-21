using UnityEngine;
using UnityEngine.Events;

public class RotateBars : MonoBehaviour
{
    [SerializeField] private float fallDuration = 0.25f;
    [SerializeField] private float targetAngle = 0f;
    [SerializeField] private GameObject pivotPoint;
    [SerializeField] private Vector3 rotateAxis = Vector3.forward;

    [SerializeField] private UnityEvent onFinish = null;

    float startAngle;
    float timer;
    bool isFalling;

    public void StartRotate()
    {
        startAngle = transform.eulerAngles.x;
        timer = 0f;
        isFalling = true;
    }

    void FixedUpdate()
    {
        if (!isFalling) return;

        timer += Time.fixedDeltaTime;
        float t = Mathf.Clamp01(timer / fallDuration);

        float currentAngle = Mathf.LerpAngle(startAngle, targetAngle, t);
        float delta = currentAngle - transform.eulerAngles.x;

        transform.RotateAround(pivotPoint.transform.position, rotateAxis, delta);

        if (t >= 1f)
        {   
            isFalling = false;
            onFinish?.Invoke();
        }
    }
}