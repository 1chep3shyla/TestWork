 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    public string Name;
    public int id;
    public Sprite ItemSprite;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            player.gameObject.GetComponent<InventorySlot>().AddItem(this);
        }
    }

}
