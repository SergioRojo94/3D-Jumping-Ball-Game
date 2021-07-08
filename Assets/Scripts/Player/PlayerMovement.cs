using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    bool jump = false;
    Rigidbody rb;
    Transform cameraHolder;
    Vector3 vec;
    bool isGameOver = false;

    public bool hasDeadBefore = false;
    public float playerSpeed;
    public float originalSpeed;
    public float jumpForce;
    public bool _canJump = true;
    public bool isDead = false;
    public bool unlocked;
    public string playerName;
    void Start() {
        /*   if (SceneManager.GetActiveScene().name == "EasyLevelSelection")
           {
               if (playerName != "Green" || playerName != "Blue" || playerName != "Purple")
               gameObject.transform.localScale = new Vector3(15f, 15f, 15f);
               else if (playerName == "Big SpikeBall")
                   gameObject.transform.localScale = new Vector3(15f, 15f, 15f);
           }*/
        PlayerAchieved();
        rb = GetComponent<Rigidbody>();
        originalSpeed = playerSpeed;
        cameraHolder = Camera.main.transform.parent;
      //  BuildObstacles();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space) && _canJump == true)
            jump = true;
        /*  if (Input.touchCount > 0)
               {
                   Touch touch = Input.GetTouch(0);
                   switch (touch.phase)
                   {
                       // So if touch began
                       case TouchPhase.Began:

                           jump = true;
                           break;
                   }
               }*/
        //}

        if (!isGameOver)
        {
            float playerY = transform.position.y;
            if (playerY < -32f || playerY > 32f)
            {
                if (SceneManager.GetActiveScene().name != "MainMenu")
                {
                    if (hasDeadBefore == false)
                    {
                        rb.useGravity = false;
                        isGameOver = true;
                        _canJump = false;
                        playerSpeed = 0f;
                        rb.constraints = RigidbodyConstraints.FreezePositionY;
                        rb.constraints = RigidbodyConstraints.FreezePositionZ;
                        Invoke("WannaContinue", 1f);
                        //transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
                    }

                    else
                    {
                        isGameOver = true;
                        playerSpeed = 0f;
                        rb.constraints = RigidbodyConstraints.FreezePositionY;
                        rb.constraints = RigidbodyConstraints.FreezePositionZ;
                        rb.useGravity = false;
                        _canJump = false;
                        Invoke("RestartGame", .3f);
                    }
                }
            }
           
        }
        if (transform.position.y < -70)
        {
            if (SceneManager.GetActiveScene().name != "MainMenu")
                Invoke("RestartGame", .3f);
        }
    }

    //Check if player is achieved
    void PlayerAchieved() {
        int checkUnlocked = PlayerPrefs.GetInt(playerName);
        if (checkUnlocked == 1)
            unlocked = true;
    }
    //Player moves forward every frame
    void FixedUpdate() {
            rb.AddForce(Vector3.forward * playerSpeed * Time.fixedDeltaTime);
            if (jump) {
                rb.AddForce(Vector3.up * jumpForce * 1000 * Time.fixedDeltaTime);
                jump = false;
            }
    }

    void LateUpdate() {
        vec.x = cameraHolder.transform.position.x;
        vec.y = cameraHolder.transform.position.y;
        vec.z = transform.position.z;

        cameraHolder.transform.position = vec;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
           // rb.velocity = Vector3.zero; //stop movement
            rb.useGravity = false; //Disable Gravity
            playerSpeed = 0f;
            _canJump = false;
            //GetComponent<MeshRenderer>().enabled = false; //hide the player
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            if (hasDeadBefore == false)
                Invoke("WannaContinue", 1f);
            else
                Invoke("RestartGame", 1f); 
                //Debug.Log("coronaonao");
            // Time.timeScale = 0.3f;
        }
    }

    #region call GameManager continue Methods
    void WannaContinue() {
        FindObjectOfType<GameManager>().continuePanel.SetActive(true);
       // rb.constraints = RigidbodyConstraints.FreezePositionY;
        //transform.position = new Vector3(transform.position.x, 0f, transform.position.z + 9);
        hasDeadBefore = true;
        StartCoroutine("Wait2secs");
    }

    IEnumerator Wait2secs() {
       // yield return new WaitForSeconds(0.9f);
       // transform.position = new Vector3(transform.position.x, 0f, transform.position.z + 9);
        yield return new WaitForSeconds(0.5f);
        rb.constraints = RigidbodyConstraints.FreezePositionY;

        //  Time.timeScale = 0f;
    }
    #endregion
    public void RestartGame() {
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        _canJump = false;
        isDead = true;
        GetComponent<MeshRenderer>().enabled = false;
        FindObjectOfType<GameManager>().levelCompleteCanvas.SetActive(true);
        FindObjectOfType<GameManager>().retryButton.SetActive(true);
        FindObjectOfType<GameManager>().nextLevelButton.SetActive(false);
        FindObjectOfType<GameManager>().levelCompleteText1.SetActive(false);
        FindObjectOfType<GameManager>().levelCompleteText2.SetActive(false);
        FindObjectOfType<GameManager>().stars.SetActive(false);

        FindObjectOfType<GameManager>().finalPoints.text = FindObjectOfType<GameManager>().pointsText.text;
    }

    //methods for arcade level:
    void Increase(){
        playerSpeed += 5;
    }
    public void IncreaseSpeed() {
        InvokeRepeating("Increase", 0f, 10f);
    }
}
