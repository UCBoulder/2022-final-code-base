using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class User
{
    /*
    Class for storing User data as given by Telemetry server
    */
    public int id;
    public string username;
    public int room;
    public string createdAt;
    public string updatedAt;

    /*
    Method to instantiate class members from json strong
    */
    public static User CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<User>(jsonString);
    }
}

/*
Class for storing list of Users
*/
public class UserList
{
    public List<User> userList;
    
    public UserList() {
        this.userList = new List<User>();
    }

    /*
    jsonString -- string argument of form list of Users
    Instantiates UserList to hold User values
    */
    public UserList(string jsonString) {
        this.userList = new List<User>();
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
                // Create new User based on temp string
                User toAdd = User.CreateFromJSON(temp);
                userList.Add(toAdd);
                temp = "";
            }
            else {
                temp += c;
            }
        }
    }
}
