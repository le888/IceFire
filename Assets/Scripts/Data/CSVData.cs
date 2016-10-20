using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using UnityEngine;
class CSVData
{
    private static string[] tableTitle;
    public static List<object> LoadData(string filePath,string typeName)
    {
        Type ty = typeof(int);
        List<object> list = new List<object>();

        using (StreamReader sr = new StreamReader(filePath,Encoding.Unicode))
        {
            string tempStr;

            //sr.ReadLine();//第一行标示行没用

            tempStr = sr.ReadLine();//第一行 title 与类名对应,区分大小写

            if(tempStr == "" || tempStr == null)
            {
                Debug.LogError("表头不能为空 " + filePath.Substring(filePath.LastIndexOf('\\')));
                     
            }

            tableTitle = tempStr.Split(',');

            while((tempStr = sr.ReadLine())!= null)
            {
                string[] strs = tempStr.Split(',');
                list.Add(DataForType(strs, typeName));
            }
        }
        return list;   
    }

    private static object DataForType(string[] data, string typeName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        

        var target  = assembly.CreateInstance(typeName,false);

        FieldInfo[] fieldInfos = target.GetType().GetFields();

        for(int i =0;i<fieldInfos.Length-1;i++)
        {
            if (!IsCSVData(fieldInfos[i]))
                continue;

            object value = Matching(fieldInfos[i].Name, data, i);

          if (value == null)
              continue;

          MatchTypeValue(target, fieldInfos[i], value);

        }
        return target;
    }

    private static void MatchTypeValue(object target, FieldInfo fieldInfo, object value)
    {
        if (fieldInfo.FieldType == typeof(int))
        {
            fieldInfo.SetValue(target, int.Parse(value.ToString()));

        }
        else if (fieldInfo.FieldType == typeof(float))
        {
            fieldInfo.SetValue(target, float.Parse(value.ToString()));
        }
        else if (fieldInfo.FieldType == typeof(double))
        {
            fieldInfo.SetValue(target, double.Parse(value.ToString()));
        }
        else if (fieldInfo.FieldType == typeof(string))
        {
            fieldInfo.SetValue(target, value.ToString());
        }
    }

    private static bool IsCSVData(FieldInfo pInfo)
    {
        object[] customAttribus = pInfo.GetCustomAttributes(false);
       foreach(object o in customAttribus)
       {
           if(o is CSVAttribute)
           {
               return (o as CSVAttribute).IsCSVData;
           }
           continue;
       }
        return false;
    }

    private static object Matching(string PropertesName, string[] data, int fistIndex)
    {
        if(PropertesName.Equals(tableTitle[fistIndex]))
            return data[fistIndex];

        int leng = tableTitle.Length - 1;
        if (leng > data.Length - 1)
            leng = data.Length - 1;

        for(int i=0;i<leng;i++)
        {
            if(PropertesName.Equals(tableTitle[i]))
                return data[i];
        }
        return null;
    }
}
