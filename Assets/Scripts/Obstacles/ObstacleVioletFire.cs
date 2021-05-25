
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleVioletFire : MonoBehaviour
{
    [SerializeField] bool violetFires;

    public int _probablyVioletFires;

    int haveVioletFires;

    void Awake()
    {
        Probabilities();
    }
    void Start()
    {
        VioletFire();
    }

    void Probabilities()
    {
        _probablyVioletFires = FindObjectOfType<GameManager>()._pVioletFire;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            _probablyVioletFires = 0;
        }
    }

    void VioletFire()
    {
        if (violetFires == false)
            transform.GetChild(4).gameObject.SetActive(false);
        else
        {
            haveVioletFires = Random.Range(0, 100);
            if (haveVioletFires > _probablyVioletFires)
                transform.GetChild(0).transform.Find("VioletFire").gameObject.SetActive(false);
        }
    }
}
