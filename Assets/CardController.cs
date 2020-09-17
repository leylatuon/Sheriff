using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardController : MonoBehaviour
{


    // Start is called before the first frame update
    public Card card;
    public bool isMouseOver;
    public BoxCollider2D thisCard;
    private void Start(){
      thisCard= gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnMouseOver(){
      isMouseOver=true;
    }
    private void OnMouseExit(){
      isMouseOver=false;
    }
}

public enum CardSprite{
  HORSE,
  TALLHAT,
  WIDEHAT,
  BANDIT,
  COW,
  SHADYMERCHANT,
  TOWNGIRL
}
