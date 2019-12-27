using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{
    public Text scorePlayerText;
    public Text scoreEnemyText;
    public SceneChanger sceneChanger;
    public AudioSource scoreSoundEffect;

    int scorePlayerQuantity;
    int scoreEnemyQuantity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Left"))
        {
            scoreEnemyQuantity++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemyQuantity);
        } else if(gameObject.CompareTag("Right"))
        {
            scorePlayerQuantity++;
            UpdateScoreLabel(scorePlayerText, scorePlayerQuantity);
        }

        collision.GetComponent<BallBehaviour>().gameStarted = false;
        scoreSoundEffect.Play();

        CheckScore();
    }

    void CheckScore()
    {
        if(scorePlayerQuantity >= 3)
        {
            sceneChanger.changeSceneTo("WinScene");
        }else if (scoreEnemyQuantity >= 3)
        {
            sceneChanger.changeSceneTo("LoseScene");
        }
    }

    void UpdateScoreLabel(Text label, int score)
    {
        label.text = score.ToString();
    }
}
