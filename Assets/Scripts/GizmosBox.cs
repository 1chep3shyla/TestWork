using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosBox : MonoBehaviour
{
    public Vector3 boxCenter = Vector3.zero;
    public Vector3 boxSize = Vector3.one;
    public GameObject objectPrefab;
    public int numberOfObjects = 3;

    private void Start()
    {
        SpawnObjects();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + boxCenter, boxSize);
    }

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GetRandomPositionWithinBox();
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomPositionWithinBox()
    {
        Vector3 halfSize = boxSize * 0.5f;
        Vector3 randomOffset = new Vector3(
            Random.Range(-halfSize.x, halfSize.x),
            Random.Range(-halfSize.y, halfSize.y),
            0f
        );

        return transform.position + boxCenter + randomOffset;
    }
}
