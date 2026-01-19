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

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            bool activateOneshot = oneShot && !activated;
            if (!oneShot || activateOneshot)
            {
                interactEvent.Invoke();
                activated = true;
            }

            if (activateOneshot)
            {
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
        canInteract = false;
        interactLabel.text = "";
    }
}
