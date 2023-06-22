using System;

public class Enemy {
    private string name;
    private int hp;


    public Enemy(string name, int hp) {
        this.name = name;
        this.hp = hp;
    }



    public void GetEnemyInfo(){
        UnityEngine.Debug.Log($"name : {this.name}  attack : {this.hp}");
    }

}
