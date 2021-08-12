using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class InitializeAds : MonoBehaviour
{
    void Awake() {
        Yodo1U3dMas.SetCOPPA(false);
    }
        
    void Start()
    {
        Yodo1U3dMas.InitializeSdk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
