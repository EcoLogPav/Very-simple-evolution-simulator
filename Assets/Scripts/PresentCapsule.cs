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
                Messages2.text = "хеей! Я тут, если интересно как тут всё работает нажми на кнопку ниже. ";
            break;
        case 1:
                Messages2.text = "Сейчас ты видишь поле по которому бегают какие-то..аааа мои собратья? Ну не важно, эти объекты представляют собой существ, они бегают и пытаются выжить, каждый раз когда их представитель съедает еду он развивает в себе какой-то навык. После когда еда кочается все существа сравнимаются, отбирается лучший и после дает потомство с его навыками, данная концепция эволюции очень упрощена, благодаря чему легко понятна. Вообщем был рад тебе помочь, но мне пора, так что удачи!";
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

                Messages.text = "Привеееет! Я \"Present Capsule\" иии по идее я должен объяснить тебе эволюцию, но у меня достаточно мало времени... Да и мой создатель пишет меня вечером, вчерашнего дня. Ок поехали! А и если хочешь пропустить туториал просто нажми F ";
                break;
            case 1:

                Messages.text = "Сначала я продемострирую тебе интерфейс....";
                break;
            case 2:
                InterfaceUI.SetActive(true);
                Messages.text = "Итак! Снизу ты видишь 6 кнопок, пойдём слева направо: Pause-как не странно пауза, Quit-выход(да, английский сложен), Restart-можешь перезапустить абсолютно все(включая меня), Camera-позволяет  поменять перспективу камеры, NextGen-запускает новое поколение с полученными навыками и наконец summary-просто сводка всех параметров";
                break;
            case 3:
                InterfaceUI.SetActive(false);
                StartButton.SetActive(true);
                Messages.text = "Ну... ты вроде готов, если хочешь начать нажми на эту непримечательную кнопку в центре экрана. Ладно за работу!";
                break;
        }
    }
    public void SkipTutorial()
    {
        
    }
}
