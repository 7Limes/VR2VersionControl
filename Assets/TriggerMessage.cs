using UnityEngine;
using TMPro;
using System.Collections;

public class TriggerMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public TMP_Text countdownText;

    private bool triggered = false;
    private float countdownTime = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;

            FreezePlayer(other.gameObject);
            messagePanel.SetActive(true);

            StartCoroutine(CountdownAndEnd());
        }
    }

    void FreezePlayer(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        
    }

    IEnumerator CountdownAndEnd()
    {
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            countdownText.text = "Game ends in " + Mathf.Ceil(timeLeft);
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
