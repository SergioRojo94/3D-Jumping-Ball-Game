
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleWaterfallManager : MonoBehaviour
{
    [SerializeField] bool waterfalls;

    public int _probablyWaterfalls;

    int haveWaterfalls;

    void Awake()
    {
        Probabilities();
    }
    void Start()
    {
        Waterfall();
    }

    void Probabilities()
    {
        _probablyWaterfalls = FindObjectOfType<GameManager>()._pWaterfalls;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            _probablyWaterfalls = 0;
        }
    }

    void Waterfall() {
        if (waterfalls == false)
            transform.GetChild(4).gameObject.SetActive(false);
        else
        {
            haveWaterfalls = Random.Range(0, 100);
            if (haveWaterfalls > _probablyWaterfalls)
                transform.GetChild(0).transform.Find("Waterfall").gameObject.SetActive(false);
        }
    }
}
