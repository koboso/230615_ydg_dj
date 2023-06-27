using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{
    [SerializeField ] private GameObject enemyPrefab;



    private void Start(){
        for(int i = 0; i< 10; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.transform.position = new Vector3(Random.Range(-2,2), 5 + Random.Range(0,3), 0);
            Enemy e = new Enemy(Enemy.EnemyType.Basic, 100, 10, 0.5f+i);
            obj.GetComponent<EnemyObject>().SetEnemy(e);
        }
    }


    // Update is called once per frame
    void Update(){


        //Instantiate()



        
    }
}
