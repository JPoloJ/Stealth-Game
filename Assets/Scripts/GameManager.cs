using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        HandleGlobalInput();
    }

    private void HandleGlobalInput()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Title")
            {
                OnStart();
            }
            else if (currentScene == "Gameplay")
            {
                OnRestart();
            }
            else if (currentScene == "Ending")
            {
                OnRestart();
            }
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Title")
            {
                OnExit();
            }
            else if (currentScene == "Gameplay" || currentScene == "Ending")
            {
                ReturnToTitle();
            }
        }
    }

    public void OnStart()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SceneManager.LoadScene("Gameplay");
        }
        else if (SceneManager.GetActiveScene().name == "Ending")
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnExit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
