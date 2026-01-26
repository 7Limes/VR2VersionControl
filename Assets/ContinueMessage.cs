using UnityEngine;

public class ContinueMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public MonoBehaviour playerMovementScript;
    public KeyCode continueKey = KeyCode.Space;
    public bool triggerOnce = true;

    private bool isShowing = false;
    private bool hasTriggered = false;

    void Update()
    {
        if (isShowing && Input.GetKeyDown(continueKey))
        {
            HideMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered && triggerOnce)
            return;

        if (!other.CompareTag("Player"))
            return;

        ShowMessage();
        hasTriggered = true;
    }

    void ShowMessage()
    {
        messagePanel.SetActive(true);
        playerMovementScript.enabled = false;
        Time.timeScale = 0f;
        isShowing = true;
    }

    void HideMessage()
    {
        messagePanel.SetActive(false);
        Time.timeScale = 1f;
        playerMovementScript.enabled = true;
        isShowing = false;
    }
}
