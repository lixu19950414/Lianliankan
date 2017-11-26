using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;

public class Logcat : MonoBehaviour {
    public static string logRootDir = "";
    public static StringBuilder stringBuilder = null;
    public static String logName = "";
    public static String logPath = "";
    public static String logTime = "";
    public static Logcat Instance = null;

    private static void LogHandler(string condition, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Log:
            case LogType.Warning:
                {
                    stringBuilder.Append(string.Format("[{0}] {1}\n", logTime, condition));
                }
                break;
            case LogType.Assert:
            case LogType.Exception:
            case LogType.Error:
                {
                    stringBuilder.Append(string.Format("[{0} ATTENTION] {1}\n", logTime, condition));
                }
                break;
        }
    }

    void Awake () {
        if (Instance == null)
        {
            Application.logMessageReceived += LogHandler;
            logRootDir = Application.persistentDataPath + "/logfile/";
            MakeSureLogRootDir();
            stringBuilder = new StringBuilder();
            logName = String.Format("{0:D4}{1:D2}{2:D2}-{3:D2}{4:D2}{5:D2}.log", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            logPath = logRootDir + logName;
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        logTime = String.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        WriteToFile();
    }

    void WriteToFile()
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(logPath, true, Encoding.UTF8))
        {
            file.Write(stringBuilder);
            stringBuilder = new StringBuilder();
        }
    }

    public void NewLogFile()
    {
        logName = String.Format("{0:D4}{1:D2}{2:D2}-{3:D2}{4:D2}{5:D2}.log", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        logPath = logRootDir + logName;
        if (File.Exists(logPath))
        {
            File.Delete(logPath);
        }
    }

    private void MakeSureLogRootDir()
    {
        if (!Directory.Exists(logRootDir))
        {
            Directory.CreateDirectory(logRootDir);
        }
    }

}
