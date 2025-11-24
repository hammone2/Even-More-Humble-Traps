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
        var player = other.GetComponent<IPlayerController>();
        trap.HandleCharacterEntered(player, trapType);
    }
}

public class Trap
{
    public void HandleCharacterEntered(IPlayerController player, TrapType trapType)
    {
        if (player.IsPlayer)
        {
            if (trapType == TrapType.Player)
                player.Health--;
        }
        else
        {
            if (trapType == TrapType.Npc)
                player.Health--;
        }

            
    }
}

public enum TrapType { Player, Npc }
