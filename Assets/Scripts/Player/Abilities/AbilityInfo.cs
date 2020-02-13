using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInfo 
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How much power this ability has")]
    private int m_Power;
    public int Power
    {
        get
        {
            return m_Power;
        }
    }

    [SerializeField]
    [Tooltip("If this is an attack that shoots something out, this value describes how far the attack can shoot")]
    private int m_Range;
    public int Range
    {
        get
        {
            return m_Range;
        }
    }

    [SerializeField]
    [Tooltip("If this is a radius attack, what is the radius")]
    private int m_Radius;
    public int Radius
    {
        get
        {
            return m_Radius;
        }
    }

    #endregion
}
