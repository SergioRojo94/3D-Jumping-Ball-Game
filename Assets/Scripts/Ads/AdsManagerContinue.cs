using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yodo1.MAS;

public class AdsManagerContinue : MonoBehaviour
{
    private GameManager _gm;
    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }


    public void ShowVideoReward()
    {
        Yodo1U3dMas.ShowRewardedAd();
        RewardedVideoEvents();
    }

    public void RewardedVideoEvents()
    {
        Yodo1U3dMas.SetRewardedAdDelegate((Yodo1U3dAdEvent adEvent, Yodo1U3dAdError error) => {
            Debug.Log("[Yodo1 Mas] RewardVideoDelegate:" + adEvent.ToString() + "\n" + error.ToString());
            switch (adEvent)
            {
                case Yodo1U3dAdEvent.AdClosed:
                   // Debug.Log("[Yodo1 Mas] Reward video ad has been closed.");
                    break;
                case Yodo1U3dAdEvent.AdOpened:
                   // Debug.Log("[Yodo1 Mas] Reward video ad has shown successful.");
                    break;
                case Yodo1U3dAdEvent.AdError:
                   // Debug.Log("[Yodo1 Mas] Reward video ad error, " + error);
                    break;
                case Yodo1U3dAdEvent.AdReward:
                   // Debug.Log("[Yodo1 Mas] Reward video ad reward, give rewards to the player.");
                    _gm.Continue();
                    break;
            }
        });
    }
}
