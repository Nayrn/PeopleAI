using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Needs : MonoBehaviour
{
    // Actual needs values 
    private float m_fHunger;
    private float m_fThirst;
    private float m_fRest;

    // UI
    public Slider hungerBar;
    public Slider restBar;
    public Slider thirstBar;

    //
    private float m_fTotalTime;

    // dirty flag method
    public bool touchedFood;
    private bool touchedWater;
    private bool isSleeping;

    // hacky fix. plz work
    private float foodTime;

	void Start ()
    {
        m_fHunger = 30.0f;
        m_fThirst = 100.0f;
        m_fRest = 100.0f;

        touchedFood = false;   // need to change naming soon
        touchedWater = false;
        isSleeping = false;

        foodTime = 0.0f;
    }
	
	void Update ()
    {
        //--Assigning value to sliders
        hungerBar.value = m_fHunger;
        thirstBar.value = m_fThirst;
        restBar.value = m_fRest;
   
        //--NEEDS 

        if (touchedFood)
        {
            m_fHunger += Time.deltaTime;

            // hacky fix that I didn't want to do.
            foodTime += Time.deltaTime;
            if(foodTime >= 3.0f)
            {
                touchedFood = false;
                foodTime = 0.0f;
            }
        }


        if (touchedWater)
            m_fThirst += Time.deltaTime;

        if (isSleeping)
            m_fRest += Time.deltaTime;
        //--END NEEDS


	    // decide in here how quickly the player should perish

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Food" && col.gameObject.activeSelf == true)
            touchedFood = true;

        if (col.gameObject.tag == "Water")
            touchedWater = true;

        if (col.gameObject.tag == "Rest")
            isSleeping = true;


    }

}
