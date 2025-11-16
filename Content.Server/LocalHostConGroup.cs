using System.Diagnostics;
using System.Net;
using JetBrains.Annotations;
using Robust.Server.Console;
using Robust.Shared.Player;
using Robust.Shared.Toolshed;
using Robust.Shared.Toolshed.Errors;
using Robust.Shared.Utility;

namespace Content.Server;

/// <summary>
///     Debug/example ConGroup controller implementation that gives any client connected through localhost every permission.
/// </summary>
[UsedImplicitly]
public sealed class LocalHostConGroup : IConGroupControllerImplementation, IPostInjectInit
{
    [Dependency] private readonly IConGroupController _controller = null!;

    public bool CanCommand(ICommonSession session, string cmdName) {
        return IsLocal(session);
    }

    public bool CanViewVar(ICommonSession session) {
        return IsLocal(session);
    }

    public bool CanAdminPlace(ICommonSession session) {
        return IsLocal(session);
    }

    public bool CanScript(ICommonSession session) {
        return IsLocal(session);
    }

    public bool CanAdminMenu(ICommonSession session) {
        return IsLocal(session);
    }

    public bool CanAdminReloadPrototypes(ICommonSession session) {
        return IsLocal(session);
    }

    private static bool IsLocal(ICommonSession player) {
        var ep = player.Channel.RemoteEndPoint;
        var addr = ep.Address;
        if (addr.IsIPv4MappedToIPv6) {
            addr = addr.MapToIPv4();
        }

        return Equals(addr, IPAddress.Loopback) || Equals(addr, IPAddress.IPv6Loopback);
    }

    void IPostInjectInit.PostInject() {
        _controller.Implementation = this;
    }

    private record NotLocalError : IConError
    {
        public FormattedMessage DescribeInner()
        {
            return FormattedMessage.FromUnformatted("Not the local user, refusing!");
        }

        public string Expression { get; set; }

        public Vector2i? IssueSpan { get; set; }

        public StackTrace Trace { get; set; }
    }
    
    public bool CheckInvokable(CommandSpec command, ICommonSession user, out IConError error)
    {
        if (!IsLocal(user))
        {
            error = new NotLocalError();
            return false;
        }

        error = null;
        return true;
    }
}