using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Make sure to add this for working with UI elements
using TMPro;
using UnityEngine.SceneManagement; // Add this namespace for scene management

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] string sceneToLoad = "Popup"; // Correct way to reference a scene name
    [SerializeField] TextMeshProUGUI warningText;
    private int countdownTime = 5; // Start countdown from 5
    private Coroutine countdownCoroutine; // To store the reference to the coroutine
    private bool Completed = false;

    // Start is called before the first frame update
    void Start()
    {
        warningText.text = "";
        
        // Ensure countdown text is initialized properly
        if (countdownText != null)
        {
            countdownText.text = countdownTime.ToString();
            StartCountdown(); // Start the countdown when the game starts
        }
        else
        {
            Debug.LogError("Countdown Text is not assigned!");
        }
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        // Stop any running countdown coroutine
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        // Reset countdown time
        countdownTime = 5;
        
        // Reset the UI text
        countdownText.text = countdownTime.ToString();
        warningText.text = ""; // Clear the warning text

        // Restart the countdown
        StartCountdown();
    }

    // Method to start the countdown coroutine
    void StartCountdown()
    {
        countdownCoroutine = StartCoroutine(CountdownCoroutine());
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
        countdownText.text = "";
        warningText.text = "Waktu Habis!";
        
        // After countdown finishes, load the specified scene
        Debug.Log("scenetoload");
        if (!Completed){
            SceneManager.LoadScene(sceneToLoad);
        } else {
            SceneManager.LoadScene("Statistik");
        }
    }

    public void ModuleComplete(){
        Completed = true;
    }
}
