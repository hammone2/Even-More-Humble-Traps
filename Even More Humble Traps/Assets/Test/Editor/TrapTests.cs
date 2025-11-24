using NSubstitute;
using NUnit.Framework;
using UnityEditor.VersionControl;
public class TrapTests
{
    [Test]
    public void PlayerEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayerController player = Substitute.For<IPlayerController>();
        player.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(player, TrapType.Player);
        Assert.AreEqual(-1, player.Health);
    }

    [Test]
    public void NpcEnteringTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        IPlayerController player = Substitute.For<IPlayerController>();

        trap.HandleCharacterEntered(player, TrapType.Npc);
        Assert.AreEqual(-1, player.Health);
    }
}
