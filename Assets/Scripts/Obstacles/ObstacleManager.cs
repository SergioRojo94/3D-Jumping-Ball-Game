
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] bool bubbles; //if level has items
    [SerializeField] bool barrels;

    public int _probablyBubbles; //probably of item appears (in editor)
    public int _probablyBarrels;

    int haveBubbles; 
    int haveBarrels;

    void Awake() {
        Probabilities();
    }
    void Start(){
        Bubble();
        Barrel();
    }

    void Probabilities() {
        _probablyBarrels = FindObjectOfType<GameManager>()._pBarrels;
        _probablyBubbles = FindObjectOfType<GameManager>()._pBubbles;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        { //In Main Menu don't want any obstacle
            _probablyBubbles = 0;
            _probablyBarrels = 0;
        }
    }
    void Bubble() {
        if (bubbles == false)
            GetComponentInChildren<Bubble>().gameObject.SetActive(false);
        else {
            haveBubbles = Random.Range(0, 100);
            if (haveBubbles > _probablyBubbles)
                GetComponentInChildren<Bubble>().gameObject.SetActive(false);
        }
    }

    void Barrel() {
        if (barrels == false)
            transform.GetChild(4).gameObject.SetActive(false);
        else {
                haveBarrels = Random.Range(0, 100);
            if (haveBarrels > _probablyBarrels)
                transform.GetChild(4).gameObject.SetActive(false);
        }
    }
}
