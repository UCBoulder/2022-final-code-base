using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class TelemetryStream : MonoBehaviour
{
    User user;
    RoomList rooms;
    SimulationState currentState;

    public int room = 4;

    public TextMeshPro bpm;
    public TextMeshPro t_battery;
    public TextMeshPro t_oxygen;
    public TextMeshPro t_water;

    public const string serverUrl = "http://localhost:8080/api/";
    public const string simState = serverUrl + "simulationstate";
    public string response;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    Debug.LogError(pages[page] + ": Connection Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    this.response = webRequest.downloadHandler.text;
                    if (uri == simState)
                    {
                        SimulationStateList simulationList = new SimulationStateList(this.response);

                        // Get vitals from room
                        int roomIndex = -1;
                        for (int i = 0; i < simulationList.simulationStateList.Count; i++)
                        {
                            if (simulationList.simulationStateList[i].room == this.room)
                            {
                                roomIndex = i;
                                break;
                            }
                        }
                        if (roomIndex == -1)
                        {
                            Debug.Log("Error: No room found.");
                            break;
                        }

                        //Debug.Log(simulationList.simulationStateList[roomIndex].heart_bpm);
                        //Debug.Log(simulationList.simulationStateList[roomIndex].t_battery);
                        //Debug.Log(simulationList.simulationStateList[roomIndex].t_oxygen);
                        //Debug.Log(simulationList.simulationStateList[roomIndex].t_water);

                        bpm.text = "BPM:\n" + simulationList.simulationStateList[roomIndex].heart_bpm.ToString();
                        t_battery.text = "Battery Time:\n" + simulationList.simulationStateList[roomIndex].t_battery;
                        t_oxygen.text = "Oxygen Time:\n" + simulationList.simulationStateList[roomIndex].t_oxygen;
                        t_water.text = "Water Time:\n" + simulationList.simulationStateList[roomIndex].t_water;
                    }
                    break;
            }
        }
    }

    void Start() {
            StartCoroutine(GetRequest(string.Format("http://localhost:8080/api/simulationcontrol/sim/{0}/stop", this.room)));
            StartCoroutine(GetRequest(string.Format("http://localhost:8080/api/simulationcontrol/sim/{0}/start", this.room)));
    }

    void Update() {
        StartCoroutine(GetRequest(simState));
    }
}
