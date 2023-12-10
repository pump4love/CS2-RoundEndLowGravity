using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Cvars;

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

    float roundtimer = ConVar.Find("mp_round_restart_delay").GetPrimitiveValue<float>();

    private HookResult Event_RoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        NativeAPI.IssueServerCommand("sv_gravity 200");

        base.AddTimer(roundtimer, () =>
        {
            NativeAPI.IssueServerCommand("sv_gravity 800");
        });
        return HookResult.Continue;
    }
}