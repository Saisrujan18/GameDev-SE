using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeStart = 60;
    public Text textBox;
    void Start()
    {
        textBox.text = ((int)timeStart).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = ((int)timeStart).ToString();
    }
}