using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Save(float highScore)
    {
        SaveData saveData = new SaveData();

        saveData.highScore = highScore;

        string jsonString = JsonUtility.ToJson(saveData);

        SaveToFile("savedata.json", jsonString);
    }

    public void Load()
    {
        //Get the saved jsonString
        string jsonString = LoadFromFile("savedata.jpg");

        Debug.Log(jsonString);

        //Convert the data to a object
        SaveData loadedData = JsonUtility.FromJson<SaveData>(jsonString);

        //If we have no save data, create some default values.
        if (loadedData == null)
        {
            Debug.Log("we have a small issue here");
          
            
        }

        //We probably would like to add some code in this function
        //that runs if we get broken or no data.

        //Restore our data back into our scene
       
    }

    public string LoadFromFile(string fileName)
    {
        // Open a stream for the supplied file name as a text file
        using (var stream = File.OpenText(fileName))
        {
            // Read the entire file and return the result. This assumes that we've written the
            // file in UTF-8
            return stream.ReadToEnd();
        }
    }

    public void SaveToFile(string fileName, string jsonString)
    {
        // Open a file in write mode. This will create the file if it's missing.
        // It is assumed that the path already exists.
        using (var stream = File.OpenWrite(fileName))
        {
            // Truncate the file if it exists (we want to overwrite the file)
            stream.SetLength(0);

            // Convert the string into bytes. Assume that the character-encoding is UTF8.
            // Do you not know what encoding you have? Then you have UTF-8
            var bytes = Encoding.UTF8.GetBytes(jsonString);

            // Write the bytes to the hard-drive
            stream.Write(bytes, 0, bytes.Length);

            // The "using" statement will automatically close the stream after we leave
            // the scope - this is VERY important
        }
    }

}

[Serializable]
 class SaveData
{

    public float highScore;

}
