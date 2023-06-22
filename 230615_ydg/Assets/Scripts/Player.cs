using System;

public class Player {
    private string name;
    private int level =1 ;
    private int hp;
    private int atk;



    public Player(string name, int hp, int atk){
        //this.name = name;
        this.name = name;
        this.hp = hp;
        this.atk = atk;
    }


    public string Name{
        get
        {
            return this.name;
        }
    }

    public int Hp{
        get
        {
            return this.hp;
        }
    }


    public void HitDamage(int number = 1)
    {
        this.hp -= number;
    }




    public Player GetPlayerInfo(){
        return this;
    }


}
