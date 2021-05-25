
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Fills progress bar UI when game ends
public class FillProgressBar : MonoBehaviour
{
    int playerPoints;
    float progressValue;
    GameManager _gm;
    Image _img;
    void Start() {
       // totalPoints = FindObjectOfType<GameManager>().goalPoints;
        _gm = FindObjectOfType<GameManager>();
        _img = GetComponent<Image>();
        FIllingBar();
    }

    void FIllingBar() {
        playerPoints = FindObjectOfType<PlayerPoints>().points;
            if (playerPoints < _gm.star1Points)
                progressValue = 0f;
            else if (playerPoints >= _gm.star1Points && playerPoints < _gm.star2Points)
                progressValue = 0.33f;
            else if (playerPoints >= _gm.star2Points && playerPoints < _gm.goalPoints)
                progressValue = 0.66f;
            else
                progressValue = 1;
        StartCoroutine("FillWithPoints");
    }

    IEnumerator FillWithPoints() {
        for (float i = 0; i < progressValue; i+=0.05f)
        yield return new WaitForEndOfFrame();
        _img.fillAmount += 0.05f;
    }
}
