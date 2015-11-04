﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;

namespace WowPacketParser.SQL.Builders
{
    [BuilderClass]
    public static class UnitMisc
    {
        [BuilderMethod(Units = true)]
        public static string Addon(Dictionary<WowGuid, Unit> units)
        {
            /*if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_template_addon))
                return string.Empty;

            const string tableName = "creature_template_addon";

            var rows = new List<SQLInsertRow>();
            foreach (var unit in units)
            {
                var npc = unit.Value;

                if (Settings.AreaFilters.Length > 0)
                    if (!(npc.Area.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.AreaFilters)))
                        continue;

                if (Settings.MapFilters.Length > 0)
                    if (!(npc.Map.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.MapFilters)))
                        continue;

                var row = new SQLInsertRow();
                row.AddValue("entry", unit.Key.GetEntry());
                row.AddValue("mount", npc.Mount);
                row.AddValue("bytes1", npc.Bytes1, true);
                row.AddValue("bytes2", npc.Bytes2, true);

                var auras = string.Empty;
                var commentAuras = string.Empty;
                if (npc.Auras != null && npc.Auras.Count() != 0)
                {
                    foreach (var aura in npc.Auras)
                    {
                        if (aura == null)
                            continue;

                        // usually "template auras" do not have caster
                        if (ClientVersion.AddedInVersion(ClientType.MistsOfPandaria) ? !aura.AuraFlags.HasAnyFlag(AuraFlagMoP.NoCaster) : !aura.AuraFlags.HasAnyFlag(AuraFlag.NotCaster))
                            continue;

                        auras += aura.SpellId + " ";
                        commentAuras += StoreGetters.GetName(StoreNameType.Spell, (int) aura.SpellId, false) + ", ";
                    }
                    auras = auras.TrimEnd(' ');
                    commentAuras = commentAuras.TrimEnd(',', ' ');
                }
                row.AddValue("auras", auras);

                row.Comment += StoreGetters.GetName(StoreNameType.Unit, (int)unit.Key.GetEntry(), false);
                if (!String.IsNullOrWhiteSpace(auras))
                    row.Comment += " - " + commentAuras;

                rows.Add(row);
            }

            return new SQLInsert(tableName, rows).Build();*/
            return string.Empty;
        }

        [BuilderMethod(Units = true)]
        public static string ModelData(Dictionary<WowGuid, Unit> units)
        {
            if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_model_info))
                return string.Empty;

            var models = new DataBag<ModelData>();
            foreach (Unit npc in units.Select(unit => unit.Value))
            {
                if (Settings.AreaFilters.Length > 0)
                    if (!(npc.Area.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.AreaFilters)))
                        continue;

