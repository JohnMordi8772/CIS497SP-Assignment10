/* John Mordi
 * VendingMachine.cs
 * Assignment#10
 * Manages the spawning on vending machine objects based on player input
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VendingMachine : MonoBehaviour
{
    ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            objectPooler.SpawnFromPool("Drink", new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z-1), gameObject.transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
