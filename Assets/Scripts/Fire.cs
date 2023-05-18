using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Fire : MonoBehaviour
{
    public TMP_Text countBull;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootForce = 10f;
    public float enemyRadius = 5f;

    public GameObject[] enemies;
    public GameObject target;
    public Button shootButton;
    public int BullCount;

    private void Start()
    {
        shootButton.interactable = false;
    }

    private void Update()
    {
        countBull.text = "" + BullCount;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            if (target == null && Vector3.Distance(transform.position, enemies[i].transform.position) <= enemyRadius)
            {
                target = enemies[i];
            }
        }
        if (target != null && Vector3.Distance(transform.position, target.transform.position) <= enemyRadius)
        {
            shootButton.interactable = true;
        }
        else
        {
            shootButton.interactable = false;
            target = null;
        }
    }
    public void Shoot()
    {
        if (BullCount > 0)
        {
            BullCount -= 1;

            Vector3 direction = (target.transform.position - firePoint.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
            if (target != null)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = target.transform.position - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRadius);
    }
}