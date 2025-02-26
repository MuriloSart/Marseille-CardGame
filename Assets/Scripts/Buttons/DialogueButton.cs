using TMPro;
using SOScript;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public DataTexts data;

    [SerializeField]private TextMeshProUGUI dialogueBox;

    private int currentDialogue = 0;

    public int CurrentDialogue
    {
        get => currentDialogue;
        set
        {
            if (value > data.dialogues.Count)
                CurrentDialogue = currentDialogue;
            else if (value < 0)
                currentDialogue = 0;
            else
                currentDialogue = value;
        }
    }

    public void NextText()
    {
        CurrentDialogue++;
        SetText();
    }

    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        dialogueBox.text = data.dialogues[CurrentDialogue];
    }
}
