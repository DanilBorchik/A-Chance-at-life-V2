using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombi : MonoBehaviour
{
    public List<Transform> spawnpoint;
    public EnemyAIv2 zombiPrefab;
    public float timer;
    public int colvoZombi;

    private bool zaspavnilis = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var Player = other.gameObject.GetComponent<PeredvizhenieIgroka>();
        if (Player != null)
        {
            if (!zaspavnilis)
            {
                zaspavnilis = true;
                StartCoroutine(Sozdavalka());
            }
        }
    }
    private IEnumerator Sozdavalka()
    {
        for (int i = 0; i < colvoZombi; i++)
        {
            for (int j = 0; j < spawnpoint.Count; j++)
            {
                EnemyAIv2 zombieClone = Instantiate(zombiPrefab, spawnpoint[j].position, Quaternion.identity);
                zombieClone.InitEnemyLinks(true);
            }
            yield return new WaitForSeconds(timer);
        }
    }
}
