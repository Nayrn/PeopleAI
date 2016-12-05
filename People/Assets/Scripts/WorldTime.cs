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
	// Use this for initialization
	void Start ()
    {
        totalTime = 0.0f;
        sunUpTime = 0.0f;
        sunDownTime = 0.0f;
        dayTime = true;
	}

    // Update is called once per frame
    void Update()
    {

        if (dirLight.intensity >= 0.8f)
            dayTime = true;



        totalTime += Time.deltaTime;
        

        if (dayTime)
        {
            sunUpTime += Time.deltaTime;
            if (sunUpTime > 20.0f)
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
            if (sunDownTime > 40.0f)
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
         
	}
}
