using System;

public class Player {
    private string name;
    private int level =1 ;
    private int hp;
    private int atk;



    public Player( int hp, int atk){
        //this.name = name;
        this.hp = hp;
        this.atk = atk;
    }


    public int Atk
    {
        get
        {
            return this.atk;
        }
    }
   

    public int Hp{
        get
        {
            return this.hp;
        }
    }

    public void Init(int hp)
    {
        this.hp = hp;
    }


    public void HitDamage(int number = 1)
    {
        this.hp -= number;
    }




    public Player GetPlayerInfo(){
        return this;
    }


}
