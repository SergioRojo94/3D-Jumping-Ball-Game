
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
        PlayerPrefs.SetInt("Points", points);
        gm.UpdateText();
    }
}
