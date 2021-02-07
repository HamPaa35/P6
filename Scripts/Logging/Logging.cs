using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Application = UnityEngine.Application;
//using Directory = UnityEngine.Windows.Directory;
using Object = UnityEngine.Object;

public class Logging : MonoBehaviour
{
    // Logging arrays
    [SerializeField] private List<List<Vector3>> allPositions = null;
    private List<string> positionIDs = new List<string>();
    private List<List<string>> timeBetweenProgress = new List<List<string>>();
    private List<float> timeStamp = new List<float>();
    private List<List<string>> otherNotes = new List<List<string>>();
    private string progressName = "Introduction";
        // Log like / dislike
    private int storyProgress;
    private List<List<string>>  likes = new List<List<string>>();

    // Visualize Logs
    [SerializeField] private Gradient speedGradient;
    [SerializeField] private float maxSpeed;
    
    // Csv 
    private string basePath;
    [SerializeField] private string path;
    [SerializeField] private string posFileName = "Positions.csv";
    [SerializeField] private string progressFileName = "ProgressTimestamps.csv";
    [SerializeField] private string likesFileName = "Likes.csv";
    [SerializeField] private string otherFileName = "Other.csv";
    private StreamWriter writer;
    private string directory;
    private string currentEntry;
    private string sep = ";";
    private string headers = "TimeStamp";
    
    // Debug
    private List<float> myDeltaTime = new List<float>();
    
    // Start is called before the first frame update
    void Start()
    {
        basePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = basePath + "/GameData";
        directory = path;
        //GetComponent<logPos>().onNewPos += AddPosition;

        // Debug prepare

    }

    // Update is called once per frame
    void Update()
    {
        // Keep timestamp
        timeStamp.Add(Time.time);
        myDeltaTime.Add(Time.deltaTime);
        
        // Debug start ------------------------------------
        /*if (allPositions != null)
        {
             for (int i = 0; i < positionIDs.Count; i++)
             {
                 for (int j = 1; j < allPositions[i].Count; j++)
                 {
                     var previousPoint = allPositions[i][j-1];
                     var point = allPositions[i][j];
                     var speed = ((point - previousPoint)/ myDeltaTime[j]).magnitude;
                     var color = this.speedGradient.Evaluate(Mathf.Min((speed/maxSpeed), 1));

                     Debug.DrawLine (previousPoint, point, color);
                 }
                        
             }
        }*/

        // Manually save logs now.
        /*
        if (Input.GetKeyDown(KeyCode.X))
        {
            saveLogs();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Liked();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Disliked();
        }
        */
        //SaveLogs();
        // Debug end ---------------------------------

    }

    public void AddPosition(Vector3 pos, string nameIn)
    {
        // Add data to existing category. Checks categories and then adds the position
        // to a matching category.
        if (allPositions != null)
        {
            for (int i = 0; i < positionIDs.Count; i++)
            {
                if (nameIn == positionIDs[i])
                {
                    allPositions[i].Add(pos);
                    return;
                }
            }
        }
        // Initialize list
        if (allPositions == null)
        {
            allPositions = new List<List<Vector3>>();
        }
        
        // add new category for pos tracking
        positionIDs.Add(nameIn); // Add the name
        allPositions.Add(new List<Vector3>()); // Add list
        allPositions[allPositions.Count-1].Add(pos); // Add Position

    }

    public void AddStoryProgress(int storyEvent)
    {
        storyProgress = storyEvent;
        switch (storyProgress)
        {
            case 0: // Introduction
                progressName = "Introduction";
                break;
            case 1: // Cut head off
                progressName = "Dead Ox";
                break;
            case 2: // Talk to Hymer again
                progressName = "Preparing to get in boat";
                break;
            case 3: //Get in the boat
                progressName = "In boat";
                break;
            case 4: // To Battle!
                progressName = "In Battle!";
                break;
            case 5: // Outro
                progressName = "Outro";
                break;
            case 6: // Game is done
                progressName = "Game Finished";
                break;
        }
        
        timeBetweenProgress.Add(new List<string>());
        var count = timeBetweenProgress.Count - 1;
        timeBetweenProgress[count].Add(Time.time.ToString());
        timeBetweenProgress[count].Add(progressName);
        
    }

    public void Liked()
    { 
        LikeOrDislike("Liked");
    }

    public void Disliked()
    {
        LikeOrDislike("Disliked");
    }

