using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] float _degreesPerSecond;
    public GameObject target;
    public GameObject[] targetArray;

    void Start() { 
        for (int i = 0; i < targetArray.Length; i++)
        {
            if (targetArray[i].activeInHierarchy == true)
                target = targetArray[i];
        }
    }
    void Update() {
        transform.RotateAround(target.transform.position, Vector3.up, _degreesPerSecond * Time.deltaTime);
    }
}
