using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PresentCapsule : MonoBehaviour
{
    public TMP_Text Messages;
    public TMP_Text Messages2;
    public GameObject GameManager;
    public GameObject InterfaceUI;
    public GameObject PresentUI;
    public GameObject StartButton;
    public GameObject InGameStudyUI;
    
    private int textNumPresentText = 0;
    private int textNumIntStudyText = 0;
    private bool _isStart = false;

    void Start()
    {
        transform.position = new Vector3(-17.15997f, 13.29999f, -23.619f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (textNumPresentText < 4)
        {
            Switch();
            PresentText();
        }
        if (textNumIntStudyText < 4&&_isStart==true)
        {
            inGameStudyText();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            PresentUI.SetActive(false);
            InGameStudyUI.SetActive(false);
            gameObject.SetActive(false);
            InterfaceUI.SetActive(true);
            GameManager.SetActive(true);
        }
    }
    void Switch()
    {
        if (Input.anyKeyDown)
        {
            textNumPresentText++;
            
        }
    }
    public void Startbutton()
    {
        PresentUI.SetActive(false);
        InterfaceUI.SetActive(true);
        GameManager.SetActive(true);
        InGameStudyUI.SetActive(true);
        transform.position = new Vector3(-16f, -4.25f, -7.35f);
        _isStart = true;
    }
   
    
        
    
    public void TutorialButton()
    {
        textNumIntStudyText++;
    }
    void inGameStudyText()
    {
        switch (textNumIntStudyText)
        {
        case 0:
                Messages2.text = "����! � ���, ���� ��������� ��� ��� �� �������� ����� �� ������ ����. ";
            break;
        case 1:
                Messages2.text = "������ �� ������ ���� �� �������� ������ �����-��..���� ��� ��������? �� �� �����, ��� ������� ������������ ����� �������, ��� ������ � �������� ������, ������ ��� ����� �� ������������� ������� ��� �� ��������� � ���� �����-�� �����. ����� ����� ��� �������� ��� �������� ������������, ���������� ������ � ����� ���� ��������� � ��� ��������, ������ ��������� �������� ����� ��������, ��������� ���� ����� �������. ������� ��� ��� ���� ������, �� ��� ����, ��� ��� �����!";
            break;
            case 2:
                InGameStudyUI.SetActive(false);
                gameObject.SetActive(false);
                break;
        }
    }
    void PresentText()
    {
        switch (textNumPresentText)
        {
            case 0:

                Messages.text = "���������! � \"Present Capsule\" ��� �� ���� � ������ ��������� ���� ��������, �� � ���� ���������� ���� �������... �� � ��� ��������� ����� ���� �������, ���������� ���. �� �������! � � ���� ������ ���������� �������� ������ ����� F ";
                break;
            case 1:

                Messages.text = "������� � �������������� ���� ���������....";
                break;
            case 2:
                InterfaceUI.SetActive(true);
                Messages.text = "����! ����� �� ������ 6 ������, ����� ����� �������: Pause-��� �� ������� �����, Quit-�����(��, ���������� ������), Restart-������ ������������� ��������� ���(������� ����), Camera-���������  �������� ����������� ������, NextGen-��������� ����� ��������� � ����������� �������� � ������� summary-������ ������ ���� ����������";
                break;
            case 3:
                InterfaceUI.SetActive(false);
                StartButton.SetActive(true);
                Messages.text = "��... �� ����� �����, ���� ������ ������ ����� �� ��� ���������������� ������ � ������ ������. ����� �� ������!";
                break;
        }
    }
    public void SkipTutorial()
    {
        
    }
}
