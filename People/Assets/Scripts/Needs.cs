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
    private bool touchedFood;
    private bool touchedWater;
    private bool isSleeping;

	void Start ()
    {
        m_fHunger = 30.0f;
        m_fThirst = 100.0f;
        m_fRest = 100.0f;

        touchedFood = false;   // need to change naming soon
        touchedWater = false;
        isSleeping = false;
    }
	
	void Update ()
    {
        //--Assigning value to sliders
        hungerBar.value = m_fHunger;
        thirstBar.value = m_fThirst;
        restBar.value = m_fRest;
        //--

        if (touchedFood)
            m_fHunger += Time.deltaTime; // bug here, once the object destroys, bool never gets set to false

        if (touchedWater)
            m_fThirst += Time.deltaTime;

        if (isSleeping)
            m_fRest += Time.deltaTime;

        Debug.Log(touchedFood);

	    // decide in here how quickly the player should perish

	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Food")
            touchedFood = true;

        if (col.gameObject.tag == "Water")
            touchedWater = true;

        if (col.gameObject.tag == "Rest")
            isSleeping = true;

    }

   void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Food")
            touchedFood = false;


        if (col.gameObject.tag == "Water")
            touchedWater = false;


        if (col.gameObject.tag == "Rest")
            isSleeping = false;
    }
}
