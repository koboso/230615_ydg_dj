using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour{
    float itemSpawnTime = 0f;
    [SerializeField] private GameObject itemObject;

    List<GameObject> itemList;



    void Start(){
        itemList = new List<GameObject>();

        StartCoroutine(ItemCreatorCorutine());

    }

    /*
    void Update(){

    }
    */

    IEnumerator ItemCreatorCorutine(){

        while (true)
        {

            if (GameCore.Instance.gameStatus == GameCore.GameStatus.Play)
            {
                if (itemList.Count == 0){
                    itemSpawnTime += Time.deltaTime;
                }
                else
                {
                    if (itemList[0] == null && itemList.Count == 1)
                    {
                        itemList.Clear();
                    }
                }

                if (itemSpawnTime >= 5f)
                {
                    itemSpawnTime = 0f;
                    ItemCreator();
                }

            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }



    void ItemCreator(){
        GameObject item = Instantiate(itemObject, Vector2.zero, Quaternion.identity, this.transform);
        item.transform.position = new Vector3(0, 7, 0);
        itemList.Add(item);
    }

}
