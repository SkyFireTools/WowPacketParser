using System;
using System.Collections.Generic;
using System.Linq;
using WowPacketParser.Enums;
using WowPacketParser.Misc;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;

namespace WowPacketParser.SQL.Builders
{
    [BuilderClass]
    public static class WDBTemplates
    {
        [BuilderMethod]
        public static string Quest()
        {
            if (Storage.QuestTemplates.IsEmpty())
                return String.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.quest_template))
                return String.Empty;

            var entries = Storage.QuestTemplates.Keys();
            var templatesDb = SQLDatabase.GetDict<uint, QuestTemplate>(entries, "Id");

            return SQLUtil.CompareDicts(Storage.QuestTemplates, templatesDb, StoreNameType.Quest, "Id");
        }

        [BuilderMethod]
        public static string QuestWod()
        {
            if (Storage.QuestTemplatesWod.IsEmpty())
                return String.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.quest_template))
                return String.Empty;

            var entries = Storage.QuestTemplatesWod.Keys();
            var templatesDb = SQLDatabase.GetDict<uint, QuestTemplateWod>(entries, "Id");

            return SQLUtil.CompareDicts(Storage.QuestTemplatesWod, templatesDb, StoreNameType.Quest, "Id");
        }

        [BuilderMethod]
        public static string QuestObjective()
        {
            /*
            var result = "";
            if (Storage.QuestObjectives.IsEmpty())
                return String.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.quest_template))
                return String.Empty;

            var entries = Storage.QuestObjectives.Keys();
            var templatesDb = SQLDatabase.GetDict<uint, QuestInfoObjective>(entries, "Id");

            result += SQLUtil.CompareDicts(Storage.QuestObjectives, templatesDb, StoreNameType.QuestObjective, "Id");

            var rowsIns = new List<SQLInsertRow>();
            var rowsUpd = new List<SQLUpdateRow>();

            foreach (var questObjectives in Storage.QuestObjectives)
            {
                foreach (var visualEffectIds in questObjectives.Value.Item1.VisualEffectIds)
                {
                    if (SQLConnector.Enabled)
                    {
                        var query = string.Format("SELECT `VisualEffect`, `VerifiedBuild` FROM {0}.quest_visual_effect WHERE `Id`={1} AND `Index`={2};",
                            Settings.TDBDatabase, questObjectives.Key, visualEffectIds.Index);

                        using (var reader = SQLConnector.ExecuteQuery(query))
                        {
                            if (reader.HasRows) // possible update
                            {
                                while (reader.Read())
                                {
                                    var row = new SQLUpdateRow();

                                    if (!Utilities.EqualValues(reader.GetValue(0), visualEffectIds.VisualEffect))
                                        row.AddValue("VisualEffect", visualEffectIds.VisualEffect);

                                    if (!Utilities.EqualValues(reader.GetValue(1), questObjectives.Value.Item1.VerifiedBuild))
                                        row.AddValue("VerifiedBuild", questObjectives.Value.Item1.VerifiedBuild);

                                    row.AddWhere("Id", questObjectives.Key);
                                    row.AddWhere("Index", visualEffectIds.Index);

                                    row.Table = "quest_visual_effect";

                                    if (row.ValueCount != 0)
                                        rowsUpd.Add(row);
                                }
                            }
                            else // insert
                            {
                                var row = new SQLInsertRow();

                                row.AddValue("Id", questObjectives.Key);
                                row.AddValue("Index", visualEffectIds.Index);
                                row.AddValue("VisualEffect", visualEffectIds.VisualEffect);
                                row.AddValue("VerifiedBuild", questObjectives.Value.Item1.VerifiedBuild);

                                rowsIns.Add(row);
                            }
                        }
                    }
                    else // insert
                    {
                        var row = new SQLInsertRow();

                        row.AddValue("Id", questObjectives.Key);
                        row.AddValue("Index", visualEffectIds.Index);
                        row.AddValue("VisualEffect", visualEffectIds.VisualEffect);
                        row.AddValue("VerifiedBuild", questObjectives.Value.Item1.VerifiedBuild);

                        rowsIns.Add(row);
                    }
                }
             }

            result += new SQLInsert("quest_visual_effect", rowsIns, 2).Build() + new SQLUpdate(rowsUpd).Build();

            return result;*/
            return string.Empty;
        }

        [BuilderMethod(Units = true)]
        public static string CreatureTemplate(Dictionary<WowGuid, Unit> units)
        {
            if (Storage.CreatureTemplates.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.creature_template))
                return string.Empty;

            var templatesDb = SQLDatabase.Get(Storage.CreatureTemplates);

            foreach (var cre in Storage.CreatureTemplates) // set some default values
            {
                Unit unit = units.FirstOrDefault(p => p.Key.GetEntry() == cre.Item1.Entry.GetValueOrDefault()).Value;
                var levels = UnitMisc.GetLevels(units);

                if (unit != null)
                {
                    if (unit.GossipId == 0)
                        cre.Item1.GossipMenuID = null;
                    else
                        cre.Item1.GossipMenuID = unit.GossipId;

                    cre.Item1.MinLevel = levels[cre.Item1.Entry.GetValueOrDefault()].Item1;
                    cre.Item1.MaxLevel = levels[cre.Item1.Entry.GetValueOrDefault()].Item2;

                    HashSet<uint> playerFactions = new HashSet<uint> { 1, 2, 3, 4, 5, 6, 115, 116, 1610, 1629, 2203, 2204 };
                    cre.Item1.Faction = unit.Faction.GetValueOrDefault(35);
                    if (playerFactions.Contains(unit.Faction.GetValueOrDefault()))
                        cre.Item1.Faction = 35;
                    
                    cre.Item1.NpcFlag = unit.NpcFlags.GetValueOrDefault(NPCFlags.None);
                    cre.Item1.SpeedWalk = unit.Movement.WalkSpeed;
                    cre.Item1.SpeedRun = unit.Movement.RunSpeed;
                    
                    cre.Item1.BaseAttackTime = unit.MeleeTime.GetValueOrDefault(2000);
                    cre.Item1.RangeAttackTime = unit.RangedTime.GetValueOrDefault(2000);
                    
                    cre.Item1.UnitClass = (uint)unit.Class.GetValueOrDefault(Class.Warrior);

                    cre.Item1.UnitFlags = unit.UnitFlags.GetValueOrDefault(UnitFlags.None);
                    cre.Item1.UnitFlags &= ~UnitFlags.IsInCombat;
                    cre.Item1.UnitFlags &= ~UnitFlags.PetIsAttackingTarget;
                    cre.Item1.UnitFlags &= ~UnitFlags.PlayerControlled;
                    cre.Item1.UnitFlags &= ~UnitFlags.Silenced;
                    cre.Item1.UnitFlags &= ~UnitFlags.PossessedByPlayer;

                    cre.Item1.UnitFlags2 = unit.UnitFlags2.GetValueOrDefault(UnitFlags2.None);

                    if (Settings.TargetedDatabase != TargetedDatabase.WarlordsOfDraenor)
                    {
                        cre.Item1.DynamicFlags = unit.DynamicFlags.GetValueOrDefault(UnitDynamicFlags.None);
                        cre.Item1.DynamicFlags &= ~UnitDynamicFlags.Lootable;
                        cre.Item1.DynamicFlags &= ~UnitDynamicFlags.Tapped;
                        cre.Item1.DynamicFlags &= ~UnitDynamicFlags.TappedByPlayer;
                        cre.Item1.DynamicFlags &= ~UnitDynamicFlags.TappedByAllThreatList;
                    }
                    else
                    {
                        cre.Item1.DynamicFlagsWod = unit.DynamicFlagsWod.GetValueOrDefault(UnitDynamicFlagsWOD.None);
                        cre.Item1.DynamicFlagsWod &= ~UnitDynamicFlagsWOD.Lootable;
                        cre.Item1.DynamicFlagsWod &= ~UnitDynamicFlagsWOD.Tapped;
                        cre.Item1.DynamicFlagsWod &= ~UnitDynamicFlagsWOD.TappedByPlayer;
                        cre.Item1.DynamicFlagsWod &= ~UnitDynamicFlagsWOD.TappedByAllThreatList;
                    }
                    cre.Item1.VehicleID = unit.Movement.VehicleId;
                    cre.Item1.HoverHeight = unit.HoverHeight.GetValueOrDefault(1.0f);

                    //TODO: set TrainerType from SMSG_TRAINER_LIST
                    cre.Item1.TrainerType = 0;

                    cre.Item1.Resistances = new uint?[] {0, 0, 0, 0, 0, 0};
                    for (int i = 0; i < unit.Resistances.Length - 1; i++)
                        cre.Item1.Resistances[i] = unit.Resistances[i + 1];
                }

                // has trainer flag but doesn't have prof nor class trainer flag
                if (cre.Item1.NpcFlag.GetValueOrDefault().HasFlag(NPCFlags.Trainer) &&
                    (!cre.Item1.NpcFlag.GetValueOrDefault().HasFlag(NPCFlags.ProfessionTrainer) ||
                     !cre.Item1.NpcFlag.GetValueOrDefault().HasFlag(NPCFlags.ClassTrainer)))
                {
                    string name = StoreGetters.GetName(StoreNameType.Unit, (int)cre.Item1.Entry.GetValueOrDefault(), false);
                    int firstIndex = name.LastIndexOf('<');
                    int lastIndex = name.LastIndexOf('>');
                    if (firstIndex != -1 && lastIndex != -1)
                    {
                        string subname = name.Substring(firstIndex + 1, lastIndex - firstIndex - 1);

                        if (UnitMisc._professionTrainers.Contains(subname))
                            cre.Item1.NpcFlag |= NPCFlags.ProfessionTrainer;
                        else if (UnitMisc._classTrainers.Contains(subname))
                            cre.Item1.NpcFlag |= NPCFlags.ClassTrainer;
                    }
                }

                cre.Item1.DifficultyEntries = new uint?[] {null, null, null};
                cre.Item1.Scale = 1;
                cre.Item1.DmgSchool = 0;
                cre.Item1.BaseVariance = 1;
                cre.Item1.RangeVariance = 1;
                cre.Item1.Resistances = new uint?[] {null, null, null, null, null, null};
                cre.Item1.Spells = new uint?[] {0, 0, 0, 0, 0, 0, 0, 0};
                cre.Item1.HealthModifierExtra = 1;
                cre.Item1.ManaModifierExtra = 1;
                cre.Item1.ArmorModifier = 1;
            }

            foreach (
                var cre in
                    Storage.CreatureTemplates.Where(
                        cre => Storage.SpellsX.ContainsKey(cre.Item1.Entry.GetValueOrDefault())))
            {
                cre.Item1.Spells = Storage.SpellsX[cre.Item1.Entry.GetValueOrDefault()].Item1.ToArray();
            }

            return SQLUtil.Compare(Storage.CreatureTemplates, templatesDb, StoreNameType.Unit);
        }

        [BuilderMethod]
        public static string GameObjectTemplate()
        {
            if (Storage.GameObjectTemplates.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.gameobject_template))
                return string.Empty;

            var templatesDb = SQLDatabase.Get(Storage.GameObjectTemplates);

            return SQLUtil.Compare(Storage.GameObjectTemplates, templatesDb, StoreNameType.GameObject);
        }

        [BuilderMethod]
        public static string ItemTemplate()
        {
            if (Settings.TargetedDatabase == TargetedDatabase.WarlordsOfDraenor)
                return string.Empty;

            if (Storage.ItemTemplates.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.item_template))
                return string.Empty;

            var entries = Storage.ItemTemplates;
            var templatesDb = SQLDatabase.Get(entries);

            return SQLUtil.Compare(Storage.ItemTemplates, templatesDb, StoreNameType.Item);
        }

        [BuilderMethod]
        public static string PageText()
        {
            if (Storage.PageTexts.IsEmpty())
                return string.Empty;

            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.page_text))
                return string.Empty;

            var entries = Storage.PageTexts;
            var templatesDb = SQLDatabase.Get(entries);

            return SQLUtil.Compare(Storage.PageTexts, templatesDb, StoreNameType.PageText);
        }

        [BuilderMethod]
        public static string NpcText()
        {
            if (!Settings.SQLOutputFlag.HasAnyFlagBit(SQLOutput.npc_text))
                return string.Empty;

            if (!Storage.NpcTexts.IsEmpty() && 
                (Settings.TargetedDatabase == TargetedDatabase.WrathOfTheLichKing || 
                Settings.TargetedDatabase == TargetedDatabase.Cataclysm))
            {
                foreach (var npcText in Storage.NpcTexts)
                    npcText.Item1.ConvertToDBStruct();

                var entries = Storage.NpcTexts;
                var templatesDb = SQLDatabase.Get<NpcText>(entries);

                return SQLUtil.Compare(Storage.NpcTexts, templatesDb, StoreNameType.NpcText);
            }

            if (!Storage.NpcTextsMop.IsEmpty() && Settings.TargetedDatabase == TargetedDatabase.WarlordsOfDraenor)
            {
                foreach (var npcText in Storage.NpcTextsMop)
                    npcText.Item1.ConvertToDBStruct();

                var entries = Storage.NpcTextsMop;
                var templatesDb = SQLDatabase.Get<NpcTextMop>(entries);

                return SQLUtil.Compare(Storage.NpcTextsMop, templatesDb, StoreNameType.NpcText);
            }

            return string.Empty;
        }
    }
}
