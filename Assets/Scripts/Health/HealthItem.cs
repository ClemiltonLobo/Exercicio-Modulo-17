using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healthAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthBase playerHealth = other.GetComponent<HealthBase>();
            if (playerHealth != null)
            {
                playerHealth.GainLife(healthAmount);
                Destroy(gameObject);
            }
        }
    }
}
