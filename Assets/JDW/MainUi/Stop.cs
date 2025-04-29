using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    public bool IsPaues;
    void Start()
    {
        IsPaues = false;
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsPaues == false)
            {
                Time.timeScale = 0;
                IsPaues = true;
                return;
            }
            if (IsPaues == true)
            {
                Time.timeScale = 1;
                IsPaues = false;
                return;
            }
        }
    }
}
