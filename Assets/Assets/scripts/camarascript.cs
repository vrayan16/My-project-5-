using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camarascript : MonoBehaviour
{
    public GameObject Meat;
    void Update()
    {
        if (Meat != null) 
        {
            Vector3 position = transform.position;
            position.x = Meat.transform.position.x;
            transform.position = position; }
    }
    
    
}
