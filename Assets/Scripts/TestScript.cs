using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    int numberOfAttempts = 0;

    [Range(0,100)]
    public int valueToEnter;

    // Start is called before the first frame update
    void Start()
    {
        print("coucou, c'est Benji");
        print("enter select a number and press space");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            numberOfAttempts++;
            print("you entered  " + valueToEnter);
        }
    }
}
