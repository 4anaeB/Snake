using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Drawing;

public class Controls : MonoBehaviour
{
    public Transform player;
    public Vector3 direction;
    public float speed;
    public float Sensitivity;
    private Vector3 _previousMousePosition;
    private double halfWidth = 5.0;
    private double radius = 0.5;

    public int Length = 1;

    public int points;
    public int Block;


    public Text textScore;

    public Rigidbody rb;



    private void Start()
    {

    }

    void Update()
    {

        rb = GetComponent<Rigidbody>();
        if (rb)
            rb.velocity = direction * speed;


        if (Input.GetMouseButton(0))
        {

            Vector3 delta = Input.mousePosition - _previousMousePosition;
            if (delta.x > 0)
            {
                if (player.position.x + radius < halfWidth)
                {
                    SetPosition(delta);
                }

            }
            else
            {
                if (player.position.x - radius > -halfWidth)
                {
                    SetPosition(delta);

                }

            }

        }
        _previousMousePosition = Input.mousePosition;

    }
    private void SetPosition(Vector3 delta)
    {
        player.Translate(delta.x * Sensitivity, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Point")
        {
            points++;
            other.gameObject.SetActive(false);
            textScore.text = points.ToString();
        }
    }
}
