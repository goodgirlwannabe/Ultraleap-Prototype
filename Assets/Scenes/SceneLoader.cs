using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Tooltip("Name of the scene to load. Make sure it's added in Build Settings.")]
    public string sceneName;

    [Tooltip("Build index of the scene to load (overrides Name if >= 0).")]
    public int sceneIndex = -1;

    /// <summary>
    /// Call this (e.g. via a UI Button) to load the scene specified in the Inspector.
    /// </summary>
    public void LoadScene()
    {
        if (sceneIndex >= 0)
            SceneManager.LoadScene(sceneIndex);
        else if (!string.IsNullOrEmpty(sceneName))
            SceneManager.LoadScene(sceneName);
        else
            Debug.LogError("SceneLoader: No sceneName or valid sceneIndex set.");
    }

    /// <summary>
    /// Load any scene by name from code.
    /// </summary>
    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// Load any scene by build index from code.
    /// </summary>
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
