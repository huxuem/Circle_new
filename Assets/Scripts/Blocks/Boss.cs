using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Block
{
    [SerializeField] private float Force;
    [SerializeField] private Block OnHitBlock;
    [SerializeField] private int SpawnNum = 4;
    private Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    public void OnHit(Vector3 Velocity)
    {
        hitRemain -= 1;
        //Debug.Log("Boss get hit,hitRemain:"+hitRemain);

        rb.velocity = Velocity * Force;

        CheckDestory();
        changeMaterial();
    }

    protected override void CheckDestory()
    {
        for (int i = 0; i < SpawnNum; i++)
        {
            Instantiate(OnHitBlock, transform.position, Quaternion.identity);
        }
        if (hitRemain <= 0)
        {
            for (int i = 0; i < SpawnNum*2; i++)
            {
                Instantiate(OnHitBlock, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}