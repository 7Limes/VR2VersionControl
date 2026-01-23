using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public TMP_Text countdownText;

    public float freezeTime = 10f;

    public MonoBehaviour playerInputScript;

    private bool triggered = false;
    private Rigidbody playerRb;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            playerRb = other.GetComponent<Rigidbody>();

            FreezePlayer();
            DisablePlayerInput();

            messagePanel.SetActive(true);
            StartCoroutine(CountdownAndUnfreeze());
        }
    }

    void FreezePlayer()
    {
        if (playerRb != null)
        {
            playerRb.linearVelocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void UnfreezePlayer()
    {
        if (playerRb != null)
        {
            playerRb.constraints = RigidbodyConstraints.None;
            playerRb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void DisablePlayerInput()
    {
        if (playerInputScript != null)
        {
            playerInputScript.enabled = false;
        }
    }

    void EnablePlayerInput()
    {
        if (playerInputScript != null)
        {
            playerInputScript.enabled = true;
        }
    }

    IEnumerator CountdownAndUnfreeze()
    {
        float timeLeft = freezeTime;

        while (timeLeft > 0)
        {
            countdownText.text = "Try again in " + Mathf.Ceil(timeLeft);
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        messagePanel.SetActive(false);

        UnfreezePlayer();
        EnablePlayerInput();

        triggered = false; 
    }
}
