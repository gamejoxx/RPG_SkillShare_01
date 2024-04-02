using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;


public class DialogController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogText, nameText;
    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] dialogLines;
    [SerializeField] int currentLine;

    public static DialogController instance;

    private bool dialogJustStarted;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Check if there are any dialog lines before setting the text and activating the dialog box
        if (dialogLines != null && dialogLines.Length > 0)
        {
            dialogText.text = dialogLines[currentLine];
        }
        else
        {
            // Optionally, hide the dialog box if there are no lines to display
            dialogBox.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!dialogJustStarted) // If the dialog didn't just start, advance to the next line.
                {
                    currentLine++;
                }
                else // If the dialog just started, don't advance to the next line yet, but clear the flag.
                {
                    dialogJustStarted = false;
                }

                if (currentLine >= dialogLines.Length) // Check if we've gone through all lines.
                {
                    dialogBox.SetActive(false);
                    dialogJustStarted = true; // Reset for the next time dialog is activated.
                    Player.instance.deactivateMovement = false;
                }
                else
                {
                    CheckForName();
                    dialogText.text = dialogLines[currentLine]; // Update the dialog text.
                }
            }
        }
    }


    public void ActivateDialog(string[] newLinesToUse)
    {
        dialogLines = newLinesToUse;
        currentLine = 0;
        
        CheckForName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);

        dialogJustStarted = true;
        Player.instance.deactivateMovement = true;
      
    }

    void CheckForName()
    {
        if (dialogLines[currentLine].StartsWith("#"))
        {
            nameText.text = dialogLines[currentLine].Replace("#", "");
            currentLine++;
        }
    }

    public bool IsDialogActive()
    {
        return dialogBox.activeInHierarchy;
    }

}
