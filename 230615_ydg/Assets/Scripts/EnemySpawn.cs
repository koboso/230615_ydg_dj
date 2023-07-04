using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    [SerializeField ] private GameObject enemyPrefab;


    List<GameObject> enemyPool = new List<GameObject>();
    float time = 0f;

    int currentEnemeyCount = 0;

    // Update is called once per frame
    void Update(){
        if (GameCore.Instance.gameStatus != GameCore.GameStatus.Play) return;


        if (enemyPool.Count != 10){


            if(currentEnemeyCount >= GameCore.Instance.GetWaveEnemey){
                currentEnemeyCount = 0;
                GameCore.Instance.IncreaseWave();
            }

            int level = GameCore.Instance.Wave;

            GameObject obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(6, 8), 0);
            Enemy e = new Enemy(Enemy.EnemyType.Basic, 10 + (2* level) , 10 + level , Random.Range(1,3));
            obj.GetComponent<EnemyObject>().SetEnemy(e);
            enemyPool.Add(obj);
            currentEnemeyCount++;
        }
        else
        {
            for (int i = 0; i < enemyPool.Count; i++) {
                if (enemyPool[i] == null) enemyPool.RemoveAt(i);
            }
        }
    }
}
