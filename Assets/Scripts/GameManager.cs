using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GameObject[] foods = new GameObject[15];
    private GameObject[] Creatures = new GameObject[10];
    public static float eated=0;
    public int foodNum=0;
    public int foodEated;
    public GameObject food;
    public GameObject startCreature;
    public GameObject bestCreature; 
    public TMP_Text Generation;
    public TMP_Text Summary;
    private int generation = 0;
    public float speed = 0;
    public float power = 0;
    public float heal = 0;
    public int LiveCreatures=0;
     float sum;
    void Start()
    {
        startSpawn();   
        //Restart();
        Summary.text = "speed " + 0 + "% " + "heal " + 0 + "% " + "power " + 0 + "% ";
        Generation.text = "generation 0";
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < foods.Length; i++)
        {
            if (foods[i] == null)
            {
                foodNum++;
            }
            else
            {
                foodNum = 0;
            }
        }
            if (foodNum == foods.Length)
            {
            /*    for (int j = 0; j < Creatures.Length; j++)
                {
                    if (Creatures[j] != null)
                    {
                        Creatures[j].GetComponent<StartCreatue>().Restart();
                    }
                }
            */
                Restart();
                eated = 0;

            }
            foodNum = 0;
        
        
        
      
    }
  public  void Restart()
    {


       
        
            for (int i = 0; i < Creatures.Length-1; i++)
            {
                float sum1 = Creatures[i].GetComponent<StartCreatue>().speed + Creatures[i].GetComponent<StartCreatue>().power + Creatures[i].GetComponent<StartCreatue>().heal;
                float sum2 = Creatures[i + 1].GetComponent<StartCreatue>().speed + Creatures[i + 1].GetComponent<StartCreatue>().power + Creatures[i + 1].GetComponent<StartCreatue>().heal;
               
                if (sum1 > sum2)
                {

                    Destroy(Creatures[i + 1]);
                    Creatures[i + 1] = Creatures[i];

                 
                }
                else if(sum1 < sum2)
                {
                    Destroy(Creatures[i]);
                }
                else if (sum1 == sum2)
                {
                    int rnd = Random.Range(0, 1);
                    if (rnd == 0)
                    {
                        Destroy(Creatures[i + 1]);
                        Creatures[i + 1] = Creatures[i];
                    }
                    else
                    {
                        Destroy(Creatures[i]);
                    }
                }
              bestCreature= Creatures[i + 1];
            
            }

        for (int i = 0; i < Creatures.Length; i++)
        {
            Creatures[i] = Instantiate(bestCreature);
            Creatures[i].transform.position = new Vector3(Random.Range(-5.2f, 9.7f), -1.77f, Random.Range(-12.87415f, 2.16f));
        }

        Destroy(bestCreature);
        for (int i = 0; i < foods.Length; i++)
        {
            if (foods[i] == null)
            {
                foods[i] = Instantiate(food);
                foods[i].transform.position = new Vector3(Random.Range(-5.2f, 9.7f), -1.77f, Random.Range(-12.87415f, 2.16f));
            }
        }
        perksCheck();
        generation++;
        countingPerks();
        Summary.text = "speed "+speed.ToString()+"% "+ "heal "+heal.ToString() + "% "+ "power "+power.ToString() + "% ";
        Generation.text = "generation " + generation.ToString();
        speed = 0;
        power = 0;
        heal = 0;
    }
    void startSpawn()
    {
        for(int i = 0; i < Creatures.Length; i++)
        {
            Creatures[i]= Instantiate(startCreature);
            Creatures[i].transform.position = new Vector3(Random.Range(-5.2f, 9.7f), -1.77f, Random.Range(-12.87415f , 2.16f));
        }
        for (int i = 0; i < foods.Length; i++)
        {
            foods[i] = Instantiate(food);
            foods[i].transform.position = new Vector3(Random.Range(-5.2f, 9.7f), -1.77f, Random.Range(-12.87415f, 2.16f));
        }
    }
    void perksCheck()
    {
        for (int i = 0; i < Creatures.Length; i++)
        {
            if (Creatures[i] != null)
            {
                speed += Creatures[i].GetComponent<StartCreatue>().speed;
                power += Creatures[i].GetComponent<StartCreatue>().power;
                heal += Creatures[i].GetComponent<StartCreatue>().heal;
            }
        }
    }
    void countingPerks()
    {
        sum = speed + heal + power;

        speed /= sum;
        power /= sum;
        heal /= sum;
        speed *= 100;
        heal *= 100;
        power *= 100;
        speed = Mathf.Round(speed);
        heal = Mathf.Round(heal);
        power = Mathf.Round(power);
    }
}
