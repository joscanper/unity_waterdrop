using System.Collections;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject Prefab;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject.Instantiate(Prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
