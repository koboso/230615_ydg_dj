using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyObject : MonoBehaviour{
    [SerializeField] private Sprite[] enemyImg;
    [SerializeField] private Slider hpbar;

    Enemy enemy = null;


    public Enemy GetEnemy
    {
        get
        {
            return this.enemy;
        }
    }

    float time = 0f;

    public void SetEnemy(Enemy e){
        this.enemy = e;
        this.hpbar.maxValue = enemy.Hp;
        this.hpbar.value = enemy.Hp;

    }


    private void Start(){
       // SetEnemy(new Enemy(Enemy.EnemyType.Basic, 100, 10, 3.0f));
    }




    private void Update(){
        if (enemy == null) return;
        MoveEnemy();
    }

    private void MoveEnemy(){

        if (this.transform.position.y <= -5f){
            return;
        }
        else
        {
            this.transform.position -= new Vector3(0, enemy.Speed * Time.deltaTime, 0);
        }

    }





}
