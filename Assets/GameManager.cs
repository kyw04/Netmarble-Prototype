using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject menuSet;

    // Update is called once per frame
    void Update()
    {

        // UI - Button의 onClick 코드 부분 => 종료 버튼의 KeyCode값 : Escape
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit(); // 종료시킬 코드 담긴 함수

        // 메뉴 버튼 or 홈버튼(= 겜 계속하기)를 누르면 메뉴 창이 꺼져야 하기 때문에 || 씀
        // * 홈버튼은 코드 더 수정해서 적용할 예정 , 임시로 걍 묶어논거임 *
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu))
        {
            ISelectHandler();
        }

    }

    // GameManager의 함수들 중 GameQuit 이라는 함수를 여기에 선언해둔 후 갖다 쓰려고 만든거임
    public void GameQuit()
    {
        Application.Quit(); // 앱 종료하라는 거
    }

    // 위와 같음 => ISelectHandler : 오브젝트를 선택하는 순간 호출하라는 뜻
    public void ISelectHandler()
    {
        // 오브젝트(버튼)를 선택했을 때에 따라 메뉴 창이 꺼지고 켜지는 거
        if (menuSet.activeSelf)
        {
            menuSet.SetActive(false);
        }
        else
        {
            menuSet.SetActive(true);
        }
    }

}
