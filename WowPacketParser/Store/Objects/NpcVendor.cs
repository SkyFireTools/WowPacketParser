﻿using System.Collections.Generic;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    public sealed class NpcVendor : IDataModel
    {
        [DBFieldName("entry", true)]
        public uint? Entry;

        [DBFieldName("slot")]
        public int? Slot;

        [DBFieldName("item", true)]
        public int? Item;

        [DBFieldName("maxcount")]
        public uint? MaxCount;

        [DBFieldName("ExtendedCost", true)]
        public uint? ExtendedCost;

        [DBFieldName("type", true)]
        public uint? Type;

        [DBFieldName("PlayerConditionID")]
        public uint? PlayerConditionID;

        [DBFieldName("IgnoreFiltering")]
        public bool? IgnoreFiltering;

        [DBFieldName("VerifiedBuild")]
        public int? VerifiedBuild = ClientVersion.BuildInt;
    }
}