                if (Settings.MapFilters.Length > 0)
                    if (!(npc.Map.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.MapFilters)))
                        continue;

                uint modelId;
                if (npc.Model.HasValue)
                    modelId = npc.Model.Value;
                else
                    continue;

                ModelData model = new ModelData
                {
                    DisplayID = modelId
                };

                if (models.ContainsKey(model))
                    continue;

                float scale = npc.Size.GetValueOrDefault(1.0f);
                model.BoundingRadius = npc.BoundingRadius.GetValueOrDefault(0.306f) / scale;
                model.CombatReach = npc.CombatReach.GetValueOrDefault(1.5f) / scale;
                model.Gender = npc.Gender.GetValueOrDefault(Gender.Male);

                models.Add(model, null);
            }

            var modelsDb = SQLDatabase.Get(models);
            return SQLUtil.Compare(models, modelsDb, StoreNameType.None);
        }

        [BuilderMethod]
        public static string NpcTrainer()
        {
            if (Storage.NpcTrainers.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.npc_trainer))
                return string.Empty;

            var templatesDb = SQLDatabase.Get(Storage.NpcTrainers);

            return SQLUtil.Compare(Storage.NpcTrainers, templatesDb, StoreNameType.Unit);
        }

        [BuilderMethod]
        public static string NpcVendor()
        {
            if (Storage.NpcVendors.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.npc_vendor))
                return string.Empty;

            var templatesDb = SQLDatabase.Get(Storage.NpcVendors);

            return SQLUtil.Compare(Storage.NpcVendors, templatesDb,
                vendor => StoreGetters.GetName(vendor.Type <= 1 ? StoreNameType.Item : StoreNameType.Currency, vendor.Item.GetValueOrDefault(), false));
        }

        [BuilderMethod(Units = true)]
        public static string CreatureEquip(Dictionary<WowGuid, Unit> units)
        {
            if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_equip_template))
                return string.Empty;

            var equips = new DataBag<CreatureEquipment>();
            foreach (KeyValuePair<WowGuid, Unit> npc in units)
            {
                if (Settings.AreaFilters.Length > 0)
                    if (!(npc.Value.Area.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.AreaFilters)))
                        continue;

                if (Settings.MapFilters.Length > 0)
                    if (!(npc.Value.Map.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.MapFilters)))
                        continue;

                if (npc.Value.Equipment == null || npc.Value.Equipment.Length != 3)
                    continue;

                if (npc.Value.Equipment[0] == 0 && npc.Value.Equipment[1] == 0 && npc.Value.Equipment[2] == 0)
                    continue;

                CreatureEquipment equip = new CreatureEquipment
                {
                    CreatureID = npc.Key.GetEntry(),
                    ItemID1 = npc.Value.Equipment[0],
                    ItemID2 = npc.Value.Equipment[1],
                    ItemID3 = npc.Value.Equipment[2]
                };

                if (equips.Contains(equip))
                    continue;

                for (uint i = 1;; i++)
                {
                    equip.ID = i;
                    if (!equips.ContainsKey(equip))
                        break;
                }

                equips.Add(equip, null);
            }

            var equipsDb = SQLDatabase.Get(equips);
            return SQLUtil.Compare(equips, equipsDb, StoreNameType.Unit);
        }

        [BuilderMethod]
        public static string Loot()
        {
            /*if (Storage.Loots.IsEmpty())
                return String.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.LootTemplate))
                return string.Empty;

            // Not TDB structure
            const string tableName = "LootTemplate";

            var rows = new List<SQLInsertRow>();
            foreach (var loot in Storage.Loots)
            {
                var comment = new SQLInsertRow
                {
                    HeaderComment =
                        StoreGetters.GetName(Utilities.ObjectTypeToStore(Storage.Loots.Keys().First().Item2),
                            (int) loot.Key.Item1, false) +
                        " (" + loot.Value.Item1.Gold + " gold)"
                };
                rows.Add(comment);
                foreach (var lootItem in loot.Value.Item1.LootItems)
                {
                    var row = new SQLInsertRow();
                    row.AddValue("Id", loot.Key.Item1);
                    row.AddValue("Type", loot.Key.Item2);
                    row.AddValue("ItemId", lootItem.ItemId);
                    row.AddValue("Count", lootItem.Count);
                    row.Comment = StoreGetters.GetName(StoreNameType.Item, (int)lootItem.ItemId, false);

                    rows.Add(row);
                }
            }

            return new SQLInsert(tableName, rows, 2).Build();*/
            return string.Empty;
        }

        [BuilderMethod]
        public static string Gossip()
        {
            // TODO: This should be rewritten

            /*if (Storage.Gossips.IsEmpty())
                return string.Empty;

            var result = "";

            // `gossip`
            if (Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.gossip_menu))
            {
                if (SQLConnector.Enabled)
                {
                    var query =
                        new StringBuilder(string.Format("SELECT `entry`,`text_id` FROM {0}.`gossip_menu` WHERE ",
                                                        Settings.TDBDatabase));
                    foreach (Tuple<uint, uint> gossip in Storage.Gossips.Keys())
                    {
                        query.Append("(`entry`=").Append(gossip.Item1).Append(" AND ");
                        query.Append("`text_id`=").Append(gossip.Item2).Append(") OR ");
                    }
                    query.Remove(query.Length - 4, 4).Append(";");

                    var rows = new List<SQLInsertRow>();
                    using (var reader = SQLConnector.ExecuteQuery(query.ToString()))
                    {
                        if (reader != null)
                            while (reader.Read())
                            {
                                var values = new object[2];
                                var count = reader.GetValues(values);
                                if (count != 2)
                                    break; // error in query

                                var entry = Convert.ToUInt32(values[0]);
                                var textId = Convert.ToUInt32(values[1]);

                                // our table is small, 2 fields and both are PKs; no need for updates
                                if (!Storage.Gossips.ContainsKey(Tuple.Create(entry, textId)))
                                {
                                    var row = new SQLInsertRow();
                                    row.AddValue("entry", entry);
                                    row.AddValue("text_id", textId);
                                    row.Comment = StoreGetters.GetName(StoreNameType.Unit,
                                                                       // BUG: GOs can send gossips too
                                                                       (int) entry, false);
                                    rows.Add(row);
                                }
                            }
                    }
                    //result += new SQLInsert("gossip_menu", rows, 2).Build();
                }
                else
                {
                    var rows = new List<SQLInsertRow>();
                    foreach (var gossip in Storage.Gossips)
                    {
                        var row = new SQLInsertRow();

                        row.AddValue("entry", gossip.Key.Item1);
                        row.AddValue("text_id", gossip.Key.Item2);
                        row.Comment = StoreGetters.GetName(Utilities.ObjectTypeToStore(gossip.Value.Item1.ObjectType),
                                                           (int) gossip.Value.Item1.ObjectEntry, false);

                        rows.Add(row);
                    }

                    //result += new SQLInsert("gossip_menu", rows, 2).Build();
                }
            }

            // `gossip_menu_option`
            /*
            if (Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.gossip_menu_option))
            {
                if (SQLConnector.Enabled)
                {
                    var rowsIns = new List<SQLInsertRow>();
                    var rowsUpd = new List<SQLUpdateRow>();

                    foreach (var gossip in Storage.Gossips)
                    {
                        if (gossip.Value.Item1.GossipOptions == null)
                            continue;

                        foreach (var gossipOption in gossip.Value.Item1.GossipOptions)
                        {
                            var query = //         0     1       2         3         4        5         6
                                string.Format(
                                    "SELECT menu_id,id,option_icon,box_coded,box_money,box_text,option_text " +
                                    "FROM {2}.gossip_menu_option WHERE menu_id={0} AND id={1};", gossip.Key.Item1,
                                    gossipOption.Index, Settings.TDBDatabase);

                            using (var reader = SQLConnector.ExecuteQuery(query))
                            {
                                if (reader.HasRows) // possible update
                                {
                                    while (reader.Read())
                                    {
                                        var row = new SQLUpdateRow();

                                        if (!Utilities.EqualValues(reader.GetValue(2), gossipOption.OptionIcon))
                                            row.AddValue("option_icon", gossipOption.OptionIcon);

                                        if (!Utilities.EqualValues(reader.GetValue(3), gossipOption.Box))
                                            row.AddValue("box_coded", gossipOption.Box);

                                        if (!Utilities.EqualValues(reader.GetValue(4), gossipOption.RequiredMoney))
                                            row.AddValue("box_money", gossipOption.RequiredMoney);

                                        if (!Utilities.EqualValues(reader.GetValue(5), gossipOption.BoxText))
                                            row.AddValue("box_text", gossipOption.BoxText);

                                        if (!Utilities.EqualValues(reader.GetValue(6), gossipOption.OptionText))
                                            row.AddValue("option_text", gossipOption.OptionText);

                                        row.AddWhere("menu_id", gossip.Key.Item1);
                                        row.AddWhere("id", gossipOption.Index);

                                        row.Comment =
                                            StoreGetters.GetName(
                                                Utilities.ObjectTypeToStore(gossip.Value.Item1.ObjectType),
                                                (int) gossip.Value.Item1.ObjectEntry, false);

                                        row.Table = "gossip_menu_option";

                                        if (row.ValueCount != 0)
                                            rowsUpd.Add(row);
                                    }
                                }
                                else // insert
                                {
                                    var row = new SQLInsertRow();

                                    row.AddValue("menu_id", gossip.Key.Item1);
                                    row.AddValue("id", gossipOption.Index);
                                    row.AddValue("option_icon", gossipOption.OptionIcon);
                                    row.AddValue("option_text", gossipOption.OptionText);
                                    row.AddValue("box_coded", gossipOption.Box);
                                    row.AddValue("box_money", gossipOption.RequiredMoney);
                                    row.AddValue("box_text", gossipOption.BoxText);

                                    row.Comment =
                                        StoreGetters.GetName(Utilities.ObjectTypeToStore(gossip.Value.Item1.ObjectType),
                                                             (int) gossip.Value.Item1.ObjectEntry, false);

                                    rowsIns.Add(row);
                                }
                            }
                        }
                    }
                    result += new SQLInsert("gossip_menu_option", rowsIns, 2).Build() +
                              new SQLUpdate(rowsUpd).Build();
                              
                }
                else
                {
                    var rows = new List<SQLInsertRow>();
                    foreach (var gossip in Storage.Gossips)
                    {
                        if (gossip.Value.Item1.GossipOptions != null)
                            foreach (var gossipOption in gossip.Value.Item1.GossipOptions)
                            {
                                var row = new SQLInsertRow();

                                row.AddValue("menu_id", gossip.Key.Item1);
                                row.AddValue("id", gossipOption.Index);
                                row.AddValue("option_icon", gossipOption.OptionIcon);
                                row.AddValue("option_text", gossipOption.OptionText);
                                row.AddValue("box_coded", gossipOption.Box);
                                row.AddValue("box_money", gossipOption.RequiredMoney);
                                row.AddValue("box_text", gossipOption.BoxText);

                                row.Comment =
                                    StoreGetters.GetName(Utilities.ObjectTypeToStore(gossip.Value.Item1.ObjectType),
                                                         (int) gossip.Value.Item1.ObjectEntry, false);

                                rows.Add(row);
                            }
                    }

                    result += new SQLInsert("gossip_menu_option", rows, 2).Build();
                }
            }
            
            return result;*/
            return string.Empty;
        }

        [BuilderMethod]
        public static string PointsOfInterest()
        {
            /*if (Storage.GossipPOIs.IsEmpty())
                return string.Empty;

            var result = string.Empty;

            if (!Storage.GossipSelects.IsEmpty() && Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.gossip_menu_option))
            {
                var gossipPOIsTable = new Dictionary<Tuple<uint, uint>, uint>();

                foreach (var poi in Storage.GossipPOIs)
                {
                    foreach (var gossipSelect in Storage.GossipSelects)
                    {
                        var tuple = Tuple.Create(gossipSelect.Key.Item1, gossipSelect.Key.Item2);

                        if (gossipPOIsTable.ContainsKey(tuple))
                            continue;

                        var timeSpan = poi.Value.Item2 - gossipSelect.Value.Item2;
                        if (timeSpan != null && timeSpan.Value.Duration() <= TimeSpan.FromSeconds(1))
                            gossipPOIsTable.Add(tuple, poi.Key);
                    }
                }

                var rowsUpd = new List<SQLUpdateRow>();

                foreach (var u in gossipPOIsTable)
                {
                    var row = new SQLUpdateRow();

                    row.AddValue("action_poi_id", u.Value);

                    row.AddWhere("menu_id", u.Key.Item1);
                    row.AddWhere("id", u.Key.Item2);

                    row.Table = "gossip_menu_option";

                    rowsUpd.Add(row);
                }

                result += new SQLUpdate(rowsUpd).Build();
            }

            if (Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.points_of_interest))
            {
                const string tableName = "points_of_interest";
                var rowsIns = new List<SQLInsertRow>();

                uint count = 0;

                foreach (var poi in Storage.GossipPOIs)
                {
                    var row = new SQLInsertRow();

                    row.AddValue("ID", "@ID+" + count, noQuotes: true);
                    row.AddValue("PositionX", poi.Value.Item1.PositionX);
                    row.AddValue("PositionY", poi.Value.Item1.PositionY);
                    row.AddValue("Icon", poi.Value.Item1.Icon);
                    row.AddValue("Flags", poi.Value.Item1.Flags);
                    row.AddValue("Importance", poi.Value.Item1.Importance);
                    row.AddValue("Name", poi.Value.Item1.Name);

                    rowsIns.Add(row);
                    count++;
                }

                result += new SQLDelete(Tuple.Create("@ID+0", "@ID+" + (count - 1)), "entry", tableName).Build();
                result += new SQLInsert(tableName, rowsIns, withDelete: false).Build();
            }

            return result;*/
            return string.Empty;
        }

        //                      entry, <minlevel, maxlevel>
        private static Dictionary<uint, Tuple<uint, uint>> GetLevels(Dictionary<WowGuid, Unit> units)
        {
            if (units.Count == 0)
                return null;

            var entries = units.GroupBy(unit => unit.Key.GetEntry());
            var list = new Dictionary<uint, List<uint>>();

            foreach (var pair in entries.SelectMany(entry => entry))
            {
                if (list.ContainsKey(pair.Key.GetEntry()))
                    list[pair.Key.GetEntry()].Add(pair.Value.Level.GetValueOrDefault(1));
                else
                    list.Add(pair.Key.GetEntry(), new List<uint> { pair.Value.Level.GetValueOrDefault(1) });
            }

            var result = list.ToDictionary(pair => pair.Key, pair => Tuple.Create(pair.Value.Min(), pair.Value.Max()));

            return result.Count == 0 ? null : result;
        }

        private static readonly HashSet<string> _professionTrainers = new HashSet<string>
        {
            "Alchemy Trainer", "Armorsmith Trainer", "Armorsmithing Trainer", "Blacksmith Trainer",
            "Blacksmithing Trainer", "Blacksmithing Trainer & Supplies", "Cold Weather Flying Trainer",
            "Cooking Trainer", "Cooking Trainer & Supplies", "Dragonscale Leatherworking Trainer",
            "Elemental Leatherworking Trainer", "Enchanting Trainer", "Engineering Trainer",
            "First Aid Trainer", "Fishing Trainer", "Fishing Trainer & Supplies",
            "Gnome Engineering Trainer", "Gnomish Engineering Trainer", "Goblin Engineering Trainer",
            "Grand Master Alchemy Trainer", "Grand Master Blacksmithing Trainer",
            "Grand Master Cooking Trainer", "Grand Master Enchanting Trainer",
            "Grand Master Engineering Trainer", "Grand Master First Aid Trainer",
            "Grand Master Fishing Trainer", "Grand Master Fishing Trainer & Supplies",
            "Grand Master Herbalism Trainer", "Grand Master Inscription Trainer",
            "Grand Master Jewelcrafting Trainer", "Grand Master Leatherworking Trainer",
            "Grand Master Mining Trainer", "Grand Master Skinning Trainer",
            "Grand Master Tailoring Trainer", "Herbalism Trainer",
            "Herbalism Trainer & Supplies", "Inscription Trainer",
            "Jewelcrafting Trainer", "Leatherworking Trainer",
            "Master Alchemy Trainer", "Master Blacksmithing Trainer",
            "Master Enchanting Trainer", "Master Engineering Trainer",
            "Master Fishing Trainer", "Master Herbalism Trainer",
            "Master Inscription Trainer", "Master Jewelcrafting Trainer",
            "Master Leatherworking Trainer", "Master Mining Trainer",
            "Master Skinning Trainer", "Master Tailoring Trainer",
            "Mining Trainer", "Skinning Trainer", "Tailor Trainer", "Tailoring Trainer",
            "Tribal Leatherworking Trainer", "Weaponsmith Trainer", "Weaponsmithing Trainer",
            "Horse Riding Trainer", "Ram Riding Trainer", "Raptor Riding Trainer",
            "Tiger Riding Trainer", "Wolf Riding Trainer", "Mechastrider Riding Trainer",
            "Riding Trainer", "Undead Horse Riding Trainer"
        };

        private static readonly HashSet<string> _classTrainers = new HashSet<string>
        {
            "Druid Trainer", "Portal Trainer", "Portal: Darnassus Trainer",
            "Portal: Ironforge Trainer", "Portal: Orgrimmar Trainer",
            "Portal: Stormwind Trainer", "Portal: Thunder Bluff Trainer",
            "Portal: Undercity Trainer", "Deathknight Trainer",
            "Hunter Trainer", "Mage Trainer", "Paladin Trainer",
            "Priest Trainer", "Shaman Trainer", "Warlock Trainer",
            "Warrior Trainer"
        };

        private static string GetSubName(int Entry, bool withEntry)
        {
            var name = StoreGetters.GetName(StoreNameType.Unit, Entry, withEntry);
            var firstIndex = name.LastIndexOf('<');
            var lastIndex = name.LastIndexOf('>');
            if (firstIndex != -1 && lastIndex != -1)
                return name.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

            return "";
        }

        private static uint ProcessNpcFlags(string subName)
        {
            if (_professionTrainers.Contains(subName))
                return (uint)NPCFlags.ProfessionTrainer;
            if (_classTrainers.Contains(subName))
                return (uint)NPCFlags.ClassTrainer;

            return 0;
        }

        // Non-WDB data but nevertheless data that should be saved to creature_template
        [BuilderMethod(Units = true)]
        public static string NpcTemplateNonWDB(Dictionary<WowGuid, Unit> units)
        {
            if (ClientVersion.AddedInVersion(ClientType.WarlordsOfDraenor))
                return string.Empty;

            if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_template))
                return string.Empty;

            var levels = GetLevels(units);

            var templates = new StoreDictionary<uint, UnitTemplateNonWDB>();
            foreach (var unit in units)
            {
                if (templates.ContainsKey(unit.Key.GetEntry()))
                    continue;

                var npc = unit.Value;
                var template = new UnitTemplateNonWDB
                {
                    GossipMenuId = npc.GossipId,
                    MinLevel = (int) levels[unit.Key.GetEntry()].Item1,
                    MaxLevel = (int) levels[unit.Key.GetEntry()].Item2,
                    Faction = npc.Faction.GetValueOrDefault(35),
                    NpcFlag = (uint) npc.NpcFlags.GetValueOrDefault(NPCFlags.None),
                    SpeedRun = npc.Movement.RunSpeed,
                    SpeedWalk = npc.Movement.WalkSpeed,
                    BaseAttackTime = npc.MeleeTime.GetValueOrDefault(2000),
                    RangedAttackTime = npc.RangedTime.GetValueOrDefault(2000),
                    UnitClass = (uint) npc.Class.GetValueOrDefault(Class.Warrior),
                    UnitFlag = (uint) npc.UnitFlags.GetValueOrDefault(UnitFlags.None),
                    UnitFlag2 = (uint) npc.UnitFlags2.GetValueOrDefault(UnitFlags2.None),
                    DynamicFlag = (uint) npc.DynamicFlags.GetValueOrDefault(UnitDynamicFlags.None),
                    VehicleId = npc.Movement.VehicleId,
                    HoverHeight = npc.HoverHeight.GetValueOrDefault(1.0f)
                };

                if (template.Faction == 1 || template.Faction == 2 || template.Faction == 3 ||
                        template.Faction == 4 || template.Faction == 5 || template.Faction == 6 ||
                        template.Faction == 115 || template.Faction == 116 || template.Faction == 1610 ||
                        template.Faction == 1629 || template.Faction == 2203 || template.Faction == 2204) // player factions
                    template.Faction = 35;

                template.UnitFlag &= ~(uint)UnitFlags.IsInCombat;
                template.UnitFlag &= ~(uint)UnitFlags.PetIsAttackingTarget;
                template.UnitFlag &= ~(uint)UnitFlags.PlayerControlled;
                template.UnitFlag &= ~(uint)UnitFlags.Silenced;
                template.UnitFlag &= ~(uint)UnitFlags.PossessedByPlayer;

                if (!ClientVersion.AddedInVersion(ClientType.WarlordsOfDraenor))
                {
                    template.DynamicFlag &= ~(uint)UnitDynamicFlags.Lootable;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlags.Tapped;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlags.TappedByPlayer;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlags.TappedByAllThreatList;
                }
                else
                {
                    template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.Lootable;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.Tapped;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.TappedByPlayer;
                    template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.TappedByAllThreatList;
                }

                // has trainer flag but doesn't have prof nor class trainer flag
                if ((template.NpcFlag & (uint) NPCFlags.Trainer) != 0 &&
                    ((template.NpcFlag & (uint) NPCFlags.ProfessionTrainer) == 0 ||
                     (template.NpcFlag & (uint) NPCFlags.ClassTrainer) == 0))
                {
                    UnitTemplate unitData;
                    var subname = GetSubName((int)unit.Key.GetEntry(), false); // Fall back
                    if (Storage.UnitTemplates.TryGetValue(unit.Key.GetEntry(), out unitData))
                    {
                        if (unitData.SubName.Length > 0)
                            template.NpcFlag |= ProcessNpcFlags(unitData.SubName);
                        else // If the SubName doesn't exist or is cached, fall back to DB method
                            template.NpcFlag |= ProcessNpcFlags(subname);
                    }
                    else // In case we have NonWDB data which doesn't have an entry in UnitTemplates
                        template.NpcFlag |= ProcessNpcFlags(subname);
                }

                templates.Add(unit.Key.GetEntry(), template);
            }

            var templatesDb = SQLDatabase.GetDict<uint, UnitTemplateNonWDB>(templates.Keys());
            return SQLUtil.CompareDicts(templates, templatesDb, StoreNameType.Unit);
        }

        // Non-WDB data but nevertheless data that should be saved to creature_template
        [BuilderMethod(Units = true)]
        public static string CreatureDifficultyMisc(Dictionary<WowGuid, Unit> units)
        {
            if (!ClientVersion.AddedInVersion(ClientType.WarlordsOfDraenor))
                return string.Empty;

            if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_template))
                return string.Empty;

            var templates = new StoreDictionary<uint, CreatureDifficultyMisc>();
            foreach (var unit in units)
            {
                if (SQLDatabase.CreatureDifficultyStores != null)
                {
                    foreach (var creatureDiff in SQLDatabase.CreatureDifficultyStores)
                    {
                        if (!Utilities.EqualValues(unit.Key.GetEntry(), creatureDiff.Value.CreatureID))
                            continue;

                        if (templates.ContainsKey(creatureDiff.Key))
                            continue;

                        var npc = unit.Value;
                        var template = new CreatureDifficultyMisc
                        {
                            CreatureId = unit.Key.GetEntry(),
                            GossipMenuId = npc.GossipId,
                            NpcFlag = (uint)npc.NpcFlags.GetValueOrDefault(NPCFlags.None),
                            SpeedRun = npc.Movement.RunSpeed,
                            SpeedWalk = npc.Movement.WalkSpeed,
                            BaseAttackTime = npc.MeleeTime.GetValueOrDefault(2000),
                            RangedAttackTime = npc.RangedTime.GetValueOrDefault(2000),
                            UnitClass = (uint)npc.Class.GetValueOrDefault(Class.Warrior),
                            UnitFlag = (uint)npc.UnitFlags.GetValueOrDefault(UnitFlags.None),
                            UnitFlag2 = (uint)npc.UnitFlags2.GetValueOrDefault(UnitFlags2.None),
                            DynamicFlag = (uint)npc.DynamicFlags.GetValueOrDefault(UnitDynamicFlags.None),
                            VehicleId = npc.Movement.VehicleId,
                            HoverHeight = npc.HoverHeight.GetValueOrDefault(1.0f)
                        };

                        template.UnitFlag &= ~(uint)UnitFlags.IsInCombat;
                        template.UnitFlag &= ~(uint)UnitFlags.PetIsAttackingTarget;
                        template.UnitFlag &= ~(uint)UnitFlags.PlayerControlled;
                        template.UnitFlag &= ~(uint)UnitFlags.Silenced;
                        template.UnitFlag &= ~(uint)UnitFlags.PossessedByPlayer;

                        if (!ClientVersion.AddedInVersion(ClientType.WarlordsOfDraenor))
                        {
                            template.DynamicFlag &= ~(uint)UnitDynamicFlags.Lootable;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlags.Tapped;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlags.TappedByPlayer;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlags.TappedByAllThreatList;
                        }
                        else
                        {
                            template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.Lootable;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.Tapped;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.TappedByPlayer;
                            template.DynamicFlag &= ~(uint)UnitDynamicFlagsWOD.TappedByAllThreatList;
                        }

                        // has trainer flag but doesn't have prof nor class trainer flag
                        if ((template.NpcFlag & (uint)NPCFlags.Trainer) != 0 &&
                            ((template.NpcFlag & (uint)NPCFlags.ProfessionTrainer) == 0 ||
                             (template.NpcFlag & (uint)NPCFlags.ClassTrainer) == 0))
                        {
                            var name = StoreGetters.GetName(StoreNameType.Unit, (int)unit.Key.GetEntry(), false);
                            var firstIndex = name.LastIndexOf('<');
                            var lastIndex = name.LastIndexOf('>');
                            if (firstIndex != -1 && lastIndex != -1)
                            {
                                var subname = name.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

                                if (_professionTrainers.Contains(subname))
                                    template.NpcFlag |= (uint)NPCFlags.ProfessionTrainer;
                                else if (_classTrainers.Contains(subname))
                                    template.NpcFlag |= (uint)NPCFlags.ClassTrainer;
                            }
                        }

                        templates.Add(creatureDiff.Key, template);
                    }
                }
            }

            var templatesDb = SQLDatabase.GetDict<uint, CreatureDifficultyMisc>(templates.Keys(), "Id");
            return SQLUtil.CompareDicts(templates, templatesDb, StoreNameType.Unit, "Id");
        }

        [BuilderMethod]
        public static string SpellsX()
        {
            if (Storage.SpellsX.IsEmpty())
                return String.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_template))
                return string.Empty;

            var entries = Storage.SpellsX.Keys();
            var spellsXDb = SQLDatabase.GetDict<uint, SpellsX>(entries);

            return SQLUtil.CompareDicts(Storage.SpellsX, spellsXDb, StoreNameType.Unit);
        }

        [BuilderMethod]
        public static string CreatureText()
        {
            /*if (Storage.CreatureTexts.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_text))
                return string.Empty;

            // For each sound and emote, if the time they were send is in the +1/-1 seconds range of
            // our texts, add that sound and emote to our Storage.CreatureTexts

            var broadcastTextStoresMale = SQLDatabase.BroadcastTextStores.GroupBy(blub => blub.Item2.MaleText).ToDictionary(group => group.Key, group => group.ToList());
            var broadcastTextStoresFemale = SQLDatabase.BroadcastTextStores.GroupBy(blub => blub.Item2.FemaleText).ToDictionary(group => group.Key, group => group.ToList());

            foreach (var text in Storage.CreatureTexts)
            {
                // For each text
                foreach (var textValue in text.Value)
                {
                    // For each emote
                    var text1 = text;
                    var value1 = textValue;
                    foreach (var emoteValue in from emote in Storage.Emotes where emote.Key.GetEntry() == text1.Key from emoteValue in emote.Value let timeSpan = value1.Item2 - emoteValue.Item2 where timeSpan != null && timeSpan.Value.Duration() <= TimeSpan.FromSeconds(1) select emoteValue)
                        textValue.Item1.Emote = emoteValue.Item1;

                    // For each sound
                    var value = textValue;
                    foreach (var sound in from sound in Storage.Sounds let timeSpan = value.Item2 - sound.Item2 where timeSpan != null && timeSpan.Value.Duration() <= TimeSpan.FromSeconds(1) select sound)
                        textValue.Item1.Sound = sound.Item1;

                    if (SQLDatabase.BroadcastTextStores != null)
                    {
                        List<Tuple<uint, BroadcastText>> textList;
                        if (broadcastTextStoresMale.TryGetValue(textValue.Item1.Text, out textList) ||
                            broadcastTextStoresFemale.TryGetValue(textValue.Item1.Text, out textList))
                            foreach (var broadcastTextId in textList)
                            {
                                if (!String.IsNullOrWhiteSpace(textValue.Item1.BroadcastTextID))
                                    textValue.Item1.BroadcastTextID += " - " + broadcastTextId.Item1;
                                else
                                    textValue.Item1.BroadcastTextID = broadcastTextId.Item1.ToString();
                            }
                    }

                    // Set comment
                    string from = null, to = null;
                    if (!textValue.Item1.SenderGUID.IsEmpty() || textValue.Item1.SenderGUID != null)
                    {
                        if (textValue.Item1.SenderGUID.GetObjectType() == ObjectType.Player)
                            from = "Player";
                        else
                            @from = !string.IsNullOrEmpty(textValue.Item1.SenderName) ? textValue.Item1.SenderName : StoreGetters.GetName(StoreNameType.Unit, (int)textValue.Item1.SenderGUID.GetEntry(), false);
                    }

                    if (!textValue.Item1.ReceiverGUID.IsEmpty() || textValue.Item1.ReceiverGUID != null)
                    {
                        if (textValue.Item1.ReceiverGUID.GetObjectType() == ObjectType.Player)
                            to = "Player";
                        else
                            to = !string.IsNullOrEmpty(textValue.Item1.ReceiverName) ? textValue.Item1.ReceiverName : StoreGetters.GetName(StoreNameType.Unit, (int)textValue.Item1.ReceiverGUID.GetEntry(), false);
                    }

                    Trace.Assert(text.Key == textValue.Item1.SenderGUID.GetEntry() ||
                        text.Key == textValue.Item1.ReceiverGUID.GetEntry());

                    if (from != null && to != null)
                        textValue.Item1.Comment = from + " to " + to;
                    else if (from != null)
                        textValue.Item1.Comment = from;
                    else
                        Trace.Assert(false);
                }
            }

            /* can't use compare DB without knowing values of groupid or id
            var entries = Storage.CreatureTexts.Keys.ToList();
            var creatureTextDb = SQLDatabase.GetDict<uint, CreatureText>(entries);
            */

            /*const string tableName = "creature_text";

            var rows = new List<SQLInsertRow>();
            foreach (var text in Storage.CreatureTexts)
            {
                foreach (var textValue in text.Value)
                {
                    var row = new SQLInsertRow();

                    row.AddValue("entry", text.Key);
                    row.AddValue("groupid", "x", false, true);
                    row.AddValue("id", "x", false, true);
                    row.AddValue("text", textValue.Item1.Text);
                    row.AddValue("type", textValue.Item1.Type);
                    row.AddValue("language", textValue.Item1.Language);
                    row.AddValue("probability", 100.0);
                    row.AddValue("emote", textValue.Item1.Emote);
                    row.AddValue("duration", 0);
                    row.AddValue("sound", textValue.Item1.Sound);
                    row.AddValue("BroadcastTextID", textValue.Item1.BroadcastTextID);
                    row.AddValue("comment", textValue.Item1.Comment);

                    rows.Add(row);
                }
            }

            return new SQLInsert(tableName, rows, 1, false).Build();*/
            return string.Empty;
        }

        [BuilderMethod]
        public static string VehicleAccessory()
        {
            if (Storage.VehicleTemplateAccessorys.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.vehicle_template_accessory))
                return string.Empty;

            var rows = new RowList<VehicleTemplateAccessory>();
            foreach (var accessory in Storage.VehicleTemplateAccessorys)
            {
                var row = new Row<VehicleTemplateAccessory>();

                if (accessory.Item1.SeatId < 0 || accessory.Item1.SeatId > 7)
                    continue;

                row.Comment = StoreGetters.GetName(StoreNameType.Unit, (int)accessory.Item1.Entry, false) + " - ";
                row.Comment += StoreGetters.GetName(StoreNameType.Unit, (int)accessory.Item1.AccessoryEntry, false);
                accessory.Item1.Description = row.Comment;
                row.Data = accessory.Item1;

                rows.Add(row);
            }

            return new SQLInsert<VehicleTemplateAccessory>(rows, false).Build();
        }

        [BuilderMethod]
        public static string NpcSpellClick()
        {
            if (Storage.NpcSpellClicks.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.npc_spellclick_spells))
                return string.Empty;

            var rows = new RowList<NpcSpellClick>();

            foreach (var npcSpellClick in Storage.NpcSpellClicks)
            {
                foreach (var spellClick in Storage.SpellClicks)
                {
                    var row = new Row<NpcSpellClick>();

                    if (spellClick.Item1.CasterGUID.GetObjectType() == ObjectType.Unit && spellClick.Item1.TargetGUID.GetObjectType() == ObjectType.Unit)
                        spellClick.Item1.CastFlags = 0x0;
                    if (spellClick.Item1.CasterGUID.GetObjectType() == ObjectType.Player && spellClick.Item1.TargetGUID.GetObjectType() == ObjectType.Unit)
                        spellClick.Item1.CastFlags = 0x1;
                    if (spellClick.Item1.CasterGUID.GetObjectType() == ObjectType.Unit && spellClick.Item1.TargetGUID.GetObjectType() == ObjectType.Player)
                        spellClick.Item1.CastFlags = 0x2;
                    if (spellClick.Item1.CasterGUID.GetObjectType() == ObjectType.Player && spellClick.Item1.TargetGUID.GetObjectType() == ObjectType.Player)
                        spellClick.Item1.CastFlags = 0x3;

                    spellClick.Item1.Entry = npcSpellClick.Item1.GetEntry();
                    row.Data = spellClick.Item1;

                    var timeSpan = spellClick.Item2 - npcSpellClick.Item2;
                    if (timeSpan != null && timeSpan.Value.Duration() <= TimeSpan.FromSeconds(1))
                        rows.Add(row);
                }
            }

            return new SQLInsert<NpcSpellClick>(rows, false).Build();
        }

        [BuilderMethod(Units = true)]
        public static string NpcSpellClickMop(Dictionary<WowGuid, Unit> units)
        {
            if (units.Count == 0)
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.npc_spellclick_spells))
                return string.Empty;

            var rows = new RowList<NpcSpellClick>();

            foreach (var unit in units)
            {
                var row = new Row<NpcSpellClick>();

                Unit npc = unit.Value;
                if (npc.InteractSpellID == null)
                    continue;

                if (Settings.AreaFilters.Length > 0)
                    if (!(npc.Area.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.AreaFilters)))
                        continue;

                if (Settings.MapFilters.Length > 0)
                    if (!(npc.Map.ToString(CultureInfo.InvariantCulture).MatchesFilters(Settings.MapFilters)))
                        continue;

                row.Data.Entry = unit.Key.GetEntry();
                row.Data.SpellID = npc.InteractSpellID.GetValueOrDefault();

                rows.Add(row);
            }

            return new SQLInsert<NpcSpellClick>(rows, false).Build();
        }
    }
}
