using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaqueBehaviour : MonoBehaviour
{
    [Tooltip("The Image component to change - leave empty if this GameObject has the Image component")]
    public Image targetImage;
    
    [Tooltip("Gray color in hex format - default is 3F3F3F")]
    public Color startColor = new Color(0.247f, 0.247f, 0.247f); // 3F3F3F in RGB
    
    [Tooltip("Green color for correct state")]
    public Color correctColor = Color.green;
    
    // Start is called before the first frame update
    void Start()
    {
        // If no target image is assigned, try to get one from this GameObject
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
            if (targetImage == null)
            {
                Debug.LogError("PlaqueBehaviour: No Image component found. Please add one or assign a target Image.");
                return;
            }
        }
        
        // Set the initial color to gray (3F3F3F)
        targetImage.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method to change the color to green (only if active)
    public void Correct()
    {
        // Only change color if this GameObject is active
        if (gameObject.activeInHierarchy)
        {
            if (targetImage != null)
            {
                targetImage.color = correctColor;
                Debug.Log("PlaqueBehaviour: Changed to correct (green) color");
            }
            else
            {
                Debug.LogWarning("PlaqueBehaviour: Can't change color - no Image component found");
            }
        }
        else
        {
            Debug.Log("PlaqueBehaviour: GameObject is not active, color not changed");
        }
    }
    
    // Call this method to reset back to the gray color
    public void Reset()
    {
        if (targetImage != null)
        {
            targetImage.color = startColor;
            Debug.Log("PlaqueBehaviour: Reset to start color");
        }
    }
}
