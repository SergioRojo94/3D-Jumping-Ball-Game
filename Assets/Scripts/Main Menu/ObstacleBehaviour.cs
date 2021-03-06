using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroy Obstacles and Moves Forward
public class ObstacleBehaviour : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        rb.AddForce(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obstacle"))
            Destroy(collision.gameObject);
    }

    //methods for arcade level:
    void Increase() {
        speed += 5;
    }
    public void IncreaseSpeed() {
        InvokeRepeating("Increase", 0f, 10f);
    }
}
