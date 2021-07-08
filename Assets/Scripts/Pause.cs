using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Text coinsText, surrenderText1, surrenderText2;
    [SerializeField] GameObject surrenderButton;
    GameManager _gm;
    PlayerPoints _player;
    private void Start() {
        _gm = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<PlayerPoints>();
        CheckSurrender();
        coinsText.text = _gm.SetStars().ToString();
    }

    private void Update()
    {
        CheckSurrender();
    }
    void CheckSurrender() {
        if (_player.points >= _gm.star1Points) {
            coinsText.gameObject.SetActive(true);
            surrenderButton.gameObject.SetActive(true);
            surrenderText1.gameObject.SetActive(true);
            surrenderText2.gameObject.SetActive(true);
            coinsText.text = _gm.SetStars().ToString();
        }
    }
    public void Continue() {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Surrender() {
        Debug.Log("Surrendio");
        _gm.LevelComplete();
    }

    public void ExitGame() {
        Application.Quit();
    }
}
