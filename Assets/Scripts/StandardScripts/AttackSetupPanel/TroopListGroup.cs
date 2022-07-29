using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TroopListGroup{
    public List<string> NorthList;
    public List<string> SouthList;
    public List<string> EastList;
    public List<string> WestList;


    public TroopListGroup(List<string> northList, List<string> southList, List<string> eastList, List<string> westList) {
        NorthList = northList;
        SouthList = southList;
        EastList = eastList;
        WestList = westList;
    }
}
