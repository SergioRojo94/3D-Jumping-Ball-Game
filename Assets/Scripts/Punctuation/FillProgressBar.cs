
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Fills progress bar UI when game ends
public class FillProgressBar : MonoBehaviour
{
    [SerializeField] GameObject bronze, silver, gold;
    int playerPoints;
    float progressValue;
    GameManager _gm;
    Image _img;

    void Awake(){
        if (SceneManager.GetActiveScene().name == "ArcadeScene") //no sense progress bar in arcade
            gameObject.SetActive(false);
    }
    void Start() {
       // totalPoints = FindObjectOfType<GameManager>().goalPoints;
        _gm = FindObjectOfType<GameManager>();
        _img = GetComponent<Image>();
        FIllingBar();
    }

    void FIllingBar() {
        playerPoints = FindObjectOfType<PlayerPoints>().points;
        if (playerPoints < _gm.star1Points)
            return;
        else if (playerPoints >= _gm.star1Points && playerPoints < _gm.star2Points)
            bronze.gameObject.SetActive(true);
        else if (playerPoints >= _gm.star2Points && playerPoints < _gm.goalPoints) {
            bronze.gameObject.SetActive(true);
            silver.gameObject.SetActive(true);
        }

        else {
            bronze.gameObject.SetActive(true);
            silver.gameObject.SetActive(true);
            gold.gameObject.SetActive(true);
        }
            
        //StartCoroutine("FillWithPoints");
    }

   /* IEnumerator FillWithPoints() {
        for (float i = 0; i < progressValue; i+=0.05f)
        yield return new WaitForEndOfFrame();
        _img.fillAmount += 0.05f;
    }*/
}
