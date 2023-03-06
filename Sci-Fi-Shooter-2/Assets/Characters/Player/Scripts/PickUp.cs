using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Medicine Chest"))
        {
            var health = GetComponent<HealthPoints>();
            health.TakeHealth(health.MaxHealth);

            Destroy(other.gameObject);
        }
    }
}
