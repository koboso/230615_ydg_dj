using UnityEngine;
public class Parallax : MonoBehaviour{

    [SerializeField] private GameObject[] bg;


    private void Start()
    {
        
    }


    private void InitBG()
    {
        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].transform.position = new Vector3(0, 11 * i, 0);
        }
    }


    private void FixedUpdate(){
        
        for(int i = 0; i < bg.Length; i++)
        {

            if(bg[i].transform.position.y <= -11f)
            {
                bg[i].transform.position = new Vector3(0, 44f, 0);
            }
            else
            {
                bg[i].transform.position -= new Vector3(0, 5 * Time.deltaTime, 0);
            }

        }

    }


}
