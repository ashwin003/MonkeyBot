﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MonkeyBot.Common;
using MonkeyBot.Services.Common.Trivia;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MonkeyBot.Services
{
    /// <summary>
    /// Service that handles Trivias on a per guild and channel basis
    /// Uses Open Trivia database https://opentdb.com
    /// </summary>
    public class OTDBTriviaService : ITriviaService
    {
        private readonly DbService dbService;
        private readonly DiscordSocketClient discordClient;

        // holds all trivia instances on a per guild and channel basis
        private readonly ConcurrentDictionary<DiscordId, OTDBTriviaInstance> trivias;

        public OTDBTriviaService(DbService db, DiscordSocketClient client)
        {
            this.dbService = db;
            this.discordClient = client;
            trivias = new ConcurrentDictionary<DiscordId, OTDBTriviaInstance>();
        }

        /// <summary>
        /// Start a new trivia with the specified amount of questions in the specified Discord Channel
        /// Returns boolean success
        /// </summary>
        /// <param name="questionsToPlay">Amount of questions to play</param>
        /// <param name="context">Message context of the channel where the trivia should be hosted</param>
        /// <returns>success</returns>
        public async Task<bool> StartTriviaAsync(int questionsToPlay, SocketCommandContext context)
        {
            // Create a combination of guildID and channelID to form a unique identifier for each trivia instance
            DiscordId id = new DiscordId(context.Guild.Id, context.Channel.Id, null);
            if (!trivias.ContainsKey(id))
            {
#pragma warning disable CC0022 // Should dispose object
                trivias.TryAdd(id, new OTDBTriviaInstance(context, dbService));
#pragma warning restore CC0022 // Should dispose object
            }

            return await trivias[id].StartTriviaAsync(questionsToPlay).ConfigureAwait(false);
        }

        /// <summary>
        /// Skips the trivia in the specified guild's channel if a trivia is running, otherwise returns false
        /// </summary>
        /// <param name="id">Combined Id of the Discord Guild and channel for the trivia</param>
        /// <returns>success</returns>
        public async Task<bool> SkipQuestionAsync(DiscordId id)
        {
            return trivias.ContainsKey(id) ? await trivias[id].SkipQuestionAsync() : false;
        }

        /// <summary>
        /// Stops the trivia in the specified guild's channel if a trivia is running, otherwise returns false
        /// </summary>
        /// <param name="id">Combined Id of the Discord Guild and channel for the trivia</param>
        /// <returns>success</returns>
        public async Task<bool> StopTriviaAsync(DiscordId id)
        {
            if (!trivias.ContainsKey(id))
                return false;
            else
            {
                var result = await trivias[id].StopTriviaAsync();
                if (trivias.TryRemove(id, out var instance))
                {
                    instance.Dispose();
                }

                return result;
            }
        }

        /// <summary>
        /// Get a discord embed for showing the current global high scores for the guild
        /// </summary>
        /// <param name="context">Context of the channel where the high score was requested</param>
        /// <returns></returns>
        public async Task<Embed> GetGlobalHighScoresEmbedAsync(int amount, SocketCommandContext context)
        {
            var id = new DiscordId(context.Guild.Id, context.Channel.Id, null);
            if (id.GuildId == null || !trivias.ContainsKey(id))
            {
                using (var trivia = new OTDBTriviaInstance(context, dbService))
                {
                    return await trivia.GetGlobalHighScoresEmbedAsync(amount, id.GuildId.Value);
                }
            }
            else
                return await trivias[id].GetGlobalHighScoresEmbedAsync(amount, id.GuildId.Value);
        }
    }
}