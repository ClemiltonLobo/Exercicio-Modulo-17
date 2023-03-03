using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBase : MonoBehaviour
{
    public Image filledLife;
    public int currentLife;
    public int fullLife = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = fullLife;
    }

    // Update is called once per frame
    void Update()
    {
               
    }
    public void TakesDamage()
    {
        currentLife -= 10;

        if (currentLife <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
