using TMPro;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject Block;
    public int HealthBlock;
    public int damageCount = 1;
    public TextMeshPro hp;

    private void Start()
    {
        hp.text = hp.ToString();
    }

    private void Update()
    {
        if(HealthBlock <= 0)
        {
            Block.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            HealthBlock -= 1;
            hp.text = hp.ToString();
        }
    }
}
