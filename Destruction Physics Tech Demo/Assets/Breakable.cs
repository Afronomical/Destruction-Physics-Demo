using UnityEngine;

public class Breakable : MonoBehaviour
{

    [SerializeField] private GameObject brokenVersion;
    [SerializeField] private bool isBroken;
    [SerializeField] private float breakForce = 2;
    [SerializeField] private float collisionMultiplier = 100;





    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        if (collision.relativeVelocity.magnitude >= breakForce)
        {
            isBroken = true;
            var _brokenVersion = Instantiate(brokenVersion, transform.position, transform.rotation);
            var rbList = _brokenVersion.GetComponentsInChildren<Rigidbody>();
            foreach (var rb in rbList)
            {
                rb.AddExplosionForce(collision.relativeVelocity.magnitude * collisionMultiplier, collision.contacts[0].point, 2);
            }
            Destroy(gameObject);
        }
    }



}
