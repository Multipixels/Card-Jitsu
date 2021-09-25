using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject standardCard;
    [SerializeField] private GameObject cardWin;
    private static Deck deck1;
    private static Deck deck2;
    private static GameObject playerHand;
    private static GameObject enemyHand;
    private static GameObject playerWins;
    private static GameObject enemyWins;
    private static GameObject timerObject;
    
    private static IEnumerator timerCoroutine;

    private int[] playerCardWins = {0, 0, 0};
    private int[] enemyCardWins = {0, 0, 0};

    private List<Card>[] playerCardsThatWon = new List<Card>[3];
    private List<Card>[] enemyCardsThatWon = new List<Card>[3];

    [SerializeField] private List<Sprite> cardSprites = new List<Sprite>();

    void Start() {
        playerHand = GameObject.Find("Cards");
        enemyHand = GameObject.Find("EnemyCards");
        playerWins = GameObject.Find("PlayerWins");
        enemyWins = GameObject.Find("EnemyWins");
        timerObject = GameObject.Find("Timer");

        CardConcept[] cardDeck = new CardConcept[30];
        for(int i = 0; i < 30; i++) {
            cardDeck[i] = new CardConcept(i);
        }

        for(int i = 0; i < 3; i++) {
            playerCardsThatWon[i] = new List<Card>();
            enemyCardsThatWon[i] = new List<Card>();
        }

        deck1 = new Deck(cardDeck);
        deck2 = new Deck(cardDeck);
        deck2.shuffle();

        for(int i = 0; i < 5; i++) {
            drawCard(i);
            drawEnemyCard(i);
        }

        timerCoroutine = timerCountdown();
        StartCoroutine(timerCoroutine);
    }

    public void drawCard(int position) {
        GameObject cardObject = Instantiate(standardCard);

        cardObject.transform.SetParent(playerHand.transform);

        cardObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-455 + (position * 115), -285);
        cardObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        int cardId = deck1.draw();

        cardObject.GetComponent<Card>().setCard(cardId, position, cardSprites[cardId]);
    }

    public void drawEnemyCard(int position) {
        GameObject cardObject = Instantiate(standardCard);

        cardObject.transform.SetParent(enemyHand.transform);

        cardObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(480 - (position * 66) ,-265);
        cardObject.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f, 1);
        cardObject.GetComponent<Button>().interactable = false;

        int cardId = deck2.draw();

        cardObject.GetComponent<Card>().setCard(cardId, position, cardSprites[cardId]);

        cardObject.transform.Find("Back").GetComponent<Canvas>().sortingOrder = 1;
        cardObject.tag = "Untagged";
        cardObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 180, 0);
    }

    public void pickCard(GameObject cardObject) {
        StopCoroutine(timerCoroutine);

        timerObject.SetActive(false);

        StartCoroutine(pickCardCoroutine(cardObject));
    }

    public IEnumerator smoothGUIMove(GameObject coolObject, Vector2 finalPos, float time) {
        Vector3 startingPos = coolObject.GetComponent<RectTransform>().anchoredPosition;
        float elapsedTime = 0;

        while (coolObject.GetComponent<RectTransform>().anchoredPosition != finalPos) {
            coolObject.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(time / 60);
        }
    }

    public IEnumerator smoothGUIScale(GameObject coolObject, Vector3 finalScale, float time) {
        Vector3 startingPos = coolObject.GetComponent<RectTransform>().localScale;
        float elapsedTime = 0;
        
        while (coolObject.GetComponent<RectTransform>().localScale != finalScale) {
            coolObject.GetComponent<RectTransform>().localScale = Vector3.Lerp(startingPos, finalScale, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(time / 60);
        }
    }

    public IEnumerator smoothGUIRotation(GameObject coolObject, Quaternion finalRotation, float time) {
        Quaternion startingPos = coolObject.GetComponent<RectTransform>().rotation;
        float elapsedTime = 0;
        
        while (coolObject.GetComponent<RectTransform>().eulerAngles != finalRotation.eulerAngles) {
            coolObject.GetComponent<RectTransform>().rotation = Quaternion.Lerp(startingPos, finalRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(time / 60);
        }
    }

    public IEnumerator pickCardCoroutine(GameObject cardObject) {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag("card");

        foreach(GameObject card in buttons) {
            card.GetComponent<Button>().interactable = false;
        }

        StartCoroutine(smoothGUIMove(cardObject, new Vector2(-300, 110), 0.5f));
        StartCoroutine(smoothGUIScale(cardObject, new Vector2(1.5f, 1.5f), 0.5f));

        int randomCard = Random.Range(0, 5);
        GameObject enemyCardObject = enemyHand.transform.GetChild(randomCard).gameObject;

        StartCoroutine(smoothGUIMove(enemyCardObject, new Vector2(300, 110), 0.5f));
        StartCoroutine(smoothGUIScale(enemyCardObject, new Vector2(1.5f, 1.5f), 0.5f));

        yield return new WaitForSeconds(1);

        StartCoroutine(smoothGUIRotation(enemyCardObject, Quaternion.Euler(new Vector2(0, 0)), 0.5f));

        yield return new WaitForSeconds(0.25f);

        enemyCardObject.transform.Find("Back").GetComponent<Canvas>().sortingOrder = -1;

        yield return new WaitForSeconds(1.75f);

        //////////////////////////////////////////////////

        Card playerCard = cardObject.GetComponent<Card>();
        Card enemyCard = enemyCardObject.GetComponent<Card>();

        int whoWon = 0;

        if(playerCard.getElementId() == enemyCard.getElementId()) {

            if(playerCard.getValue() == enemyCard.getValue()) {
                whoWon = 0;
            } else if(playerCard.getValue() > enemyCard.getValue()) {
                whoWon = 1;
            } else {
                whoWon = 2;
            }

        } else if(playerCard.getElementId() - 1 == enemyCard.getElementId() || playerCard.getElementId() + 2 == enemyCard.getElementId()) {
            whoWon = 1;
        } else {
            whoWon = 2;
        }

        //////////////////////////////////////////////////

        if(whoWon == 1) {
            GameObject cardWinObject = Instantiate(cardWin);

            cardWinObject.transform.SetParent(playerWins.transform);

            cardWinObject.GetComponent<RectTransform>().anchoredPosition = cardObject.GetComponent<RectTransform>().anchoredPosition;
            StartCoroutine(smoothGUIMove(cardWinObject, new Vector2(-480 + (playerCard.getElementId() * 80), 270 - (playerCardWins[playerCard.getElementId()] * 15)), 0.25f));
            cardWinObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            cardWinObject.GetComponent<Image>().color = cardObject.transform.Find("Color").GetComponent<Image>().color;
            cardWinObject.transform.Find("ElementImage").GetComponent<Image>().sprite = cardObject.transform.Find("ElementImage").GetComponent<Image>().sprite;
            cardWinObject.transform.SetAsFirstSibling();

            playerCardWins[playerCard.getElementId()] += 1;
            playerCardsThatWon[playerCard.getElementId()].Add(playerCard);
        } else if(whoWon == 2) {
            GameObject cardWinObject = Instantiate(cardWin);

            cardWinObject.transform.SetParent(playerWins.transform);

            cardWinObject.GetComponent<RectTransform>().anchoredPosition = enemyCardObject.GetComponent<RectTransform>().anchoredPosition;
            StartCoroutine(smoothGUIMove(cardWinObject, new Vector2(320 + (enemyCard.getElementId() * 80), 270 - (enemyCardWins[enemyCard.getElementId()] * 15)), 0.25f));
            cardWinObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            cardWinObject.GetComponent<Image>().color = enemyCardObject.transform.Find("Color").GetComponent<Image>().color;
            cardWinObject.transform.Find("ElementImage").GetComponent<Image>().sprite = enemyCardObject.transform.Find("ElementImage").GetComponent<Image>().sprite;
            cardWinObject.transform.SetAsFirstSibling();

            enemyCardWins[enemyCard.getElementId()] += 1;
            enemyCardsThatWon[enemyCard.getElementId()].Add(enemyCard);
        }

        if(checkWin(playerCardsThatWon)) {
            Debug.Log("Player Won");
            Destroy(cardObject);
            Destroy(enemyCardObject);
            yield break;
        } else if(checkWin(enemyCardsThatWon)) {
            Debug.Log("Enemy Won");
            Destroy(cardObject);
            Destroy(enemyCardObject);
            yield break;
        }

        
        drawCard(playerCard.getPosition());
        drawEnemyCard(enemyCard.getPosition());
        Destroy(cardObject);
        Destroy(enemyCardObject);

        foreach(GameObject card in buttons) {
            card.GetComponent<Button>().interactable = true;
        }

        timerObject.SetActive(true);
        timerCoroutine = timerCountdown();
        StartCoroutine(timerCoroutine);
    }

    public IEnumerator timerCountdown() {

        for(int i = 20; i >= 0; i--) {

            timerObject.transform.Find("GreenSlider").GetComponent<Image>().fillAmount = 0.05f * i;
            timerObject.transform.Find("Seconds").GetComponent<Text>().text = "" + i;

            yield return new WaitForSeconds(1);
        }

        Debug.Log("Done");

        int randomCard = Random.Range(0, 5);
        GameObject cardObject = playerHand.transform.GetChild(randomCard).gameObject;

        pickCard(cardObject);
        StopCoroutine(timerCoroutine);
    }

    public bool checkWin(List<Card>[] cardsToCheck) {

        List<Color32> colorsUsed = new List<Color32>();

        //Checks indibidual
        for(int i = 0; i < 3; i++) {
            if(cardsToCheck[i].Count >= 3) {
                foreach(Card card in cardsToCheck[i]) {
                    if(!colorsUsed.Contains(card.getColor32())) {
                        colorsUsed.Add(card.getColor32());
                    }
                }

                if(colorsUsed.Count == 3) {
                    return true;
                } else {
                    colorsUsed = new List<Color32>();
                }
            }
        }

        //Check All
        if(cardsToCheck[0].Any() && cardsToCheck[1].Any() && cardsToCheck[2].Any())
        foreach(Card fire in cardsToCheck[0]) {
            foreach(Card water in cardsToCheck[1]) {
                foreach (Card snow in cardsToCheck[2]) {
                    if(!fire.getColor32().Equals(water.getColor32()) && !fire.getColor32().Equals(snow.getColor32()) && !water.getColor32().Equals(snow.getColor32())) {
                        return true;
                    }
                }
            }
        }

        return false;

    }
}
