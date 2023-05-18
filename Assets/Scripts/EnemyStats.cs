using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int hp;
    public int hpMax;
    public GameObject spriteMask;
    public Rigidbody2D rb;
    public float pos;
    public ListDrop dropAll;
    void Start()
    {
        dropAll = Camera.main.GetComponent<ListDrop>();
    }
    void Update()
    {
        if (hp != hpMax)
        {
            pos = (float)(hp % hpMax) / hpMax;
        }
        else
        {
            pos = 1;
        }
        if (hp <= 0)
        {
            Drop();
            Destroy(gameObject);
        }
        rb.velocity = new Vector3(0f, 0f, 0f);
        spriteMask.transform.localPosition = new Vector3(-pos,0,0);
    }
    public void Drop()
    {
        int i = Random.Range(0, dropAll.drop.Length);
        GameObject Newdrop = Instantiate(dropAll.drop[i], transform.position, dropAll.drop[i].transform.rotation);
    }
}
