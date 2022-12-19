using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private List<Transform> snaketail;
    [SerializeField] Transform snaketail_prefab;
    public Rigidbody Rigidbody;
    public Vector3 Force;
    public Game Game;

    private void Start()
    {
        snaketail = new List<Transform>();
        snaketail.Add(this.transform);
    }
    public void ReachFinish()
    {
        Game.OnPlayerReachedFinish();
         Rigidbody.velocity = Vector3.zero;  
       
    }
    private void FixedUpdate()
    {
        for(int i = snaketail.Count - 1; i > 0; i --)
        {
            snaketail[i].position = snaketail[i - 1].position;
        }
    }
    private void AddTail()
    {
        Transform tail = Instantiate(this.snaketail_prefab);
        tail.position = snaketail[snaketail.Count - 1].position;

        snaketail.Add(tail);
    }
    private void RemoveTail()
    {
        Destroy(snaketail[2].gameObject);
        snaketail.RemoveAt(2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Point")
        {
            AddTail();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        Rigidbody.AddForce(Force, ForceMode.Impulse);
    }
}
