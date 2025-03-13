using System;
using System.Collections;
using System.Threading;
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
            SceneManager.LoadScene("Scenes/Startmenu");
        }
    }

    public void Death()
    {
        StartCoroutine(DoDeath());
    }

    IEnumerator DoDeath()
    {
        GameObject deathFadeObject = GameObject.Find("DeathFade"); //Find the DeathFade
        DeathFade deathFade = deathFadeObject.GetComponent<DeathFade>(); //Get the component
        deathFade.prepareFade(); //Execute the fade function
        deathFade.StartFadeIn();
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("Scenes/DeathMenu");
    }
    
    public void Replay()
    {
        //Replay function is in the game controller, to make developement of logic that knows what level the player is on. For example a death on level 2 wont sent u back to level 1.
        SceneManager.LoadScene("Scenes/OWNSide");
    }

    public void Nextlevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 0:
                SceneManager.LoadScene("OWNSide");
                break;
            case 1:
                SceneManager.LoadScene("Scenes/OWNSide 1");
                break;
            case 2:
                SceneManager.LoadScene("Scenes/Startmenu");
                break;
        }
    }
    

}

