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
        SceneManager.LoadScene("LevelTemplate");
    }

    public void Quit()
    {
        Application.Quit();
    }
}


