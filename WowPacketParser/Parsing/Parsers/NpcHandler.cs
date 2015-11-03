using System;
using System.Collections.Generic;
using System.Globalization;
using WowPacketParser.Enums;
using WowPacketParser.Enums.Version;
using WowPacketParser.Misc;
using WowPacketParser.Store;
using WowPacketParser.Store.Objects;

namespace WowPacketParser.Parsing.Parsers
{
    public static class NpcHandler
    {
        public static uint LastGossipPOIEntry;

        [Parser(Opcode.SMSG_GOSSIP_POI)]
        public static void HandleGossipPoi(Packet packet)
        {
            LastGossipPOIEntry++;

            var gossipPOI = new GossipPOI
            {
                Flags = (uint) packet.ReadInt32E<UnknownFlags>("Flags")
            };

            var pos = packet.ReadVector2("Coordinates");
            gossipPOI.Icon = packet.ReadUInt32E<GossipPOIIcon>("Icon");
            gossipPOI.Importance = packet.ReadUInt32("Data");
            gossipPOI.Name = packet.ReadCString("Icon Name");

            gossipPOI.PositionX = pos.X;
            gossipPOI.PositionY = pos.Y;

            Storage.GossipPOIs.Add(LastGossipPOIEntry, gossipPOI, packet.TimeSpan);
        }

