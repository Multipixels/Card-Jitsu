using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    private CardConcept concept;
    private int position;

    [SerializeField] private Sprite fireSprite;
    [SerializeField] private Sprite waterSprite;
    [SerializeField] private Sprite snowSprite;

    public void setCard(int conceptPar, int positionPar, Sprite cardSprite) {
        concept = new CardConcept(conceptPar);
        position = positionPar;

        gameObject.transform.Find("ValueText").GetComponent<TextMeshProUGUI>().text = "" + concept.getValue();
        
        switch(concept.getElementId()) {
            case 0:
                gameObject.transform.Find("ElementImage").GetComponent<Image>().sprite = fireSprite;
                break;
            case 1:
                gameObject.transform.Find("ElementImage").GetComponent<Image>().sprite = waterSprite;
                break;
            case 2:
                gameObject.transform.Find("ElementImage").GetComponent<Image>().sprite = snowSprite;
                break;
        }

        gameObject.transform.Find("Color").GetComponent<Image>().color = getColor32();
        gameObject.transform.Find("CornerColor").GetComponent<Image>().color = getColor32();

        gameObject.transform.Find("CardArt").GetComponent<Image>().sprite = cardSprite;

        gameObject.GetComponent<Button>().onClick.AddListener(delegate{GameObject.Find("CardJitsuGameManager").GetComponent<CardJitsuGameManager>().pickCard(gameObject);});
    }

    public Color32 getColor32() {
        Color32 color = new Color32(255, 255, 255, 255);

        switch(concept.getColor()) {
            case "red":
                color = new Color32(227, 60, 37, 255);
                break;
            case "orange":
                color = new Color32(248, 149, 43, 255);
                break;
            case "yellow":
                color = new Color32(248, 234, 43, 255);
                break;
            case "purple":
                color = new Color32(163, 153, 204, 255);
                break;
            case "blue":
                color = new Color32(16, 72, 160, 255);
                break;
            case "green":
                color = new Color32(98, 184, 71, 255);
                break;
        }

        return color;
    }

    public int getElementId() {
        return concept.getElementId();
    }

    public int getValue() {
        return concept.getValue();
    }

    public int getPosition() {
        return position;
    }

}
