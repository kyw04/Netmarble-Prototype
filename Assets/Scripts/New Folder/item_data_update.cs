using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_data_update : MonoBehaviour
{
    [SerializeField]
    public GameObject shop;//�����θ� ������Ʈ
    public item_Data I_D;
    public Button button;
    public Text text;
    private float x;
    private float y;
    private float z;


    public item_Data item_data { set { I_D = value; } }
    void Start()
    {
        shop = this.transform.parent.parent.parent.parent.gameObject;
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>(I_D.Item_name);
        this.GetComponent<Button>().onClick.AddListener(printitem_info);
        this.GetComponentInChildren<Text>().text = I_D.Item_name;
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
        z = this.gameObject.transform.position.z;
        this.transform.position = new Vector3(x, y - 30, z);//�������� ��ġ�� �������� õ�忡 �����κ��� ���ֱ����� ����
    }
    public void printitem_info()
    {
        shop.GetComponent<shop>().sel_item_image.sprite = Resources.Load<Sprite>(I_D.Item_name);//������ �̹����� ���
        shop.GetComponent<shop>().sel_item_price.text = "price:" + I_D.Price.ToString();//�������� ������ ���
    }
}