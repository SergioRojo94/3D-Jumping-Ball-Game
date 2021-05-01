using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollider : MonoBehaviour
{
    [SerializeField] int points;
    PlayerPoints _playerP;
    void Start() {
        _playerP = FindObjectOfType<PlayerPoints>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
            _playerP.SumPoints(points);
    }
}
