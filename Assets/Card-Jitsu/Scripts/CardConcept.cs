using System.Collections;
using System.Collections.Generic;

public class CardConcept
{
    private string color;
    private string title;
    private int element;
    private int value;
    private int effect;
    private int id;

    public CardConcept(int idPar) {
        id = idPar;
        setData(id);
    }

    public string getElement() {
        switch(element) {
            case 0:
                return "Fire";
            case 1:
                return "Water";
            case 2:
                return "Snow";
        }

        return "Error";
    }

    public int getElementId() {
        return element;
    }

    public int getValue() {
        return value;
    }

    public int getId() {
        return id;
    }

    public string getColor() {
        return color;
    }

    public string getTitle() {
        return title;
    }

    private void setData(int id) {
        switch(id) {
            case 0:
                color = "blue"; element = 0; title = "Cart Surfer"; value = 3; effect = 0;
                break;
            case 1:
                color = "green"; element = 0; title = "Coffee Shop"; value = 2; effect = 0;
                break;
            case 2:
                color = "green"; element = 0; title = "Astro-Barrier"; value = 8; effect = 0;
                break;
            case 3:
                color = "orange"; element = 0; title = "Hot Chocolate"; value = 3; effect = 0;
                break;
            case 4:
                color = "purple"; element = 0; title = "Landing Pad"; value = 4; effect = 0;
                break;
            case 5:
                color = "purple"; element = 0; title = "Pizza Chef"; value = 6; effect = 0;
                break;
            case 6:
                color = "red"; element = 0; title = "Paint By Letters"; value = 2; effect = 0;
                break;
            case 7:
                color = "red"; element = 0; title = "Mine"; value = 7; effect = 0;
                break;
            case 8:
                color = "yellow"; element = 0; title = "Construction Worker"; value = 2; effect = 0;
                break;
            case 9:
                color = "yellow"; element = 0; title = "Jet Pack Adventure"; value = 5; effect = 0;
                break;
            case 10:
                color = "blue"; element = 2; title = "Gift Shop"; value = 3; effect = 0;
                break;
            case 11:
                color = "green"; element = 2; title = "Hiking In The Forest"; value = 2; effect = 0;
                break;
            case 12:
                color = "green"; element = 2; title = "Rescue Squad"; value = 5; effect = 0;
                break;
            case 13:
                color = "orange"; element = 2; title = "Pet Shop"; value = 3; effect = 0;
                break;
            case 14:
                color = "purple"; element = 2; title = "Ski Village"; value = 4; effect = 0;
                break;
            case 15:
                color = "purple"; element = 2; title = "Ice Hockey"; value = 8; effect = 0;
                break;
            case 16:
                color = "red"; element = 2; title = "Ski Hill"; value = 2; effect = 0;
                break;
            case 17:
                color = "red"; element = 2; title = "Snowball Fight"; value = 6; effect = 0;
                break;
            case 18:
                color = "yellow"; element = 2; title = "Snow Forts"; value = 2; effect = 0;
                break;
            case 19:
                color = "yellow"; element = 2; title = "Soccer"; value = 7; effect = 0;
                break;
            case 20:
                color = "blue"; element = 1; title = "Beach"; value = 3; effect = 0;
                break;
            case 21:
                color = "blue"; element = 1; title = "Football"; value = 5; effect = 0;
                break;
            case 22:
                color = "green"; element = 1; title = "Baseball"; value = 2; effect = 0;
                break;
            case 23:
                color = "green"; element = 1; title = "Emerald Princess"; value = 8; effect = 0;
                break;
            case 24:
                color = "orange"; element = 1; title = "Bean Counters"; value = 3; effect = 0;
                break;
            case 25:
                color = "purple"; element = 1; title = "Manhole Cover"; value = 4; effect = 0;
                break;
            case 26:
                color = "purple"; element = 1; title = "Newspaper Archives"; value = 6; effect = 0;
                break;
            case 27:
                color = "red"; element = 1; title = "Underground Pool"; value = 2; effect = 0;
                break;
            case 28:
                color = "red"; element = 1; title = "Scuba Diving"; value = 7; effect = 0;
                break;
            case 29:
                color = "yellow"; element = 1; title = "Ice Fishing"; value = 2; effect = 0;
                break;
            
        }
    }
}
