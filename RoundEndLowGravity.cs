using CounterStrikeSharp.API.Core;

namespace RoundEndLowGravity;

public class RoundEndLowGravity : BasePlugin
{
    public override string ModuleName => "RoundEndLowGravity";

    public override string ModuleVersion => "0.0.2";

    public override string ModuleAuthor => "Pump4Love";

    public override string ModuleDescription => "RoundEndLowGravity.";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventRoundEnd>(Event_RoundEnd, HookMode.Post);
    }

    int endtimer = ConVar.Find("sv_cheats");

    private HookResult Event_RoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        NativeAPI.IssueServerCommand("sv_gravity 200");

        base.AddTimer(endtimer, () =>
        {
            NativeAPI.IssueServerCommand("sv_gravity 800");
        });
        return HookResult.Continue;
    }
}