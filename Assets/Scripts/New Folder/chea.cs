using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Game_manager").GetComponent<Game_manager>().lvss();
    }
}
