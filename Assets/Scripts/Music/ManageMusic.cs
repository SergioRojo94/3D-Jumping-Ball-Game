using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMusic : MonoBehaviour
{
    public GameObject OnButton, OffButton;
    void Start()
    {
        if (AudioManager.instance.musicIsActive == true)
        {
            OffButton.SetActive(true);
            OnButton.SetActive(false);
        }
        else
        {
            OffButton.SetActive(false);
            OnButton.SetActive(true);
        }
    }

    public void AllowMusic()
    {
        if (OnButton.activeInHierarchy == true)
        {
            OffButton.SetActive(true);
            OnButton.SetActive(false);
            AudioManager.instance.ReanudeAllSound();
        }
        else
        {
            OffButton.SetActive(false);
            OnButton.SetActive(true);
            AudioManager.instance.StopAllSound();
        }
    }

    public void GoToURL() {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=Serendipia+Games");
    }
}
