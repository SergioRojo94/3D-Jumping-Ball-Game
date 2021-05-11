
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] string _scene;

    public void GoTo() {
        SceneManager.LoadScene(_scene);
    }
}
