using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStartButtons : MonoBehaviour
{
    //this script is setted in barrels scene objects (level selection), in StartButtons. 
    public GameObject buttonStart, buttonTry, buttonShop;
    PlayerMovement _player;
    void Start()
    {
        Check();
    }

    void Update()
    {
        Check();
    }

    void Check() {
        _player = FindObjectOfType<PlayerMovement>();

        if (_player.unlocked == true) {
            buttonStart.SetActive(true);
            buttonTry.SetActive(false);
            buttonShop.SetActive(false);
        }
        else {
            buttonStart.SetActive(false);
            buttonTry.SetActive(true);
            buttonShop.SetActive(true);
        }
    }
}
