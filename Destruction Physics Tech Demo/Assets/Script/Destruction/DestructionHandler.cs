using UnityEngine;

public class DestructionHandler : MonoBehaviour, IDamageable
{
    public Collider[] fractureColliders;


    public void Damage(float receivedDMG)
    {

    }



    void DetectCollisionBound()
    {
        foreach (Collider col in fractureColliders)
        {

        }
    }
}
