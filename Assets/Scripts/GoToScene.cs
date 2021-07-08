
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] string _scene;

    public void GoTo() {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Shop") {
            AudioManager.instance.Play("ButtonClick");
            //  return;
            //  AudioManager.instance.StopSong(AudioManager.instance.songName);
        }
        else if (SceneManager.GetActiveScene().name == "EasyLevelSelection" || SceneManager.GetActiveScene().name == "MediumLevelSelection" ||
                   SceneManager.GetActiveScene().name == "HardLevelSelection")
        {
            AudioManager.instance.Play("ButtonClick");
        }
        else {
            AudioManager.instance.StopSong(FindObjectOfType<GameManager>().song);
            AudioManager.instance.Play("ButtonClick");
        }
        SceneManager.LoadScene(_scene);
    }
}
