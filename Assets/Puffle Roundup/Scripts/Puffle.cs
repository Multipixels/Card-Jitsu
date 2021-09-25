using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puffle : MonoBehaviour
{

    private int puffleId;
    private string puffleColor;

    private float puffleSensitivityRadius;

    private void Start() {
        
        puffleId = Random.Range(1, 10);
        puffleColor = getColorFromId(puffleId);
        puffleSensitivityRadius = getPuffleSensitivityRadiusFromId(puffleId);

        GetComponent<CircleCollider2D>().radius = puffleSensitivityRadius;
        GetComponent<SpriteRenderer>().color = getColor32FromId(puffleId);

        while(true) {
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(-3f, 3f);

            if( !(x >= -1.6f && x <= 1.5f) || !(y >= -3.4f && y <= -0.1f) ) {
                transform.position = new Vector2(x, y);
                break;
            }
        }

    }

    private void Update() {
        if(transform.position.x <= -6.5f || transform.position.x >= 6.5f || transform.position.y >= 3.5f || transform.position.y <= -4f) {
            Destroy(gameObject);
        }
    }

    private string getColorFromId(int id) {

        string colorString = "Error";

        if(id == 1) {
            colorString = "Brown";
        } else if(id == 2) {
            colorString = "Blue";
        } else if(id == 3) {
            colorString = "Red";
        } else if(id == 4) {
            colorString = "Black";
        } else if(id == 5) {
            colorString = "Pink";
        } else if(id == 6) {
            colorString = "Green";
        } else if(id == 7) {
            colorString = "Purple";
        } else if(id == 8) {
            colorString = "Orange";
        } else if(id == 9) {
            colorString = "White";
        } else if(id == 10) {
            colorString = "Yellow";
        }

        return colorString;
    }

    private Color32 getColor32FromId(int id) {
        Color32 color32Return = new Color32(0, 0, 0, 0);

        if(id == 1) {
            color32Return = new Color32(114, 71, 26, 255);
        } else if(id == 2) {
            color32Return = new Color32(43, 180, 238, 255);
        } else if(id == 3) {
            color32Return = new Color32(251, 84, 69, 255);
        } else if(id == 4) {
            color32Return = new Color32(106, 101, 107, 255);
        } else if(id == 5) {
            color32Return = new Color32(240, 200, 240, 255);
        } else if(id == 6) {
            color32Return = new Color32(36, 165, 0, 255);
        } else if(id == 7) {
            color32Return = new Color32(158, 93, 179, 255);
        } else if(id == 8) {
            color32Return = new Color32(234, 139, 0, 255);
        } else if(id == 9) {
            color32Return = new Color32(255, 254, 250, 255);
        } else if(id == 10) {
            color32Return = new Color32(255, 240, 0, 255) ;
        }

        return color32Return;
    }

    private float getPuffleSensitivityRadiusFromId(int id) {

        float puffleSensitivity = 0f;

        if(id == 1) {
            puffleSensitivity = 0.75f;
        } else if(id == 2) {
            puffleSensitivity = 0.35f;
        } else if(id == 3) {
            puffleSensitivity = 0.6f;
        } else if(id == 4) {
            puffleSensitivity = 0.5f;
        } else if(id == 5) {
            puffleSensitivity = 0.65f;
        } else if(id == 6) {
            puffleSensitivity = 0.7f;
        } else if(id == 7) {
            puffleSensitivity = 0.55f;
        } else if(id == 8) {
            puffleSensitivity = 0.45f;
        } else if(id == 9) {
            puffleSensitivity = 0.3f;
        } else if(id == 10) {
            puffleSensitivity = 0.4f;
        }

        return puffleSensitivity;
    }
    
}
