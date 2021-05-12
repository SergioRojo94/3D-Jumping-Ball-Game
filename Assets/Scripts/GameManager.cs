
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] int goalPoints;
    
    [SerializeField] Text recordPoints;
    public string levelIndex;

    [SerializeField] RotateAround _camera; //increase camera rotation in arcade
    PlayerMovement _player;
    CreatorBehaviour _creator;
    ObstacleBehaviour _destructor;

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

    void Start(){
        _player = FindObjectOfType<PlayerMovement>();
        _creator = FindObjectOfType<CreatorBehaviour>();
        _destructor = FindObjectOfType<ObstacleBehaviour>();

        recordPoints.text = PlayerPrefs.GetInt("Lv" + levelIndex).ToString(); //get playerpref and show the record of the current level
        if (SceneManager.GetActiveScene().name == "ArcadeScene") {
            SpeedUp();
        }
    }
    public void UpdateText() {
        pointsText.text = PlayerPrefs.GetInt("Points").ToString();
        if (SceneManager.GetActiveScene().name != "ArcadeScene") { //arcade is infinite
            if (int.Parse(pointsText.text) == goalPoints) {
                PlayerPrefs.SetInt("Lv" + levelIndex, int.Parse(pointsText.text));
                Time.timeScale = 0f;
            }
                
        }
    }

    void SpeedUp() {
        _player.IncreaseSpeed();
        _creator.IncreaseSpeed();
        _destructor.IncreaseSpeed();
        _camera.IncreaseSpeed();
    }
}
