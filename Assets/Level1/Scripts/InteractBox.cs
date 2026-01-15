using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractBox : MonoBehaviour
{
    [SerializeField] private string interactPrompt = "Press E to do something";
    [SerializeField] private UnityEvent interactEvent;

    [SerializeField] private bool oneShot = true;

    bool canInteract = false;
    bool activated = false;

    TextMeshProUGUI interactLabel;

    void Start()
    {
        GameObject interactLabelObject = GameObject.FindGameObjectWithTag("InteractLabel");
        interactLabel = interactLabelObject.GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
        {   
            if (!oneShot || (oneShot && !activated))
            {
                interactEvent.Invoke();
                activated = true;
                interactPrompt = "";
                interactLabel.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        canInteract = true;
        interactLabel.text = interactPrompt;
    }

    void OnTriggerExit(Collider other)
    {
        canInteract = true;
        interactLabel.text = "";
    }
}
