using StarterAssets;
using UnityEngine;

public class PlayerTrampolineBounce : MonoBehaviour
{
    [SerializeField] private float bounceThreshold = 3.0f;

    ThirdPersonController controller;
    void Start()
    {
        controller = GetComponent<ThirdPersonController>();
    }

    public void DoBounce()
    {   
        if (Mathf.Abs(controller.verticalVelocity) >= bounceThreshold)
        {
            controller.verticalVelocity = -controller.verticalVelocity;
        }
    }
}
