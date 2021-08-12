
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int points = 0;
    GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }
    public void SumPoints(int p) {
        points += p;
        if (points > PlayerPrefs.GetInt("Lv"+gm.levelIndex))
            PlayerPrefs.SetInt("Lv" + gm.levelIndex, points);
        PlayerPrefs.SetInt("Points", points);
        gm.UpdateText();
        gm.CheckArcadeRewards();
    }
}
