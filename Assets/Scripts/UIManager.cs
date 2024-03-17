
/*          [  Solo Designs  ]          */
//Use this script to fit all your game with the screen size

using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Refs for main menu
    public TextMeshProUGUI score;
    public TextMeshProUGUI previousScoreTxt;
    public TextMeshProUGUI highScore;
    public Button PlayButton;
    public TextMeshProUGUI coin;

    public GameObject cam;
    public int previousScore;

    //Set game in menu state
    void Start()
    {
        score.gameObject.SetActive(false);
        SetScore();
    }

    //Update the score value
    void Update()
    {
        SetScore();
    }

    private void SetScore()
    {
        //Calculate the score
        float scoreValue = cam.transform.position.y / 5f;
        int finalScore = (int)scoreValue;
        //Display the scores
        score.text = finalScore.ToString();
        previousScoreTxt.text = previousScore.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //Save the current Score
        if (0 < finalScore)
            previousScore = finalScore;
        //Save the best Score
        if(finalScore > PlayerPrefs.GetInt("HighScore", 0))
            PlayerPrefs.SetInt("HighScore", finalScore);
        //Set Coin Text
        coin.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }
}
