using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Settings")]
    [Tooltip("The dialogue number to show (1 to dialogueSprites.Length)")]
    [SerializeField] int dialogueNumber;
    
    [Tooltip("Reference to the DialogueBoxUIController that handles the dialogue UI.")]
    public DialogueBoxUIController dialogueBoxController;

    // When the player (or the intended object) enters the trigger collider...
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ensure that the collider belongs to the player (or any target tag you require)
        if (other.CompareTag("Player"))
        {
            if (dialogueBoxController != null)
            {
                dialogueBoxController.ShowDialogue(dialogueNumber);
            }
            else
            {
                Debug.LogError("DialogueTrigger: DialogueBoxUIController reference is missing!");
            }
        }
    }

    // When the player leaves the trigger collider...
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting collider belongs to the player.
        if (other.CompareTag("Player"))
        {
            if (dialogueBoxController != null)
            {
                dialogueBoxController.HideDialogue();
            }
            else
            {
                Debug.LogError("DialogueTrigger: DialogueBoxUIController reference is missing!");
            }
        }
    }
}