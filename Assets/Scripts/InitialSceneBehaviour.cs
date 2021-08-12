using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialSceneBehaviour : MonoBehaviour
{
    
    void Start()
    {
        Invoke("StartGame", 5.5f);
    }

    void StartGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
