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
    public GameObject shopPanel; // 아이템목록을 보여주는 패널
    void Start()//씬이 시작될떄 호출
    {



        int j = 0;//가로줄
        int k = 0;//세로줄
        int galo = 5;//가로줄
        //아이템 리스트 만큼 객체생성
        for (int i = 0; 2 * k < item_data_list.Count; i++)//아이템갯수만큼 생성  //item_data_list.Count=3임 (현재) 아이템 카운트가 만약 10개라면 그리고 가로줄에 2개 한다면  1 2 1 2 1 2 1 2 총 5줄
        {
            for (j = 0; j < galo; j++)//가로줄
            {
                GameObject item = Instantiate(Resources.Load<GameObject>("item"));
                item.GetComponent<item_data_update>().I_D = item_data_list[j + k * galo];
                item.transform.SetParent(shopPanel.transform);
                item.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                item.transform.localPosition = new Vector3(-130 + 60 * j, -60 * k, 0);//간격 생성
                item.GetComponent<item_data_update>().item_data = item_data_list[j + k * galo];
            }
            k++;
        }
        this.gameObject.SetActive(false);//씬이호출될때 표시되지않게함
    }

}
