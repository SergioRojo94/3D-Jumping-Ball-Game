
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text pointsText;
    [SerializeField] Text recordPoints;

    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;

    #region final canvas 
    public int star1Points;
    public int star2Points;
    public int goalPoints;

    public GameObject levelCompleteCanvas;
    public GameObject retryButton, nextLevelButton;
    public GameObject stars0, levelCompleteText,stars;
    [SerializeField] Text finalPoints;
    [SerializeField] Text coinsAmount;
    #endregion
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
    bool _PPBlueFire;
    bool _PPVioletFire;
    #endregion

    #region probability of item appears (in editor)
    public int _pBubbles; 
    public int _pBarrels;
    public int _pTowerBarrels;
    public int _pWaterfalls;
    public int _pBlueFire;
    public int _pVioletFire;
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
            UpdateStars();
            if (int.Parse(pointsText.text) == goalPoints) {
                StartCoroutine(LevelComplete());
            }
                
        }
    }

    void SpeedUp() {
        _player.IncreaseSpeed();
        _creator.IncreaseSpeed();
        _destructor.IncreaseSpeed();
        _camera.IncreaseSpeed();
    }

    void UpdateStars() {
       if (pointsText.text == star1Points.ToString()) {
            star1.SetActive(true);
        }
       else if (pointsText.text == star2Points.ToString()) {
            star2.SetActive(true);
        }
       //nothing 'bout 3 star because when player reches 3rd star, the game ends and victory gui appears
    }

    IEnumerator LevelComplete(){
        PlayerPrefs.SetInt("Lv" + levelIndex, int.Parse(pointsText.text));
        finalPoints.text = pointsText.text;
        coinsAmount.text = SetStars().ToString();
        levelCompleteCanvas.SetActive(true);
        _player.GetComponent<SphereCollider>().enabled = false; //prepare player for not to die
        _player.jumpForce = 0;
        _player.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(1.5f);
        _player.transform.position = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);
    }

    private int SetStars() { //transform stars obtained in silver coins for the player
        if (pointsText.text == goalPoints.ToString())
            return 3;
        else if (star2.activeInHierarchy)
            return 2;
        else if (star1.activeInHierarchy)
            return 1;
        else
            return 0;
    }
}
