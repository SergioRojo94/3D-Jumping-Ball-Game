using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleFluidManager : MonoBehaviour
{
    [SerializeField] bool fluids;

    public int _probablyFluids;

    int haveFluids;

    void Awake()
    {
        Probabilities();
    }
    void Start()
    {
       Fluid();
    }

    void Probabilities()
    {
        _probablyFluids = FindObjectOfType<GameManager>()._pFluid;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            _probablyFluids = 0;
        }
    }

    void Fluid()
    {
        if (fluids == false)
            transform.GetChild(4).gameObject.SetActive(false);
        else
        {
            haveFluids = Random.Range(0, 100);
            if (haveFluids > _probablyFluids)
                transform.GetChild(0).transform.Find("Fluid").gameObject.SetActive(false);
        }
    }
}
