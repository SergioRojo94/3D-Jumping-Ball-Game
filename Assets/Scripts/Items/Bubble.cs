using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    int _scale;
    [SerializeField] int min, max;
    void Start()
    {
        _scale = Random.Range(min, max);
        gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Light>().enabled = false;
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }
}
