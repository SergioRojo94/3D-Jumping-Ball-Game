
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] int goalPoints;

    public int _pBubbles; //probably of item appears (in editor)
    public int _pBarrels;
    public int _pTowerBarrels;

    public void UpdateText() {
        pointsText.text = PlayerPrefs.GetInt("Points").ToString();
        if (int.Parse(pointsText.text) == goalPoints)
            Time.timeScale = 0f;

    }
}
