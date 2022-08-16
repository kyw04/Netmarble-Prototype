using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextReader : MonoBehaviour
{
    private TextAsset asset;
    private string str;
    public float[] time;
    public int[] type;
    public int n;

    private void Awake()
    {
        asset = Resources.Load<TextAsset>("test");
        str = asset.text;
        //StringReader streader = new StringReader(str);
        //string txt = "";

        string[] datas = str.Split('\n');
        n = datas.Length;

        time = new float[n];
        type = new int[n];

        string[] temp = datas[0].Split(',');
        float.TryParse(temp[0], out time[0]);
        int.TryParse(temp[1], out type[0]);

        for (int i = 1; i < n; i++)
        {
            //txt = streader.ReadLine();
            temp = datas[i].Split(',');

            if (temp.Length == 2)
            {
                float.TryParse(temp[0], out time[i]);
                int.TryParse(temp[1], out type[i]);

                //Debug.Log(time[i].ToString() + " " + type[i].ToString());
            }
        }
    }
}
