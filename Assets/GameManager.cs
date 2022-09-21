using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuSetOpenButton;
    public GameObject menuSet;
    public AudioSource music;
    private bool isMenuSetActive;


    private void Start()
    {
        isMenuSetActive = false;
        menuSet.SetActive(false);
        menuSetOpenButton.SetActive(true);
       
        Time.timeScale = 1;
        music.Play();
    }

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

    }

    // ������Ʈ(��ư)�� �������� ���� ���� �޴� â�� ������ ������ ��
    public void MenuSet()
    {
        isMenuSetActive = !isMenuSetActive;
        menuSet.SetActive(isMenuSetActive);
        menuSetOpenButton.SetActive(!isMenuSetActive);
        
        // �ϴ� �����ϰ� �ð� ���߰� �ϱ� �ߴµ� ���߿� �ٲ�� �� ��
        if (isMenuSetActive)
        {
            Time.timeScale = 0;
            music.Pause();
        }
        else
        {
            Time.timeScale = 1;
            music.Play();
        }
    }

    public void GameRestart()
    {
        // ���� 0�� �� ��ȣ
        SceneManager.LoadScene(0);
    }

}