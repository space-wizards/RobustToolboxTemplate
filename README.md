## Robust Toolbox Template
This template is designed to provide an easy entrypoint into creating a new game on [RobustToolbox](https://github.com/space-wizards/RobustToolbox), 
with a functional client and server provided that can connect to one another (if not much else until you start adding content.)

This template additionally includes some helpful IDE settings if you're using Visual Studio or Rider, like RobustToolbox-specific file templates to quickly make new components, systems, and prototypes.

An example file structure for Resources is also provided.

### Wait, why would I use RobustToolbox? 
RobustToolbox is a fairly modern ECS game engine with strong multiplayer support. Out of the box, it's netcode is capable of handling hundreds of players (as demonstrated by the game it was originally written for, [Space Station 14](https://spacestation14.io/)) and is relatively easy to use with less risk of common mistakes like giving clients authority over game state compared to other engines.

It provides prediction-based server authoritative netcode by default, with options to both autogenerate simple state synchronization for components and to manually implement more complex state application algorithms as necessary. Additionally, basic RPC is provided through networked entity events (which can be sent both ways, and optionally targeted at specific entities) alongside direct access to the underlying transit layer for more direct control when necessary.

Features like network visibility culling (called PVS by the engine) and replay recording are also provided by default, and client/server code is split to greatly reduce the odds that server specific information leaks over to the client due to programmer error.

Additionally, RobustToolbox has strong mod support, with ECS architecture encouraging code flexibility combined with engine level code sandboxing and mod loading. While a mod menu isn't a built-in feature of the engine at this time, automatically synchronizing assets to players on a per-server basis is, allowing for servers to modify your game's content fairly freely if utilized.