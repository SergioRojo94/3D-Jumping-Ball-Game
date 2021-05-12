using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creates obstacles randomly and moves forward
public class CreatorBehaviour : MonoBehaviour
{
    public GameObject[] obstacles;
    [SerializeField] float generatorTimer;
    int length;
    Vector3 vec;
    [SerializeField] float obstacleDistance;
    [SerializeField] float obstaclePosY;

    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] bool inMenu = false;
    void Start() {
        rb = GetComponent<Rigidbody>();
        StartGenerator();
        if (inMenu == true)
            obstaclePosY = 0;
    }
    void FixedUpdate() {
        rb.AddForce(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    //Generate Obstacles randomly
    void CreateObstacle() {
        length = obstacles.Length;
        vec.z += obstacleDistance;
        vec.y = Random.Range(-obstaclePosY, obstaclePosY);

        Instantiate(obstacles[Random.Range(0, length)], vec, Quaternion.identity);
    }

    public void StartGenerator() {
        InvokeRepeating("CreateObstacle", 0f, generatorTimer);
    }

    //methods for arcade level:
    void Increase()
    {
        speed += 5;
    }
    public void IncreaseSpeed()
    {
        InvokeRepeating("Increase", 0f, 10f);
    }
}
