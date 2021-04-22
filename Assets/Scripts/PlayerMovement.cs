using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    bool jump = false;
    Rigidbody rb;
    Transform cameraHolder;
    Vector3 vec;
    int length;
    bool isGameOver = false;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] GameObject[] obstacles;
    [SerializeField] float obstacleDistance;
    [SerializeField] float obstaclePosY;
    [SerializeField] int numberOfObstacles;

    void Start() {
        rb = GetComponent<Rigidbody>();
        cameraHolder = Camera.main.transform.parent;
        BuildObstacles();
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Space))
            jump = true;

        if (!isGameOver) {
            float playerY = transform.position.y;
            if(playerY < -32f || playerY > 32f) {
                isGameOver = true;
                Invoke("RestartGame", .3f);
            }
        }
    }

    //Generate Obstacles randomly
    void BuildObstacles() {
        length = obstacles.Length;
        vec.z = 56.4f;
        for (int i = 0; i < numberOfObstacles; i++) {
            vec.z += obstacleDistance;
            vec.y = Random.Range(-obstaclePosY, obstaclePosY);

            Instantiate(obstacles[Random.Range(0, length)], vec, Quaternion.identity);
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

    void OnCollisionEnter() {
        rb.velocity = Vector3.zero; //stop movement
        rb.useGravity = false; //Disable Gravity
        rb.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<MeshRenderer>().enabled = false; //hide the player
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        Invoke("RestartGame", 1f);
       // Time.timeScale = 0.3f;
    }

    void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
