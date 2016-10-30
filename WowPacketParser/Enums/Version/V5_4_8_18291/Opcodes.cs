using WowPacketParser.Misc;

namespace WowPacketParser.Enums.Version.V5_4_8_18291
{
 public static class Opcodes_5_4_8
 {
  public static BiDictionary<Opcode, int> Opcodes(Direction direction)
  {
   if (direction == Direction.ClientToServer || direction == Direction.BNClientToServer)
    return ClientOpcodes;
   if (direction == Direction.ServerToClient || direction == Direction.BNServerToClient)
    return ServerOpcodes;
   return MiscOpcodes;
  }

  private static readonly BiDictionary<Opcode, int> ClientOpcodes = new BiDictionary<Opcode, int>
        {
            {Opcode.CMSG_ACCEPT_LEVEL_GRANT, 0x02FB},
            {Opcode.CMSG_ACCEPT_TRADE, 0x144D},
            {Opcode.CMSG_ACTIVATE_TAXI, 0x03C9},
            {Opcode.CMSG_ACTIVATE_TAXI_EXPRESS, 0x06FB},
            {Opcode.CMSG_ADDON_REGISTERED_PREFIXES, 0x040E},
            {Opcode.CMSG_ADD_FRIEND, 0x09A6},
            {Opcode.CMSG_ADD_IGNORE, 0x0D20},
            {Opcode.CMSG_ALTER_APPEARANCE, 0x07F0},
            {Opcode.CMSG_AREATRIGGER, 0x1C44},// SkyFire
            {Opcode.CMSG_AREA_SPIRIT_HEALER_QUERY, 0x03F1},
            {Opcode.CMSG_AREA_SPIRIT_HEALER_QUEUE, 0x12D8},
            {Opcode.CMSG_ATTACKSTOP, 0x0345},// SkyFire
            {Opcode.CMSG_ATTACKSWING, 0x02E7},// SkyFire
            {Opcode.CMSG_AUCTION_HELLO, 0x0379},// SkyFire
            {Opcode.CMSG_AUCTION_LIST_BIDDER_ITEMS, 0x12D0},
            {Opcode.CMSG_AUCTION_LIST_ITEMS, 0x02EA},
            {Opcode.CMSG_AUCTION_LIST_OWNER_ITEMS, 0x0361},
            {Opcode.CMSG_AUCTION_REMOVE_ITEM, 0x0259},
            {Opcode.CMSG_AUCTION_SELL_ITEM, 0x02EB},
            {Opcode.CMSG_AUTH_SESSION, 0x00B2},
            {Opcode.CMSG_AUTOBANK_ITEM, 0x066D},
            {Opcode.CMSG_AUTOEQUIP_ITEM, 0x025F},// SkyFire
            {Opcode.CMSG_AUTOSTORE_BAG_ITEM, 0x067C},
            {Opcode.CMSG_AUTOSTORE_BANK_ITEM, 0x02CF},
            {Opcode.CMSG_AUTOSTORE_LOOT_ITEM, 0x0354},
            {Opcode.CMSG_AUTO_DECLINE_GUILD_INVITES, 0x06CB},
            {Opcode.CMSG_BANKER_ACTIVATE, 0x02E9},
            {Opcode.CMSG_BATTLEFIELD_LEAVE, 0x0257},
            {Opcode.CMSG_BATTLEFIELD_LIST, 0x1C41},
            {Opcode.CMSG_BATTLEFIELD_MGR_ENTRY_INVITE_RESPONSE, 0x1806},// SkyFire
            {Opcode.CMSG_BATTLEFIELD_MGR_EXIT_REQUEST, 0x08B3},// SkyFire
            {Opcode.CMSG_BATTLEFIELD_MGR_QUEUE_INVITE_RESPONSE, 0x0A97},// SkyFire
            {Opcode.CMSG_BATTLEFIELD_PORT, 0x1379},
            {Opcode.CMSG_BATTLEMASTER_JOIN, 0x0769},
            {Opcode.CMSG_BATTLEMASTER_JOIN_ARENA, 0x02D2},
            {Opcode.CMSG_BATTLE_PET_DELETE_PET, 0x18B6},
            {Opcode.CMSG_BATTLE_PET_MODIFY_NAME, 0x1887},
            {Opcode.CMSG_BATTLE_PET_QUERY_NAME, 0x1CE0},// SkyFire
            {Opcode.CMSG_BATTLE_PET_SET_BATTLE_SLOT, 0x0163},
            {Opcode.CMSG_BATTLE_PET_SET_FLAGS, 0x17AC},
            {Opcode.CMSG_BATTLE_PET_SUMMON_COMPANION, 0x1896},
            {Opcode.CMSG_BEGIN_TRADE, 0x1CE3},
            {Opcode.CMSG_BINDER_ACTIVATE, 0x1248},
            {Opcode.CMSG_BLACKMARKET_BID, 0x12C8},// SkyFire
            {Opcode.CMSG_BLACKMARKET_HELLO, 0x075A},// SkyFire
            {Opcode.CMSG_BLACKMARKET_REQUEST_ITEMS, 0x127A},// SkyFire
            {Opcode.CMSG_BUYBACK_ITEM, 0x0661},// SkyFire
            {Opcode.CMSG_BUY_BANK_SLOT, 0x12F2},
            {Opcode.CMSG_BUY_ITEM, 0x02E2},
            {Opcode.CMSG_CALENDAR_ADD_EVENT, 0x0A37},
            {Opcode.CMSG_CALENDAR_COMPLAIN, 0x1F8F},
            {Opcode.CMSG_CALENDAR_COPY_EVENT, 0x1A97},
            {Opcode.CMSG_CALENDAR_EVENT_INVITE, 0x1D8E},
            {Opcode.CMSG_CALENDAR_EVENT_MODERATOR_STATUS, 0x0708},
            {Opcode.CMSG_CALENDAR_EVENT_REMOVE_INVITE, 0x0962},
            {Opcode.CMSG_CALENDAR_EVENT_RSVP, 0x1FB8},
            {Opcode.CMSG_CALENDAR_EVENT_SIGNUP, 0x01E3},// SkyFire
            {Opcode.CMSG_CALENDAR_EVENT_STATUS, 0x1AB3},
            {Opcode.CMSG_CALENDAR_GET_CALENDAR, 0x1F9F},
            {Opcode.CMSG_CALENDAR_GET_EVENT, 0x030C},
            {Opcode.CMSG_CALENDAR_REMOVE_EVENT, 0x0C61},
            {Opcode.CMSG_CALENDAR_UPDATE_EVENT, 0x1F8D},
            {Opcode.CMSG_CANCEL_AURA, 0x1861},
            {Opcode.CMSG_CANCEL_AUTO_REPEAT_SPELL, 0x1272},
            {Opcode.CMSG_CANCEL_CAST, 0x18C0},
            {Opcode.CMSG_CANCEL_CHANNELLING, 0x08C0},
            {Opcode.CMSG_CANCEL_MOUNT_AURA, 0x10E3},
            {Opcode.CMSG_CANCEL_TEMP_ENCHANTMENT, 0x024B},
            {Opcode.CMSG_CANCEL_TRADE, 0x1941},
            {Opcode.CMSG_CAST_SPELL, 0x0206},
            {Opcode.CMSG_CHANGE_SEATS_ON_CONTROLLED_VEHICLE, 0x08F8},
            {Opcode.CMSG_CHANNEL_ANNOUNCEMENTS, 0x06AF},// SkyFire
            {Opcode.CMSG_CHANNEL_BAN, 0x08BF},// SkyFire
            {Opcode.CMSG_CHANNEL_INVITE, 0x10AB},// SkyFire
            {Opcode.CMSG_CHANNEL_KICK, 0x0E0B},// SkyFire
            {Opcode.CMSG_CHANNEL_LIST, 0x0C1B},// SkyFire
            {Opcode.CMSG_CHANNEL_MODERATOR, 0x00AE},// SkyFire
            {Opcode.CMSG_CHANNEL_MUTE, 0x000A},// SkyFire
            {Opcode.CMSG_CHANNEL_OWNER, 0x00AF},// SkyFire
            {Opcode.CMSG_CHANNEL_PASSWORD, 0x0A1E},// SkyFire
            {Opcode.CMSG_CHANNEL_UNBAN, 0x081F},// SkyFire
            {Opcode.CMSG_CHANNEL_UNMODERATOR, 0x041E},// SkyFire
            {Opcode.CMSG_CHANNEL_UNMUTE, 0x022A},// SkyFire
            {Opcode.CMSG_CHAR_CREATE, 0x0F1D},// SkyFire
            {Opcode.CMSG_CHAR_CUSTOMIZE, 0x0A13},
            {Opcode.CMSG_CHAR_DELETE, 0x04E2},
            {Opcode.CMSG_CHAR_ENUM, 0x00E0},// SkyFire
            {Opcode.CMSG_CHAR_FACTION_OR_RACE_CHANGE, 0x0329},// SkyFire
            {Opcode.CMSG_CHAR_RENAME, 0x0963},// SkyFire
            {Opcode.CMSG_CHAT_IGNORED, 0x048A},// SkyFire
            {Opcode.CMSG_CLEAR_TRADE_ITEM, 0x00A7},
            {Opcode.CMSG_CONFIRM_RESPEC_WIPE, 0x0275},
            {Opcode.CMSG_CONTACT_LIST, 0x0BB4},
            {Opcode.CMSG_CREATURE_QUERY, 0x0842},// SkyFire
            {Opcode.CMSG_DB_QUERY_BULK, 0x158D},
            {Opcode.CMSG_DEL_FRIEND, 0x1103},
            {Opcode.CMSG_DEL_IGNORE, 0x0737},
            {Opcode.CMSG_DESTROY_ITEM, 0x0026},
            {Opcode.CMSG_DISMISS_CRITTER, 0x12DB},
            {Opcode.CMSG_DUEL_PROPOSED, 0x1A26},
            {Opcode.CMSG_DUEL_RESPONSE, 0x03E2},
            {Opcode.CMSG_EJECT_PASSENGER, 0x06E7},
            {Opcode.CMSG_EMOTE, 0x1924},
            {Opcode.CMSG_ENABLE_TAXI, 0x0741},// SkyFire
            {Opcode.CMSG_EQUIPMENT_SET_DELETE, 0x02E8},
            {Opcode.CMSG_EQUIPMENT_SET_SAVE, 0x0669},
            {Opcode.CMSG_EQUIPMENT_SET_USE, 0x036E},
            {Opcode.CMSG_FORCE_MOVE_ROOT_ACK, 0x107A},
            {Opcode.CMSG_FORCE_MOVE_UNROOT_ACK, 0x1051},
            {Opcode.CMSG_GAMEOBJECT_QUERY, 0x1461},// SkyFire
            {Opcode.CMSG_GAMEOBJ_REPORT_USE, 0x06D9},// SkyFire
            {Opcode.CMSG_GAMEOBJ_USE, 0x06D8},// SkyFire
            {Opcode.CMSG_GET_MAIL_LIST, 0x077A},// SkyFire
            {Opcode.CMSG_GET_MIRROR_IMAGE_DATA, 0x02A3},
            {Opcode.CMSG_GM_TICKET_CREATE, 0x1A86},
            {Opcode.CMSG_GM_TICKET_DELETE_TICKET, 0x1A23},
            {Opcode.CMSG_GM_TICKET_GET_TICKET, 0x1F89},
            {Opcode.CMSG_GM_TICKET_SYSTEM_STATUS, 0x0A82},// SkyFire
            {Opcode.CMSG_GM_TICKET_CASE_STATUS, 0x15A8},// SkyFire
            {Opcode.CMSG_GM_TICKET_UPDATE_TEXT, 0x0A26},
            {Opcode.CMSG_GOSSIP_HELLO, 0x12F3},
            {Opcode.CMSG_GOSSIP_SELECT_OPTION, 0x0748},
            {Opcode.CMSG_GRANT_LEVEL, 0x0662},
            {Opcode.CMSG_GROUP_ASSISTANT_LEADER, 0x1897},// SkyFire
            {Opcode.CMSG_GROUP_DISBAND, 0x1798},
            {Opcode.CMSG_GROUP_INITIATE_ROLE_POLL, 0x1882},// SkyFire
            {Opcode.CMSG_GROUP_INVITE, 0x072D},
            {Opcode.CMSG_GROUP_INVITE_RESPONSE, 0x0D61},
            {Opcode.CMSG_GROUP_RAID_CONVERT, 0x032C},
            {Opcode.CMSG_GROUP_SET_LEADER, 0x15BB},
            {Opcode.CMSG_GROUP_SET_ROLES, 0x1A92},
            {Opcode.CMSG_GROUP_UNINVITE_GUID, 0x0CE1},
            {Opcode.CMSG_GUILD_ACCEPT, 0x18A2},
            {Opcode.CMSG_GUILD_ACHIEVEMENT_PROGRESS_QUERY, 0x1552},// SkyFire
            {Opcode.CMSG_GUILD_ADD_RANK, 0x047A},
            {Opcode.CMSG_GUILD_ASSIGN_MEMBER_RANK, 0x05D0},
            {Opcode.CMSG_GUILD_BANKER_ACTIVATE, 0x0372},// SkyFire
            {Opcode.CMSG_GUILD_BANK_BUY_TAB, 0x0251},
            {Opcode.CMSG_GUILD_BANK_DEPOSIT_MONEY, 0x0770},
            {Opcode.CMSG_GUILD_BANK_LOG_QUERY, 0x0CD3},
            {Opcode.CMSG_GUILD_BANK_MONEY_WITHDRAWN_QUERY, 0x14DB},// SkyFire
            {Opcode.CMSG_GUILD_BANK_NOTE, 0x04D9},// SkyFire
            {Opcode.CMSG_GUILD_BANK_QUERY_TAB, 0x1372},
            {Opcode.CMSG_GUILD_BANK_QUERY_TEXT, 0x0550},// SkyFire
            {Opcode.CMSG_GUILD_BANK_SWAP_ITEMS, 0x136A},
            {Opcode.CMSG_GUILD_BANK_UPDATE_TAB, 0x07C2},
            {Opcode.CMSG_GUILD_BANK_WITHDRAW_MONEY, 0x07EA},
            {Opcode.CMSG_GUILD_DECLINE, 0x147B},// SkyFire
            {Opcode.CMSG_GUILD_DEL_RANK, 0x0D79},// SkyFire
            {Opcode.CMSG_GUILD_DEMOTE, 0x1553},// SkyFire
            {Opcode.CMSG_GUILD_DISBAND, 0x0D73},
            {Opcode.CMSG_GUILD_EVENT_LOG_QUERY, 0x15D9},
            {Opcode.CMSG_GUILD_INFO_TEXT, 0x0C70},
            {Opcode.CMSG_GUILD_INVITE, 0x0869},
            {Opcode.CMSG_GUILD_LEAVE, 0x04D8},
            {Opcode.CMSG_GUILD_MOTD, 0x1473},
            {Opcode.CMSG_GUILD_NEWS_UPDATE_STICKY, 0x04D1},
            {Opcode.CMSG_GUILD_PERMISSIONS, 0x145A},// SkyFire
            {Opcode.CMSG_GUILD_PROMOTE, 0x0571},// SkyFire
            {Opcode.CMSG_GUILD_QUERY, 0x1AB6},// SkyFire
            {Opcode.CMSG_GUILD_QUERY_NEWS, 0x1C58},
            {Opcode.CMSG_GUILD_QUERY_RANKS, 0x0D50},// SkyFire
            {Opcode.CMSG_GUILD_REMOVE, 0x0CD8},// SkyFire
            {Opcode.CMSG_GUILD_REPLACE_GUILD_MASTER, 0x0CD0},
            {Opcode.CMSG_GUILD_REQUEST_CHALLENGE_UPDATE, 0x147A},
            {Opcode.CMSG_GUILD_ROSTER, 0x1459},// SkyFire
            {Opcode.CMSG_GUILD_SET_ACHIEVEMENT_TRACKING, 0x0CF0},
            {Opcode.CMSG_GUILD_SET_GUILD_MASTER, 0x1A83},
            {Opcode.CMSG_GUILD_SET_NOTE, 0x05DA},
            {Opcode.CMSG_GUILD_SET_RANK_PERMISSIONS, 0x0C7A},
            {Opcode.CMSG_GUILD_SWITCH_RANK, 0x0CD1},
            {Opcode.CMSG_IGNORE_TRADE, 0x0276},
            {Opcode.CMSG_INITIATE_TRADE, 0x0267},
            {Opcode.CMSG_INSPECT, 0x1259},
            {Opcode.CMSG_INSPECT_HONOR_STATS, 0x0882},// SkyFire
            {Opcode.CMSG_ITEM_REFUND_INFO, 0x1258},// SkyFire
            {Opcode.CMSG_JOIN_CHANNEL, 0x148E},// SkyFire
            {Opcode.CMSG_LEARN_PREVIEW_TALENTS_PET, 0x077B},
            {Opcode.CMSG_LEARN_TALENT, 0x02A7},
            {Opcode.CMSG_LEAVE_CHANNEL, 0x042A},// SkyFire
            {Opcode.CMSG_LFG_JOIN, 0x046B},
            {Opcode.CMSG_LFG_LOCK_INFO_REQUEST, 0x006B},// SkyFire
            {Opcode.CMSG_LFG_TELEPORT, 0x1AA6},
            {Opcode.CMSG_LF_GUILD_ADD_APPLICATION, 0x0C63},// SkyFire
            {Opcode.CMSG_LF_GUILD_BROWSE, 0x159A},
            {Opcode.CMSG_LF_GUILD_GET_APPLICATIONS, 0x0558},
            {Opcode.CMSG_LF_GUILD_GET_RECRUITS, 0x057A},
            {Opcode.CMSG_LF_GUILD_REMOVE_APPLICATION, 0x1C53},// SkyFire
            {Opcode.CMSG_LF_GUILD_SET_GUILD_POST, 0x1D9F},
            {Opcode.CMSG_LIST_INVENTORY, 0x02D8},
            {Opcode.CMSG_LOAD_SCREEN, 0x1DBD},// SkyFire
            {Opcode.CMSG_LOGOUT_CANCEL, 0x06C1},
            {Opcode.CMSG_LOGOUT_REQUEST, 0x1349},
            {Opcode.CMSG_LOG_DISCONNECT, 0x10B3},
            {Opcode.CMSG_LOOT, 0x1CE2},// SkyFire
            {Opcode.CMSG_LOOT_METHOD, 0x0DE1},// SkyFire
            {Opcode.CMSG_LOOT_MONEY, 0x02F6},
            {Opcode.CMSG_LOOT_RELEASE, 0x0840},
            {Opcode.CMSG_LOOT_ROLL, 0x15C2},
            {Opcode.CMSG_MAIL_CREATE_TEXT_ITEM, 0x1270},
            {Opcode.CMSG_MAIL_DELETE, 0x14E2},
            {Opcode.CMSG_MAIL_MARK_AS_READ, 0x0241},
            {Opcode.CMSG_MAIL_QUERY_NEXT_TIME, 0x077B},// SkyFire
            {Opcode.CMSG_MAIL_RETURN_TO_SENDER, 0x1FA8},
            {Opcode.CMSG_MAIL_TAKE_ITEM, 0x1371},
            {Opcode.CMSG_MAIL_TAKE_MONEY, 0x06FA},
            {Opcode.CMSG_MESSAGECHAT_ADDON_WHISPER, 0x0EBB},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_AFK, 0x0EAB},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_CHANNEL, 0x00BB},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_DND, 0x002E},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_EMOTE, 0x103E},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_GUILD, 0x0CAE},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_OFFICER, 0x0ABF},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_PARTY, 0x109A},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_RAID, 0x083E},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_RAID_WARNING, 0x16AB},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_SAY, 0x0A9A},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_WHISPER, 0x123E},// SkyFire
            {Opcode.CMSG_MESSAGECHAT_YELL, 0x04AA},// SkyFire
            {Opcode.CMSG_MINIMAP_PING, 0x0837},
            {Opcode.CMSG_MOUNTSPECIAL_ANIM, 0x0082},// SkyFire
            {Opcode.CMSG_MOVE_CHNG_TRANSPORT, 0x09DB},
            {Opcode.CMSG_MOVE_FEATHER_FALL_ACK, 0x08D0},
            {Opcode.CMSG_MOVE_FORCE_FLIGHT_SPEED_CHANGE_ACK, 0x09DA},
            {Opcode.CMSG_MOVE_FORCE_RUN_BACK_SPEED_CHANGE_ACK, 0x0158},
            {Opcode.CMSG_MOVE_FORCE_RUN_SPEED_CHANGE_ACK, 0x10F3},
            {Opcode.CMSG_MOVE_FORCE_SWIM_SPEED_CHANGE_ACK, 0x1853},
            {Opcode.CMSG_MOVE_FORCE_WALK_SPEED_CHANGE_ACK, 0x00DB},
            {Opcode.CMSG_MOVE_GRAVITY_DISABLE_ACK, 0x09D3},
            {Opcode.CMSG_MOVE_GRAVITY_ENABLE_ACK, 0x11D8},
            {Opcode.CMSG_MOVE_SET_CAN_FLY_ACK, 0x1052},
            {Opcode.CMSG_MOVE_SET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY_ACK, 0x11DB},
            {Opcode.CMSG_MOVE_SET_COLLISION_HEIGHT_ACK, 0x09FB},
            {Opcode.CMSG_MOVE_SPLINE_DONE, 0x11D9},
            {Opcode.CMSG_MOVE_TELEPORT_ACK, 0x0078},
            {Opcode.CMSG_MOVE_TIME_SKIPPED, 0x0150},
            {Opcode.CMSG_MOVE_WATER_WALK_ACK, 0x10F2},
            {Opcode.CMSG_NAME_QUERY, 0x0328},
            {Opcode.CMSG_REALM_NAME_QUERY, 0x1A16},// SkyFire
            {Opcode.CMSG_NPC_TEXT_QUERY, 0x0287},// SkyFire
            {Opcode.CMSG_OBJECT_UPDATE_FAILED, 0x1061},
            {Opcode.CMSG_OFFER_PETITION, 0x15BE},
            {Opcode.CMSG_OPENING_CINEMATIC, 0x0130},
            {Opcode.CMSG_OPEN_ITEM, 0x1D10},
            {Opcode.CMSG_OPT_OUT_OF_LOOT, 0x06E0},
            {Opcode.CMSG_PAGE_TEXT_QUERY, 0x1022},// SkyFire
            {Opcode.CMSG_PETITION_BUY, 0x12D9},
            {Opcode.CMSG_PETITION_DECLINE, 0x1279},
            {Opcode.CMSG_PETITION_RENAME, 0x1F9A},
            {Opcode.CMSG_PETITION_QUERY, 0x0255},
            {Opcode.CMSG_PETITION_SHOWLIST, 0x037B},// SkyFire
            {Opcode.CMSG_PETITION_SHOW_SIGNATURES, 0x136B},
            {Opcode.CMSG_PETITION_SIGN, 0x06DA},
            {Opcode.CMSG_PET_ABANDON, 0x07D0},
            {Opcode.CMSG_PET_ACTION, 0x025B},
            {Opcode.CMSG_PET_CAST_SPELL, 0x044D},
            {Opcode.CMSG_PET_NAME_QUERY, 0x1C62},// SkyFire
            {Opcode.CMSG_PET_RENAME, 0x0A32},
            {Opcode.CMSG_PET_SET_ACTION, 0x12E9},
            {Opcode.CMSG_PET_SPELL_AUTOCAST, 0x06F0},
            {Opcode.CMSG_PET_STOP_ATTACK, 0x065B},
            {Opcode.CMSG_PING, 0x0012},
            {Opcode.CMSG_PLAYED_TIME, 0x03F6},// SkyFire
            {Opcode.CMSG_PLAYER_LOGIN, 0x158F},
            {Opcode.CMSG_PLAYER_VEHICLE_ENTER, 0x0277},
            {Opcode.CMSG_PUSHQUESTTOPARTY, 0x03D2},// SkyFire
            {Opcode.CMSG_PVP_LOG_DATA, 0x14C2},
            {Opcode.CMSG_QUERY_GUILD_REWARDS, 0x06C4},// SkyFire
            {Opcode.CMSG_QUERY_GUILD_XP, 0x05F8},// SkyFire
            {Opcode.CMSG_QUERY_INSPECT_ACHIEVEMENTS, 0x0373},
            {Opcode.CMSG_QUERY_TIME, 0x0640},
            {Opcode.CMSG_QUESTGIVER_ACCEPT_QUEST, 0x06D1},// SkyFire
            {Opcode.CMSG_QUESTGIVER_CHOOSE_REWARD, 0x07CB},// SkyFire
            {Opcode.CMSG_QUESTGIVER_COMPLETE_QUEST, 0x0659},// SkyFire
            {Opcode.CMSG_QUESTGIVER_HELLO, 0x02DB},// SkyFire
            {Opcode.CMSG_QUESTGIVER_QUERY_QUEST, 0x12F0},// SkyFire
            {Opcode.CMSG_QUESTGIVER_REQUEST_REWARD, 0x0378},// SkyFire
            {Opcode.CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY, 0x02F1},// SkyFire
            {Opcode.CMSG_QUESTGIVER_STATUS_QUERY, 0x036A},// SkyFire
            {Opcode.CMSG_QUESTLOG_REMOVE_QUEST, 0x0779},// SkyFire
            {Opcode.CMSG_QUEST_CONFIRM_ACCEPT, 0x124B},
            {Opcode.CMSG_QUEST_NPC_QUERY, 0x1DAE},// SkyFire
            {Opcode.CMSG_QUEST_POI_QUERY, 0x10C2},
            {Opcode.CMSG_QUEST_QUERY, 0x02D5},// SkyFire
            {Opcode.CMSG_RAID_READY_CHECK, 0x0817},// SkyFire
            {Opcode.CMSG_RAID_READY_CHECK_CONFIRM, 0x158B},// SkyFire
            {Opcode.CMSG_RAID_TARGET_UPDATE, 0x0886},// SkyFire
            {Opcode.CMSG_RANDOM_ROLL, 0x08A3},
            {Opcode.CMSG_RANDOMIZE_CHAR_NAME, 0x0B1C},// SkyFire
            {Opcode.CMSG_READY_FOR_ACCOUNT_DATA_TIMES, 0x031C},
            {Opcode.CMSG_READ_ITEM, 0x0D00},
            {Opcode.CMSG_REALM_SPLIT, 0x18B2},
            {Opcode.CMSG_RECLAIM_CORPSE, 0x03D3},
            {Opcode.CMSG_REFORGE_ITEM, 0x0C4F},
            {Opcode.CMSG_REORDER_CHARACTERS, 0x08A7},
            {Opcode.CMSG_REPAIR_ITEM, 0x02C1},
            {Opcode.CMSG_REPOP_REQUEST, 0x134A},
            {Opcode.CMSG_REPORT_PVP_AFK, 0x06F9},// SkyFire
            {Opcode.CMSG_REQUEST_ACCOUNT_DATA, 0x1D8A},
            {Opcode.CMSG_REQUEST_CEMETERY_LIST, 0x06E4},
            {Opcode.CMSG_REQUEST_HOTFIX, 0x158D},
            {Opcode.CMSG_REQUEST_PARTY_MEMBER_STATS, 0x0806},
            {Opcode.CMSG_REQUEST_PVP_OPTIONS_ENABLED, 0x0A22},// SkyFire
            {Opcode.CMSG_REQUEST_PVP_REWARDS, 0x0375},
            {Opcode.CMSG_REQUEST_RATED_BG_INFO, 0x0826},
            {Opcode.CMSG_REQUEST_RESEARCH_HISTORY, 0x15E2},
            {Opcode.CMSG_RESET_FACTION_CHEAT, 0x10B6},
            {Opcode.CMSG_RESET_INSTANCES, 0x0C69},
            {Opcode.CMSG_RESURRECT_RESPONSE, 0x0B0C},
            {Opcode.CMSG_RETURN_TO_GRAVEYARD, 0x12EA},// SkyFire
            {Opcode.CMSG_ROLE_POLL_BEGIN, 0x1882},
            {Opcode.CMSG_SAVE_CUF_PROFILES, 0x06E6},
            {Opcode.CMSG_SELL_ITEM, 0x1358},
            {Opcode.CMSG_SELECT_FACTION, 0x0027},// SkyFire
            {Opcode.CMSG_SEND_MAIL, 0x1DBA},
            {Opcode.CMSG_SETSHEATHED, 0x0249},// SkyFire
            {Opcode.CMSG_SET_ACTIONBAR_TOGGLES, 0x0672},// SkyFire
            {Opcode.CMSG_SET_ACTION_BUTTON, 0x1F8C},
            {Opcode.CMSG_SET_ACTIVE_MOVER, 0x09F0},
            {Opcode.CMSG_SET_CONTACT_NOTES, 0x0937},
            {Opcode.CMSG_SET_CURRENCY_FLAGS, 0x03E4},
            {Opcode.CMSG_SET_DUNGEON_DIFFICULTY, 0x1A36},
            {Opcode.CMSG_SET_EVERYONE_IS_ASSISTANT, 0x01E1},
            {Opcode.CMSG_SET_FACTION_ATWAR, 0x027B},// SkyFire
            {Opcode.CMSG_SET_FACTION_INACTIVE, 0x0778},// SkyFire
            {Opcode.CMSG_SET_FACTION_NOTATWAR, 0x064B},// SkyFire
            {Opcode.CMSG_SET_PLAYER_DECLINED_NAMES, 0x09E2},
            {Opcode.CMSG_SET_PRIMARY_TALENT_TREE, 0x06C6},
            {Opcode.CMSG_SET_PVP, 0x02C5},
            {Opcode.CMSG_SET_SELECTION, 0x0740},
            {Opcode.CMSG_SET_TAXI_BENCHMARK_MODE, 0x0762},
            {Opcode.CMSG_SET_TITLE, 0x03C7},
            {Opcode.CMSG_SET_TRADE_CURRENCY, 0x0C44},
            {Opcode.CMSG_SET_TRADE_GOLD, 0x14E3},
            {Opcode.CMSG_SET_TRADE_ITEM, 0x03D5},
            {Opcode.CMSG_SET_WATCHED_FACTION, 0x06C9},
            {Opcode.CMSG_SHOWING_CLOAK, 0x02F2},
            {Opcode.CMSG_SHOWING_HELM, 0x126B},
            {Opcode.CMSG_SOCKET_GEMS, 0x02CB},
            {Opcode.CMSG_SPELLCLICK, 0x067A},// SkyFire
            {Opcode.CMSG_SPIRIT_HEALER_ACTIVATE, 0x0340},
            {Opcode.CMSG_SPLIT_ITEM, 0x02EC},
            {Opcode.CMSG_STANDSTATECHANGE, 0x03E6},// SkyFire
            {Opcode.CMSG_SUBMIT_BUG, 0x0861},// SkyFire
            {Opcode.CMSG_SUBMIT_COMPLAIN, 0x030D},// SkyFire
            {Opcode.CMSG_SUGGESTION_SUBMIT, 0x0A12},
            {Opcode.CMSG_SUMMON_RESPONSE, 0x0A33},
            {Opcode.CMSG_SWAP_INV_ITEM, 0x03DF},
            {Opcode.CMSG_SWAP_ITEM, 0x035D},
            {Opcode.CMSG_TAXI_NODE_STATUS_QUERY, 0x02E1},
            {Opcode.CMSG_TAXI_QUERY_AVAILABLE_NODES, 0x02E3},
            {Opcode.CMSG_TEXT_EMOTE, 0x07E9},// SkyFire
            {Opcode.CMSG_TIME_SYNC_RESP, 0x01DB},// SkyFire
            {Opcode.CMSG_TIME_SYNC_RESP_FAILED, 0x0058},// SkyFire
            {Opcode.CMSG_TOGGLE_PVP, 0x0644},
            {Opcode.CMSG_TOTEM_DESTROYED, 0x1263},
            {Opcode.CMSG_TRAINER_BUY_SPELL, 0x0352},
            {Opcode.CMSG_TRAINER_LIST, 0x034B},
            {Opcode.CMSG_TRANSMOGRIFY_ITEMS, 0x06D7},
            {Opcode.CMSG_TURN_IN_PETITION, 0x0673},
            {Opcode.CMSG_TUTORIAL_CLEAR, 0x0F23},
            {Opcode.CMSG_TUTORIAL_FLAG, 0x1D36},
            {Opcode.CMSG_TUTORIAL_RESET, 0x0307},
            {Opcode.CMSG_UNACCEPT_TRADE, 0x0023},
            {Opcode.CMSG_UNLEARN_SKILL, 0x0268},
            {Opcode.CMSG_UNREGISTER_ALL_ADDON_PREFIXES, 0x029F},// SkyFire
            {Opcode.CMSG_UPDATE_ACCOUNT_DATA, 0x0068},
            {Opcode.CMSG_USED_FOLLOW, 0x0374},
            {Opcode.CMSG_USE_ITEM, 0x1CC1},
            {Opcode.CMSG_VIOLENCE_LEVEL, 0x0040},
            {Opcode.CMSG_VOICE_SESSION_ENABLE, 0x15A9},
            {Opcode.CMSG_VOID_STORAGE_QUERY, 0x0140},
            {Opcode.CMSG_VOID_STORAGE_TRANSFER, 0x1440},
            {Opcode.CMSG_VOID_STORAGE_UNLOCK, 0x0444},// SkyFire
            {Opcode.CMSG_VOID_SWAP_ITEM, 0x0655},// SkyFire
            {Opcode.CMSG_WARDEN_DATA, 0x1816},
            {Opcode.CMSG_WHO, 0x18A3},
            {Opcode.CMSG_WORLD_STATE_UI_TIMER_UPDATE, 0x15AB},// SkyFire
            {Opcode.CMSG_WRAP_ITEM, 0x02DF},
            {Opcode.CMSG_CORPSE_QUERY, 0x1FBE},
            {Opcode.MSG_LIST_STABLED_PETS, 0x02CA},
            {Opcode.MSG_MOVE_FALL_LAND, 0x08FA},
            {Opcode.MSG_MOVE_HEARTBEAT, 0x01F2},
            {Opcode.MSG_MOVE_JUMP, 0x1153},
            {Opcode.MSG_MOVE_SET_FACING, 0x1050},
            {Opcode.MSG_MOVE_SET_PITCH, 0x017A},
            {Opcode.MSG_MOVE_SET_RUN_MODE, 0x0979},
            {Opcode.MSG_MOVE_SET_WALK_MODE, 0x08D1},
            {Opcode.MSG_MOVE_START_ASCEND, 0x11FA},
            {Opcode.MSG_MOVE_START_BACKWARD, 0x09D8},
            {Opcode.MSG_MOVE_START_DESCEND, 0x01D1},
            {Opcode.MSG_MOVE_START_FORWARD, 0x095A},
            {Opcode.MSG_MOVE_START_PITCH_DOWN, 0x08D8},
            {Opcode.MSG_MOVE_START_PITCH_UP, 0x00D8},
            {Opcode.MSG_MOVE_START_STRAFE_LEFT, 0x01F8},
            {Opcode.MSG_MOVE_START_STRAFE_RIGHT, 0x1058},
            {Opcode.MSG_MOVE_START_SWIM, 0x1858},
            {Opcode.MSG_MOVE_START_TURN_LEFT, 0x01D0},
            {Opcode.MSG_MOVE_START_TURN_RIGHT, 0x107B},
            {Opcode.MSG_MOVE_STOP, 0x08F1},
            {Opcode.MSG_MOVE_STOP_ASCEND, 0x115A},
            {Opcode.MSG_MOVE_STOP_PITCH, 0x007A},
            {Opcode.MSG_MOVE_STOP_STRAFE, 0x0171},
            {Opcode.MSG_MOVE_STOP_SWIM, 0x0950},
            {Opcode.MSG_MOVE_STOP_TURN, 0x1170},
            {Opcode.MSG_MOVE_WORLDPORT_ACK, 0x1FAD},
            {Opcode.MSG_QUERY_NEXT_MAIL_TIME, 0x089B},
            {Opcode.MSG_SET_RAID_DIFFICULTY, 0x0591},
        };

  private static readonly BiDictionary<Opcode, int> ServerOpcodes = new BiDictionary<Opcode, int>
        {
            {Opcode.SMSG_ACCOUNT_CRITERIA_UPDATE, 0x189E},
            {Opcode.SMSG_ACCOUNT_DATA_TIMES, 0x162B},
            {Opcode.SMSG_ACHIEVEMENT_EARNED, 0x080B},
            {Opcode.SMSG_ACTIVATE_TAXI_REPLY, 0x02A7},
            {Opcode.SMSG_ADDON_INFO, 0x160A},
            {Opcode.SMSG_AI_REACTION, 0x06AF},
            {Opcode.SMSG_ALL_ACCOUNT_CRITERIA, 0x0A9E},
            {Opcode.SMSG_ALL_ACHIEVEMENT_DATA, 0x180A},
            {Opcode.SMSG_AREA_TRIGGER_NO_CORPSE, 0x089E},
            {Opcode.SMSG_ATTACKER_STATE_UPDATE, 0x06AA},
            {Opcode.SMSG_ATTACK_START, 0x1A9E},
            {Opcode.SMSG_ATTACK_STOP, 0x12AF},
            {Opcode.SMSG_AUCTION_HELLO_RESPONSE, 0x10A7},
            {Opcode.SMSG_AURA_UPDATE, 0x0072},
            {Opcode.SMSG_AUTH_CHALLENGE, 0x0949},
            {Opcode.SMSG_AUTH_RESPONSE, 0x0ABA},
            {Opcode.SMSG_BARBER_SHOP_RESULT, 0x0C3F},
            {Opcode.SMSG_BATTLEFIELD_LIST, 0x160E},
            {Opcode.SMSG_BATTLEFIELD_MGR_EJECTED, 0x18C2},
            {Opcode.SMSG_BATTLEFIELD_MGR_ENTERING, 0x081B},
            {Opcode.SMSG_BATTLEFIELD_STATUS, 0x0433},
            {Opcode.SMSG_BATTLEFIELD_STATUS_ACTIVE, 0x1AAF},
            {Opcode.SMSG_BATTLEFIELD_STATUS_FAILED, 0x1140},
            {Opcode.SMSG_BATTLEFIELD_STATUS_NEED_CONFIRMATION, 0x1EAF},
            {Opcode.SMSG_BATTLEFIELD_STATUS_QUEUED, 0x122E},
            {Opcode.SMSG_BATTLEGROUND_PLAYER_JOINED, 0x1E2F},
            {Opcode.SMSG_BATTLEGROUND_PLAYER_LEFT, 0x0206},
            {Opcode.SMSG_BATTLE_PET_DELETED, 0x18AB},
            {Opcode.SMSG_BATTLE_PET_JOURNAL, 0x1542},
            {Opcode.SMSG_BATTLE_PET_JOURNAL_LOCK_ACQUIRED, 0x1A0F},
            {Opcode.SMSG_BATTLE_PET_JOURNAL_LOCK_DENIED, 0x0203},
            {Opcode.SMSG_QUERY_BATTLE_PET_NAME_RESPONSE, 0x1540},
            {Opcode.SMSG_BATTLE_PET_PET_UPDATES, 0x041A},
            {Opcode.SMSG_BATTLE_PET_SLOT_UPDATE, 0x16AF},
            {Opcode.SMSG_BINDER_CONFIRM, 0x1287},
            {Opcode.SMSG_BIND_POINT_UPDATE, 0x0E3B},
            {Opcode.SMSG_BLACK_MARKET_OPEN_RESULT, 0x00AE},
            {Opcode.SMSG_BUY_FAILED, 0x1563},
            {Opcode.SMSG_BUY_SUCCEEDED, 0x101A},
            {Opcode.SMSG_CANCEL_AUTO_REPEAT, 0x1E0F},
            {Opcode.SMSG_CANCEL_COMBAT, 0x0534},
            {Opcode.SMSG_CAST_FAILED, 0x143A},
            {Opcode.SMSG_CHANNEL_NOTIFY, 0x0F06},
            {Opcode.SMSG_CHAT, 0x1A9A},
            {Opcode.SMSG_SPELL_CHANNEL_START, 0x10F9},
            {Opcode.SMSG_SPELL_CHANNEL_UPDATE, 0x11D9},
            {Opcode.SMSG_CREATE_CHAR, 0x1CAA},
            {Opcode.SMSG_DELETE_CHAR, 0x0C9F},
            {Opcode.SMSG_ENUM_CHARACTERS_RESULT, 0x11C3},
            {Opcode.SMSG_CHAT_PLAYER_NOTFOUND, 0x1082},
            {Opcode.SMSG_CACHE_VERSION, 0x002A},
            {Opcode.SMSG_CONTROL_UPDATE, 0x1043},
            {Opcode.SMSG_CONTACT_LIST, 0x1F22},
            {Opcode.SMSG_CONVERT_RUNE, 0x1A1B},
            {Opcode.SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE, 0x1A3A},
            {Opcode.SMSG_CORPSE_QUERY_RESPONSE, 0x0E0B},
            {Opcode.SMSG_CORPSE_RECLAIM_DELAY, 0x022A},
            {Opcode.SMSG_QUERY_CREATURE_RESPONSE, 0x048B},
            {Opcode.SMSG_CRITERIA_UPDATE, 0x0E9B},
            {Opcode.SMSG_DB_REPLY, 0x103B},
            {Opcode.SMSG_DEATH_RELEASE_LOC, 0x1063},
            {Opcode.SMSG_DEFENSE_MESSAGE, 0x0A1F},
            {Opcode.SMSG_DESTROY_OBJECT, 0x14C2},
            {Opcode.SMSG_DUEL_COMPLETE, 0x1C0A},
            {Opcode.SMSG_DUEL_COUNTDOWN, 0x129F},
            {Opcode.SMSG_DUEL_IN_BOUNDS, 0x163A},
            {Opcode.SMSG_DUEL_OUT_OF_BOUNDS, 0x001A},
            {Opcode.SMSG_DUEL_REQUESTED, 0x0022},
            {Opcode.SMSG_DUEL_WINNER, 0x10E1},
            {Opcode.SMSG_EMOTE, 0x0987},
            {Opcode.SMSG_ENABLE_BARBER_SHOP, 0x1222},
            {Opcode.SMSG_ENVIRONMENTAL_DAMAGE_LOG, 0x0DF1},
            {Opcode.SMSG_EXPLORATION_EXPERIENCE, 0x189A},
            {Opcode.SMSG_FEATURE_SYSTEM_STATUS, 0x16BB},
            {Opcode.SMSG_FLIGHT_SPLINE_SYNC, 0x0063},
            {Opcode.SMSG_FRIEND_STATUS, 0x0532},
            {Opcode.SMSG_QUERY_GAME_OBJECT_RESPONSE, 0x06BF},
            {Opcode.SMSG_GAME_STORE_INGAME_BUY_FAILED, 0x023A},
            {Opcode.SMSG_GOSSIP_COMPLETE, 0x034E},
            {Opcode.SMSG_GOSSIP_MESSAGE, 0x0244},
            {Opcode.SMSG_GOSSIP_POI, 0x0785},
            {Opcode.SMSG_GROUP_DECLINE, 0x17A3},
            {Opcode.SMSG_GROUP_DESTROYED, 0x1B27},
            {Opcode.SMSG_GROUP_INVITE, 0x0A8F},
            {Opcode.SMSG_GROUP_LIST, 0x0CBB},
            {Opcode.SMSG_GROUP_SET_LEADER, 0x18BF},
            {Opcode.SMSG_GROUP_SET_ROLE, 0x1E1F},
            {Opcode.SMSG_GUILD_BANK_QUERY_RESULTS, 0x0B79},
            {Opcode.SMSG_GUILD_BANK_LOG_QUERY_RESULTS, 0x0FF0},
            {Opcode.SMSG_GUILD_CHALLENGE_UPDATE, 0x0AE9},
            {Opcode.SMSG_GUILD_COMMAND_RESULT, 0x0EF1},
            {Opcode.SMSG_GUILD_EVENT_LOG_QUERY_RESULTS, 0x1AF1},
            {Opcode.SMSG_GUILD_INVITE, 0x0F71},
            {Opcode.SMSG_GUILD_INVITE_CANCEL, 0x0FE1},
            {Opcode.SMSG_GUILD_MEMBER_DAILY_RESET, 0x1BE8},
            {Opcode.SMSG_GUILD_NEWS_UPDATE, 0x0AE8},
            {Opcode.SMSG_QUERY_GUILD_INFO_RESPONSE, 0x1B79},
            {Opcode.SMSG_GUILD_RANKS, 0x0A79},
            {Opcode.SMSG_GUILD_REPUTATION_WEEKLY_CAP, 0x1A71},
            {Opcode.SMSG_GUILD_REWARD_LIST, 0x1A69},
            {Opcode.SMSG_GUILD_ROSTER, 0x0BE0},
            {Opcode.SMSG_GUILD_SEND_RANK_CHANGE, 0x0A60},
            {Opcode.SMSG_GUILD_SET_NOTE, 0x0BE1},
            {Opcode.SMSG_GUILD_XP, 0x0AF0},
            {Opcode.SMSG_GUILD_XP_GAIN, 0x0FE0},
            {Opcode.SMSG_HIGHEST_THREAT_UPDATE, 0x14AE},
            {Opcode.SMSG_HOTFIX_NOTIFY_BLOB, 0x1EBA},
            {Opcode.SMSG_SEND_KNOWN_SPELLS, 0x045A},
            {Opcode.SMSG_INIT_WORLD_STATES, 0x1560},
            {Opcode.SMSG_INSPECT_RESULTS_UPDATE, 0x1842},
            {Opcode.SMSG_INSTANCE_RESET, 0x160F},
            {Opcode.SMSG_INVENTORY_CHANGE_FAILURE, 0x0C1E},
            {Opcode.SMSG_ITEM_ENCHANT_TIME_UPDATE, 0x10A2},
            {Opcode.SMSG_ITEM_PUSH_RESULT, 0x0E0A},
            {Opcode.SMSG_ITEM_TIME_UPDATE, 0x18C1},
            {Opcode.SMSG_LEARNED_SPELLS, 0x129A},
            {Opcode.SMSG_LEVEL_UP_INFO, 0x1961},
            {Opcode.SMSG_LFG_JOIN_RESULT, 0x18E3},
            {Opcode.SMSG_LFG_PLAYER_INFO, 0x1861},
            {Opcode.SMSG_LFG_QUEUE_STATUS, 0x0C2E},
            {Opcode.SMSG_VENDOR_INVENTORY, 0x1AAE},
            {Opcode.SMSG_LOAD_CUF_PROFILES, 0x0E32},
            {Opcode.SMSG_LOAD_EQUIPMENT_SET, 0x18E2},
            {Opcode.SMSG_LOGIN_SET_TIME_SPEED, 0x082B},
            {Opcode.SMSG_LOGIN_VERIFY_WORLD, 0x1C0F},
            {Opcode.SMSG_LOGOUT_CANCEL_ACK, 0x0AAF},
            {Opcode.SMSG_LOGOUT_COMPLETE, 0x142F},
            {Opcode.SMSG_LOGOUT_RESPONSE, 0x008F},
            {Opcode.SMSG_LOG_XP_GAIN, 0x1E9A},
            {Opcode.SMSG_LOOT_CLEAR_MONEY, 0x1632},
            {Opcode.SMSG_LOOT_MONEY_NOTIFY, 0x14C0},
            {Opcode.SMSG_LOOT_RELEASE, 0x123F},
            {Opcode.SMSG_LOOT_REMOVED, 0x0C3E},
            {Opcode.SMSG_LOOT_RESPONSE, 0x128A},
            {Opcode.SMSG_MAIL_LIST_RESULT, 0x1C0B},
            {Opcode.SMSG_MINIMAP_PING, 0x168F},
            {Opcode.SMSG_MOTD, 0x183B},
            {Opcode.SMSG_MOVE_ROOT, 0x15AE},
            {Opcode.SMSG_MOVE_SET_ACTIVE_MOVER, 0x0C6D},
            {Opcode.SMSG_MOVE_SET_CAN_FLY, 0x178D},
            {Opcode.SMSG_MOVE_SET_FLIGHT_SPEED, 0x006E},
            {Opcode.SMSG_MOVE_SET_RUN_SPEED, 0x184C},
            {Opcode.SMSG_MOVE_SET_SWIM_SPEED, 0x0817},
            {Opcode.SMSG_MOVE_SPLINE_SET_FLIGHT_SPEED, 0x1DAB},
            {Opcode.SMSG_MOVE_SPLINE_SET_RUN_BACK_SPEED, 0x1F9F},
            {Opcode.SMSG_MOVE_SPLINE_SET_RUN_SPEED, 0x02F1},
            {Opcode.SMSG_MOVE_SPLINE_SET_SWIM_SPEED, 0x1D8E},
            {Opcode.SMSG_MOVE_SPLINE_SET_WALK_BACK_SPEED, 0x08B2},
            {Opcode.SMSG_MOVE_TELEPORT, 0x0B39},
            {Opcode.SMSG_MOVE_UNROOT, 0x1FAE},
            {Opcode.SMSG_MOVE_UNSET_CAN_FLY, 0x0162},
            {Opcode.SMSG_MOVE_UPDATE, 0x1A32},
            {Opcode.SMSG_QUERY_PLAYER_NAME_RESPONSE, 0x169B},
            {Opcode.SMSG_NEW_WORLD, 0x1C3B},
            {Opcode.SMSG_NOTIFICATION, 0x0C2A},
            {Opcode.SMSG_QUERY_NPC_TEXT_RESPONSE, 0x140A},
            {Opcode.SMSG_ON_MONSTER_MOVE, 0x1A07},
            {Opcode.SMSG_QUERY_PAGE_TEXT_RESPONSE, 0x081E},
            {Opcode.SMSG_PARTY_COMMAND_RESULT, 0x0F86},
            {Opcode.SMSG_PARTY_MEMBER_STATS, 0x0A9A},
            {Opcode.SMSG_SPELL_PERIODIC_AURA_LOG, 0x0CF2},
            {Opcode.SMSG_PETITION_ALREADY_SIGNED, 0x0286},
            {Opcode.SMSG_PETITION_QUERY_RESPONSE, 0x1083},
            {Opcode.SMSG_PETITION_RENAME_RESPONSE, 0x082A},
            {Opcode.SMSG_PETITION_SHOW_LIST, 0x10A3},
            {Opcode.SMSG_PETITION_SHOW_SIGNATURES, 0x00AA},
            {Opcode.SMSG_PETITION_SIGN_RESULTS, 0x06AE},
            {Opcode.SMSG_QUERY_PET_NAME_RESPONSE, 0x0ABE},
            {Opcode.SMSG_PET_SPELLS_MESSAGE, 0x095A},
            {Opcode.SMSG_PLAYED_TIME, 0x11E2},
            {Opcode.SMSG_PLAYER_BOUND, 0x1B60},
            {Opcode.SMSG_PLAY_OBJECT_SOUND, 0x1443},
            {Opcode.SMSG_PLAY_SOUND, 0x102A},
            {Opcode.SMSG_PLAY_SPELL_VISUAL_KIT, 0x11E3},
            {Opcode.SMSG_PONG, 0x1969},
            {Opcode.SMSG_POWER_UPDATE, 0x109F},
            {Opcode.SMSG_PVP_LOG_DATA, 0x1E8F},
            {Opcode.SMSG_PVP_SEASON, 0x069B},
            {Opcode.SMSG_QUERY_TIME_RESPONSE, 0x100F},
            {Opcode.SMSG_QUEST_GIVER_OFFER_REWARD_MESSAGE, 0x074F},
            {Opcode.SMSG_QUEST_GIVER_QUEST_COMPLETE, 0x0346},
            {Opcode.SMSG_QUEST_GIVER_QUEST_DETAILS, 0x134C},
            {Opcode.SMSG_QUEST_GIVER_QUEST_LIST_MESSAGE, 0x02D4},
            {Opcode.SMSG_QUEST_GIVER_REQUEST_ITEMS, 0x0277},
            {Opcode.SMSG_QUEST_GIVER_STATUS, 0x1275},
            {Opcode.SMSG_QUEST_GIVER_STATUS_MULTIPLE, 0x06CE},
            {Opcode.SMSG_QUEST_CONFIRM_ACCEPT, 0x13C7},
            {Opcode.SMSG_QUEST_LOG_FULL, 0x07FD},
            {Opcode.SMSG_QUEST_POI_QUERY_RESPONSE, 0x067F},
            {Opcode.SMSG_QUERY_QUEST_INFO_RESPONSE, 0x0276},
            {Opcode.SMSG_QUEST_UPDATE_ADD_KILL, 0x1645},
            {Opcode.SMSG_QUEST_UPDATE_COMPLETE, 0x0776},
            {Opcode.SMSG_GENERATE_RANDOM_CHARACTER_NAME_RESULT, 0x169F},
            {Opcode.SMSG_RANDOM_ROLL, 0x141A},
            {Opcode.SMSG_READY_CHECK_COMPLETED, 0x15C2},
            {Opcode.SMSG_READY_CHECK_RESPONSE, 0x02AF},
            {Opcode.SMSG_READY_CHECK_STARTED, 0x1C8E},
            {Opcode.SMSG_READ_ITEM_RESULT_OK, 0x0305},
            {Opcode.SMSG_REALM_QUERY_RESPONSE, 0x063E},
            {Opcode.SMSG_REAL_GROUP_UPDATE, 0x0000},
            {Opcode.SMSG_CONNECT_TO, 0x1149},
            {Opcode.SMSG_REFORGE_RESULT, 0x141E},
            {Opcode.SMSG_REQUEST_PVP_REWARDS_RESPONSE, 0x08AA},
            {Opcode.SMSG_RESUME_COMMS, 0x0969},
            {Opcode.SMSG_SELL_ITEM, 0x048E},
            {Opcode.SMSG_MAIL_COMMAND_RESULT, 0x1A9B},
            {Opcode.SMSG_SEND_UNLEARN_SPELLS, 0x10F1},
            {Opcode.SMSG_CHAT_SERVER_MESSAGE, 0x0302},
            {Opcode.SMSG_SETUP_CURRENCY, 0x1A8B},
            {Opcode.SMSG_SET_DUNGEON_DIFFICULTY, 0x1283},
            {Opcode.SMSG_SET_FACTION_STANDING, 0x10AA},
            {Opcode.SMSG_SET_FLAT_SPELL_MODIFIER, 0x10F2},
            {Opcode.SMSG_SET_FORCED_REACTIONS, 0x068F},
            {Opcode.SMSG_SET_PCT_SPELL_MODIFIER, 0x09D3},
            {Opcode.SMSG_PHASE_SHIFT_CHANGE, 0x02A2},
            {Opcode.SMSG_SET_PROFICIENCY, 0x1440},
            {Opcode.SMSG_RAID_DIFFICULTY_SET, 0x0591},
            {Opcode.SMSG_SET_TIME_ZONE_INFORMATION, 0x19C1},
            {Opcode.SMSG_SHOW_BANK, 0x0007},
            {Opcode.SMSG_SHOW_TAXI_NODES, 0x1E1A},
            {Opcode.SMSG_CATEGORY_COOLDOWN, 0x01DB},
            {Opcode.SMSG_SPELL_COOLDOWN, 0x0452},
            {Opcode.SMSG_SPELL_DELAYED, 0x087A},
            {Opcode.SMSG_SPELL_DISPELL_LOG, 0x0DF9},
            {Opcode.SMSG_SPELL_ENERGIZE_LOG, 0x0D79},
            {Opcode.SMSG_SPELL_EXECUTE_LOG, 0x00D8},
            {Opcode.SMSG_SPELL_FAILED_OTHER, 0x040B},
            {Opcode.SMSG_SPELL_FAILURE, 0x04AF},
            {Opcode.SMSG_SPELL_GO, 0x09D8},
            {Opcode.SMSG_SPELL_HEAL_LOG, 0x09FB},
            {Opcode.SMSG_SPELL_NON_MELEE_DAMAGE_LOG, 0x1450},
            {Opcode.SMSG_SPELL_START, 0x107A},
            {Opcode.SMSG_STAND_STATE_UPDATE, 0x1C12},
            {Opcode.SMSG_START_TIMER, 0x0E3F},
            {Opcode.SMSG_SUSPEND_COMMS, 0x1D48},
            {Opcode.SMSG_UPDATE_TALENT_DATA, 0x0A9B},
            {Opcode.SMSG_TEXT_EMOTE, 0x02E},
            {Opcode.SMSG_THREAT_CLEAR, 0x180B},
            {Opcode.SMSG_THREAT_REMOVE, 0x1960},
            {Opcode.SMSG_THREAT_UPDATE, 0x0632},
            {Opcode.SMSG_TIME_SYNC_REQUEST, 0x1A8F},
            {Opcode.SMSG_TRAINER_LIST, 0x189F},
            {Opcode.SMSG_TRANSFER_PENDING, 0x061B},
            {Opcode.SMSG_TRIGGER_CINEMATIC, 0x0B01},
            {Opcode.SMSG_TRIGGER_MOVIE, 0x1C2E},
            {Opcode.SMSG_TURN_IN_PETITION_RESULT, 0x0E13},
            {Opcode.SMSG_TUTORIAL_FLAGS, 0x1B90},
            {Opcode.SMSG_UI_TIME, 0x0027},
            {Opcode.SMSG_UNLEARNED_SPELLS, 0x14C3},
            {Opcode.SMSG_UPDATE_ACCOUNT_DATA, 0x0AAE},
            {Opcode.SMSG_UPDATE_ACTION_BUTTONS, 0x081A},
            {Opcode.SMSG_UPDATE_LAST_INSTANCE, 0x189B},
            {Opcode.SMSG_UPDATE_OBJECT, 0x1792},
            {Opcode.SMSG_UPDATE_WORLD_STATE, 0x121B},
            {Opcode.SMSG_VIGNETTE_UPDATE, 0x0CBE},
            {Opcode.SMSG_VOID_ITEM_SWAP_RESPONSE, 0x1EBF},
            {Opcode.SMSG_VOID_STORAGE_CONTENTS, 0x008B},
            {Opcode.SMSG_VOID_STORAGE_FAILED, 0x1569},
            {Opcode.SMSG_VOID_STORAGE_TRANSFER_CHANGES, 0x14BA},
            {Opcode.SMSG_VOID_TRANSFER_RESULT, 0x1C9E},
            {Opcode.SMSG_WARDEN_DATA, 0x0C0A},
            {Opcode.SMSG_WEATHER, 0x06AB},
            {Opcode.SMSG_WHO, 0x161B},
            {Opcode.SMSG_WORLD_SERVER_INFO, 0x0082},
            {Opcode.SMSG_ZONE_UNDER_ATTACK, 0x10C2}
        };

  private static readonly BiDictionary<Opcode, int> MiscOpcodes = new BiDictionary<Opcode, int>
        {
            {Opcode.MSG_MOVE_FALL_LAND, 0x08FA},
            {Opcode.MSG_MOVE_HEARTBEAT, 0x01F2},
            {Opcode.MSG_MOVE_JUMP, 0x1153},
            {Opcode.MSG_MOVE_SET_FACING, 0x1050},
            {Opcode.MSG_MOVE_SET_PITCH, 0x017A},
            {Opcode.MSG_MOVE_SET_RUN_MODE, 0x0979},
            {Opcode.MSG_MOVE_SET_WALK_MODE, 0x08D1},
            {Opcode.MSG_MOVE_START_ASCEND, 0x11FA},
            {Opcode.MSG_MOVE_START_BACKWARD, 0x09D8},
            {Opcode.MSG_MOVE_START_DESCEND, 0x01D1},
            {Opcode.MSG_MOVE_START_FORWARD, 0x095A},
            {Opcode.MSG_MOVE_START_PITCH_DOWN, 0x08D8},
            {Opcode.MSG_MOVE_START_PITCH_UP, 0x00D8},
            {Opcode.MSG_MOVE_START_STRAFE_LEFT, 0x01F8},
            {Opcode.MSG_MOVE_START_STRAFE_RIGHT, 0x1058},
            {Opcode.MSG_MOVE_START_SWIM, 0x1858},
            {Opcode.MSG_MOVE_START_TURN_LEFT,0x01D0},
            {Opcode.MSG_MOVE_START_TURN_RIGHT, 0x107B},
            {Opcode.MSG_MOVE_STOP, 0x08F1},
            {Opcode.MSG_MOVE_STOP_ASCEND, 0x115A},
            {Opcode.MSG_MOVE_STOP_PITCH, 0x007A},
            {Opcode.MSG_MOVE_STOP_STRAFE, 0x0171},
            {Opcode.MSG_MOVE_STOP_SWIM, 0x0950},
            {Opcode.MSG_MOVE_STOP_TURN, 0x1170},
            {Opcode.MSG_MOVE_WORLDPORT_ACK, 0x1FAD},
            {Opcode.MSG_VERIFY_CONNECTIVITY, 0x4F57}
        };
 }
}
