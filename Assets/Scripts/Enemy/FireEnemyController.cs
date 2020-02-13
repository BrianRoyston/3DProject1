using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("How much health the enemy has")]
    private int m_MaxHealth;

    [SerializeField]
    [Tooltip("How fast the enemy can move")]
    private float m_Speed;

    [SerializeField]
    [Tooltip("Approximate amount of damage dealt per frame")]
    private float m_Damage;

    [SerializeField]
    [Tooltip("The amount of smaller enemies made each death")]
    private int m_NumBabies;


    [SerializeField]
    [Tooltip("The child enemy")]
    private GameObject m_ChildEnemy;

    [SerializeField]
    [Tooltip("The range of the child spawn")]
    private int m_Range;

    [SerializeField]
    [Tooltip("The probability that this enemy drops a health pill")]
    private float m_HealthPillDropRate;

    [SerializeField]
    [Tooltip("The type of health pill that this enemy drops")]
    private GameObject m_HealthPill;

    [SerializeField]
    [Tooltip("How many points killing this enemy will provide")]
    private int m_Score;
    #endregion

    #region Private Variables
    private float p_currHealth;
    #endregion

    #region Cached Components
    private Rigidbody cc_Rb;
    #endregion

    #region Cached References
    private Transform cr_Player;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_currHealth = m_MaxHealth;

        cc_Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        cr_Player = FindObjectOfType<PlayerController>().transform;
    }
    #endregion

    #region Main Updates
    private void FixedUpdate()
    {
        Vector3 dir = cr_Player.position - transform.position;
        dir.Normalize();
        cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
    }
    #endregion

    #region Collision Methods
    private void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
        }
        if(other.CompareTag("AttackAbility"))
        {
            DecreaseHealth(4);
        }
    }
    #endregion

    #region Health Methods
    public void DecreaseHealth(float amount)
    {
        p_currHealth -= amount;
        if(p_currHealth <= 0)
        {
            ScoreManager.singleton.IncreaseScore(m_Score);
            HUDController.singleton.IncreaseScore(m_Score);
            if (Random.value < m_HealthPillDropRate)
            {
                Instantiate(m_HealthPill, transform.position, Quaternion.identity);
            }
            for (int i = 0; i < m_NumBabies; i++)
            {
                
                Instantiate(m_ChildEnemy, transform.position+ new Vector3(Random.Range(-m_Range,m_Range),0,Random.Range(-m_Range, m_Range)), Quaternion.identity);
            }
            Destroy(gameObject);
        }
       
    }
    #endregion
}
