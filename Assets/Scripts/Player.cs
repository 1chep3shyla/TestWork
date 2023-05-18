using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public float pos;
    public GameObject spriteMask;
    public GameObject diePanel;
    private float timeSave = 0.5f;

    void Start()
    {
        LoadPlayer();
    }
    void Update()
    {
        timeSave -= Time.deltaTime;
        if (timeSave <= 0f)
        {
            SavePlayer();
        }
        if (hp != maxHp)
        {
            pos = (float)(hp % maxHp) / maxHp;
        }
        else
        {
            pos = 1;
        }
        if (hp <= 0)
        {
            diePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        spriteMask.transform.localPosition = new Vector3(-pos, 0, 0);
    }
    public void TakeDamage(int dmg)
    {
        hp -= dmg;
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        if (data != null)
        {
            for (int i = 0; i < gameObject.GetComponent<InventorySlot>().items.Length; i++)
            {
                gameObject.GetComponent<InventorySlot>().items[i] = data.slotIs[i];
                gameObject.GetComponent<InventorySlot>().idItem[i] = data.idSlot[i];
                gameObject.GetComponent<InventorySlot>().count[i] = data.allCount[i];
                if (gameObject.GetComponent<InventorySlot>().allSprites[data.idSlot[i]] != null)
                {
                    gameObject.GetComponent<InventorySlot>().itemImages[i].sprite = gameObject.GetComponent<InventorySlot>().allSprites[data.idSlot[i]];
                }
            }
        }
    }
}
