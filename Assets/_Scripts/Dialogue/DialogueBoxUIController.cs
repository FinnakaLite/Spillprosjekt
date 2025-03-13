using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxUIController : MonoBehaviour
{
    [Header("References")]
    // Reference to the UI Image component that displays the dialogue.
    public Image dialogueImage;

    [Header("Dialogue Sprites")]
    // Populate this array with your dialogue PNG sprites.
    // The order should match your intended dialogue numbering (Dialogue 1 at index 0, etc.).
    public Sprite[] dialogueSprites; 

    void Awake()
    {
        // Auto-assign the Image component if not set
        if (dialogueImage == null)
        {
            dialogueImage = GetComponent<Image>();
            if (dialogueImage == null)
            {
                Debug.LogError("DialogueBoxUIController: No Image component found on this GameObject. Please assign one in the Inspector.", this);
            }
        }
        
        // Ensure the dialogue box is hidden at startup so it doesn't appear as a white box.
        HideDialogue();
    }

    /// <summary>
    /// Displays the dialogue by setting the image sprite and enabling the Image component.
    /// </summary>
    /// <param name="dialogueNumber">Dialogue number (1 to dialogueSprites.Length)</param>
    public void ShowDialogue(int dialogueNumber)
    {
        int index = dialogueNumber - 1; // Adjusting for 0-based indexing
        if (index < 0 || index >= dialogueSprites.Length)
        {
            Debug.LogError("Dialogue number " + dialogueNumber + " is out of range.");
            return;
        }

        if (dialogueImage == null)
        {
            Debug.LogError("DialogueBoxUIController: dialogueImage reference is missing!");
            return;
        }

        // Assign the dialogue sprite
        dialogueImage.sprite = dialogueSprites[index];
        // Enable the Image component to display the sprite
        dialogueImage.enabled = true;
    }

    /// <summary>
    /// Hides the dialogue box.
    /// </summary>
    public void HideDialogue()
    {
        if (dialogueImage == null)
        {
            Debug.LogError("DialogueBoxUIController: dialogueImage reference is missing!");
            return;
        }

        // Clear the sprite so nothing is rendered,
        // then disable the Image component.
        dialogueImage.sprite = null;
        dialogueImage.enabled = false;
    }
}