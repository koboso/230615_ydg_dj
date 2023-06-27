using System;

public class Enemy  {
    public enum EnemyType{
        Basic = 0,
        Range,
    }
    private EnemyType enemyType;
    private int hp;
    private int atk;
    private float speed;

    public Enemy(EnemyType type, int hp, int atk, float speed) {
        this.enemyType = type;
        this.hp = hp;
        this.atk = atk;
        this.speed = speed;
    }


    public int Hp
    {
        get { return this.hp; }
    }

    public int Atk
    {
        get { return this.atk; }
    }

    public float Speed
    {
        get { return this.speed; }
    }

    public bool Hit(int dmg){
        if (this.hp - dmg <= 0) return false;

        this.hp -= dmg;

        return true;
    }
    




}
