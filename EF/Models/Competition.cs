﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ELO.EF.Models
{
    public class Competition
    {
        public Competition() { }
        public Competition(ulong guildId)
        {
            this.GuildId = guildId;
            this.DefaultLossModifier = 5;
        }

        public ulong GuildId { get; set; }
        public ulong AdminRole { get; set; }
        public ulong ModeratorRole { get; set; }
        public TimeSpan? RequeueDelay { get; set; } = null;
        public ulong RegisteredRankId { get; set; } = 0;
        public int ManualGameCounter { get; set; } = 0;
        public string RegisterMessageTemplate { get; set; } = "You have registered as `{name}`, all roles/name updates have been applied if applicable.";

        public string NameFormat { get; set; } = "[{score}] {name}";
        public bool UpdateNames { get; set; } = true;

        public string FormatRegisterMessage(Player player)
        {
            return RegisterMessageTemplate
                    .Replace("{score}", player.Points.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{name}", player.DisplayName, StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{wins}", player.Wins.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{losses}", player.Losses.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{draws}", player.Draws.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{games}", player.Games.ToString(), StringComparison.InvariantCultureIgnoreCase);
            //TODO: Fix length to max of 1023
        }

        public string GetNickname(Player player)
        {
            return NameFormat
                    .Replace("{score}", player.Points.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{name}", player.DisplayName, StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{wins}", player.Wins.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{losses}", player.Losses.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{draws}", player.Draws.ToString(), StringComparison.InvariantCultureIgnoreCase)
                    .Replace("{games}", player.Games.ToString(), StringComparison.InvariantCultureIgnoreCase);
            //TODO: Max length 31
        }

        public bool AllowMultiQueueing { get; set; } = true;
        public bool AllowNegativeScore { get; set; } = false;

        public bool AllowReRegister { get; set; } = true;
        public bool AllowSelfRename { get; set; } = true;

        //TODO: Consider adding a setter to ensure value is always positive.
        public int DefaultWinModifier { get; set; } = 10;

        private int _DefaultLossModifier;

        public int DefaultLossModifier
        {
            get
            {
                return _DefaultLossModifier;
            }
            set
            {
                //Ensure the value that gets set is positive as it will be subtracted from scores.
                _DefaultLossModifier = Math.Abs(value);

            }
        }

        public ulong? PremiumRedeemer { get; set; }

        public DateTime? LegacyPremiumExpiry { get; set; }
    }
}