        [Parser(Opcode.CMSG_TRAINER_BUY_SPELL, ClientVersionBuild.Zero, ClientVersionBuild.V4_2_2_14545)]
        [Parser(Opcode.SMSG_TRAINER_BUY_FAILED, ClientVersionBuild.Zero, ClientVersionBuild.V4_3_4_15595)]
        [Parser(Opcode.SMSG_TRAINER_BUY_RESULT)]
        public static void HandleServerTrainerBuy(Packet packet)
        {
            packet.ReadGuid("GUID");
            if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_0_3_13329))
                packet.ReadInt32("Unk");
            packet.ReadInt32<SpellId>("Spell ID");
            if (packet.Opcode == Opcodes.GetOpcode(Opcode.SMSG_TRAINER_BUY_FAILED, Direction.ServerToClient)
                || packet.Opcode == Opcodes.GetOpcode(Opcode.SMSG_TRAINER_BUY_RESULT, Direction.ServerToClient))
                packet.ReadUInt32("Reason");
        }

        [Parser(Opcode.SMSG_TRAINER_BUY_FAILED, ClientVersionBuild.V4_3_4_15595)]
        public static void HandleTrainerBuyFailed434(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadInt32<SpellId>("Spell ID");
            packet.ReadUInt32("Reason");
        }

        // Might be a completely different opcode on 4.2.2 (trainer related)
        // Subv says it is SMSG_TRAINER_REPORT_ERROR_IN_CONSOLE but I think he is trolling me.
        [Parser(Opcode.SMSG_TRAINER_BUY_SUCCEEDED)]
        public static void HandleServerTrainerBuySucceedeed(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadInt32<SpellId>("Spell ID");
            if (ClientVersion.Build == ClientVersionBuild.V4_2_2_14545)
                packet.ReadInt32("Trainer Service"); // <TS>

            /* Comments about TS:
             * if !TS, "Trainer service <TS> unavailable"
             * if TS == 1, "Not enough money for trainer service <TS>"
             * Anyway... could only find 0s (and one 1)
             * */
        }

        [Parser(Opcode.CMSG_TRAINER_BUY_SPELL, ClientVersionBuild.V4_2_2_14545)]
        public static void HandleTrainerBuySpell(Packet packet)
        {
            packet.ReadGuid("GUID");
            packet.ReadInt32("Unknown Int32"); // same unk exists in SMSG_TRAINER_LIST
            packet.ReadInt32<SpellId>("Spell ID");
        }

        [Parser(Opcode.SMSG_TRAINER_LIST)]
        public static void HandleServerTrainerList(Packet packet)
        {
            uint entry = packet.ReadGuid("GUID").GetEntry();

            packet.ReadInt32E<TrainerType>("Type");

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_0_6a_13623))
                packet.ReadInt32("Unk Int32"); // Same unk exists in CMSG_TRAINER_BUY_SPELL

            int count = packet.ReadInt32("Count");
            for (int i = 0; i < count; ++i)
            {
                NpcTrainer npcTrainer = new NpcTrainer
                {
                    ID = entry,
                    SpellID = packet.ReadInt32<SpellId>("Spell ID", i)
                };

                packet.ReadByteE<TrainerSpellState>("State", i);

                npcTrainer.MoneyCost = packet.ReadUInt32("Cost", i);

                if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_0_6a_13623))
                {
                    npcTrainer.ReqLevel = packet.ReadByte("Required Level", i);
                    npcTrainer.ReqSkillLine = packet.ReadUInt32("Required Skill", i);
                    npcTrainer.ReqSkillRank = packet.ReadUInt32("Required Skill Level", i);
                    if (ClientVersion.RemovedInVersion(ClientVersionBuild.V5_1_0_16309))
                    {
                        packet.ReadInt32<SpellId>("Chain Spell ID", i, 0);
                        packet.ReadInt32<SpellId>("Chain Spell ID", i, 1);
                    }
                    else
                        packet.ReadInt32<SpellId>("Required Spell ID", i);
                }

                packet.ReadInt32("Profession Dialog", i);
                packet.ReadInt32("Profession Button", i);

                if (ClientVersion.RemovedInVersion(ClientVersionBuild.V4_0_6a_13623))
                {
                    npcTrainer.ReqLevel = packet.ReadByte("Required Level", i);
                    npcTrainer.ReqSkillLine = packet.ReadUInt32("Required Skill", i);
                    npcTrainer.ReqSkillRank = packet.ReadUInt32("Required Skill Level", i);
                    packet.ReadInt32<SpellId>("Chain Spell ID", i, 0);
                    packet.ReadInt32<SpellId>("Chain Spell ID", i, 1);
                }

                if (ClientVersion.RemovedInVersion(ClientVersionBuild.V4_0_6a_13623))
                    packet.ReadInt32("Unk Int32", i);

                Storage.NpcTrainers.Add(npcTrainer, packet.TimeSpan);
            }

            packet.ReadCString("Title");
        }

        [Parser(Opcode.SMSG_VENDOR_INVENTORY, ClientVersionBuild.Zero, ClientVersionBuild.V4_2_2_14545)]
        public static void HandleVendorInventoryList(Packet packet)
        {
            uint entry = packet.ReadGuid("GUID").GetEntry();
            int count = packet.ReadByte("Item Count");

            if (count == 0)
            {
                packet.ReadByte("Unk 1");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                NpcVendor vendor = new NpcVendor
                {
                    Entry = entry,
                    Slot = packet.ReadInt32("Item Position", i)
                };

                if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_0_3_13329))
                    vendor.Type = packet.ReadUInt32("Item Type", i); // not confirmed

                vendor.Item = packet.ReadInt32<ItemId>("Item ID", i);
                packet.ReadInt32("Display ID", i);
                int maxCount = packet.ReadInt32("Max Count", i);
                packet.ReadInt32("Price", i);
                packet.ReadInt32("Max Durability", i);
                uint buyCount = packet.ReadUInt32("Buy Count", i);
                vendor.ExtendedCost = packet.ReadUInt32("Extended Cost", i);

                if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_0_3_13329))
                    packet.ReadByte("Unk Byte", i);

                vendor.MaxCount = maxCount == -1 ? 0 : (uint)maxCount; // TDB
                if (vendor.Type == 2)
                    vendor.MaxCount = buyCount;

                Storage.NpcVendors.Add(vendor, packet.TimeSpan);
            }
        }

        [Parser(Opcode.SMSG_VENDOR_INVENTORY, ClientVersionBuild.V4_2_2_14545, ClientVersionBuild.V4_3_0_15005)]
        public static void HandleVendorInventoryList422(Packet packet)
        {
            var guidBytes = packet.StartBitStream(5, 6, 1, 2, 3, 0, 7, 4);

            packet.ReadXORByte(guidBytes, 2);
            packet.ReadXORByte(guidBytes, 3);

            uint count = packet.ReadUInt32("Item Count");

            packet.ReadXORByte(guidBytes, 5);
            packet.ReadXORByte(guidBytes, 0);
            packet.ReadXORByte(guidBytes, 1);

            packet.ReadByte("Unk Byte");

            packet.ReadXORByte(guidBytes, 4);
            packet.ReadXORByte(guidBytes, 7);
            packet.ReadXORByte(guidBytes, 6);

            uint entry = packet.WriteGuid("GUID", guidBytes).GetEntry();

            for (int i = 0; i < count; i++)
            {
                NpcVendor npcVendor = new NpcVendor
                {
                    Entry = entry
                };

                packet.ReadInt32("Max Durability", i);
                npcVendor.Slot = packet.ReadInt32("Item Position", i);
                npcVendor.Item = packet.ReadInt32<ItemId>("Item ID", i);
                packet.ReadInt32("Unk Int32 1", i);
                packet.ReadInt32("Display ID", i);
                int maxCount = packet.ReadInt32("Max Count", i);
                npcVendor.MaxCount = maxCount == -1 ? 0 : (uint)maxCount; // TDB
                packet.ReadUInt32("Buy Count", i);
                npcVendor.ExtendedCost = packet.ReadUInt32("Extended Cost", i);
                packet.ReadInt32("Unk Int32 2", i);
                packet.ReadInt32("Price", i);

                // where's the vendorItem.Type (1/2)?

                Storage.NpcVendors.Add(npcVendor, packet.TimeSpan);
            }
        }

        [Parser(Opcode.SMSG_VENDOR_INVENTORY, ClientVersionBuild.V4_3_4_15595)]
        public static void HandleVendorInventoryList434(Packet packet)
        {
            var guidBytes = new byte[8];

            guidBytes[1] = packet.ReadBit();
            guidBytes[0] = packet.ReadBit();

            uint count = packet.ReadBits("Item Count", 21);

            guidBytes[3] = packet.ReadBit();
            guidBytes[6] = packet.ReadBit();
            guidBytes[5] = packet.ReadBit();
            guidBytes[2] = packet.ReadBit();
            guidBytes[7] = packet.ReadBit();

            var hasExtendedCost = new bool[count];
            var hasCondition = new bool[count];
            for (int i = 0; i < count; ++i)
            {
                hasExtendedCost[i] = !packet.ReadBit();
                hasCondition[i] = !packet.ReadBit();
            }

            guidBytes[4] = packet.ReadBit();

            List<NpcVendor> tempList = new List<NpcVendor>();
            for (int i = 0; i < count; ++i)
            {
                NpcVendor npcVendor = new NpcVendor
                {
                    Slot = packet.ReadInt32("Item Position", i)
                };

                packet.ReadInt32("Max Durability", i);
                if (hasExtendedCost[i])
                    npcVendor.ExtendedCost = packet.ReadUInt32("Extended Cost", i);
                npcVendor.Item = packet.ReadInt32<ItemId>("Item ID", i);
                npcVendor.Type = packet.ReadUInt32("Type", i); // 1 - item, 2 - currency
                packet.ReadInt32("Price", i);
                packet.ReadInt32("Display ID", i);
                if (hasCondition[i])
                    packet.ReadInt32("Row ID", i);
                int maxCount = packet.ReadInt32("Max Count", i);
                npcVendor.MaxCount = maxCount == -1 ? 0 : (uint)maxCount; // TDB
                uint buyCount = packet.ReadUInt32("Buy Count", i);

                if (npcVendor.Type == 2)
                    npcVendor.MaxCount = buyCount;

                tempList.Add(npcVendor);
            }

            packet.ReadXORByte(guidBytes, 5);
            packet.ReadXORByte(guidBytes, 4);
            packet.ReadXORByte(guidBytes, 1);
            packet.ReadXORByte(guidBytes, 0);
            packet.ReadXORByte(guidBytes, 6);

            packet.ReadByte("Unk Byte");

            packet.ReadXORByte(guidBytes, 2);
            packet.ReadXORByte(guidBytes, 3);
            packet.ReadXORByte(guidBytes, 7);

            uint entry = packet.WriteGuid("GUID", guidBytes).GetEntry();
            tempList.ForEach(v =>
            {
                v.Entry = entry;
                Storage.NpcVendors.Add(v, packet.TimeSpan);
            });
        }

        [Parser(Opcode.CMSG_GOSSIP_HELLO)]
        [Parser(Opcode.CMSG_TRAINER_LIST)]
        [Parser(Opcode.CMSG_LIST_INVENTORY)]
        [Parser(Opcode.MSG_TABARDVENDOR_ACTIVATE)]
        [Parser(Opcode.CMSG_BANKER_ACTIVATE)]
        [Parser(Opcode.CMSG_SPIRIT_HEALER_ACTIVATE)]
        [Parser(Opcode.CMSG_BINDER_ACTIVATE)]
        [Parser(Opcode.SMSG_BINDER_CONFIRM)]
        [Parser(Opcode.SMSG_SHOW_BANK)]
        public static void HandleNpcHello(Packet packet)
        {
            packet.ReadGuid("GUID");
        }

        [Parser(Opcode.CMSG_GOSSIP_SELECT_OPTION)]
        public static void HandleNpcGossipSelectOption(Packet packet)
        {
            packet.ReadGuid("GUID");
            var menuEntry = packet.ReadUInt32("Menu Id");
            var gossipId = packet.ReadUInt32("Gossip Id");

            if (packet.CanRead()) // if ( byte_F3777C[v3] & 1 )
                packet.ReadCString("Box Text");

            Storage.GossipSelects.Add(Tuple.Create(menuEntry, gossipId), null, packet.TimeSpan);
        }

        [HasSniffData]
        [Parser(Opcode.SMSG_GOSSIP_MESSAGE)]
        public static void HandleNpcGossip(Packet packet)
        {
            var gossip = new Gossip();

            var guid = packet.ReadGuid("GUID");

            gossip.ObjectType = guid.GetObjectType();
            gossip.ObjectEntry = guid.GetEntry();

            var menuId = packet.ReadUInt32("Menu Id");

            if (ClientVersion.AddedInVersion(ClientType.MistsOfPandaria))
                packet.ReadUInt32("Friendship Faction");

            var textId = packet.ReadUInt32("Text Id");

            if (guid.GetObjectType() == ObjectType.Unit)
                if (Storage.Objects.ContainsKey(guid))
                        ((Unit) Storage.Objects[guid].Item1).GossipId = menuId;

            var count = packet.ReadUInt32("Amount of Options");

            gossip.GossipOptions = new List<GossipOption>((int) count);
            for (var i = 0; i < count; i++)
            {
                var gossipOption = new GossipOption
                {
                    Index = packet.ReadUInt32("Index", i),
                    OptionIcon = packet.ReadByteE<GossipOptionIcon>("Icon", i),
                    Box = packet.ReadBool("Box", i),
                    RequiredMoney = packet.ReadUInt32("Required money", i),
                    OptionText = packet.ReadCString("Text", i),
                    BoxText = packet.ReadCString("Box Text", i)
                };

                gossip.GossipOptions.Add(gossipOption);
            }

            if (Storage.Gossips.ContainsKey(Tuple.Create(menuId, textId)))
            {
                var oldGossipOptions = Storage.Gossips[Tuple.Create(menuId, textId)];
                if (oldGossipOptions != null)
                {
                    foreach (var gossipOptions in gossip.GossipOptions)
                        oldGossipOptions.Item1.GossipOptions.Add(gossipOptions);
                }
            }
            else
                Storage.Gossips.Add(Tuple.Create(menuId, textId), gossip, packet.TimeSpan);

            packet.AddSniffData(StoreNameType.Gossip, (int)menuId, guid.GetEntry().ToString(CultureInfo.InvariantCulture));

            var questgossips = packet.ReadUInt32("Amount of Quest gossips");
            for (var i = 0; i < questgossips; i++)
            {
                packet.ReadUInt32<QuestId>("Quest ID", i);

                packet.ReadUInt32("Icon", i);
                packet.ReadInt32("Level", i);
                packet.ReadUInt32E<QuestFlags>("Flags", i);
                if (ClientVersion.AddedInVersion(ClientVersionBuild.V5_1_0_16309))
                    packet.ReadUInt32E<QuestFlags2>("Flags 2", i);

                packet.ReadBool("Change Icon", i);
                packet.ReadCString("Title", i);
            }
        }

        [Parser(Opcode.SMSG_THREAT_UPDATE)]
        [Parser(Opcode.SMSG_HIGHEST_THREAT_UPDATE)]
        public static void HandleThreatlistUpdate(Packet packet)
        {
            packet.ReadPackedGuid("GUID");

            if (packet.Opcode == Opcodes.GetOpcode(Opcode.SMSG_HIGHEST_THREAT_UPDATE, Direction.ServerToClient))
                packet.ReadPackedGuid("New Highest");

            var count = packet.ReadUInt32("Size");
            for (int i = 0; i < count; i++)
            {
                packet.ReadPackedGuid("Hostile", i);
                packet.ReadUInt32("Threat", i);
            }
        }

        [Parser(Opcode.SMSG_THREAT_CLEAR)]
        [Parser(Opcode.SMSG_THREAT_REMOVE)]
        public static void HandleRemoveThreatlist(Packet packet)
        {
            packet.ReadPackedGuid("GUID");

            if (packet.Opcode == Opcodes.GetOpcode(Opcode.SMSG_THREAT_REMOVE, Direction.ServerToClient))
                packet.ReadPackedGuid("Victim GUID");
        }
    }
}
