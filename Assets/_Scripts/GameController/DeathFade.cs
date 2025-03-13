using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DeathFade : MonoBehaviour
{
    public float fadeDuration = 3f;
    private Image deathFadeImage;
    private float targetAlpha = 2.55f; // 100% opacity
    public DialogueBoxUIController dialogueBoxController;

    public void prepareFade()
    {
        // Find the "DeathFade" GameObject and its Image component
        GameObject deathFadeObject = GameObject.Find("DeathFade");
        if (deathFadeObject != null)
        {
            deathFadeImage = deathFadeObject.GetComponent<Image>();
            if (deathFadeImage == null)
            {
                Debug.LogError("DeathFade GameObject does not have an Image component.");
            }
        }
        else
        {
            Debug.LogError("DeathFade GameObject not found.");
        }

        // Ensure the DeathFade GameObject is enabled and the initial alpha is 0
        if (deathFadeImage != null)
        {
            deathFadeImage.gameObject.SetActive(true);
            Color initialColor = deathFadeImage.color;
            initialColor.a = 0f;
            deathFadeImage.color = initialColor;
        }
    }

    public void StartFadeIn()
    {
        if (deathFadeImage != null)
        {
            StartCoroutine(FadeInCoroutine());
        }
    }

    IEnumerator FadeInCoroutine()
    {
        dialogueBoxController.HideDialogue();
        float elapsedTime = 0f;
        Color startColor = deathFadeImage.color;
        Color endColor = startColor;
        endColor.a = targetAlpha;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            deathFadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            yield return null;
        }

        deathFadeImage.color = endColor; // Ensure the final alpha is exactly 1
    }
}