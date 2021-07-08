
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string song, difficulty;
    public Text pointsText;
    [SerializeField] Text recordPoints;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public GameObject continuePanel;
    #region final canvas 
    public int star1Points;
    public int star2Points;
    public int goalPoints;

    [SerializeField] GameObject pauseCanvas;
    public GameObject levelCompleteCanvas;
    public GameObject retryButton, nextLevelButton;
    public GameObject levelCompleteText1, levelCompleteText2, stars;
    public Image levelProgressUI;
    public Text finalPoints;
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
        Debug.Log(_player.playerName);
        _creator = FindObjectOfType<CreatorBehaviour>();
        _destructor = FindObjectOfType<ObstacleBehaviour>();
        Time.timeScale = 1f;
        AudioManager.instance.Play(song);
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
               
                // StartCoroutine("LevelComplete");
                LevelComplete();
            }
                
        }
    }

    public void RetryLevel() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    /* IEnumerator LevelComplete(){
         PlayerPrefs.SetInt("Lv" + levelIndex, int.Parse(pointsText.text));
         levelCompleteCanvas.SetActive(true);
         finalPoints.text = pointsText.text;
         coinsAmount.text = SetStars().ToString();


         //_player.GetComponent<SphereCollider>().enabled = false; //prepare player for not to die
         _player.jumpForce = 0;
         _player.GetComponent<Rigidbody>().useGravity = false;
         _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
         yield return new WaitForSeconds(1.5f);
         _player.transform.position = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);
     }*/
    public void LevelComplete()
    {
        Time.timeScale = 1f;
        pauseCanvas.gameObject.SetActive(false);
        _player = FindObjectOfType<PlayerMovement>();
        PlayerPrefs.SetInt("Lv" + levelIndex, int.Parse(pointsText.text));
        levelCompleteCanvas.SetActive(true);
        Debug.Log(_player.playerName);
        finalPoints.text = pointsText.text;
        coinsAmount.text = SetStars().ToString();
        retryButton.SetActive(false);

        // _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.GetComponent<SphereCollider>().enabled = false; //prepare player for not to die
        _player.jumpForce = 0;
        _player._canJump = false;
        _player.GetComponent<Rigidbody>().useGravity = false;
        _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        /*  yield return new WaitForSeconds(1.5f);
          _player.transform.position = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);*/
    }

    public int SetStars() { //transform stars obtained in silver coins for the player
        if (pointsText.text == goalPoints.ToString()) {
            FindObjectOfType<SingleLevel>().PressStarsButton(3);
            return 3;
        }
            
        else if (star2.activeInHierarchy) {
            FindObjectOfType<SingleLevel>().PressStarsButton(2);
            return 2;
        }
            
        else if (star1.activeInHierarchy) {
            FindObjectOfType<SingleLevel>().PressStarsButton(1);
            return 1;
        }
            
        else
            return 0;
    }

    #region continue methods
    public void Continue() {
        // _player.GetComponent<Rigidbody>().velocity = _player.originalSpeed; //stop movement
        _player = FindObjectOfType<PlayerMovement>();
        _player.transform.position = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z + 9);
        continuePanel.SetActive(false);
        _player.hasDeadBefore = true;
        _player._canJump = true;
        _player.GetComponent<Rigidbody>().useGravity = true;
        ReanudeConstraints();
        
        _player.playerSpeed = _player.originalSpeed;
        _player.GetComponent<MeshRenderer>().enabled = true;
        Time.timeScale = 1f;
    }

    /* IEnumerator ContinuePlaying() { 
     }
    IEnumerator ContinuePlaying()
    {
        // _player.GetComponent<Rigidbody>().velocity = _player.originalSpeed; //stop movement
        _player = FindObjectOfType<PlayerMovement>();
        continuePanel.SetActive(false);
        _player.hasDeadBefore = true;
        _player.GetComponent<Rigidbody>().useGravity = true;
        ReanudeConstraints();

        _player.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 1f;
    }*/
    public void DontContinue() {
        // _player.hasDeadBefore = true;
        _player = FindObjectOfType<PlayerMovement>();
        continuePanel.SetActive(false);
        _player.isDead = true;
        Time.timeScale = 1f;
        _player.RestartGame();
    }
    void ReanudeConstraints() {
        _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        _player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
       
    }
    #endregion
    #region pause methods
    public void PauseGame() {
        StartCoroutine("PauseTime");
    }

    IEnumerator PauseTime() {
        pauseCanvas.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 0f;
    }
    #endregion

    public void GoToNextScene() {
        SumCoins();
        switch (difficulty)
        {
            case "Easy":
                AudioManager.instance.StopSong(song);
                AudioManager.instance.Play("ButtonClick");
                SceneManager.LoadScene("EasyLevelSelection");
                break;
            case "Medium":
                AudioManager.instance.StopSong(song);
                AudioManager.instance.Play("ButtonClick");
                SceneManager.LoadScene("MediumLevelSelection");
                break;
            case "Hard":
                AudioManager.instance.StopSong(song);
                AudioManager.instance.Play("ButtonClick");
                SceneManager.LoadScene("HardLevelSelection");
                break;
        }
    }

    public void SumCoins() {
        int coins = PlayerPrefs.GetInt("Coins");
        int newCoins = coins + int.Parse(coinsAmount.text.ToString());
        Debug.Log("coins:" + coins);
        Debug.Log("newCoins:" + newCoins);
        PlayerPrefs.SetInt("Coins", newCoins);
    }
}
