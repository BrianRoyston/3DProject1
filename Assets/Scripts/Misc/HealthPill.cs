using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPill : MonoBehaviour
{
    #region Editor Variabes
    [SerializeField]
    [Tooltip("The amount of health that this pill restores")]
    private int m_HealthGain;
    public int HealthGain
    {
        get
        {
            return m_HealthGain;
        }
    }

    #endregion

    #region

    public void Start()
    {
        Rigidbody cc_Rb = GetComponent<Rigidbody>();
        cc_Rb.MovePosition(new Vector3(cc_Rb.position.x,1,cc_Rb.position.z));
    }
    
    #endregion

    #region

    #endregion
}
