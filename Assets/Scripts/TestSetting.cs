using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestSetting : MonoBehaviour
{
    public InputField input;
    public Text placeholder;

    private void Start()
    {
        if (PlayerPrefs.HasKey("WaitTime"))
        {
            input.transform.GetChild(0).GetComponent<Text>().text = "�뷡 ���� �ð� : " + PlayerPrefs.GetFloat("WaitTime");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SaveButton()
    {
        float temp;
        if (input.text != "" && float.TryParse(input.text, out temp))
        {
            PlayerPrefs.SetFloat("WaitTime", temp);
            placeholder.text = "�뷡 ���� �ð� : " + input.text;
            input.text = "";
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
