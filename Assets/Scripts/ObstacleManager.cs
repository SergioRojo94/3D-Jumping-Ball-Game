using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] bool bubbles; //if level has items
    [SerializeField] bool barrels;
    [SerializeField] bool towerBarrels;

    public int _probablyBubbles; //probably of item appears (in editor)
    public int _probablyBarrels;
    public int _probablyTowerBarrels;

    int haveBubbles; 
    int haveBarrels;
    int haveTowerBarrels;

    void Awake() {
        Probabilities();
    }
    void Start()
    {
       
        Bubble();
        Barrel();
        TowerBarrel();
    }

    void Probabilities() {
        _probablyBarrels = FindObjectOfType<GameManager>()._pBarrels;
        _probablyBubbles = FindObjectOfType<GameManager>()._pBubbles;
        _probablyTowerBarrels = FindObjectOfType<GameManager>()._pTowerBarrels;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        { //In Main Menu don't want any obstacle
            _probablyBubbles = 0;
            _probablyBarrels = 0;
            _probablyTowerBarrels = 0;
        }
    }
    void Bubble() {
        haveBubbles = Random.Range(0, 100);
        if (haveBubbles > _probablyBubbles)
            GetComponentInChildren<Bubble>().gameObject.SetActive(false);
    }

    void Barrel() {
        haveBarrels = Random.Range(0, 100);
        if (haveBarrels > _probablyBarrels)
            transform.GetChild(4).gameObject.SetActive(false);
    }

    void TowerBarrel()
    {
        haveTowerBarrels = Random.Range(0, 100);
        if (haveTowerBarrels > _probablyTowerBarrels)
            transform.GetChild(5).gameObject.SetActive(false);
    }
}
