using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private string sentence;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        sentence = "";
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with "+dialogue.name);
        sentence = dialogue.sentence;
        DisplaySentence();
    }

    public void DisplaySentence()
    {
        Debug.Log("Sentence = "+ sentence);
        text.text = sentence;
    }

    public void EndDialog()
    {
        Debug.Log("End of Conversation");
    }
}
