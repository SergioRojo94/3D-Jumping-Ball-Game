
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleFireManager : MonoBehaviour
{
    [SerializeField] bool fires;

    public int _probablyFires;

    int haveFires;

    void Awake()
    {
        Probabilities();
    }
    void Start()
    {
        BlueFire();
    }

    void Probabilities()
    {
        _probablyFires = FindObjectOfType<GameManager>()._pBlueFire;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            _probablyFires = 0;
        }
    }

    void BlueFire()
    {
        if (fires == false)
            transform.GetChild(4).gameObject.SetActive(false);
        else
        {
            haveFires = Random.Range(0, 100);
            if (haveFires > _probablyFires)
                transform.GetChild(0).transform.Find("BlueFire").gameObject.SetActive(false);
        }
    }
}
