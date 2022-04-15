using System;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogText, nameText;
    [SerializeField] private GameObject dialogBox, nameBox;

    [SerializeField] private String[] dialogSentences;
    [SerializeField] private int currentSentence;


    public static DialogController instance;

    private bool dialogJustStarted;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogText.text = dialogSentences[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!dialogJustStarted)
                {
                    
                    currentSentence++;
                    if (currentSentence >= dialogSentences.Length)
                    {
                        dialogBox.SetActive(false);
                        GameManager.instance.dialogBoxOpened = false;
                    }
                    else
                    {
                        CheckForName();
                        dialogText.text = dialogSentences[currentSentence];
                    }
                }
                else
                {
                    dialogJustStarted = false;
                }
                
            }
        }
    }


    public void ActivateDialog(string[] newSentencesToUse)
    {
        dialogSentences = newSentencesToUse;
        currentSentence = 0;
        GameManager.instance.dialogBoxOpened = true;

        CheckForName();
        dialogText.text = dialogSentences[currentSentence];
        dialogBox.SetActive(true);
        dialogJustStarted = true;
    }

    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }

    private void CheckForName()
    {
        if (dialogSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }
}
