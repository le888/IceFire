using System;
using System.Collections.Generic;

class DataManager
{
    private List<WindowsData> windowsData;

    public List<WindowsData> WindowsData
    {
        get
        {
            return windowsData;
        }

        set
        {
            windowsData = value;
        }
    }




    public void InitData()
    {
        //CSVData.LoadData( )
    }
}

