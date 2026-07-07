using Content.Client;
using NUnit.Framework;
using Robust.Server.Player;
using Robust.Shared.Enums;
using Robust.Shared.IoC;
using Robust.Shared.Network;
using Robust.Shared.Player;
using Robust.UnitTesting;

namespace Content.Tests;

[TestFixture]
public sealed class StartupTest : RobustIntegrationTest
{
    [Test]
    public async Task ServerStarts()
    {
        var server = StartServer(ServerOptions());

        await server.WaitIdleAsync();

        Assert.That(server.IsAlive, Is.True);
        Assert.That(server.UnhandledException, Is.Null);
    }

    [Test]
    public async Task ClientStarts()
    {
        var client = StartClient(ClientOptions());

        await client.WaitIdleAsync();

        Assert.That(client.IsAlive, Is.True);
        Assert.That(client.UnhandledException, Is.Null);
    }

    [Test]
    public async Task ClientConnectsToServer()
    {
        await using var pair = await StartConnectedPair(ServerOptions(), ClientOptions(), "TemplateTester");
        var server = pair.Server;
        var client = pair.Client;

        await RunTicksSync(server, client, 10);

        await server.WaitAssertion(() =>
        {
            var playerManager = IoCManager.Resolve<IPlayerManager>();

            Assert.That(playerManager.PlayerCount, Is.EqualTo(1));
            Assert.That(playerManager.Sessions, Has.One.Matches<ICommonSession>(
                session => session.Status == SessionStatus.Connected && session.Channel.IsConnected));
        });

        await client.WaitAssertion(() =>
        {
            var netManager = IoCManager.Resolve<IClientNetManager>();

            Assert.That(netManager.IsConnected, Is.True);
            Assert.That(netManager.ServerChannel, Is.Not.Null);
            Assert.That(netManager.ServerChannel!.IsConnected, Is.True);
        });
    }

    private static ServerIntegrationOptions ServerOptions()
    {
        return new ServerIntegrationOptions
        {
            ContentStart = true,
            ContentAssemblies = [typeof(Content.Server.EntryPoint).Assembly],
            Options = new Robust.Server.ServerOptions
            {
                ContentModulePrefix = "Content.",
                LoadConfigAndUserData = false,
                LoadContentResources = false,
            },
        };
    }

    private static ClientIntegrationOptions ClientOptions()
    {
        return new ClientIntegrationOptions
        {
            ContentStart = true,
            ContentAssemblies = [typeof(EntryPoint).Assembly],
            Options = new Robust.Client.GameControllerOptions
            {
                ContentModulePrefix = "Content.",
                LoadConfigAndUserData = false,
                LoadContentResources = false,
            },
        };
    }
}
