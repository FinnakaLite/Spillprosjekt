using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private int levelNumber;
    private void Start()
    {
        MusicManager.Instance.PlayMusic("example-music");
    }

    public void Play()
    {
        // Find the GameObject with the GameController script
        GameObject gameControllerObject = GameObject.Find("GameController"); // Or use a public GameObject variable assigned in the Inspector
        if (gameControllerObject != null)
        {
            // Get the GameController component
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            if (gameController != null)
            {
                // Call the Death function
                gameController.Nextlevel(levelNumber);
            }
            else
            {
                Debug.LogError("GameController component not found on GameController GameObject.");
            }
        }
        else
        {
            Debug.LogError("GameController GameObject not found.");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}


