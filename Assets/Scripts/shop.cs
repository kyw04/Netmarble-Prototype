using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shop : MonoBehaviour
{
    public Text got_gold;
    public Text sel_item_price;
    public Image sel_item_image;
    [SerializeField]
    private List<item_Data> item_data_list;
    public GameObject shopPanel; // �����۸���� �����ִ� �г�
    void Start()//���� ���۵ɋ� ȣ��
    {



        int j = 0;//������
        int k = 0;//������
        int galo = 5;//������
        //������ ����Ʈ ��ŭ ��ü����
        for (int i = 0; 2 * k < item_data_list.Count; i++)//�����۰�����ŭ ����  //item_data_list.Count=3�� (����) ������ ī��Ʈ�� ���� 10����� �׸��� �����ٿ� 2�� �Ѵٸ�  1 2 1 2 1 2 1 2 �� 5��
        {
            for (j = 0; j < galo; j++)//������
            {
                GameObject item = Instantiate(Resources.Load<GameObject>("item"));
                item.GetComponent<item_data_update>().I_D = item_data_list[j + k * galo];
                item.transform.SetParent(shopPanel.transform);
                item.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                item.transform.localPosition = new Vector3(-130 + 60 * j, -60 * k, 0);//���� ����
                item.GetComponent<item_data_update>().item_data = item_data_list[j + k * galo];
            }
            k++;
        }
        this.gameObject.SetActive(false);//����ȣ��ɶ� ǥ�õ����ʰ���
    }

}
