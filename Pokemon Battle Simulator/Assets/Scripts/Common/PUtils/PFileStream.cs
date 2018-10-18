﻿/********************************************************************************* 
  *Author:Rebuild failed
  *Date:  2018-10-9
  *Description: 各种文件读写
**********************************************************************************/
using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PFileStream
{

    //读取CSV文件
    public static Dictionary<string, Dictionary<string, string>> ReadCsvFile(string _fileName)
    {
        Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
        string url = PPlatform.SplitPath(new string[] { PPlatform.DATA_PATH, "CSV", _fileName });
        string[] fileData = File.ReadAllLines(url);
        if (fileData.Length < 3)
        {
            return result;
        }

        /* CSV文件的第一行为Key字段，第二行为说明（不需要读取），第三行开始是数据。第一个字段一定是ID。 */
        string[] keys = fileData[0].Split(',');
        for (int i = 2; i < fileData.Length; i++)
        {
            string[] line = fileData[i].Split(',');

            /* 以ID为key值，创建一个新的集合，用于保存当前行的数据 */
            string ID = line[0];
            result[ID] = new Dictionary<string, string>();
            for (int j = 0; j < line.Length; j++)
            {
                /* 每一行的数据存储规则：Key字段-Value值 */
                result[ID].Add(keys[j],line[j]);
            }
        }
        return result;
    }
}
