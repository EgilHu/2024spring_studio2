using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public GameObject square;

    public GameObject circle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActive()
    {
        square.gameObject.SetActive(true);
    }
    
    public void SetInactive()
    {
        square.gameObject.SetActive(false);
    }
    
    public void SetCircleActive()
    {
        circle.gameObject.SetActive(true);
    }
    
    public void SetCircleInactive()
    {
        circle.gameObject.SetActive(false);
    }
}
