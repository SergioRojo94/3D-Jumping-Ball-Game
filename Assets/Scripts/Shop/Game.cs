using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region Singleton:Game

    public static Game Instance;

    void Awake() { 
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    #endregion

    int Coins = PlayerPrefs.GetInt("Coins");

    public void UseCoins(int amount) {
        Coins -= amount;
        PlayerPrefs.SetInt("Coins", Coins);
        AudioManager.instance.Play("ButtonClick");
    }

    public bool HasEnoughCoins(int amount) {
        return (Coins >= amount);
    }
}
