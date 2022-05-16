using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QueueGroup{
    public List<GameObject> NorthList;
    public List<GameObject> SouthList;
    public List<GameObject> EastList;
    public List<GameObject> WestList;



    public QueueGroup(List<GameObject> northList, List<GameObject> southList, List<GameObject> eastList, List<GameObject> westList) {
        NorthList = northList;
        SouthList = southList;
        EastList = eastList;
        WestList = westList;
    }
    
}
