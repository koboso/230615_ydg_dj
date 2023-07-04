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


    private void Update(){
        if (enemy == null) return;

        if (GameCore.Instance.gameStatus != GameCore.GameStatus.Play) Destroy(this.gameObject);
        MoveEnemy();
    }

    private void MoveEnemy(){
        if (this.transform.position.y <= -5f){
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.position -= new Vector3(0, enemy.Speed * Time.deltaTime, 0);
        }
    }


    public void Hit(int dmg){

        if (enemy.Hp - dmg <= 0) Destroy(this.gameObject);

        if (enemy.Hit(dmg) == false){
            GameCore.Instance.IncreaseScore();
        }
        this.hpbar.value = enemy.Hp;
    }

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.tag == "Player"){
            GameCore.Instance.HitDamage();

            Destroy(this.gameObject);
        }
        
    }





}
