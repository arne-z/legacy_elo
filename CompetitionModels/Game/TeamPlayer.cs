﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ELO.Models
{
    public class TeamPlayer
    {
        [ForeignKey("GuildId")]
        public Competition Comp { get; set; }
        public ulong GuildId { get; set; }
        [ForeignKey("ChannelId")]
        public Lobby Lobby { get; set; }
        public ulong ChannelId { get; set; }

        public ulong UserId { get; set; }

        public GameResult Game { get; set; }

        public int GameNumber { get; set; }
        public int TeamNumber { get; set; }
    }
}
