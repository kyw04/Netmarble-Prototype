using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curtainmove : MonoBehaviour
{
public Transform target1;
public Transform target2;
public int main =0; 

    void Update()
    {
        if(main == 0)
        {
          transform.position = Vector3.Lerp(gameObject.transform.position, target1.transform.position, 0.005f);
        }
         if(main == 1)
        {
          transform.position = Vector3.Lerp(gameObject.transform.position, target2.transform.position, 0.005f);
          Invoke("A", 2f);
        }        
    }
    public void  onclickbutton()
    {

      main = 1;

    }

    public void A()
    {
      main = 0;
    }
    
}
