using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start() {
        rb = GetComponent<Rigidbody>();
        StartGenerator();
    }
    void FixedUpdate() {
        rb.AddForce(Vector3.forward * speed * Time.fixedDeltaTime);
    }
    void CreateObstacle() {
        length = obstacles.Length;
        vec.z += obstacleDistance;
        vec.y = Random.Range(-obstaclePosY, obstaclePosY);

        Instantiate(obstacles[Random.Range(0, length)], vec, Quaternion.identity);
    }

    public void StartGenerator() {
        InvokeRepeating("CreateObstacle", 0f, generatorTimer);
    }
}
