
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI references :")]
    /* [SerializeField] private Image uiFillImage;
     [SerializeField] private Text uiStartText;
     [SerializeField] private Text uiEndText;*/
    [SerializeField] private Image bronzeImage;
    [SerializeField] private Image silverImage;
    [SerializeField] private Image goldImage;

    [Header("Player & Total points references :")]
    int playerPoints;
    int totalPoints;

    GameManager _gm;

    // "endLinePosition" to cache endLine's position to avoid
    // "endLineTransform.position" each time since the End line has a fixed position.
   // private Vector3 endLinePosition;

    // "fullDistance" stores the default distance between the player & end line.
   // private float fullDistance;




    private void Start() {
        totalPoints = FindObjectOfType<GameManager>().goalPoints;
        _gm = FindObjectOfType<GameManager>();
    }


   /* public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level + 1).ToString();
    }*/


   /* private float GetDistance()
    {
        // Slow
        //return Vector3.Distance (playerTransform.position, endLinePosition) ;

        // Fast
        return (endLinePosition - playerTransform.position).sqrMagnitude;
    }*/


    /*private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }*/


    private void Update() {
        Filling();
    }

    void Filling() {
        playerPoints = FindObjectOfType<PlayerPoints>().points;
        // check if the player doesn't pass the End Line
        if (playerPoints <= totalPoints)
        {
            // float newDistance = GetDistance();
            //float progressValue = Mathf.InverseLerp( 0f, playerPoints, totalPoints);
            if (playerPoints < _gm.star1Points)
                return;
            else if (playerPoints >= _gm.star1Points && playerPoints < _gm.star2Points)
                bronzeImage.gameObject.SetActive(true);
            else if (playerPoints >= _gm.star2Points && playerPoints < _gm.goalPoints)
                silverImage.gameObject.SetActive(true);
            else
                goldImage.gameObject.SetActive(true);
        }
    }
    }

    /*
       Mathf.InverseLerp (fullDistance, 0f, newDistance) ;
       InverseLerp( min , max , v ) : always returns a value between 0 & 1
       v is between min and max, 
          if v is close to min InverseLerp returns a number closed to 0 
          if v is close to max InverseLerp returns a number closed to 1 
       Example ( min = 0  , max = 50 ) :
          InverseLerp( min , max , 0 )  =>  0
          InverseLerp( min , max , 50 )  =>  1
          InverseLerp( min , max , 25 )  =>  0.5
          InverseLerp( min , max , -10 )  =>  0
          InverseLerp( min , max , 250 )  =>  1
          InverseLerp( min , max , 55 )  =>  1
          InverseLerp( min , max , 10 )  =>  (10-min)/(max-min) => 0.2
          ...
          ...
    */

