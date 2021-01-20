using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialText : MonoBehaviour
{
    public TextMeshProUGUI tutorialText1;

    void Start()
    {
        //tutorialText1.text = "Testing.";
        Invoke("DisableText", 5f); //Invoke after 3 seconds
        Invoke("ObjectiveText", 6f);
        Invoke("EnableText", 7f);

        Invoke("DisableText",13f);
        Invoke("ScoringText", 14f);
        Invoke("EnableText", 15f);

        Invoke("DisableText", 20f);
        Invoke("AttackText", 21f);
        Invoke("EnableText", 22f);

        Invoke("DisableText", 42f);
        Invoke("DeflectText", 43f);
        Invoke("EnableText", 44f);

        Invoke("DisableText", 64f);
        Invoke("JumpText", 65f);
        Invoke("EnableText", 66f);

        Invoke("DisableText", 86f);
        Invoke("BonusText", 87f);
        Invoke("EnableText", 88f);

        Invoke("DisableText", 94f);
        Invoke("ColorText", 95f);
        Invoke("EnableText", 96f);

        Invoke("DisableText", 102f);
        Invoke("FreeText", 103f);
        Invoke("EnableText", 104f);

        Invoke("DisableText", 106f);
    }
    void DisableText()
    {
        //tutorialText1.faceColor = Color.Lerp(tutorialText1.color, Color.clear, fadeSpeed * Time.deltaTime);
        Debug.Log("Fade");
        tutorialText1.faceColor = new Color(0, 0, 0, 0);
    }

    void EnableText()
    {
        Debug.Log("Enable");
        tutorialText1.faceColor = new Color(255, 255, 255, 255);
    }

    void ObjectiveText()
    {
        tutorialText1.text = "Your goal is to stop the incoming enemies.";
    }

    void ScoringText()
    {
        tutorialText1.text = "Try to hit the enemies in the middle of your buttons.";
    }

    void AttackText()
    {
        tutorialText1.text = "Press Q to hit the Yellow Enemies at the Top.";
    }

    void DeflectText()
    {
        tutorialText1.text = "Press E to hit the Purple Enemies in the Middle.";
    }

    void JumpText()
    {
        tutorialText1.text = "Press W to jump over the Green Obstacles at the Bottom.";
    }

    void BonusText()
    {
        tutorialText1.text = "The more you hit in a row, the better your score.";
    }

    void ColorText()
    {
        tutorialText1.text = "Blue hits are perfect, Gold hits are Good, Purple hits are normal.";
    }

    void FreeText()
    {
        tutorialText1.text = "Try to hit all of them! Good Luck!";
    }
}
