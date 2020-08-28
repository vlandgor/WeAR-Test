using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> dataObjects = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (GameManager.isStart)
            {
                GameObject figure = Instantiate(dataObjects[Random.Range(0, 3)], transform.position, Quaternion.identity);
                figure.GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            }
        }
    }
}
