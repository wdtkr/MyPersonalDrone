using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AirSimUnity.DroneStructs;

namespace AirSimUnity {
    //[RequireComponent(typeof(Drone))]
public class ResetButton : MonoBehaviour
{
    private Drone drone;

    // Start is called before the first frame update
    void Start()
    {
        drone = GameObject.Find("Drone1").GetComponent<Drone>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClick()
    {
        Debug.Log("reset");
        SceneManager.LoadScene ("DroneDemo");
        //Drone.transform.rotation = new Vector3(0.0f,0.0f,0.0f);
        

        
    }
}
}