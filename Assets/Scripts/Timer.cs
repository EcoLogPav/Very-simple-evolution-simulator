using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time = 0;
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        GetComponent<TMP_Text>().text = Mathf.Round(time).ToString(); ;
       // GetComponent<TMP_Text>().text = time
    }
}
