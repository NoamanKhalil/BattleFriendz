using UnityEngine;

public class EnemyProjectileCs : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag.Equals("shield"))
        {
             Debug.Log("Collison with shield happening");
            if (col.gameObject.GetComponent<ShieldCs>() != null)
            {
                col.gameObject.GetComponent<ShieldCs>().removeShield();
                Destroy(this.gameObject);
            }
 
        }
        else if (col.gameObject.tag.Equals("WeakPoint"))
        {
            col.gameObject.GetComponentInParent<PlayerBehaviourScriptCs>().takeMoreDamage();
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag.Equals("Player"))
        {
            if (col.gameObject.GetComponent<PlayerBehaviourScriptCs>() != null)
            {
                col.gameObject.GetComponent<PlayerBehaviourScriptCs>().takeDamage();
                Destroy(this.gameObject);
            }
            else if (col.gameObject.GetComponent<OfflinePlayerBehaviourScriptCs>() != null)
            {
                col.gameObject.GetComponent<OfflinePlayerBehaviourScriptCs>().takeDamage();
                Destroy(this.gameObject);
            }
     
        }
        else if (col.gameObject.tag.Equals("EnemyBullet"))
        {
            Destroy(this.gameObject);
        }
      
            Destroy(this.gameObject, 1.0f);
        
    }
}