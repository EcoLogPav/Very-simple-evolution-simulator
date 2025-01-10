using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartCreatue : MonoBehaviour
{
    Color red = Color.red;
    Color green = Color.green;
    Color blue = Color.blue;
    Renderer rend;
    private float _Speed;
    private float _Damage;
    private float _HP;
    private Transform food;
    public Transform victim;
    public float speed=0;
    public float heal=0;
    public float power=0;
    public  float eated=0;
    public static float endScore;
    public static float eatedAll;
    public bool isAngry = false;
    public static int isAll=0;
    void Start()
    {
        rend = GetComponent<Renderer>();
       
        StatisticCheck();
    }
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position,transform.forward, Color.yellow);
      
            if (food == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit) && (hit.transform.gameObject.tag == "Food"))
                {


                    food = hit.transform;

                }
                else
                {
                    transform.Rotate(0, _Speed, 0);
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, food.position, _Speed * Time.deltaTime);
            
        
        
      /*  if (eatedAll == 5&& power > 0&&eated==0)
        {
            isAngry= true;
            if (victim == null)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit) && (hit.transform.gameObject.tag == "Creature"))
                {


                    victim = hit.transform;

                }
                else
                {
                    transform.Rotate(0, _Speed, 0);
                }
                transform.position = Vector3.MoveTowards(transform.position, victim.position, _Speed * Time.deltaTime);
            }
        }
        eatedAll = GameManager.eated;
      */

    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Food":
                eated++;
                GameManager.eated ++;
                Destroy(collision.gameObject);
                food= null;
                isAll++;
                evolution();
                break;
            case "Creature":
                if (isAngry)
                {
                    eated++;
                    isAngry = false;
                  //  Destroy(collision.gameObject);
                    victim= null;
                }
                break;
        }



    }
    void evolution()
    {
        int probability;
        probability=Random.Range(0, 7);
        switch (probability)
        {
            case 0:
                speed++;
                
                break;
            case 1:
                heal++;
                break;
            case 2:
                power++;
                break;
            case 3:
                speed--;
                break;
            case 4:
                heal--;
                break;
            case 5:
                power--;
                
                break;
            case 6:
                Debug.Log("Yeah i'm here!");
                break;
        }
        StatisticCheck();
    }
    void StatisticCheck()
    {
        _Damage = power + 1;
        _HP = heal + 1;
        _Speed = speed+1;
        if (speed > heal && speed > power)
        {
            rend.GetComponent<Renderer>().material.color = blue;
       
        }
        else if(heal> power&&heal>speed)
        {
            rend.GetComponent<Renderer>().material.color = green;
        }
        else if (power>heal&&power>speed)
        {
            rend.GetComponent<Renderer>().material.color =red ;
        }
        
    }
   public void Restart()
    {
       
        if (eated > 1)
        {
            
        }
        else
        {
            if (_HP > 0)
            {
                _HP--;
              
            }
            else
            {
                Destroy(gameObject);
            }
        }
        eated= 0;
        isAngry = false;
    }
}
