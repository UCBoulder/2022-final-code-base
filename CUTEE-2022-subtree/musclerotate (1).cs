using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Collections.Generic;

public class musclerotate : MonoBehaviour
{
	SerialPort data_stream = new SerialPort("COM5", 9600); // Arduino is connected to COM5 with 9600 baud rate
	public string receivedstring;
	public GameObject test_data;
	public Rigidbody rb;
	public float sensitivity = 0.01f;

	public string[] datas;
	
	void Begin(){
		data_stream.Open(); // Initiate the serial stream
	}
	
	void Update(){
		receivedstring = data_stream.ReadLine();
        
    }
    
        if(receivedstring >= 900){
            public float speed = 10f;
    
            // Start is called before the first frame update
            void Start(){
            this.GetComponent<Renderer>().material.color = new Color(255, 0, 0); 	//Changes the sphere color to red on start
            }
            // Update is called once per frame
            void Update(){
            transform.Rotate(speed*Time.deltaTime,0,speed*Time.deltaTime); 	//Rotate around the X and z-axis at speed degrees/s
            }   
        }
        else(){
            
            this.GetComponent<Renderer>().material.color = new Color(0, 255, 255); //Changes the sphere color to blue
        
        }
    
    
}
