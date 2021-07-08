using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [SerializeField] GameObject enableObject;
    [SerializeField] GameObject disableObject;
    GameObject StartButtons;
    public void EnableObject() {
        StartButtons = GameObject.FindWithTag("StartButton");
        if (StartButtons != null)
        StartButtons.gameObject.SetActive(false);

        enableObject.SetActive(true);
        AudioManager.instance.Play("ButtonClick");
    }
    public void DisableObject() {
        disableObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
