using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectingCoins : MonoBehaviour
{

    public TMP_Text scoreTxt;
    public TMP_Text lifePlayer;
    private int score;
    private int life;

    public HealthBase healthBase;


    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        life = healthBase.startLife;
        UpdateScoreAndLifeTexts();

    }

    // Update is called once per frame
    private void Update()
    {
        UpdateScoreAndLifeTexts();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Moeda"))
        {
            score++;
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("Vida"))
        {
            life++;
            Destroy(col.gameObject);
        }
    }

    private void UpdateScoreAndLifeTexts()
    {
        scoreTxt.text = "Score: " + score.ToString();
        lifePlayer.text = "Life: " + life.ToString();
    }
}
