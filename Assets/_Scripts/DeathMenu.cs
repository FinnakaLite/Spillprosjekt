using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
 //   private void Start()
  //  { 
  //      MusicManager.Instance.PlayMusic("example-music");
   // }

    public void Replay()
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
                gameController.Nextlevel(2);
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


