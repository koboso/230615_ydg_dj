using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    [SerializeField ] private GameObject enemyPrefab;


    List<GameObject> enemyPool = new List<GameObject>();
    float time = 0f;



    private void Start(){



        /*for(int i = 0; i< 3; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.transform.position = new Vector3(Random.Range(-2,2), 5 , 0);
            Enemy e = new Enemy(Enemy.EnemyType.Basic, 5, 10, 2);
            obj.GetComponent<EnemyObject>().SetEnemy(e);
        }*/
    }

    // Update is called once per frame
    void Update(){

        if (enemyPool.Count != 10)
        {
            GameObject obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(10, 16), 0);
            Enemy e = new Enemy(Enemy.EnemyType.Basic, 3, 10, Random.Range(1, 5));
            obj.GetComponent<EnemyObject>().SetEnemy(e);

            enemyPool.Add(obj);
        }
        else
        {
            for (int i = 0; i < enemyPool.Count; i++) {

                if (enemyPool[i].transform.position.y <= -5f)
                {
                    time += Time.deltaTime;

                    if (time >= 1f)
                    {
                        time = 0f;
                        if (enemyPool[i].GetComponent<EnemyObject>().GetEnemy.Hit(1) == false)
                        {
                            Destroy(enemyPool[i].gameObject);
                            enemyPool.RemoveAt(i);

                        }
                    }
                }
            }
          
        }


    }
}
