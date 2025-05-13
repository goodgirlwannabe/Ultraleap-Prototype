using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to add this for working with UI elements
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    private int countdownTime = 5; // Start countdown from 5

    // Start is called before the first frame update
    void Start()
    {
        // Ensure countdown text is initialized properly
        if (countdownText != null)
        {
            countdownText.text = countdownTime.ToString();
            StartCoroutine(CountdownCoroutine());
        }
        else
        {
            Debug.LogError("Countdown Text is not assigned!");
        }
    }

    // Coroutine to handle the countdown logic
    IEnumerator CountdownCoroutine()
    {
        // Loop until the countdown reaches 0
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            countdownTime--; // Decrement the countdown
            countdownText.text = countdownTime.ToString(); // Update the text
        }

        // Optionally, display 0 when countdown finishes
        countdownText.text = "0";
    }
}
