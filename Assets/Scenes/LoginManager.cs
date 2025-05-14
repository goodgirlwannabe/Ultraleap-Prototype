using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField usernameInput;

    [SerializeField]
    private TMP_InputField passwordInput;

    [SerializeField]
    private TextMeshProUGUI errorMessage;

    [Tooltip("Name of the scene to load. Make sure it's added in Build Settings.")]
    public string sceneName;

    [Tooltip("Build index of the scene to load (overrides Name if >= 0).")]
    public int sceneIndex = -1;

    private void Start()
    {
        usernameInput.onValueChanged.AddListener(delegate { HideErrorMessage(); });
        passwordInput.onValueChanged.AddListener(delegate { HideErrorMessage(); });

        errorMessage.enabled = false;
    }

    public void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;
        string message = checkUserPass(username, password);

        if (string.IsNullOrEmpty(message))
        {
            Debug.Log("Login successful!");
            errorMessage.enabled = false;
            if (sceneIndex >= 0)
                SceneManager.LoadScene(sceneIndex);
            else if (!string.IsNullOrEmpty(sceneName))
                SceneManager.LoadScene(sceneName);
            else
                Debug.LogError("SceneLoader: No sceneName or valid sceneIndex set.");
        }
        else
        {
            errorMessage.text = message;
            errorMessage.enabled = true;
        }
    }

    private string checkUserPass(string uname, string pass)
    {
        if (string.IsNullOrEmpty(uname) && string.IsNullOrEmpty(pass))
        {
            return "Nama Pengguna dan password tidak boleh kosong.";
        }

        if (string.IsNullOrEmpty(uname))
        {
            return "Nama Pengguna tidak boleh kosong.";
        }

        if (string.IsNullOrEmpty(pass))
        {
            return "Password tidak boleh kosong.";
        }

        if (uname != "Admin")
        {
            return "Nama Pengguna tidak ditemukan.";
        }

        if (pass != "Admin")
        {
            return "Password salah.";
        }

        return "";
    }

    private void HideErrorMessage()
    {
        errorMessage.enabled = false;
    }
}
