using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectingCoins : MonoBehaviour
{

    public TMP_Text scoreTxt;
    private int score;


    // Start is called before the first frame update
    private void Start()
    {
        score = 0;        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Moeda"))
        {
            score++;
            Destroy(col.gameObject);
        }        
    }

    private void UpdateScore()
    {
        scoreTxt.text = "Score: " + score.ToString();
    }
}