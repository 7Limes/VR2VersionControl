using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Elevator : MonoBehaviour
{
    
    [SerializeField] private float downDuration = 5.0f;
    [SerializeField] private float upDuration = 10.0f;
    [SerializeField] private Transform downPoint;

    bool isMoving = false;
    float moveTimer = 0.0f;
    float moveDuration;
    Vector3 currentPoint, targetPoint;

    void Start()
    {
        moveDuration = downDuration;
        currentPoint = transform.position;
        targetPoint = downPoint.position;
    }

    public void DoMove()
    {
        if (!isMoving)
        {
            isMoving = true;
            moveTimer = 0.0f;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            float t = moveTimer / moveDuration;
            transform.position = Vector3.Lerp(currentPoint, targetPoint, t);

            moveTimer = Mathf.MoveTowards(moveTimer, moveDuration, Time.deltaTime);
            if (moveTimer == moveDuration)
            {
                isMoving = false;
                Vector3 tempPoint = currentPoint;
                currentPoint = targetPoint;
                targetPoint = tempPoint;

                moveDuration = moveDuration == downDuration ? upDuration : downDuration;
            }
        }
    }
}
