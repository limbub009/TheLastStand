using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int scoreval = 0;
    //global variable declared;
    Text score;
    //variable that holds UI text

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        //variable assigned to the text on UI.
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreval;
        //the text changes to display the cuerrent score on the UI.
    }
}
//public static int scoreval = 0;
