using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullRe : MonoBehaviour
{
    public int reCount;
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.gameObject.GetComponent<Fire>().BullCount += reCount;
            Destroy(gameObject);
        }
    }
}
