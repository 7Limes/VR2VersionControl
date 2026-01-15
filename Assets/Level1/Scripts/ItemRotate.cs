using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotateAxis = Vector3.up;
    [SerializeField] private float rotateSpeed = 2f;

    void Update()
    {
        transform.Rotate(rotateAxis, rotateSpeed * Time.deltaTime);
    }
}
