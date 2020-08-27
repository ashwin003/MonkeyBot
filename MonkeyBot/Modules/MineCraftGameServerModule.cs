﻿using Discord;
using Discord.Commands;
using Microsoft.Extensions.Logging;
using MonkeyBot.Common;
using MonkeyBot.Models;
using MonkeyBot.Preconditions;
using MonkeyBot.Services;
using System.Threading.Tasks;

namespace MonkeyBot.Modules
{
    /// <summary>Module that provides support for Minecraft game servers</summary>
    [Group("MineCraftGameServers")]
    [Description("MineCraftGameServers")]
    [MinPermissions(AccessLevel.ServerAdmin)]
    [RequireGuild]
    [RequireBotPermission(GuildPermission.EmbedLinks)]
    public class MineCraftGameServerModule : GameServerModuleBase
    {
        public MineCraftGameServerModule(MineCraftGameServerService gameServerService, ILogger<MineCraftGameServerModule> logger) : base(gameServerService, logger)
        {
        }

        [Command("Add")]
        [Description("Adds the specified game server and posts it's info info in the current channel")]
        [Example("!minecraftgameservers add 127.0.0.1:1234")]
        public Task AddGameServerAsync([RemainingText][Summary("The ip adress and query port of the server")] string ip)
            => AddGameServerInternalAsync(ip, Context.Channel.Id);

        [Command("Add")]
        [Description("Adds the specified game server and sets the channel where the info will be posted.")]
        [Example("!minecraftgameservers add \"127.0.0.1:1234\" \"general\"")]
        public async Task AddGameServerAsync([Summary("The ip adress and query port of the server")] string ip, [Summary("The channel where the server info should be posted")] ITextChannel channel)
        {
            if (channel == null)
            {
                _ = await ctx.RespondAsync("The specified channel does not exist").ConfigureAwait(false);
            }
            else
            {
                await AddGameServerInternalAsync(ip, channel.Id).ConfigureAwait(false);
            }
        }

        [Command("List")]
        [Description("Lists all added steam game servers")]
        [Example("!minecraftgameservers list")]
        public Task ListSteamGameserversAsync()
            => ListGameServersInternalAsync(GameServerType.Minecraft);

        [Command("Remove")]
        [Description("Removes the specified game server")]
        [Example("!minecraftgameservers remove 127.0.0.1:1234")]
        public Task RemoveGameServerAsync([Summary("The ip adress and query port of the server")] string ip)
            => RemoveGameServerInternalAsync(ip);
    }
}