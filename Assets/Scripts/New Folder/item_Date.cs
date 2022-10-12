using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item_data", menuName = "Scriptable Object/item_data", order = int.MaxValue)]

public class item_Data : ScriptableObject
{

    [SerializeField]
    private string item_name;//�������̸�
    public string Item_name { get { return item_name; } }
    [SerializeField]
    private int price;//����
    public int Price { get { return price; } }
 
}