﻿using Discord;
using Discord.Commands;
using MonkeyBot.Common;
using MonkeyBot.Preconditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyBot.Modules
{
    /// <summary>
    /// Provides some commands for the bot owner
    /// </summary>
    [MinPermissions(AccessLevel.BotOwner)]
    [Description("Owner Commands")]
    public class OwnerModule : MonkeyModuleBase
    {
        [Command("Say")]
        [Description("Say something in a specific guild's channel")]
        public async Task SayAsync(ulong guildId, ulong channelId, [RemainingText] string message)
        {
            IGuild guild = await Context.Client.GetGuildAsync(guildId).ConfigureAwait(false);
            if (guild == null)
            {
                _ = await ctx.RespondAsync("Guild not found").ConfigureAwait(false);
                return;
            }
            ITextChannel textChannel = await guild.GetTextChannelAsync(channelId).ConfigureAwait(false);
            if (textChannel == null)
            {
                _ = await ctx.RespondAsync("Channel not found").ConfigureAwait(false);
                return;
            }
            _ = await textChannel.SendMessageAsync(message).ConfigureAwait(false);
        }

        [Command("ListGuilds")]
        [Description("List all the guilds the Bot joined")]
        public async Task ListGuildsAsync()
        {
            IReadOnlyCollection<IGuild> guilds = await Context.Client.GetGuildsAsync().ConfigureAwait(false);
            var builder = new DiscordEmbedBuilder()
                .WithAuthor(Context.Client.CurrentUser)
                .WithTitle("Currently connected guilds");
            foreach (IGuild guild in guilds)
            {
                int channelCount = (await guild.GetChannelsAsync().ConfigureAwait(false)).Count;
                int userCount = (await guild.GetUsersAsync().ConfigureAwait(false)).Count;
                IGuildUser owner = await guild.GetOwnerAsync().ConfigureAwait(false);
                string guildInfo = $"{channelCount} Channels, {userCount} Users, Owned by {owner.Username}, Created at {guild.CreatedAt}";
                if (!guild.Description.IsEmptyOrWhiteSpace())
                {
                    guildInfo += $"\n Description: {guild.Description}";
                }
                _ = builder.AddField(guild.Name, guildInfo);
            }            
            _ = await ctx.RespondAsync(embed: builder.Build()).ConfigureAwait(false);
        }

        [Command("AddOwner")]
        [Description("Adds the specified user to the list of bot owners")]
        public async Task AddOwnerAsync([Summary("The name of the user to add")] string username)
        {
            IGuildUser user = await GetUserInGuildAsync(username).ConfigureAwait(false);
            if (user == null)
            {
                return;
            }
            DiscordClientConfiguration config = await DiscordClientConfiguration.LoadAsync().ConfigureAwait(false);
            if (!config.Owners.Contains(user.Id))
            {
                config.AddOwner(user.Id);
                await config.SaveAsync().ConfigureAwait(false);
                _ = await ctx.RespondAsync($"{user.Username} has been added to the list of bot owners!").ConfigureAwait(false);
            }
            else
            {
                _ = await ctx.RespondAsync($"{user.Username} already is a bot owner!").ConfigureAwait(false);
            }
        }

        [Command("RemoveOwner")]
        [Description("Removes the specified user from the list of bot owners")]
        [MinPermissions(AccessLevel.BotOwner)]
        public async Task RemoveOwnerAsync([Summary("The name of the user to remove")] string username)
        {
            IGuildUser user = await GetUserInGuildAsync(username).ConfigureAwait(false);
            if (user == null)
            {
                return;
            }
            DiscordClientConfiguration config = await DiscordClientConfiguration.LoadAsync().ConfigureAwait(false);
            if (config.Owners.Contains(user.Id))
            {
                config.RemoveOwner(user.Id);
                await config.SaveAsync().ConfigureAwait(false);
                _ = await ctx.RespondAsync($"{user.Username} has been removed from the list of bot owners!").ConfigureAwait(false);
            }
            else
            {
                _ = await ctx.RespondAsync($"{user.Username} is not a bot owner!").ConfigureAwait(false);
            }
        }
    }
}