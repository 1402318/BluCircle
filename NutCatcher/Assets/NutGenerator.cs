using UnityEngine;
using System.Collections;

public class NutGenerator : MonoBehaviour {

    private Vector3 startPostion;
    public float moveSpeed = 1f;
    public float moveDistance = 4f;
    public GameObject[] prefabs;
    private float newXpos = -10f;

    public float spawnTime = 0f;
    public float startTime = 0f;
    public float spawnDelay = 1.5f;

    void Start()
    {
        startPostion = transform.position;
    }

    void Update()
    {
        newXpos = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);

        transform.position = new Vector3(newXpos, startPostion.y, startPostion.z);

        spawnTime = Time.time - startTime;

        if(spawnTime >= spawnDelay)
        {
            startTime = Time.time;
            spawnTime = 0;
            SpawnObject();

        }
    }

    void SpawnObject ()
    {
        GameObject myObject = Instantiate(prefabs[0]) as GameObject;
        myObject.transform.position = transform.position;
    }
}
