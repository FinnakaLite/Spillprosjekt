using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadSceneAsync(("OWNSide"));
   }

       public void QuitGame()
    {
        // If running in the editor, stop play mode
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();  // Quit the game in a built application
        #endif
    }
}
