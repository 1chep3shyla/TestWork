using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Transform weaponTransform;
    public GameObject enemy;
    public Fire targetMain;
    public float offset;

    private void Update()
    {
        enemy = targetMain.target;
        if (enemy != null)
        {
            Vector3 direction = enemy.transform.position - weaponTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg +offset;
            weaponTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}