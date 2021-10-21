/////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2021 Tegridy Ltd                                          //
// Author: Darren Braviner                                                 //
// Contact: db@tegridygames.co.uk                                          //
/////////////////////////////////////////////////////////////////////////////
//                                                                         //
// This program is free software; you can redistribute it and/or modify    //
// it under the terms of the GNU General Public License as published by    //
// the Free Software Foundation; either version 2 of the License, or       //
// (at your option) any later version.                                     //
//                                                                         //
// This program is distributed in the hope that it will be useful,         //
// but WITHOUT ANY WARRANTY.                                               //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////
//                                                                         //
// You should have received a copy of the GNU General Public License       //
// along with this program; if not, write to the Free Software             //
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,              //
// MA 02110-1301 USA                                                       //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.IO;

using System.Text;
using UnityEngine;

namespace Tegridy.Tools
{
    public class FileTools
    {
        public static int[] SplitStringToInt(string splitData, char splitChar)
        {
            string[] split = splitData.Split(splitChar);
            int[] finalData = new int[split.Length];
            for (int i = 0; i < finalData.Length; i++)
            {
                finalData[i] = int.Parse(split[i]);
            }
            return finalData;
        }
        public static void SaveStrings(string path, string[] saveData)
        {
            //delete the old data
            if (File.Exists(path))
                File.Delete(path);
            if (!File.Exists(path))
            {
                // Create a file to write to.
                File.WriteAllLines(path, saveData, Encoding.UTF8);
            }
        }
        public static void AppendFile(string path, string value)
        {
            string writeLine = value + "^" + Time.time;
            File.AppendAllText(path, writeLine + "\n");
        }
        public static void LoadInts(string path, int[] value)
        {
            if (File.Exists(path))
            {
                string[] loadData = File.ReadAllLines(path);
                for (int i = 0; i < loadData.Length; i++)
                {
                    value[i] = int.Parse(loadData[i]);
                }
            }
            //else Debug.Log("NO FILE = " + path);
        }
        public static void LoadIntsAndResize(string path, int[] value)
        {
            if (File.Exists(path))
            {
                string[] loadData = File.ReadAllLines(path);
                for (int i = 0; i < loadData.Length; i++)
                {
                    value[i] = int.Parse(loadData[i]);
                }
            }
        }
        public static void SaveInts(string path, int[] value)
        {
            //creat our array and convert our stock ints into strings
            string[] saveData = new string[0];
            Array.Resize(ref saveData, value.Length);
            for (int i = 0; i < saveData.Length; i++)
            {
                saveData[i] = value[i].ToString();
            }
            SaveStrings(path, saveData);
        }
        public static void SaveFloats(string path, float[] value)
        {
            //creat our array and convert our stock ints into strings
            string[] saveData = new string[value.Length];
            for (int i = 0; i < saveData.Length; i++)
            {
                saveData[i] = value[i].ToString();
            }
            SaveStrings(path, saveData);
        }
        public static void SaveBools(string path, bool[] data)
        {
            string[] saveData = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                saveData[i] = data[i].ToString();
            }
            File.WriteAllLines(path, saveData);
        }
        public static bool[] LoadBools(string path)
        {
            if (File.Exists(path))
            {
                string[] loadData = File.ReadAllLines(path);
                bool[] newList = new bool[loadData.Length];
                for (int i = 0; i < loadData.Length; i++)
                {
                    newList[i] = bool.Parse(loadData[i]);
                }
                return newList;
            }
            else return null;
        }
    }
}