using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class BelajarMechanism : MonoBehaviour
{
    private GameObject[] childObjects;
    private int currentActiveIndex = 0;

    // POP UP Management
    // [SerializeField] string mainSceneName = "Challenge";
    // [SerializeField] string overlaySceneName = "Popup";

    // Start is called before the first frame update
    void Start()
    {
        // Get all children and store them in an array
        int childCount = transform.childCount;
        childObjects = new GameObject[childCount];
        
        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            // Deactivate all children initially
            childObjects[i].SetActive(false);
        }
        
        // Activate only the first child if we have any children
        if (childObjects.Length > 0)
        {
            childObjects[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this method from a button's OnClick event
    public void NextObject()
    {
        Debug.Log("NextObject");
        // Deactivate current object
        if (childObjects.Length > 0)
        {
            childObjects[currentActiveIndex].SetActive(false);
            
            // Move to next index (loop back to 0 if we reach the end)
            currentActiveIndex = (currentActiveIndex + 1) % childObjects.Length;
            
            // Activate new current object
            childObjects[currentActiveIndex].SetActive(true);
        } 
        else 
        {
            EndModule();
            // OpenPopUp();
        }
    }
    
    // Call this method from a button's OnClick event
    public void PreviousObject()
    {
        // Deactivate current object
        if (childObjects.Length > 0)
        {
            childObjects[currentActiveIndex].SetActive(false);
            
            // Move to previous index (loop to the end if we're at 0)
            currentActiveIndex = (currentActiveIndex - 1 + childObjects.Length) % childObjects.Length;
            
            // Activate new current object
            childObjects[currentActiveIndex].SetActive(true);
        }
    }
    
    // Optionally: Jump to a specific object by index
    public void JumpToObject(int index)
    {
        if (childObjects.Length > 0 && index >= 0 && index < childObjects.Length)
        {
            // Deactivate current object
            childObjects[currentActiveIndex].SetActive(false);
            
            // Set new index
            currentActiveIndex = index;
            
            // Activate new current object
            childObjects[currentActiveIndex].SetActive(true);
        }
    }

    public void ActivateAllChildren()
    {
        Debug.Log("Activate all children");
        // Iterate through all child objects in the childObjects array
        foreach (GameObject child in childObjects)
        {
            // Iterate through the sub-children of each child
            foreach (Transform subChild in child.transform) // Using Transform to access child objects
            {
                Debug.Log("Checking child: " + subChild.name);
                if (subChild.name == "GhostHands")
                {
                    Debug.Log("Activated");
                    subChild.gameObject.SetActive(true); // Set each sub-child to active
                }
                else
                {
                    subChild.gameObject.SetActive(true); // Optionally, activate other sub-children as well
                }
            }
        }
    }

    // Selesai
    public void EndModule(){
        Debug.Log("End of Module");
    }

    public void OpenPopUp(){
        // SceneManager.LoadScene(overlaySceneName, LoadSceneMode.Additive);
        Debug.Log("PopUp Opened");
    }
}
