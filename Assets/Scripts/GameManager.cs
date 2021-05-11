
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] int goalPoints;

    #region PlayerPref probabilities
    bool _PPBubbles; //TODO MAKE PLAYER PREFS FOR UNLOCK ITEMS
    bool _PPBarrels;
    bool _PPTowerBarrels;
    bool _PPWaterfalls;
    #endregion

    #region probability of item appears (in editor)
    public int _pBubbles; 
    public int _pBarrels;
    public int _pTowerBarrels;
    public int _pWaterfalls;
    #endregion

    public void UpdateText() {
        pointsText.text = PlayerPrefs.GetInt("Points").ToString();
        if (int.Parse(pointsText.text) == goalPoints)
            Time.timeScale = 0f;
    }
}
