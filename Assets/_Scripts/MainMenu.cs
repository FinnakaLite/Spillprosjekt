using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        MusicManager.Instance.PlayMusic("example-music");
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelTemplate");
    }

    public void Quit()
    {
        Application.Quit();
    }
}


