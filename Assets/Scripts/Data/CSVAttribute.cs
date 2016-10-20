using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false,Inherited = true)]
class CSVAttribute:Attribute
{
    bool isCSVData;
    public CSVAttribute(bool isCSVData)
    {
        this.isCSVData = isCSVData;
    }

    public bool IsCSVData 
    {
        get
        { return isCSVData; 
        }
    }
}

