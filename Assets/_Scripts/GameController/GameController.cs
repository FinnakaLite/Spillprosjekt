using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private void Awake()
    {
        //Makes sure gamecontroller stays alive
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Initialize")
        {
            SceneManager.LoadScene("Scenes/LevelTemplate");
        }
    }
}