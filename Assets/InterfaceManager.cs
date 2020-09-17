using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Card
    public GameManager gameManager;
    public GameObject card;
    // UI Icons
    public Image sheriffSkills;
    public Image tallHatPower;
     public Image wideHatPower;
     public Image treasure;
    // UI Impact Icons
    public Image sheriffSkillsImpact;
    public Image tallHatPowerImpact;
     public Image wideHatPowerImpact;
     public Image treasureImpact;

    void Update()
    {
        //UI Icons
        sheriffSkills.fillAmount = (float) GameManager.sheriffSkills / GameManager.maxValue;
        tallHatPower.fillAmount = (float) GameManager.tallHatPower / GameManager.maxValue;
        wideHatPower.fillAmount = (float) GameManager.wideHatPower / GameManager.maxValue;
        treasure.fillAmount = (float) GameManager.treasure / GameManager.maxValue;

        //UI Impact Icon
        //Right
        if(gameManager.direction =="right")
        {
            if(gameManager.currentCard.sheriffRight!=0)
                sheriffSkillsImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.tHatRight!=0)
                tallHatPowerImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.wHatRight!=0)
                wideHatPowerImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.moneyRight!=0)
                treasureImpact.transform.localScale = new Vector3(1,1,0);
        }
        //Left
        else if(gameManager.direction =="left")
        {
             if(gameManager.currentCard.sheriffLeft!=0)
                sheriffSkillsImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.tHatLeft!=0)
                tallHatPowerImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.wHatLeft!=0)
                wideHatPowerImpact.transform.localScale = new Vector3(1,1,0);
            if(gameManager.currentCard.moneyLeft!=0)
                treasureImpact.transform.localScale = new Vector3(1,1,0);
        }
        else
        {
            sheriffSkillsImpact.transform.localScale = new Vector3(0,0,0);
            tallHatPowerImpact.transform.localScale = new Vector3(0,0,0);
            wideHatPowerImpact.transform.localScale = new Vector3(0,0,0);
            treasureImpact.transform.localScale = new Vector3(0,0,0);
        }
    }
}
