
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleTransparentManager : MonoBehaviour
{
    [SerializeField] bool towerBarrels;

    public int _probablyTowerBarrels;

    int haveTowerBarrels;

    void Awake()
    {
        Probabilities();
    }
    void Start() {
        TowerBarrel();
    }

    void Probabilities()
    {
        _probablyTowerBarrels = FindObjectOfType<GameManager>()._pTowerBarrels;
        if (SceneManager.GetActiveScene().name == "MainMenu") { 
            _probablyTowerBarrels = 0;
        }
    }

    void TowerBarrel()
    {
        if (towerBarrels == false)
            transform.GetChild(3).gameObject.SetActive(false);
        else {
            haveTowerBarrels = Random.Range(0, 100);
            if (haveTowerBarrels > _probablyTowerBarrels)
                transform.GetChild(3).gameObject.SetActive(false);
        }
     
    }
}
