using UnityEngine;
using System.Collections;

public class WorldTime : MonoBehaviour
{
    public float totalTime;
    public Light dirLight;
    public float sunDownTime;
    public float sunUpTime;
    public int dayCount;
    private bool dayTime;
    private int pPressed;
	// Use this for initialization
	void Start ()
    {
        totalTime = 0.0f;
        sunUpTime = 0.0f;
        sunDownTime = 0.0f;
        dayTime = true;
        pPressed = 0;
	}

    // Update is called once per frame
    void Update()
    {
        // -- DAY/ NIGHT CYCLE
        if (dirLight.intensity >= 0.8f)
            dayTime = true;



        totalTime += Time.deltaTime;
        

        if (dayTime)
        {
            sunUpTime += Time.deltaTime;
            if (sunUpTime > 740.0f)
            {
                dirLight.intensity -= 0.001f;

                if (dirLight.intensity <= 0.0f)
                {
                    dirLight.intensity = 0.0f;
                    sunUpTime = 0.0f;
                    dayTime = false;
                    

                }
            }

        } 


        if(!dayTime)
        {
            // if not daytime, sun is down for this amount of time
            sunDownTime += Time.deltaTime;
            if (sunDownTime > 50.0f)
            {
                dirLight.intensity += 0.001f;

                if (dirLight.intensity >= 0.8f)
                {
                    dirLight.intensity = 0.8f;
                    sunDownTime = 0.0f;
                    dayTime = true;
                    dayCount++;
                }
               
            }
        }
// ---- END DAY/NIGHT CYCLE
        

        
// --PAUSE CODE   make a UI element for this.
        if (Input.GetKeyDown(KeyCode.P))
            pPressed++;


        if (pPressed == 1)
        {
            Time.timeScale = 0;
            Debug.Log("Pause");
        }
        else if (pPressed == 2)
        {
            Time.timeScale = 1;
            Debug.Log("Playing");
            pPressed = 0;            
        }
        

        
         
	}
}
