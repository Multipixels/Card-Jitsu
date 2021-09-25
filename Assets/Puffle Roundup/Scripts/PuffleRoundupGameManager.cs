using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuffleRoundupGameManager : MonoBehaviour
{

    [SerializeField] private GameObject puffleGameObject;
    [SerializeField] private GameObject timerObject;
    
    void Start() {
        summonPuffles();
        StartCoroutine(timerCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void summonPuffles() {
        for(int i = 0; i < 10; i++) { 
            Instantiate(puffleGameObject);
        }
    }

    public IEnumerator timerCountdown() {

        for(int i = 120; i >= 0; i--) {

            timerObject.transform.Find("WhiteFillImage").GetComponent<Image>().fillAmount = (1f / 120f) * i;
            timerObject.transform.Find("TimerText").GetComponent<TextMeshProUGUI>().text = "" + i;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