    private void LikeOrDislike(string like)
    {
        likes.Add(new List<string>());
        var count = likes.Count - 1;
        likes[count].Add(Time.time.ToString());
        likes[count].Add(like);
        likes[count].Add(progressName);
    }

    public void LogOtherNote(string other)
    {
        otherNotes.Add(new List<string>());
        var count = otherNotes.Count - 1;
        otherNotes[count].Add(Time.time.ToString());
        otherNotes[count].Add(other);
        otherNotes[count].Add(progressName);
    }

    public void saveLogs()
    {
        if (!Directory.Exists (directory)) 
        {
            Directory.CreateDirectory (directory);
        }

        directory += "/";
        
        savePositions(directory, posFileName);
        saveProgressMarkers(directory, progressFileName);
        SaveLikes(directory, likesFileName);
        SaveOther(directory, otherFileName);

        print("done logging");
        print(allPositions[0].Count + " frames saved");
    }

    private void savePositions(string pathDirectory, string fileName)
    {
        string fileLocation = pathDirectory + fileName;
        
        // Add object names as headers for file
        for (int i = 0; i < positionIDs.Count; i++)
        {
            headers = string.Concat(headers, sep + positionIDs[i]);
        }
        
        // Create new file / delete preexisting one.
        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
        using (StreamWriter writer = File.AppendText(fileLocation))
        {
            writer.WriteLine(headers);
        }

        // Identify shortest count
        var count = allPositions[0].Count;
        for (int i = 0; i < allPositions.Count; i++)
        {
            if (count > allPositions[i].Count)
            {
                count = allPositions[i].Count;
            }
        }
        
        // Write each entry to the file
        for (int i = 0; i < count; i++)
        {
            currentEntry = timeStamp[i].ToString();
            for (int j = 0; j < positionIDs.Count; j++)
            {
                currentEntry = string.Concat(currentEntry, sep + allPositions[j][i]);
            }
            // Write line to file
            using (StreamWriter writer = File.AppendText(fileLocation))
            {
                writer.WriteLine(currentEntry);
            }
        }
    }

    private void saveProgressMarkers(string pathDirectory, string fileName)
    {
        string fileLocation = pathDirectory + fileName;

        // Create new file / delete preexisting one.
        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
        using (StreamWriter writer = File.AppendText(fileLocation))
        {
            writer.WriteLine("Timestamp; StoryProgress");
        }

        // Write each entry to the file
        for (int i = 0; i < timeBetweenProgress.Count; i++)
        {
            currentEntry = timeBetweenProgress[i][0];
            for (int j = 1; j < timeBetweenProgress[i].Count; j++)
            {
                currentEntry = string.Concat(currentEntry, sep + timeBetweenProgress[i][j]);
            }
            // Write line to file
            using (StreamWriter writer = File.AppendText(fileLocation))
            {
                writer.WriteLine(currentEntry);
            }
        }
    }

    private void SaveLikes(string pathDirectory, string fileName)
    {
        string fileLocation = pathDirectory + fileName;

        // Create new file / delete preexisting one.
        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
        using (StreamWriter writer = File.AppendText(fileLocation))
        {
            writer.WriteLine("Timestamp; Liked; StoryProgress");
        }

        // Write each entry to the file
        for (int i = 0; i < likes.Count; i++)
        {
            currentEntry = likes[i][0];
            for (int j = 1; j < likes[i].Count; j++)
            {
                currentEntry = string.Concat(currentEntry, sep + likes[i][j]);
            }
            
            // Write line to file
            using (StreamWriter writer = File.AppendText(fileLocation))
            {
                writer.WriteLine(currentEntry);
            }
        }
    }

    private void SaveOther(string pathDirectory, string fileName)
    {
        string fileLocation = pathDirectory + fileName;
        // Create new file / delete preexisting one.
        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
        using (StreamWriter writer = File.AppendText(fileLocation))
        {
            writer.WriteLine("Timestamp; Event; StoryProgress");
        }
        
        // Write each entry to the file
        for (int i = 0; i < otherNotes.Count; i++)
        {
            currentEntry = otherNotes[i][0];
            for (int j = 1; j < otherNotes[i].Count; j++)
            {
                currentEntry = string.Concat(currentEntry, sep + otherNotes[i][j]);
            }
            
            // Write line to file
            using (StreamWriter writer = File.AppendText(fileLocation))
            {
                writer.WriteLine(currentEntry);
            }
        }
    }
}
