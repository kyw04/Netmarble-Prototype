using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject menuSet;

    // Update is called once per frame
    void Update()
    {

        // UI - Button�� onClick �ڵ� �κ� => ���� ��ư�� KeyCode�� : Escape
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit(); // �����ų �ڵ� ��� �Լ�

        // �޴� ��ư or Ȩ��ư(= �� ����ϱ�)�� ������ �޴� â�� ������ �ϱ� ������ || ��
        // * Ȩ��ư�� �ڵ� �� �����ؼ� ������ ���� , �ӽ÷� �� �������� *
        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.Menu))
        {
            ISelectHandler();
        }

    }

    // GameManager�� �Լ��� �� GameQuit �̶�� �Լ��� ���⿡ �����ص� �� ���� ������ �������
    public void GameQuit()
    {
        Application.Quit(); // �� �����϶�� ��
    }

    // ���� ���� => ISelectHandler : ������Ʈ�� �����ϴ� ���� ȣ���϶�� ��
    public void ISelectHandler()
    {
        // ������Ʈ(��ư)�� �������� ���� ���� �޴� â�� ������ ������ ��
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
