using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    CharacterController characterController;

    public int Health { get; set; }

    [SerializeField] private bool _isPlayer;
    public bool IsPlayer => _isPlayer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        characterController.Move(new Vector3(horizontal, 0, vertical));


    }
}
