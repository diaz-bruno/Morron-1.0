using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private int enemyCant;
    [SerializeField] private int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop(){
        while (enemyCount <= enemyCant){
            Instantiate(prefabEnemy,transform.position,transform.rotation);
            enemyCount += 1;
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
        }
    }
}
