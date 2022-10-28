using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainmove : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public int main =0; 
    void UpdateTarget()
    {
        if(main == 0)
        {
          target1.SetActive(true);
          target2.SetActive(false);
          target3.SetActive(false);
        }
         if(main == 1)
        {
          target1.SetActive(false);
          target2.SetActive(true);
          target3.SetActive(false);
             
        }
         if(main == 2)
        { 
          target1.SetActive(false);
          target2.SetActive(false);
          target3.SetActive(true);
        }
      if(main >= 3)
      {
        main =0;
      }
      if(main <= -1)
      {
        main =2;
      }     
    }
    public void  onclickbutton()
    {

      main++;
      Invoke(nameof(UpdateTarget), 1);

    }
     public void  onclickbuttons()
    {
      
      main--;
      Invoke(nameof(UpdateTarget), 1);

    }
}
