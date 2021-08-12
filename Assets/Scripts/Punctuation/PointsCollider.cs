using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollider : MonoBehaviour
{
    [SerializeField] int points;

    [SerializeField] GameObject[] obstacles;
    [SerializeField] Material[] materials;
    PlayerPoints _playerP;
    void Start() {
        _playerP = FindObjectOfType<PlayerPoints>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _playerP.SumPoints(points);
           // AudioManager.instance.Play("GetPoint");
        }
        ChangeColorObstacles();
    }

    void ChangeColorObstacles() {
        int i = 0;
        foreach (GameObject obs in obstacles) {
            obstacles[i].GetComponent<MeshRenderer>().material = materials[i];
            i++;
        }
            
    }
}
