using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationState
{
    public int id;
    public int room;
    public bool isRunning;
    public bool isPaused;
    public float time;
    public string timer;
    public string started_at;
    public int heart_bpm;
    public float p_sub;
    public float p_suit;
    public float t_sub;
    public int v_fan;
    public float p_o2;
    public float rate_o2;
    public float batteryPercent;
    public int cap_battery;
    public int battery_out;
    public float p_h2o_g;
    public float p_h2o_l;
    public int p_sop;
    public float rate_sop;
    public string t_battery;
    public int t_oxygenPrimary;
    public float t_oxygenSec;
    public int ox_primary;
    public int ox_secondary;
    public string t_oxygen;
    public float cap_water;
    public string t_water;
    public string createdAt;
    public string updatedAt;

    /*
    Method to instantiate class members from json strong
    */
    public static SimulationState CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<SimulationState>(jsonString);
    }
}


/*
Class for storing list of Rooms
*/
public class SimulationStateList
{
    public List<SimulationState> simulationStateList;
    
    public SimulationStateList() {
        this.simulationStateList = new List<SimulationState>();
    }

    /*
    jsonString -- string argument of form list of SimulationState
    Instantiates SimulationStateList to hold SimulationState values
    */
    public SimulationStateList(string jsonString) {
        this.simulationStateList = new List<SimulationState>();
        string temp = "";
        int level = 0;
        for(int i = 0; i < jsonString.Length; i++) {
            char c = jsonString[i];
            if (c == '[') continue;
            else if (c == ']') return;
            else if (c == '{') {
                temp += c; 
                level++;
            }
            else if (c == '}') {
                temp += c; 
                level--;
            }
            else if (c == ',' && level == 0) {
                // Create new SimulationState based on temp string
                SimulationState toAdd = SimulationState.CreateFromJSON(temp);
                simulationStateList.Add(toAdd);
                temp = "";
            }
            else {
                temp += c;
            }
        }
    }
}

