using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image[] itemImages = new Image[10];
    public bool[] items;
    public Text[] textCount;
    public int[] count;
    public Button[] buttons;
    public Sprite[] allSprites;
    public int[] idItem;
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            textCount[i].text = "" + count[i];
            if (count[i] > 1)
            {
                textCount[i].gameObject.SetActive(true);
            }
            else
            {
                textCount[i].gameObject.SetActive(false);
            }
            if (items[i] == false)
            {
                buttons[i].interactable = false;
                itemImages[i].sprite = null;
            }
            else
            {
                buttons[i].interactable = true;
            }
        }
    }
    public void AddItem(Item newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == false)
            {
                idItem[i] = newItem.id;
                count[i]++;
                items[i] = true;
                itemImages[i].sprite = newItem.ItemSprite;
                itemImages[i].enabled = true;
                Destroy(newItem.gameObject);
                break;
            }
            else
            {
                if (itemImages[i].sprite == newItem.ItemSprite)
                {
                    count[i]++;
                    Destroy(newItem.gameObject);
                    break;
                }
            }
        }
    }

    public void RemoveItem(int index)
    {
        if (count[index] > 0)
        {

            if (count[index] > 1)
            {
                count[index] -= 1;
            }
            else
            {
                count[index] -= 1;
                items[index] = false;
                itemImages[index].sprite = null;
                itemImages[index].enabled = false;
            }
        }
    }
}

