using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Room
{
    /*
    Class for storing room data as given by Telemetry server
    */
    public int id;
    public string name;
    public int users;
    public string createdAt;
    public string updatedAt;

    /*
    Method to instantiate class members from json strong
    */
    public static Room CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Room>(jsonString);
    }
}

/*
Class for storing list of rooms
*/
public class RoomList
{
    public List<Room> roomList;
    
    public RoomList() {
        this.roomList = new List<Room>();
    }

    /*
    jsonString -- string argument of form list of rooms
    Instantiates roomList to hold room values
    */
    public RoomList(string jsonString) {
        this.roomList = new List<Room>();
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
                // Create new room based on temp string
                Room toAdd = Room.CreateFromJSON(temp);
                roomList.Add(toAdd);
                temp = "";
            }
            else {
                temp += c;
            }
        }
    }
}
