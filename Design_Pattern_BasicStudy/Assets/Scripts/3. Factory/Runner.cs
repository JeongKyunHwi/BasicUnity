using UnityEngine;

public class Runner : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        health = 30;
        speed = 6f;
        damage = 5f;
    }
    public override void Attack()
    {
        Debug.Log("Runner이(가) 빠르게 연속공격을 한다.");
    }
}
