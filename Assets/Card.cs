using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card: ScriptableObject
{
  public int cardID;

  public string cardName;
  public CardSprite sprite;
  public string dialogue;
  public string leftQuote;
  public string rightQuote;
//Left
  public int sheriffLeft;
  public int tHatLeft;
  public int wHatLeft;
  public int moneyLeft;

//Right
  public int sheriffRight;
  public int tHatRight;
  public int wHatRight;
  public int moneyRight;

  public void Left(){
     Debug.Log(cardName+"left");
     //appending values
      GameManager.sheriffSkills += sheriffLeft;
      GameManager.tallHatPower += tHatLeft;
      GameManager.wideHatPower += wHatLeft;
      GameManager.treasure += moneyLeft;

   }
   public void Right(){
     Debug.Log(cardName+"Right");
      GameManager.sheriffSkills += sheriffRight;
      GameManager.tallHatPower += tHatRight;
      GameManager.wideHatPower += wHatRight;
      GameManager.treasure += moneyRight;
   }
}
