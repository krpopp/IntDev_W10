using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //these lists have all the dialogue for each phase of questions
    public List<string> phaseOneDialogue;
    public List<string> phaseTwoDialogue;
    public List<string> phaseThreeDialogue;
    public List<string> phaseFourDialogue;
    public List<string> phaseFiveDialogue;

    //holds the phase we're currently going through
    List<string> currentDialogue;

    //tracks the current phase and the line we're on in that phase
    int phaseIndex = 0;
    int dialogueIndex = 0;

    //game object for all buttons
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    //text component that is showing the dialogue
    public TMP_Text dialogueBox;

    public string clownMessage;
    public string notAClownMessage;

    //"score" for how much of a clown u r
    int clownyLove = 0;

    // Start is called before the first frame update
    void Start()
    {
        //turn off the choice buttons
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        //start the dialogue
        currentDialogue = phaseOneDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];
    }

    void SetDialogueText()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 4)
        {
            //set the dialogue component to show the line we're on
            dialogueBox.text = currentDialogue[dialogueIndex];
        }
    }

    public void AdvanceDialog()
    {
        //if we haven't gotten our results yet
        if (phaseIndex < 4)
        {
            //go to the next line
            dialogueIndex++;
            SetDialogueText();
            //if we're on the last line of dialogue
            if (dialogueIndex == currentDialogue.Count - 1)
            {
                //show the choices
                SetupChoices();
            }
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }

    void SetupChoices()
    {
        //turn off the next button and turn on the choice buttons
        nextButton.SetActive(false);
        choiceOne.SetActive(true);
        choiceTwo.SetActive(true);
    }

    public void FaceyChoice()
    {
        //if we press "no", just go to the next phase of questions
        GoToNextPhase();
    }

    public void ClownyChoice()
    {
        //if we press "yes", increase clowny's score and then go to the next phase
        clownyLove++;
        GoToNextPhase();
    }

    void GoToNextPhase()
    {
        //turn on the next button and turn off the choice buttons
        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        //reset the dialogue line counter
        dialogueIndex = 0;
        //depending on the phase
        //run an animation and determine what the next phase is
        switch (phaseIndex)
        {
            case 0:
                currentDialogue = phaseTwoDialogue;
                phaseIndex = 1;
                break;
            case 1:
                currentDialogue = phaseThreeDialogue;
                phaseIndex = 2;
                break;
            case 2:
                currentDialogue = phaseFourDialogue;
                phaseIndex = 3;
                break;
            case 3:
                currentDialogue = phaseFiveDialogue;
                phaseIndex = 4;
                GiveResults();
                break;
        }
        SetDialogueText();
    }

    void GiveResults() {
        if(clownyLove > 2)
        {
            dialogueBox.text = clownMessage;
        }
        else
        {
            dialogueBox.text = notAClownMessage;
        }
    }

}
