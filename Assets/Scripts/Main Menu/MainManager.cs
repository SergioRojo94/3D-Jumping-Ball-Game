using UnityEngine;

//This script is used in MainMenu for pick randomly a skybox and a player
public class MainManager : MonoBehaviour
{
    [SerializeField] Material[] SkyBoxMaterialsArray;
    [SerializeField] ParticleSystem.MainModule _particleSystem;

    GameObject[] PlayerArray;
    int _random, _randomSkyBox;
    void Start() {
        PlayerArray = new GameObject[transform.childCount];
        _random = Random.Range(0, PlayerArray.Length);
        _randomSkyBox = Random.Range(0, SkyBoxMaterialsArray.Length);

        RenderSettings.skybox = SkyBoxMaterialsArray[_randomSkyBox]; //"" skybox
        ActivePlayerRandomly();
    }

    void ActivePlayerRandomly() {
        for (int i = 0; i < transform.childCount; i++)
            PlayerArray[i] = transform.GetChild(i).gameObject;

        foreach (GameObject objX in PlayerArray)
            objX.SetActive(false);
        PlayerArray[_random].SetActive(true);
    }
}
