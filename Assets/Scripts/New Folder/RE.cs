using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Onclickbutton()
    {
        GameObject.Find("Game_manager").GetComponent<Game_manager>().asss();

    }
}
