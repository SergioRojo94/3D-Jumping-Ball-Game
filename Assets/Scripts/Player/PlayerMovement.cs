using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    bool jump = false;
    Rigidbody rb;
    Transform cameraHolder;
    Vector3 vec;
    bool isGameOver = false;

    [SerializeField] float playerSpeed;
    public float jumpForce;

    void Start() {
        rb = GetComponent<Rigidbody>();
        cameraHolder = Camera.main.transform.parent;
      //  BuildObstacles();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space))
            jump = true;
     /*   if (Input.touchCount > 0)
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
            

        if (!isGameOver) {
            float playerY = transform.position.y;
            if(playerY < -32f || playerY > 32f) {
                if(SceneManager.GetActiveScene().name != "MainMenu") {
                    isGameOver = true;
                    Invoke("RestartGame", .3f);
                }
            }
        }
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
            rb.velocity = Vector3.zero; //stop movement
            rb.useGravity = false; //Disable Gravity
            rb.constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<MeshRenderer>().enabled = false; //hide the player
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
            Invoke("RestartGame", 1f);
            // Time.timeScale = 0.3f;
        }
    }

    void RestartGame() {
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<GameManager>().levelCompleteCanvas.SetActive(true);
        FindObjectOfType<GameManager>().retryButton.SetActive(true);
        FindObjectOfType<GameManager>().nextLevelButton.SetActive(false);
        FindObjectOfType<GameManager>().levelCompleteText.SetActive(false);
        FindObjectOfType<GameManager>().stars.SetActive(false);
    }

    //methods for arcade level:
    void Increase(){
        playerSpeed += 5;
    }
    public void IncreaseSpeed() {
        InvokeRepeating("Increase", 0f, 10f);
    }
}
