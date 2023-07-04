using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    [SerializeField ] private GameObject enemyPrefab;


    List<GameObject> enemyPool = new List<GameObject>();
    float time = 0f;


    // Update is called once per frame
    void Update(){
        if (GameCore.Instance.gameStatus != GameCore.GameStatus.Play) return;


        if (enemyPool.Count != 2)
        {
            GameObject obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, this.transform);
            //obj.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(10, 16), 0);
            obj.transform.position = new Vector3(0, 5 + Random.Range(1,3), 0);
            Enemy e = new Enemy(Enemy.EnemyType.Basic, 15, 10, Random.Range(1,3));
            obj.GetComponent<EnemyObject>().SetEnemy(e);
            enemyPool.Add(obj);
        }
        else
        {
            for (int i = 0; i < enemyPool.Count; i++) {
                if (enemyPool[i] == null) enemyPool.RemoveAt(i);
            }
        }
    }
}
