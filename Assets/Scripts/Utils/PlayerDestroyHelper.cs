using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public GameObject playerPrefab;

    public void KillPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
