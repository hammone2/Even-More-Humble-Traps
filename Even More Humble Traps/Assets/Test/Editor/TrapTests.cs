using NSubstitute;
using NUnit.Framework;

public class TrapTests
{
    [Test]
    public void PlayerEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayerController characterController = Substitute.For<IPlayerController>();
        characterController.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterController, TrapType.Player);
        Assert.AreEqual(-1, characterController.Health);
    }

    [Test]
    public void NpcEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayerController characterController = Substitute.For<IPlayerController>();

        trap.HandleCharacterEntered(characterController, TrapType.Npc);
        Assert.AreEqual(-1, characterController.Health);
    }

    [Test]
    public void PlayerEnteringTrap_IncreasesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayerController characterController = Substitute.For<IPlayerController>();
        characterController.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterController, TrapType.HealthPickup);
        Assert.AreEqual(1, characterController.Health);
    }

    [Test]
    public void PlayerEnteringTrap_InstantlyKillsPlayer()
    {
        Trap trap = new Trap();
        IPlayerController characterController = Substitute.For<IPlayerController>();
        characterController.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterController, TrapType.InstantDeath);
        Assert.AreEqual(0, characterController.Health);
    }
}
