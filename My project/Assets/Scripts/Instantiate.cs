using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Interactor;    
    void Start()
    {
        Instantiate(Interactor, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
