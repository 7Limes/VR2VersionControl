using UnityEngine;
using TMPro;

public class ContinueMessage : MonoBehaviour
{
    [Header("UI")]
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;

    [Header("Message")]
    [TextArea]
    public string message = "Press SPACE to continue";

    [Header("Input")]
    public KeyCode continueKey = KeyCode.Space;

    [Header("Settings")]
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
        messageText.text = message;

        Time.timeScale = 0f; // Pause game
        isShowing = true;
    }

    void HideMessage()
    {
        messagePanel.SetActive(false);

        Time.timeScale = 1f; // Resume game
        isShowing = false;
    }
}
