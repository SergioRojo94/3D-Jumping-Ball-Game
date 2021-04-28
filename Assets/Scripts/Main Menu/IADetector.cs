using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Useless Right Now
public class IADetector : MonoBehaviour
{
    [SerializeField] bool down= false;
    [SerializeField] bool colliderIsActive = true;
    [SerializeField] float _speed;
    PlayerMovement _player;
    Collider _collider;
    Rigidbody _rb;
    Vector3 _playerPos;
    void Start() {
        _player = FindObjectOfType<PlayerMovement>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        // transform.position += Vector3.forward * Time.deltaTime * _speed;
        _rb.AddForce(Vector3.forward * _speed * Time.fixedDeltaTime);
                _playerPos = _player.transform.position;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            if (colliderIsActive == true) {
                StartCoroutine(TurnOffCollider());
                if (down == false) //   TODO IMPROVE THIS
                    _player.transform.position = new Vector3(_playerPos.x, _playerPos.y - 13, _playerPos.z);
                else
                    _player.transform.position = new Vector3(_playerPos.x, _playerPos.y + 13, _playerPos.z);
            }
        }
    }

    IEnumerator TurnOffCollider() {
        // quitar el collider, 1.5 segundois despues activarlo
        colliderIsActive = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(2f);
        colliderIsActive = true;
        _collider.enabled = true;
    }
}
