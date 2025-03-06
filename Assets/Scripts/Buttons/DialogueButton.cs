using TMPro;
using SOScript;
using UnityEngine;
using UnityEngine.SceneManagement;
using Save;

public class DialogueButton : MonoBehaviour
{
    public DataTexts data;

    [SerializeField]private TextMeshProUGUI dialogueBox;

    private int currentDialogue = 0;

    private int _lastLevel;

    public int CurrentDialogue
    {
        get => currentDialogue;
        set
        {
            if (value < 0)
                currentDialogue = 0;
            else
                currentDialogue = value;
        }
    }

    public void NextText()
    {
        ++CurrentDialogue;

        if (CurrentDialogue >= data.dialogues.Count) 
            SceneManager.LoadScene(_lastLevel);

        SetText();
    }

    private void Start()
    {
        SetText();
        _lastLevel = SaveManager.Instance.fileHandler.GetSetup().lastLevel;
    }

    private void SetText()
    {
        dialogueBox.text = data.dialogues[CurrentDialogue];
    }
}
