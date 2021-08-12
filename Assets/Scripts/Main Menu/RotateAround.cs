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

    //methods for arcade level:
    void Increase() {
        if (_degreesPerSecond < 1)
            _degreesPerSecond += 0.5f;
        else
            return;
    }
    public void IncreaseSpeed() {
        InvokeRepeating("Increase", 0f, 55f);
    }
}
