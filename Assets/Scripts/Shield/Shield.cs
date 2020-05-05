using UnityEngine;

[RequireComponent(typeof(ShieldMovement))]
public class Shield : MonoBehaviour
{
    [SerializeField] private ShieldMovement shieldMovement = null;

    public ShieldMovement ShieldMovement => shieldMovement;
}
