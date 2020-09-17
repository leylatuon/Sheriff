using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
  //Icon Values
  public static int sheriffSkills = 20;
  public static int tallHatPower = 20;
  public static int wideHatPower = 20;
  public static int treasure = 20;
  public static int maxValue=100;
  public int minValue=0;
    // Start is called before the first frame update
    public GameObject cardGameObject;
    public GameObject pendingCardGameObject;
    public SpriteRenderer cardSpriteRenderer;
    public CardController mainCardController;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;
    public Vector3 cardRotation;
    //tweakable variables
    public float fMovingSpeed;
    public float fRotatingSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backgroundDivideValue;
    public float fRoatationCoefficient;
    float alphaText;
    public Card currentCard;
    public Card testCard;
    public Color textColor;
    public Color actionBackgroundColor;
    public float ftransparency=0.5f;
    public TMP_Text gameStatus;
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text actionQuote;
    public TMP_Text characterName;
    public SpriteRenderer actionBackground;
    public string direction;
    Vector3 pos;
    private string leftQuote;
    private string rightQuote;
    //Subsitute
    public bool isSubstituting = false;
    public Vector3 currentRotation;
    public Vector3 initRotation;


    void Start()
    {
      LoadCard(testCard);
    }
    void UpdateDialogue(){
      actionQuote.color = textColor;
      actionBackground.color=actionBackgroundColor;
      if(cardGameObject.transform.position.x < 0){
        actionQuote.text= leftQuote;

      }
      else{
        actionQuote.text= rightQuote;

      }
    }

    // Update is called once per frame
    void Update()
    {
      //icon values

      if (sheriffSkills==100 ){
        gameStatus.text="Game Over you became too powerful";
      }
      else if (sheriffSkills==0){
        gameStatus.text="Game Over you were too weak";
      }
      else if (tallHatPower==100){
        gameStatus.text="Game Over the catus hats became too powerful";
      }
      else if (tallHatPower==0){
        gameStatus.text="Game Over a catus hat mob overthrows you ";
      }
      else if (wideHatPower==100){
        gameStatus.text="Game Over the flower hats became too powerful";
      }
      else if (wideHatPower==0) {
        gameStatus.text="Game Over a flower hat mob overthrows you ";
      }
      else if (treasure==100){
        gameStatus.text="Game Over you became too corrupt";
      }
      else if (treasure==0){
        gameStatus.text="Game Over you had to file for bankrupcy";
      }
      else {
          gameStatus.text="";
      }

      //dialogue text handling
      textColor.a = Mathf.Min((Mathf.Sqrt(Mathf.Abs(cardGameObject.transform.position.x)-fSideMargin)/divideValue),1);
      actionBackgroundColor.a =  Mathf.Min((Mathf.Sqrt(Mathf.Abs(cardGameObject.transform.position.x)-fSideMargin)/backgroundDivideValue),ftransparency);

      if(cardGameObject.transform.position.x >fSideTrigger){
        direction = "right";
        actionQuote.text = rightQuote;
        if(Input.GetMouseButtonUp(0)){
          currentCard.Right();
          NewCard();
        }
      }
      else if (cardGameObject.transform.position.x >fSideMargin){
        direction = "right";
      }
      else if (cardGameObject.transform.position.x >-fSideMargin){
          textColor.a = 0;
          actionBackgroundColor.a = 0;
          direction = "none";
      }
      else if (cardGameObject.transform.position.x >-fSideTrigger){
        direction = "left";
      }

      else{
        direction = "left";
        if(Input.GetMouseButtonUp(0)){
          currentCard.Left();
          NewCard();
        }
      }

      UpdateDialogue();
      //movement
      if (Input.GetMouseButton(0) && mainCardController.isMouseOver){
        Vector2 pos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cardGameObject.transform.position=pos;
        cardGameObject.transform.eulerAngles = new Vector3(0,0,cardGameObject.transform.position.x*fRoatationCoefficient);
      }
      else if(!isSubstituting){
        cardGameObject.transform.position= Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard ,fMovingSpeed);
        cardGameObject.transform.eulerAngles= new Vector3(0,0,0);
      }
      else if (isSubstituting){
        cardGameObject.transform.eulerAngles= Vector3.MoveTowards(cardGameObject.transform.eulerAngles,cardRotation,fRotatingSpeed);

      }
    //UI
    display.text = "" + textColor.a;
    //rotate cards
    if (cardGameObject.transform.eulerAngles==cardRotation){
      isSubstituting = false;
    }

  }

  public void LoadCard(Card card){
    cardSpriteRenderer.sprite= resourceManager.sprites[(int)card.sprite];
    leftQuote= card.leftQuote;
    rightQuote=card.rightQuote;
    currentCard = card;
    characterDialogue.text=card.dialogue;
    characterName.text=card.cardName;
    //reset pos
    cardGameObject.transform.position= defaultPositionCard;
    cardGameObject.transform.eulerAngles= new Vector3(0,0,0);
    //init of substitution
    isSubstituting=true;
    cardGameObject.transform.eulerAngles= initRotation;
  }

  public void NewCard()
  {

    int rollDice = Random.Range(0, resourceManager.cards.Length);
    LoadCard(resourceManager.cards[rollDice]);
  }


}
