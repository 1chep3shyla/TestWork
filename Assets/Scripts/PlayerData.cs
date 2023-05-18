using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class PlayerData
{
    public int[] allCount = new int[10];
    public int[] idSlot = new int[10];
    public bool[] slotIs = new bool[10];


    public PlayerData(Player player)
    { 
        for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySlot>().items.Length; i++)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySlot>().items[i] == true)
            {
                idSlot[i] = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySlot>().idItem[i];
                allCount[i] = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySlot>().count[i];
                slotIs[i] = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySlot>().items[i];
            }
        }

       


    }
}
