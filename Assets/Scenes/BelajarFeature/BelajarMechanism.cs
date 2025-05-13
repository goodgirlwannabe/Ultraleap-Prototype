using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelajarMechanism : MonoBehaviour
{
    private GameObject[] childObjects;
    private int currentActiveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get all children and store them in an array
        int childCount = transform.childCount;
        childObjects = new GameObject[childCount];
        
        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;

            // Activate all sub-children of each child
            for (int j = 0; j < childObjects[i].transform.childCount; j++)
            {
                GameObject child = childObjects[i].transform.GetChild(j).gameObject;
                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Challenge" && child.name == "GhostHands")
                {
                    child.SetActive(false);
                }
                else
                {
                    child.SetActive(true);
                }
            }

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

    // public void ActivateAllChildren()
    // {
    //     Debug.Log("Activate all children");
    //     // Activate all child objects
    //     foreach (GameObject child in childObjects)
    //     {
    //         foreach (GameObject childchild in child){
    //             Debug.Log("Checking child: " + childchild.name);
    //             if (childchild.name == "GhostHands")
    //             {
    //                 Debug.Log("Activated");
    //                 childchild.SetActive(true); // Set each child to active
    //             }
    //         }
    //     }
    // }


    // Call this method from a button's OnClick event
    public void NextObject()
    {
        Debug.Log("current active index: " + currentActiveIndex);
        // Deactivate current object
        if (childObjects.Length > 0 && currentActiveIndex < childObjects.Length-1)
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

    // Selesai
    public void EndModule(){
        Debug.Log("End of Module");
    }
}
