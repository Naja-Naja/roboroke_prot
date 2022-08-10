using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects")]
public class robotpartdata : ScriptableObject
{
    public List<robotpart> partsList = new List<robotpart>();
    public List<Quaternion> partsangle = new List<Quaternion>(); 

    public List<robotpart> GetRobotparts()
    {
        return new List<robotpart> (partsList);
    }
    public List<Quaternion> GetQuaternions()
    {
        return new List<Quaternion>(partsangle);
    }
}
