using MoreMountains.TopDownEngine;
using UnityEngine;

public class MindControlDamageOnTouch : DamageOnTouch
{
    public override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        MindControlReceiver receiver = collider.GetComponent<MindControlReceiver>();
        if (receiver != null)
        {
            Debug.Log("Mind Control applied to " + collider.name);
            receiver.TriggerMindControl(gameObject); 
        }
    }
}