/* John Mordi
 * ObjectPooler.cs
 * Assignment#10
 * Manages the spawning of objects using pools to limit their count
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Pool pool;
    Queue<GameObject> objectPool = new Queue<GameObject>();
    public static ObjectPooler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        FillPoolsWithInactiveObjects();
    }

    private void FillPoolsWithInactiveObjects()
    {

        for(int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {

        GameObject objToSpawn = objectPool.Dequeue();

        objToSpawn.SetActive(true);

        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        objectPool.Enqueue(objToSpawn);

        return objToSpawn;
    }

    public void ReturnObjectToPool(string tag, GameObject objToReturn)
    {
        objToReturn.SetActive(false);
        objectPool.Enqueue(objToReturn);
    }
}
