using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class DeathBallScript : MonoBehaviour
{
    [SerializeField] Transform m_startPoint;
    [SerializeField] Transform m_endPoint;
    [SerializeField] float m_speed;

    Transform target;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        target = m_startPoint; //sets the initial target
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, m_speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeTarget(); //if the death ball collides with either the start or stop point, this will be called
    }

    void ChangeTarget()
    {
        if (target == m_endPoint)
        {
            target = m_startPoint;
        }
        else if (target == m_startPoint) 
        {
            target = m_endPoint;
        }
            
    }

}
