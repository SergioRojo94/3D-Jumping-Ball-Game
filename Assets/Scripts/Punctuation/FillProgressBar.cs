
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
    PlayerMovement _player;

    void Awake(){
        if (SceneManager.GetActiveScene().name == "ArcadeScene") //no sense progress bar in arcade
            gameObject.SetActive(false);
    }
    void Start() {
       // totalPoints = FindObjectOfType<GameManager>().goalPoints;
        _gm = FindObjectOfType<GameManager>();
        _img = GetComponent<Image>();
        _player = FindObjectOfType<PlayerMovement>();
        FIllingBar();
        
    }

    void FIllingBar() {
        playerPoints = FindObjectOfType<PlayerPoints>().points;
        Debug.Log("Hasta aquí");
        if (_player.isDead ==false)
        {
            Debug.Log(_player.name);
            if (playerPoints < _gm.star1Points)
                return;

            else if (playerPoints >= _gm.star1Points && playerPoints < _gm.star2Points)
            {
                Debug.Log("Hasta aquí 2");
                _img.GetComponent<Image>().enabled = false;
                Debug.Log(FindObjectOfType<PlayerMovement>().isDead);
                bronze.gameObject.SetActive(true);
            }

            else if (playerPoints >= _gm.star2Points && playerPoints < _gm.goalPoints)
            {
                Debug.Log("Hasta aquí 3");
                _img.GetComponent<Image>().enabled = false;
                bronze.gameObject.SetActive(false);
                silver.gameObject.SetActive(true);
            }

            else if (playerPoints >= _gm.goalPoints)
            {
                Debug.Log("Hasta aquí 4");
                _img.GetComponent<Image>().enabled = false;
                bronze.gameObject.SetActive(false);
                silver.gameObject.SetActive(false);
                gold.gameObject.SetActive(true);
            }
        }
       
            
        //StartCoroutine("FillWithPoints");
    }

   /* IEnumerator FillWithPoints() {
        for (float i = 0; i < progressValue; i+=0.05f)
        yield return new WaitForEndOfFrame();
        _img.fillAmount += 0.05f;
    }*/
}
