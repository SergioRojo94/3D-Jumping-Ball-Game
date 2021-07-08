
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;
    public void NextCharacter() {
        AudioManager.instance.Play("ButtonClick");
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter() {
        AudioManager.instance.Play("ButtonClick");
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
            selectedCharacter += characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

   public void StartGame() {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
       // SceneManager.LoadScene(1, LoadSceneMode.Single);
   }
}
