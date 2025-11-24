using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    [SerializeField] private TrapType trapType;

    Trap trap;

    private void Awake()
    {
        trap = new Trap();
    }

    private void OnTriggerEnter(Collider other)
    {
        var characterController = other.GetComponent<IPlayerController>();
        trap.HandleCharacterEntered(characterController, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(IPlayerController characterController, TrapType trapType)
    {
        if (characterController.IsPlayer)
        {
            if (trapType == TrapType.Player)
            {
                characterController.Health--;
                return;
            }
            
            if (trapType == TrapType.HealthPickup)
            {
                characterController.Health++;
                return;
            }

            if (trapType == TrapType.InstantDeath)
            {
                characterController.Health = 0;
            }
        }
        else
        {
            if (trapType == TrapType.Npc)
                characterController.Health--;
        }    
    }
}

public enum TrapType { 
    Player, 
    Npc, 
    HealthPickup,
    InstantDeath
}
