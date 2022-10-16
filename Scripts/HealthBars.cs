using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBars : MonoBehaviour
{

    public Image CurrentHunger;
    public Image CurrentFun;
    public Image egg;
    public Image baby;
    public Image child;
    public Image adult;
    public Image elder;
    public Image Poo;
    public Image HappyEmotion;
    public Image SadEmotion;
    public Image LightOff;

    private float happiness = 100;

    private float hygiene = 100;
    private float hunger = 100;
    private float energy = 100;
    private float health = 100;
    private float max = 100;
    private float age = 0;
    private bool light = true;

    public Button FeedButton;
    public Button LightButton;
    public Button GameButton;
    public Button WashButton;
    public Button MedicineButton;
    public Button HappinessButton;
    public Button LightOnButton;

    public Text GameOverText;

    // Start is called before the first frame update
    void Start()
    {

        Button btn1 = FeedButton.GetComponent<Button>();
        btn1.onClick.AddListener(FeedPet);

        Button btn2 = LightButton.GetComponent<Button>();
        btn2.onClick.AddListener(TurnLight);

        Button btn3 = GameButton.GetComponent<Button>();
        btn3.onClick.AddListener(PlayGame);

        Button btn4 = WashButton.GetComponent<Button>();
        btn4.onClick.AddListener(WashPet);

        Button btn5 = MedicineButton.GetComponent<Button>();
        btn5.onClick.AddListener(GiveMedicine);

        Button btn6 = HappinessButton.GetComponent<Button>();
        btn6.onClick.AddListener(ShowHappiness);

        Button btn7 = LightOnButton.GetComponent<Button>();
        btn7.onClick.AddListener(LightOn);


        Poo.gameObject.SetActive(false);
        SadEmotion.gameObject.SetActive(false);
        HappyEmotion.gameObject.SetActive(false);

        //Creates listeners for each button
        Debug.Log("update call");
        UpdateHungerBar();
        UpdateFun();

        Update();
        GameOver();
        checkNeeds();
    }

    private void checkNeeds()
    {
        if (hygiene < 10)
        {
            Poo.gameObject.SetActive(true);
        }
        else
        {
            Poo.gameObject.SetActive(false);
        }
    }
    void FeedPet()
    {
        Debug.Log("Feed Button Clicked");
        hunger += 20;
        if (hunger > max)
        {
            hunger = max;
        }
        age = age + 1;
        CheckAge();
        UpdateHungerBar();
    }

    void TurnLight()
    {
        Debug.Log("Light Button Clicked");
            LightOff.gameObject.SetActive(true);
            LightOnButton.gameObject.SetActive(true);
        light = false;
    }

    void LightOn()
    {
        Debug.Log("Light Button Clicked");
        LightOff.gameObject.SetActive(false);
        LightOnButton.gameObject.SetActive(false);
        light = true;

    }

    void CheckAge()
    {
        if(age < 5)
        {
            egg.gameObject.SetActive(false);
            baby.gameObject.SetActive(true);  
        }
        if(age > 5 && age < 10)
        {
            baby.gameObject.SetActive(false);
            child.gameObject.SetActive(true);
        }
        if (age > 11 && age < 15)
        {
            child.gameObject.SetActive(false);
            adult.gameObject.SetActive(true);
        }
        if (age > 16)
        {
            adult.gameObject.SetActive(false);
            elder.gameObject.SetActive(true);
        }
    }

    void PlayGame()
    {
        Debug.Log("Game Button Clicked");
        UpdateFun();
        SceneManager.LoadScene("Invader");
    }

    void WashPet()
    {
        Debug.Log("Wash Button Clicked");
        hygiene = 100;
        if (hygiene > max)
        {
            hygiene = max;
        }
        checkNeeds();
    }

    void GiveMedicine()
    {
        Debug.Log("Medicine Button Clicked");
        health += 10;
        if (health > max)
        {
            health = max;
        }
    }

    void ShowHappiness()
    {


            if(happiness < 20 || hygiene < 20 || hunger < 20 || energy < 20 || health < 20)
            {
                SadEmotion.gameObject.SetActive(true);
                HappyEmotion.gameObject.SetActive(false);

            }
            else if (happiness > 20 || hygiene > 20 || hunger > 20 || energy > 20 || health > 20)
            {
                HappyEmotion.gameObject.SetActive(true);
                SadEmotion.gameObject.SetActive(false);

            }

    }

    // Update is called once per frame
    void Update()
    {

        happiness -= 1f * Time.deltaTime;
        if(happiness < 0)
        {
            happiness = 0;
        }
        hygiene -= 2f * Time.deltaTime;
        if (hygiene < 0)
        {
            hygiene = 0;
        }
        hunger -= 3f * Time.deltaTime;
        if (hunger < 0)
        {
            hunger = 0;
        }
        energy -= 0.5f * Time.deltaTime;
        if (energy < 0)
        {
            energy = 0;
        }
        health -= 0.25f * Time.deltaTime;
        if (health < 0)
        {
            health = 0;
        }
        age += 0.05f * Time.deltaTime;
        if (age > 100)
        {
            age = 100;
        }

        if (light == false)
        {
            energy += 5f * Time.deltaTime;
            if (energy > max)
            {
                energy = max;
            }
        }

        UpdateHungerBar();
        UpdateFun();
        GameOver();
        checkNeeds();
        CheckAge();
    }

    private void UpdateHungerBar()
    {
        float percent = hunger / max;
        CurrentHunger.rectTransform.localScale = new Vector3(percent, 1, 1);
    }

    private void UpdateFun()
    {
        float percent = happiness / max;
        CurrentFun.rectTransform.localScale = new Vector3(percent, 1, 1);
    }

    private void GameOver()
    {
        if(hunger == 0)
        {
            egg.gameObject.SetActive(false);
            baby.gameObject.SetActive(false);
            child.gameObject.SetActive(false);
            adult.gameObject.SetActive(false);
            elder.gameObject.SetActive(false);
            GameOverText.gameObject.SetActive(true);

        }
    }
}
