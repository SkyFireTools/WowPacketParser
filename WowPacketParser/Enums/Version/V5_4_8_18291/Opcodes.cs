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
            //{Opcode.CMSG_DB_QUERY_BULK, 0x158D}, Check
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
            // {Opcode.CMSG_GROUP_INITIATE_ROLE_POLL, 0x1882},// SkyFire Check
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
            //{Opcode.CMSG_LEARN_PREVIEW_TALENTS_PET, 0x077B}, Check out
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
            //{Opcode.CMSG_MAIL_QUERY_NEXT_TIME, 0x077B},// SkyFire Check out
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
            //{Opcode.CMSG_REQUEST_HOTFIX, 0x158D}, Check
            {Opcode.CMSG_REQUEST_PARTY_MEMBER_STATS, 0x0806},
            {Opcode.CMSG_REQUEST_PVP_OPTIONS_ENABLED, 0x0A22},// SkyFire
            {Opcode.CMSG_REQUEST_PVP_REWARDS, 0x0375},
            {Opcode.CMSG_REQUEST_RATED_BG_INFO, 0x0826},
            {Opcode.CMSG_REQUEST_RESEARCH_HISTORY, 0x15E2},
            {Opcode.CMSG_RESET_FACTION_CHEAT, 0x10B6},
            {Opcode.CMSG_RESET_INSTANCES, 0x0C69},
            {Opcode.CMSG_RESURRECT_RESPONSE, 0x0B0C},
            {Opcode.CMSG_RETURN_TO_GRAVEYARD, 0x12EA},// SkyFire
            //{Opcode.CMSG_ROLE_POLL_BEGIN, 0x1882}, Check
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
        };

  private static readonly BiDictionary<Opcode, int> ServerOpcodes = new BiDictionary<Opcode, int>
        {
            {Opcode.SMSG_ACCOUNT_DATA_TIMES, 0x162B},
            {Opcode.SMSG_ACHIEVEMENT_DELETED, 0x1A2F},
            {Opcode.SMSG_ACHIEVEMENT_EARNED, 0x080B},
            {Opcode.SMSG_ACTION_BUTTONS, 0x081A},// SkyFire
            {Opcode.SMSG_ACTIVATE_TAXI_REPLY, 0x02A7},
            {Opcode.SMSG_ADDON_INFO, 0x160A},
            {Opcode.SMSG_ADD_RUNE_POWER, 0x1860},
            {Opcode.SMSG_AI_REACTION, 0x06AF},
            {Opcode.SMSG_ALL_ACHIEVEMENT_DATA, 0x180A},
            {Opcode.SMSG_ARCHAEOLOGY_SURVERY_CAST, 0x1160},
            {Opcode.SMSG_AREA_SPIRIT_HEALER_TIME, 0x188E},
            {Opcode.SMSG_ATTACKERSTATEUPDATE, 0x06AA},// SkyFire
            {Opcode.SMSG_ATTACKSTART, 0x1A9E},// SkyFire
            {Opcode.SMSG_ATTACKSTOP, 0x12AF},// SkyFire
            {Opcode.SMSG_AUCTION_BIDDER_LIST_RESULT, 0x0B24},// SkyFire
            {Opcode.SMSG_AUCTION_BIDDER_NOTIFICATION, 0x11C1},
            {Opcode.SMSG_AUCTION_COMMAND_RESULT, 0x1002},
            {Opcode.SMSG_AUCTION_HELLO, 0x10A7},// SkyFire
            {Opcode.SMSG_AUCTION_LIST_RESULT, 0x0982},
            {Opcode.SMSG_AUCTION_OWNER_LIST_RESULT, 0x1785},// SkyFire
            {Opcode.SMSG_AUCTION_OWNER_NOTIFICATION, 0x1A8E},
            {Opcode.SMSG_AURA_POINTS_DEPLETED, 0x1553},
            {Opcode.SMSG_AURA_UPDATE, 0x0072},
            {Opcode.SMSG_AUTH_CHALLENGE, 0x0949},
            {Opcode.SMSG_AUTH_RESPONSE, 0x0ABA},
            {Opcode.SMSG_AVAILABLE_VOICE_CHANNEL, 0x029A},
            {Opcode.SMSG_BARBER_SHOP_RESULT, 0x0C3F},
            {Opcode.SMSG_BATTLEFIELD_LIST, 0x160E},
            {Opcode.SMSG_BATTLEFIELD_MGR_EJECTED, 0x18C2},
            {Opcode.SMSG_BATTLEFIELD_MGR_EJECT_PENDING, 0x003E},
            {Opcode.SMSG_BATTLEFIELD_MGR_ENTERED, 0x081B},// SkyFire
            {Opcode.SMSG_BATTLEFIELD_MGR_ENTRY_INVITE, 0x1226},
            {Opcode.SMSG_BATTLEFIELD_MGR_QUEUE_INVITE, 0x142E},
            {Opcode.SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE, 0x08BE},
            {Opcode.SMSG_BATTLEFIELD_MGR_STATE_CHANGE, 0x083A},
            {Opcode.SMSG_BATTLEFIELD_PORT_DENIED, 0x149A},
            {Opcode.SMSG_BATTLEFIELD_RATED_INFO, 0x0EBA},
            {Opcode.SMSG_BATTLEFIELD_STATUS, 0x0433},
            {Opcode.SMSG_BATTLEFIELD_STATUS_QUEUED, 0x122E},
            {Opcode.SMSG_BATTLEFIELD_STATUS_ACTIVE, 0x1AAF},
            {Opcode.SMSG_BATTLEFIELD_STATUS_NEEDCONFIRMATION, 0x1EAF},// SkyFire
            {Opcode.SMSG_BATTLEFIELD_STATUS_WAITFORGROUPS, 0x10A6},// SkyFire
            {Opcode.SMSG_BATTLEFIELD_STATUS_FAILED, 0x1140},
            {Opcode.SMSG_BATTLEGROUND_INFO_THROTTLED, 0x1E1E},
            {Opcode.SMSG_BATTLEGROUND_PLAYER_JOINED, 0x1E2F},
            {Opcode.SMSG_BATTLEGROUND_PLAYER_LEFT, 0x0206},
            {Opcode.SMSG_BATTLE_PET_DELETED, 0x18AB},
            {Opcode.SMSG_BATTLE_PET_JOURNAL, 0x1542},
            {Opcode.SMSG_BATTLE_PET_JOURNAL_LOCK_ACQUIRED, 0x1A0F},
            {Opcode.SMSG_BATTLE_PET_JOURNAL_LOCK_DENINED, 0x0203},// SkyFire
            {Opcode.SMSG_BATTLE_PET_QUERY_NAME_RESPONSE, 0x1540},// SkyFire
            {Opcode.SMSG_BATTLE_PET_SLOT_UPDATE, 0x16AF},
            {Opcode.SMSG_BATTLE_PET_UPDATE, 0x041A},// SkyFire
            {Opcode.SMSG_BINDER_CONFIRM, 0x1287},
            {Opcode.SMSG_BINDPOINTUPDATE, 0x0E3B},// SkyFire
            {Opcode.SMSG_BLACKMARKET_HELLO, 0x00AE},// SkyFire
            {Opcode.SMSG_BLACKMARKET_REQUEST_ITEMS_RESULT, 0x128B},// SkyFire
            {Opcode.SMSG_BLACKMARKET_BID_RESULT, 0x148A},// SkyFire
            {Opcode.SMSG_BLACKMARKET_OUT_BID, 0x1040},// SkyFire
            {Opcode.SMSG_BLACKMARKET_BID_WON, 0x1060},// SkyFire
            {Opcode.SMSG_BREAK_TARGET, 0x021A},
            {Opcode.SMSG_BUY_FAILED, 0x1563},
            {Opcode.SMSG_BUY_ITEM, 0x101A},// SkyFire
            {Opcode.SMSG_CALENDAR_CLEAR_PENDING_ACTION, 0x1E3A},
            {Opcode.SMSG_CALENDAR_COMMAND_RESULT, 0x142A},
            {Opcode.SMSG_CALENDAR_EVENT_INITIAL_INVITE, 0x16AE},// SkyFire
            {Opcode.SMSG_CALENDAR_EVENT_INVITE, 0x15C3},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_ALERT, 0x0A9F},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_NOTES, 0x11C0},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_NOTES_ALERT, 0x1286},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_REMOVED, 0x00A2},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_REMOVED_ALERT, 0x122B},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_STATUS, 0x1C9B},
            {Opcode.SMSG_CALENDAR_EVENT_INVITE_STATUS_ALERT, 0x0412},
            {Opcode.SMSG_CALENDAR_EVENT_MODERATOR_STATUS, 0x048F},// SkyFire
            {Opcode.SMSG_CALENDAR_EVENT_REMOVED_ALERT, 0x049B},
            {Opcode.SMSG_CALENDAR_EVENT_UPDATED_ALERT, 0x0A0E},
            {Opcode.SMSG_CALENDAR_RAID_LOCKOUT_ADDED, 0x0CAB},
            {Opcode.SMSG_CALENDAR_RAID_LOCKOUT_REMOVED, 0x11E0},
            {Opcode.SMSG_CALENDAR_RAID_LOCKOUT_UPDATED, 0x0E1F},
            {Opcode.SMSG_CALENDAR_SEND_CALENDAR, 0x1A0A},
            {Opcode.SMSG_CALENDAR_SEND_EVENT, 0x12AE},
            {Opcode.SMSG_CALENDAR_SEND_NUM_PENDING, 0x0A3F},
            {Opcode.SMSG_CAMERA_SHAKE, 0x0C3A},
            {Opcode.SMSG_CANCEL_AUTO_REPEAT, 0x1E0F},
            {Opcode.SMSG_CANCEL_COMBAT, 0x0534},
            {Opcode.SMSG_CAST_FAILED, 0x143A},
            {Opcode.SMSG_CHANNEL_NOTIFY, 0x0F06},
            {Opcode.SMSG_CHARACTER_LOGIN_FAILED, 0x1A0B},
            {Opcode.SMSG_CHAR_CREATE, 0x1CAA},// SkyFire
            {Opcode.SMSG_CHAR_CUSTOMIZE, 0x1432},
            {Opcode.SMSG_CHAR_DELETE, 0x0C9F},// SkyFire
            {Opcode.SMSG_CHAR_ENUM, 0x11C3},// SkyFire
            {Opcode.SMSG_CHAR_RENAME, 0x0CBF},// SkyFire
            {Opcode.SMSG_CHAT_IGNORED_ACCOUNT_MUTED, 0x0C3B},
            {Opcode.SMSG_CHAT_NOT_IN_PARTY, 0x0A8A},
            {Opcode.SMSG_CHAT_PLAYER_AMBIGUOUS, 0x061A},
            {Opcode.SMSG_CHAT_PLAYER_NOT_FOUND, 0x1082},
            {Opcode.SMSG_CHAT_RESTRICTED, 0x1A3B},
            {Opcode.SMSG_CHAT_SERVER_RECONNECTED, 0x0A2E},
            {Opcode.SMSG_CLEAR_BOSS_EMOTES, 0x062B},
            {Opcode.SMSG_CLEAR_COOLDOWNS, 0x1458},
            {Opcode.SMSG_CLEAR_TARGET, 0x1061},
            {Opcode.SMSG_CLIENTCACHE_VERSION, 0x002A},// SkyFire
            {Opcode.SMSG_CLIENT_CONTROL_UPDATE, 0x1043},// SkyFire
            {Opcode.SMSG_COMBAT_EVENT_FAILED, 0x18C3},// SkyFire
            {Opcode.SMSG_COMPLAIN_RESULT, 0x128F},// SkyFire
            {Opcode.SMSG_CONTACT_LIST, 0x1F22},
            {Opcode.SMSG_CONVERT_RUNE, 0x1A1B},
            {Opcode.SMSG_COOLDOWN_CHEAT, 0x0432},
            {Opcode.SMSG_COOLDOWN_EVENT, 0x162A},
            {Opcode.SMSG_CORPSE_MAP_POSITION_QUERY_RESPONSE, 0x1A3A},
            {Opcode.SMSG_CORPSE_NOT_IN_INSTANCE, 0x089E},// SkyFire
            {Opcode.SMSG_CORPSE_QUERY, 0x0E0B},// SkyFire
            {Opcode.SMSG_CORPSE_RECLAIM_DELAY, 0x022A},
            {Opcode.SMSG_CREATURE_QUERY_RESPONSE, 0x048B},// SkyFire
            {Opcode.SMSG_CRITERIA_DELETED, 0x1C33},
            {Opcode.SMSG_CRITERIA_UPDATE, 0x0E9B},
            {Opcode.SMSG_CROSSED_INEBRIATION_THRESHOLD, 0x1E9E},
            {Opcode.SMSG_CUSTOM_LOAD_SCREEN, 0x1CAF},
            {Opcode.SMSG_DB_REPLY, 0x103B},
            {Opcode.SMSG_DEATH_RELEASE_LOC, 0x1063},
            {Opcode.SMSG_DEBUG_RUNE_REGEN, 0x12A7},// SkyFire
            {Opcode.SMSG_DEFENSE_MESSAGE, 0x0A1F},
            {Opcode.SMSG_DESTROY_OBJECT, 0x14C2},
            {Opcode.SMSG_DESTRUCTIBLE_BUILDING_DAMAGE, 0x14BF},
            {Opcode.SMSG_DIFFERENT_INSTANCE_FROM_PARTY, 0x120B},
            {Opcode.SMSG_DISENCHANT_CREDIT, 0x10BB},
            {Opcode.SMSG_DISMOUNT, 0x0E3A},
            {Opcode.SMSG_DISMOUNTRESULT, 0x062F},// SkyFire
            {Opcode.SMSG_DISPEL_FAILED, 0x085B},
            {Opcode.SMSG_DISPLAY_GAME_ERROR, 0x181F},
            {Opcode.SMSG_DONT_AUTO_PUSH_SPELLS_TO_ACTION_BAR, 0x1C8B},
            {Opcode.SMSG_DUEL_COMPLETE, 0x1C0A},
            {Opcode.SMSG_DUEL_COUNTDOWN, 0x129F},
            {Opcode.SMSG_DUEL_INBOUNDS, 0x163A},// SkyFire
            {Opcode.SMSG_DUEL_OUTOFBOUNDS, 0x001A},// SkyFire
            {Opcode.SMSG_DUEL_REQUESTED, 0x0022},
            {Opcode.SMSG_DUEL_WINNER, 0x10E1},
            {Opcode.SMSG_DURABILITY_DAMAGE_DEATH, 0x1E3E},
            {Opcode.SMSG_EMOTE, 0x0987},
            {Opcode.SMSG_ENABLE_BARBER_SHOP, 0x1222},
            {Opcode.SMSG_ENCHANTMENT_LOG, 0x12A3},
            {Opcode.SMSG_ENVIRONMENTALDAMAGELOG, 0x0DF1},// SkyFire
            {Opcode.SMSG_EQUIPMENT_SET_ID, 0x0006},
            {Opcode.SMSG_EXPECTED_SPAM_RECORDS, 0x18C0},
            {Opcode.SMSG_EXPLORATION_EXPERIENCE, 0x189A},
            {Opcode.SMSG_FAILED_PLAYER_CONDITION, 0x1223},
            {Opcode.SMSG_FEATURE_SYSTEM_STATUS, 0x16BB},
            {Opcode.SMSG_FEIGN_DEATH_RESISTED, 0x029E},
            {Opcode.SMSG_FISH_ESCAPED, 0x0227},
            {Opcode.SMSG_FISH_NOT_HOOKED, 0x10BE},
            {Opcode.SMSG_FLIGHT_SPLINE_SYNC, 0x0063},
            {Opcode.SMSG_FORCED_DEATH_UPDATE, 0x0E8F},
            {Opcode.SMSG_FORCE_SEND_QUEUED_PACKETS, 0x0969},// SkyFire
            //{Opcode.SMSG_FORCE_SET_VEHICLE_REC_ID, 0x149F}, Check
            {Opcode.SMSG_FRIEND_STATUS, 0x0532},
            {Opcode.SMSG_GAMEOBJECT_CUSTOM_ANIM, 0x001F},// SkyFire
            {Opcode.SMSG_GAMEOBJECT_DESPAWN_ANIM, 0x108B},
            {Opcode.SMSG_GAMEOBJECT_PAGETEXT, 0x14AF},// SkyFire
            {Opcode.SMSG_GAMEOBJECT_QUERY_RESPONSE, 0x06BF},// SkyFire
            {Opcode.SMSG_GAMEOBJECT_RESET_STATE, 0x100E},// SkyFire
            {Opcode.SMSG_GAMETIME_SET, 0x0A0F},// SkyFire
            {Opcode.SMSG_GAMETIME_UPDATE, 0x0E1B},// SkyFire
            {Opcode.SMSG_GAME_OBJECT_ACTIVATE_ANIM_KIT, 0x0C8A},
            {Opcode.SMSG_GM_TICKET_RESPONSE, 0x0207},
            {Opcode.SMSG_GM_TICKET_UPDATE, 0x02A6},
            {Opcode.SMSG_GM_TICKET_GET_TICKET, 0x129B},
            {Opcode.SMSG_GM_TICKET_SYSTEM_STATUS, 0x163B},
            {Opcode.SMSG_GM_TICKET_CASE_STATUS, 0x148E},
            {Opcode.SMSG_GM_TICKET_STATUS_UPDATE, 0x000B},
            {Opcode.SMSG_GM_PLAYER_INFO, 0x102B},
            {Opcode.SMSG_GODMODE, 0x1862},// SkyFire
            {Opcode.SMSG_GOSSIP_COMPLETE, 0x034E},
            {Opcode.SMSG_GOSSIP_MESSAGE, 0x0244},
            {Opcode.SMSG_GOSSIP_POI, 0x0785},
            {Opcode.SMSG_GROUPACTION_THROTTLED, 0x0287},// SkyFire
            {Opcode.SMSG_GROUP_DECLINE, 0x17A3},
            {Opcode.SMSG_GROUP_DESTROYED, 0x1B27},
            {Opcode.SMSG_GROUP_INVITE, 0x0A8F},
            {Opcode.SMSG_GROUP_LIST, 0x0CBB},
            //{Opcode.SMSG_GROUP_ROLE_POLL_INFORM, 0x1007},// SkyFire Check
            {Opcode.SMSG_GROUP_SET_LEADER, 0x18BF},
            {Opcode.SMSG_GROUP_SET_ROLE, 0x1E1F},
            {Opcode.SMSG_GUILD_ACHIEVEMENT_DATA, 0x0EF8},// SkyFire
            {Opcode.SMSG_GUILD_ACHIEVEMENT_DELETED, 0x1E61},
            {Opcode.SMSG_GUILD_ACHIEVEMENT_EARNED, 0x1BF1},
            {Opcode.SMSG_GUILD_ACHIEVEMENT_MEMBERS, 0x1B70},
            {Opcode.SMSG_GUILD_BANK_LIST, 0x0B79},// SkyFire
            {Opcode.SMSG_GUILD_BANK_LOG_QUERY_RESULT, 0x0FF0},// SkyFire
            {Opcode.SMSG_GUILD_BANK_MONEY_WITHDRAWN, 0x0B78},// SkyFire
            {Opcode.SMSG_GUILD_BANK_QUERY_TEXT_RESULT, 0x1AE0},// SkyFire
            {Opcode.SMSG_GUILD_CHALLENGE_COMPLETED, 0x1AF8},
            {Opcode.SMSG_GUILD_CHALLENGE_UPDATED, 0x0AE9},// SkyFire
            {Opcode.SMSG_GUILD_CHANGE_NAME_RESULT, 0x0BE9},
            {Opcode.SMSG_GUILD_COMMAND_RESULT, 0x0EF1},
            {Opcode.SMSG_GUILD_CRITERIA_DATA, 0x1BF0},
            {Opcode.SMSG_GUILD_CRITERIA_DELETED, 0x1B60},
            {Opcode.SMSG_GUILD_DECLINE, 0x1AF9},
            {Opcode.SMSG_GUILD_EVENT_BANK_MONEY_CHANGED, 0x0F68},
            {Opcode.SMSG_GUILD_EVENT_BANK_TAB_ADDED, 0x1BE9},// SkyFire
            {Opcode.SMSG_GUILD_EVENT_BANK_TAB_TEXT_CHANGED, 0x0A70},// SkyFire
            {Opcode.SMSG_GUILD_EVENT_BANK_TAB_MODIFIED, 0x0BF1},// SkyFire
            {Opcode.SMSG_GUILD_EVENT_LOG_QUERY_RESULT, 0x1AF1},// SkyFire
            {Opcode.SMSG_GUILD_FLAGGED_FOR_RENAME, 0x0FE9},
            {Opcode.SMSG_GUILD_INVITE, 0x0F71},
            {Opcode.SMSG_GUILD_INVITE_CANCEL, 0x0FE1},
            {Opcode.SMSG_GUILD_MAX_DAILY_XP, 0x1BE1},
            {Opcode.SMSG_GUILD_MEMBERS_FOR_RECIPE, 0x0BF0},
            {Opcode.SMSG_GUILD_MEMBER_DAILY_RESET, 0x1BE8},
            {Opcode.SMSG_GUILD_MEMBER_RECIPES, 0x0EE1},
            {Opcode.SMSG_GUILD_MEMBER_UPDATE_NOTE, 0x0BE1},
            {Opcode.SMSG_GUILD_MOVE_COMPLETE, 0x0BE8},
            {Opcode.SMSG_GUILD_MOVE_STARTING, 0x0AE1},
            {Opcode.SMSG_GUILD_NEWS_DELETED, 0x0F70},
            {Opcode.SMSG_GUILD_NEWS_UPDATE, 0x0AE8},
            {Opcode.SMSG_GUILD_PARTY_STATE_RESPONSE, 0x0A78},// SkyFire
            {Opcode.SMSG_GUILD_PERMISSIONS_QUERY_RESULTS, 0x0FF9},// SkyFire
            {Opcode.SMSG_GUILD_QUERY_RESPONSE, 0x1B79},// SkyFire
            {Opcode.SMSG_GUILD_RANK, 0x0A79},// SkyFire
            {Opcode.SMSG_GUILD_RANKS_UPDATE, 0x0A60},// SkyFire
            {Opcode.SMSG_GUILD_RECIPES, 0x0FF1},// SkyFire
            {Opcode.SMSG_GUILD_RENAMED, 0x0E70},
            {Opcode.SMSG_GUILD_REPUTATION_REACTION_CHANGED, 0x0E71},
            {Opcode.SMSG_GUILD_REPUTATION_WEEKLY_CAP, 0x1A71},
            {Opcode.SMSG_GUILD_RESET, 0x1AF0},
            {Opcode.SMSG_GUILD_REWARDS_LIST, 0x1A69},// SkyFire
            {Opcode.SMSG_GUILD_ROSTER, 0x0BE0},
            {Opcode.SMSG_GUILD_SET_GUILD_MASTER, 0x0E69},// SkyFire
            {Opcode.SMSG_GUILD_UPDATE_ROSTER, 0x0AF1},// SkyFire
            {Opcode.SMSG_GUILD_XP, 0x0AF0},
            {Opcode.SMSG_GUILD_XP_GAIN, 0x0FE0},
            {Opcode.SMSG_HEALTH_UPDATE, 0x148B},
            {Opcode.SMSG_HIGHEST_THREAT_UPDATE, 0x14AE},
            {Opcode.SMSG_HOTFIX_INFO, 0x1EBA},// SkyFire
            {Opcode.SMSG_HOTFIX_NOTIFY, 0x0EBF},
            {Opcode.SMSG_INITIALIZE_FACTIONS, 0x0AAA},
            {Opcode.SMSG_INITIAL_SPELLS, 0x045A},// SkyFire
            {Opcode.SMSG_INIT_CURRENCY, 0x1A8B},// SkyFire
            {Opcode.SMSG_INIT_WORLD_STATES, 0x1560},
            {Opcode.SMSG_INSPECT_HONOR_STATS, 0x1A1E},
            {Opcode.SMSG_INSPECT_RESULTS, 0x1842},// SkyFire
            {Opcode.SMSG_INSTANCE_RESET, 0x160F},
            {Opcode.SMSG_INSTANCE_RESET_FAILED, 0x0026},
            {Opcode.SMSG_INSTANCE_SAVE_CREATED, 0x1EAE},
            {Opcode.SMSG_INVALIDATE_PLAYER, 0x102E},
            {Opcode.SMSG_INVALID_PROMOTION_CODE, 0x1A0E},
            {Opcode.SMSG_INVENTORY_CHANGE_FAILURE, 0x0C1E},
            {Opcode.SMSG_ITEM_ADD_PASSIVE, 0x161A},
            {Opcode.SMSG_ITEM_ENCHANT_TIME_UPDATE, 0x10A2},
            {Opcode.SMSG_ITEM_EXPIRE_PURCHASE_REFUND, 0x0E33},
            {Opcode.SMSG_ITEM_PURCHASE_REFUND_RESULT, 0x049E},
            {Opcode.SMSG_ITEM_PUSH_RESULT, 0x0E0A},
            {Opcode.SMSG_ITEM_REMOVE_PASSIVE, 0x0A2F},
            {Opcode.SMSG_ITEM_SEND_PASSIVE, 0x122F},
            {Opcode.SMSG_ITEM_TIME_UPDATE, 0x18C1},
            {Opcode.SMSG_LEARNED_SPELL, 0x129A},
            {Opcode.SMSG_LEVELUP_INFO, 0x1961},// SkyFire
            {Opcode.SMSG_LFG_DISABLED, 0x008E},
            {Opcode.SMSG_LFG_JOIN_RESULT, 0x18E3},
            {Opcode.SMSG_LFG_OFFER_CONTINUE, 0x1EAB},
            {Opcode.SMSG_LFG_PARTY_INFO, 0x168E},
            {Opcode.SMSG_LFG_PLAYER_INFO, 0x1861},
            {Opcode.SMSG_LFG_PLAYER_REWARD, 0x121A},
            {Opcode.SMSG_LFG_PROPOSAL_UPDATE, 0x1E3B},
            {Opcode.SMSG_LFG_QUEUE_STATUS, 0x1006},
            {Opcode.SMSG_LFG_ROLE_CHECK_UPDATE, 0x12BB},
            {Opcode.SMSG_LFG_ROLE_CHOSEN, 0x1A1F},
            {Opcode.SMSG_LFG_SLOT_INVALID, 0x0C12},
            {Opcode.SMSG_LFG_TELEPORT_DENIED, 0x063B},
            {Opcode.SMSG_LFG_UPDATE_SEARCH, 0x1161},
            {Opcode.SMSG_LFG_UPDATE_STATUS, 0x0C2E},
            {Opcode.SMSG_LF_GUILD_APPLICANT_LIST_UPDATED, 0x0B71},// SkyFire
            {Opcode.SMSG_LF_GUILD_APPLICATIONS_LIST_CHANGED, 0x1A70},
            {Opcode.SMSG_LF_GUILD_BROWSE_UPDATED, 0x0F69},
            {Opcode.SMSG_LF_GUILD_COMMAND_RESULT, 0x1A79},
            {Opcode.SMSG_LF_GUILD_MEMBERSHIP_LIST_UPDATED, 0x0AE0},
            {Opcode.SMSG_LF_GUILD_POST_UPDATED, 0x1B71},
            {Opcode.SMSG_LF_GUILD_RECRUIT_LIST_UPDATED, 0x0E68},
            {Opcode.SMSG_LIST_INVENTORY, 0x1AAE},// SkyFire
            {Opcode.SMSG_LOAD_CUF_PROFILES, 0x0E32},
            {Opcode.SMSG_LOAD_EQUIPMENT_SET, 0x18E2},
            {Opcode.SMSG_LOGIN_SETTIMESPEED, 0x082B},// SkyFire
            {Opcode.SMSG_LOGIN_VERIFY_WORLD, 0x1C0F},
            {Opcode.SMSG_LOGOUT_CANCEL_ACK, 0x0AAF},
            {Opcode.SMSG_LOGOUT_COMPLETE, 0x142F},
            {Opcode.SMSG_LOGOUT_RESPONSE, 0x008F},
            {Opcode.SMSG_LOG_XPGAIN, 0x1E9A},// SkyFire
            {Opcode.SMSG_LOOT_ALL_PASSED, 0x0EBB},
            {Opcode.SMSG_LOOT_CLEAR_MONEY, 0x1632},
            {Opcode.SMSG_LOOT_CONTENTS, 0x121F},
            {Opcode.SMSG_LOOT_ITEM_NOTIFY, 0x080F},
            {Opcode.SMSG_LOOT_LIST, 0x1C3F},
            {Opcode.SMSG_LOOT_MASTER_LIST, 0x02BF},
            {Opcode.SMSG_LOOT_MONEY_NOTIFY, 0x14C0},
            {Opcode.SMSG_LOOT_RELEASE_RESPONSE, 0x123F},// SkyFire
            {Opcode.SMSG_LOOT_REMOVED, 0x0C3E},
            {Opcode.SMSG_LOOT_RESPONSE, 0x128A},
            {Opcode.SMSG_LOOT_ROLL, 0x1840},
            {Opcode.SMSG_LOOT_ROLL_WON, 0x0A3A},
            {Opcode.SMSG_LOOT_START_ROLL, 0x0EAA},
            {Opcode.SMSG_MAIL_LIST_RESULT, 0x1C0B},
            {Opcode.SMSG_MAP_OBJ_EVENTS, 0x00BB},
            {Opcode.SMSG_MESSAGECHAT, 0x1A9A},// SkyFire
            {Opcode.SMSG_MESSAGE_BOX, 0x02AE},
            {Opcode.SMSG_MINIMAP_PING, 0x168F},
            {Opcode.SMSG_MIRROR_IMAGE_COMPONENTED_DATA, 0x04D9},
            {Opcode.SMSG_MIRROR_IMAGE_CREATURE_DATA, 0x04D0},
            {Opcode.SMSG_MISSILE_CANCEL, 0x1203},
            {Opcode.SMSG_MODIFY_COOLDOWN, 0x1E2E},
            {Opcode.SMSG_MONEY_NOTIFY, 0x0C0F},
            {Opcode.SMSG_MONSTER_MOVE, 0x1A07},// SkyFire
            {Opcode.SMSG_MOTD, 0x183B},
            {Opcode.SMSG_MOUNTRESULT, 0x0E0F},// SkyFire
            {Opcode.SMSG_MOUNTSPECIAL_ANIM, 0x003A},// SkyFire
            //{Opcode.SMSG_MOVE_COLLISION_DISABLE, 0x15B8},// SkyFire Check
            //{Opcode.SMSG_MOVE_COLLISION_ENABLE, 0x1826},// SkyFire Check
            {Opcode.SMSG_MOVE_FEATHER_FALL, 0x0C60},// SkyFire
            {Opcode.SMSG_MOVE_GRAVITY_DISABLE, 0x159F},// SkyFire
            {Opcode.SMSG_MOVE_GRAVITY_ENABLE, 0x0A27},// SkyFire
            {Opcode.SMSG_MOVE_KNOCK_BACK, 0x0562},
            {Opcode.SMSG_MOVE_LAND_WALK, 0x086A},// SkyFire
            {Opcode.SMSG_MOVE_NORMAL_FALL, 0x08E0},// SkyFire
            {Opcode.SMSG_MOVE_ROOT, 0x15AE},
            {Opcode.SMSG_MOVE_SET_ACTIVE_MOVER, 0x0C6D},
            {Opcode.SMSG_MOVE_SET_CAN_FLY, 0x178D},
            {Opcode.SMSG_MOVE_SET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY, 0x11DB},// SkyFire
            {Opcode.SMSG_MOVE_SET_COLLISION_HEIGHT, 0x0250},
            {Opcode.SMSG_MOVE_SET_COMPOUND_STATE, 0x0061},
            {Opcode.SMSG_MOVE_SET_FLIGHT_BACK_SPEED, 0x0319},
            {Opcode.SMSG_MOVE_SET_FLIGHT_SPEED, 0x006E},
            {Opcode.SMSG_MOVE_SET_HOVER, 0x1802},// SkyFire
            {Opcode.SMSG_MOVE_SET_PITCH_RATE, 0x17AB},
            {Opcode.SMSG_MOVE_SET_RUN_BACK_SPEED, 0x0A83},
            {Opcode.SMSG_MOVE_SET_RUN_SPEED, 0x184C},
            {Opcode.SMSG_MOVE_SET_SWIM_BACK_SPEED, 0x0962},
            {Opcode.SMSG_MOVE_SET_SWIM_SPEED, 0x0817},
            {Opcode.SMSG_MOVE_SET_TURN_RATE, 0x0069},
            {Opcode.SMSG_MOVE_SET_VEHICLE_REC_ID, 0x0861},
            {Opcode.SMSG_MOVE_SET_WALK_SPEED, 0x0469},
            {Opcode.SMSG_MOVE_TELEPORT, 0x0B39},
            {Opcode.SMSG_MOVE_UNROOT, 0x1FAE},
            {Opcode.SMSG_MOVE_UNSET_CAN_FLY, 0x0162},
            {Opcode.SMSG_MOVE_UNSET_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY, 0x0868},// SkyFire
            {Opcode.SMSG_MOVE_UNSET_HOVER, 0x02D3},// SkyFire
            {Opcode.SMSG_MOVE_UPDATE_COLLISION_HEIGHT, 0x1812},
            {Opcode.SMSG_MOVE_UPDATE_FLIGHT_BACK_SPEED, 0x036A},
            {Opcode.SMSG_MOVE_UPDATE_FLIGHT_SPEED, 0x00E1},
            {Opcode.SMSG_MOVE_UPDATE_KNOCK_BACK, 0x0251},
            {Opcode.SMSG_MOVE_UPDATE_PITCH_RATE, 0x09E2},
            {Opcode.SMSG_MOVE_UPDATE_RUN_BACK_SPEED, 0x08A3},
            {Opcode.SMSG_MOVE_UPDATE_RUN_SPEED, 0x158E},
            {Opcode.SMSG_MOVE_UPDATE_SWIM_BACK_SPEED, 0x025A},
            {Opcode.SMSG_MOVE_UPDATE_SWIM_SPEED, 0x01E2},
            {Opcode.SMSG_MOVE_UPDATE_TELEPORT, 0x15A9},
            {Opcode.SMSG_MOVE_UPDATE_TURN_RATE, 0x0D62},
            {Opcode.SMSG_MOVE_UPDATE_WALK_SPEED, 0x0047},
            {Opcode.SMSG_MOVE_WATER_WALK, 0x1F9A},// SkyFire
            {Opcode.SMSG_NAME_QUERY_RESPONSE, 0x169B},// SkyFire
            {Opcode.SMSG_REALM_NAME_QUERY_RESPONSE, 0x063E},// SkyFire
            {Opcode.SMSG_NEW_TAXI_PATH, 0x141B},
            {Opcode.SMSG_NEW_WORLD, 0x1C3B},
            {Opcode.SMSG_NEW_WORLD_ABORT, 0x0C1B},
            {Opcode.SMSG_NOTIFICATION, 0x0C2A},
            {Opcode.SMSG_NOTIFY_DEST_LOC_SPELL_CAST, 0x1E0E},
            {Opcode.SMSG_NPC_TEXT_UPDATE, 0x140A},
            {Opcode.SMSG_OFFER_PETITION_ERROR, 0x161E},
            {Opcode.SMSG_ON_CANCEL_EXPECTED_RIDE_VEHICLE_AURA, 0x1A2A},
            {Opcode.SMSG_OPEN_CONTAINER, 0x14BB},
            {Opcode.SMSG_OPEN_LFG_DUNGEON_FINDER, 0x0E8A},
            {Opcode.SMSG_OVERRIDE_LIGHT, 0x068A},
            {Opcode.SMSG_PAGE_TEXT_QUERY_RESPONSE, 0x081E},// SkyFire
            {Opcode.SMSG_PARTYKILLLOG, 0x048A},// SkyFire
            {Opcode.SMSG_PARTY_COMMAND_RESULT, 0x0F86},
            {Opcode.SMSG_PARTY_MEMBER_STATS, 0x0A9A},
            {Opcode.SMSG_PAUSE_MIRROR_TIMER, 0x162E},
            {Opcode.SMSG_PETGODMODE, 0x1940},
            {Opcode.SMSG_PETITION_ALREADY_SIGNED, 0x0286},
            {Opcode.SMSG_PETITION_QUERY_RESPONSE, 0x1083},
            {Opcode.SMSG_PETITION_RENAME_RESULT, 0x082A},// SkyFire
            {Opcode.SMSG_PETITION_SHOWLIST, 0x10A3},// SkyFire
            {Opcode.SMSG_PETITION_SHOW_SIGNATURES, 0x00AA},
            {Opcode.SMSG_PETITION_SIGN_RESULTS, 0x06AE},
            {Opcode.SMSG_PET_ACTION_FEEDBACK, 0x080E},
            {Opcode.SMSG_PET_ACTION_SOUND, 0x15E2},
            {Opcode.SMSG_PET_ADDED, 0x123A},
            {Opcode.SMSG_PET_CAST_FAILED, 0x149B},
            {Opcode.SMSG_PET_DISMISS_SOUND, 0x1ABB},
            {Opcode.SMSG_PET_GUIDS, 0x1227},
            {Opcode.SMSG_PET_LEARNED_SPELL, 0x0282},// SkyFire
            {Opcode.SMSG_PET_MODE, 0x163F},
            {Opcode.SMSG_PET_NAME_INVALID, 0x028E},
            {Opcode.SMSG_PET_NAME_QUERY_RESPONSE, 0x0ABE},// SkyFire
            {Opcode.SMSG_PET_REMOVED_SPELL, 0x1CAE},// SkyFire
            {Opcode.SMSG_PET_SLOT_UPDATED, 0x069A},
            {Opcode.SMSG_PET_SPELLS_MESSAGE, 0x095A},
            {Opcode.SMSG_PET_TAME_FAILURE, 0x040E},
            {Opcode.SMSG_PLAYED_TIME, 0x11E2},
            {Opcode.SMSG_PLAYERBOUND, 0x088E},// SkyFire
            {Opcode.SMSG_PLAYER_DIFFICULTY_CHANGE, 0x128E},
            {Opcode.SMSG_PLAYER_MOVE, 0x1A32},// SkyFire
            {Opcode.SMSG_PLAYER_SKINNED, 0x1463},
            {Opcode.SMSG_PLAY_MUSIC, 0x0023},
            {Opcode.SMSG_PLAY_OBJECT_SOUND, 0x1443},
            {Opcode.SMSG_PLAY_ONE_SHOT_ANIM_KIT, 0x043E},
            {Opcode.SMSG_PLAY_SOUND, 0x102A},
            {Opcode.SMSG_PLAY_SPELL_VISUAL, 0x061E},
            {Opcode.SMSG_PLAY_SPELL_VISUAL_KIT, 0x11E3},
            {Opcode.SMSG_PLAY_TIME_WARNING, 0x062A},
            {Opcode.SMSG_PONG, 0x1969},
            {Opcode.SMSG_POWER_UPDATE, 0x109F},
            {Opcode.SMSG_PRE_RESURRECT, 0x19C0},// SkyFire
            {Opcode.SMSG_PROCRESIST, 0x12BE},// SkyFire
            {Opcode.SMSG_PROPOSE_LEVEL_GRANT, 0x109A},
            {Opcode.SMSG_PVP_CREDIT, 0x100A},
            {Opcode.SMSG_PVP_LOG_DATA, 0x1E8F},
            {Opcode.SMSG_PVP_OPTIONS_ENABLED, 0x080A},
            {Opcode.SMSG_PVP_SEASON, 0x069B},
            {Opcode.SMSG_QUERY_TIME_RESPONSE, 0x100F},
            {Opcode.SMSG_QUESTGIVER_OFFER_REWARD, 0x074F},// SkyFire
            {Opcode.SMSG_QUESTGIVER_QUEST_COMPLETE, 0x0346},// SkyFire
            {Opcode.SMSG_QUESTGIVER_QUEST_DETAILS, 0x134C},// SkyFire
            {Opcode.SMSG_QUESTGIVER_QUEST_FAILED, 0x12DE},// SkyFire
            {Opcode.SMSG_QUESTGIVER_QUEST_INVALID, 0x027D},// SkyFire
            {Opcode.SMSG_QUESTGIVER_QUEST_LIST, 0x02D4},// SkyFire
            {Opcode.SMSG_QUESTGIVER_REQUEST_ITEMS, 0x0277},// SkyFire
            {Opcode.SMSG_QUESTGIVER_STATUS, 0x1275},// SkyFire
            {Opcode.SMSG_QUESTGIVER_STATUS_MULTIPLE, 0x06CE},// SkyFire
            {Opcode.SMSG_QUESTLOG_FULL, 0x07FD},// SkyFire
            {Opcode.SMSG_QUESTUPDATE_ADD_CREDIT, 0x1645},// SkyFire
            {Opcode.SMSG_QUESTUPDATE_ADD_PVP_KILL, 0x0256},// SkyFire
            {Opcode.SMSG_QUESTUPDATE_COMPLETE, 0x0776},// SkyFire
            {Opcode.SMSG_QUESTUPDATE_FAILED, 0x07DD},// SkyFire
            {Opcode.SMSG_QUESTUPDATE_FAILEDTIMER, 0x06FF},// SkyFire
            {Opcode.SMSG_QUEST_CONFIRM_ACCEPT, 0x13C7},
            {Opcode.SMSG_QUEST_FORCE_REMOVE, 0x07C5},// SkyFire
            {Opcode.SMSG_QUEST_NPC_QUERY_RESPONSE, 0x036D},// SkyFire
            {Opcode.SMSG_QUEST_POI_QUERY_RESPONSE, 0x067F},
            {Opcode.SMSG_QUEST_PUSH_RESULT, 0x074D},
            {Opcode.SMSG_QUEST_QUERY_RESPONSE, 0x0276},// SkyFire
            {Opcode.SMSG_RAID_INSTANCE_INFO, 0x16BF},
            {Opcode.SMSG_RAID_INSTANCE_MESSAGE, 0x0CAF},
            {Opcode.SMSG_RAID_MARKERS_CHANGED, 0x008A},
            {Opcode.SMSG_RAID_READY_CHECK, 0x1C8E},// SkyFire
            {Opcode.SMSG_RAID_READY_CHECK_COMPLETED, 0x15C2},// SkyFire
            {Opcode.SMSG_RAID_READY_CHECK_CONFIRM, 0x02AF},// SkyFire
            {Opcode.SMSG_RAID_SUMMON_FAILED, 0x108A},
            {Opcode.SMSG_RAID_TARGET_UPDATE_ALL, 0x0283},// SkyFire
            {Opcode.SMSG_RAID_TARGET_UPDATE_SINGLE, 0x160B},// SkyFire
            {Opcode.SMSG_RANDOM_ROLL, 0x141A},
            {Opcode.SMSG_RANDOMIZE_CHAR_NAME, 0x169F},// SkyFire
            {Opcode.SMSG_READ_ITEM_RESULT_FAILED, 0x0E8B},
            {Opcode.SMSG_READ_ITEM_RESULT_OK, 0x0305},
            {Opcode.SMSG_REALM_SPLIT, 0x1A2E},
            {Opcode.SMSG_RECEIVED_MAIL, 0x182B},
            {Opcode.SMSG_REDIRECT_CLIENT, 0x1149},// SkyFire
            {Opcode.SMSG_REFER_A_FRIEND_EXPIRED, 0x1143},
            {Opcode.SMSG_REFER_A_FRIEND_FAILURE, 0x021E},
            {Opcode.SMSG_REFORGE_RESULT, 0x141E},
            {Opcode.SMSG_REMOVED_SPELL, 0x14C3},// SkyFire
            {Opcode.SMSG_REPORT_PVP_AFK_RESULT, 0x18BE},
            {Opcode.SMSG_REQUEST_CEMETERY_LIST_RESPONSE, 0x042A},
            {Opcode.SMSG_REQUEST_PVP_REWARDS_RESPONSE, 0x08AA},
            {Opcode.SMSG_RESEARCH_COMPLETE, 0x0C0E},
            {Opcode.SMSG_RESEARCH_SETUP_HISTORY, 0x08AB},// SkyFire
            {Opcode.SMSG_RESET_FAILED_NOTIFY, 0x10AE},
            {Opcode.SMSG_RESPEC_WIPE_CONFIRM, 0x02AB},
            {Opcode.SMSG_RESPOND_INSPECT_ACHIEVEMENTS, 0x009E},
            {Opcode.SMSG_RESURRECT_REQUEST, 0x1062},
            {Opcode.SMSG_RESYNC_RUNES, 0x15E3},
            //{Opcode.SMSG_ROLE_POLL_BEGIN, 0x1007}, Check
            {Opcode.SMSG_SELL_ITEM, 0x048E},
            {Opcode.SMSG_SEND_MAIL_RESULT, 0x1A9B},// SkyFire
            {Opcode.SMSG_SEND_UNLEARN_SPELLS, 0x0D51},
            {Opcode.SMSG_SERVERTIME, 0x1C3E},
            {Opcode.SMSG_SERVER_FIRST_ACHIEVEMENT, 0x028B},
            {Opcode.SMSG_SERVER_INFO_RESPONSE, 0x022E},
            {Opcode.SMSG_SERVER_MESSAGE, 0x0302},// SkyFire
            {Opcode.SMSG_SET_DF_FAST_LAUNCH_RESULT, 0x1041},
            {Opcode.SMSG_SET_DUNGEON_DIFFICULTY, 0x1283},
            {Opcode.SMSG_SET_FACTION_ATWAR, 0x0C9B},// SkyFire
            {Opcode.SMSG_SET_FACTION_STANDING, 0x10AA},
            {Opcode.SMSG_SET_FACTION_VISIBLE, 0x1E8E},
            {Opcode.SMSG_SET_FLAT_SPELL_MODIFIER, 0x10F2},
            {Opcode.SMSG_SET_FORCED_REACTIONS, 0x068F},
            {Opcode.SMSG_SET_ITEM_PURCHASE_DATA, 0x1C9A},
            {Opcode.SMSG_SET_PCT_SPELL_MODIFIER, 0x09D3},
            {Opcode.SMSG_SET_PHASE_SHIFT, 0x02A2},// SkyFire
            {Opcode.SMSG_SET_PLAYER_DECLINED_NAMES_RESULT, 0x180E},
            {Opcode.SMSG_SET_PLAY_HOVER_ANIM, 0x069F},
            {Opcode.SMSG_SET_PROFICIENCY, 0x1440},
            {Opcode.SMSG_SET_TIMEZONE_INFORMATION, 0x19C1},// SkyFire
            //{Opcode.SMSG_SET_VEHICLE_REC_ID, 0x149F}, Check
            {Opcode.SMSG_SHOW_TAXI_NODES, 0x1E1A},
            {Opcode.SMSG_SHOW_BANK, 0x0007},
            {Opcode.SMSG_SHOW_NEURTRAL_PLAYER_FACTION_SELECT_UI, 0x15E0},// SkyFire
            {Opcode.SMSG_SOCKET_GEMS_RESULT, 0x12A6},// SkyFire
            {Opcode.SMSG_SOR_START_EXPERIENCE_INCOMPLETE, 0x0083},
            {Opcode.SMSG_SPELLDAMAGESHIELD, 0x05F3},// SkyFire
            {Opcode.SMSG_SPELLENERGIZELOG, 0x0D79},// SkyFire
            {Opcode.SMSG_SPELLHEALLOG, 0x09FB},// SkyFire
            {Opcode.SMSG_SPELLINSTAKILLLOG, 0x09F8},// SkyFire
            {Opcode.SMSG_SPELLINTERRUPTLOG, 0x1851},// SkyFire
            {Opcode.SMSG_SPELLLOGEXECUTE, 0x00D8},// SkyFire
            {Opcode.SMSG_SPELLLOGMISS, 0x1570},// SkyFire
            {Opcode.SMSG_SPELLNONMELEEDAMAGELOG, 0x1450},// SkyFire
            {Opcode.SMSG_SPELLORDAMAGE_IMMUNE, 0x08FB},// SkyFire
            {Opcode.SMSG_SPELL_CATEGORY_COOLDOWN, 0x01DB},// SkyFire
            {Opcode.SMSG_SPELL_CHANNEL_START, 0x10F9},
            {Opcode.SMSG_SPELL_CHANNEL_UPDATE, 0x11D9},
            {Opcode.SMSG_SPELL_COOLDOWN, 0x0452},
            {Opcode.SMSG_SPELL_DELAYED, 0x087A},
            {Opcode.SMSG_SPELL_FAILED_OTHER, 0x040B},
            {Opcode.SMSG_SPELL_FAILURE, 0x04AF},
            {Opcode.SMSG_SPELL_GO, 0x09D8},
            {Opcode.SMSG_SPELL_PERIODIC_AURA_LOG, 0x0CF2},
            {Opcode.SMSG_SPELL_START, 0x107A},
            {Opcode.SMSG_SPELL_UPDATE_CHAIN_TARGETS, 0x0D52},
            {Opcode.SMSG_SPIRIT_HEALER_CONFIRM, 0x1EAA},
            //{Opcode.SMSG_SPLINE_MOVE_COLLISION_DISABLE, 0x15B8},// SkyFire Check
            //{Opcode.SMSG_SPLINE_MOVE_COLLISION_ENABLE, 0x1826},// SkyFire Check
            {Opcode.SMSG_SPLINE_MOVE_GRAVITY_DISABLE, 0x0845},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_GRAVITY_ENABLE, 0x0865},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_ROOT, 0x0728},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_FEATHER_FALL, 0x1893},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_FLIGHT_BACK_SPEED, 0x0B28},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_FLIGHT_SPEED, 0x1DAB},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_FLYING, 0x1046},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_HOVER, 0x0258},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_LAND_WALK, 0x18B6},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_NORMAL_FALL, 0x0B08},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_PITCH_RATE, 0x0AB3},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_RUN_BACK_SPEED, 0x1F9F},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_RUN_MODE, 0x0B18},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_RUN_SPEED, 0x02F1},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_SWIM_BACK_SPEED, 0x0046},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_SWIM_SPEED, 0x1D8E},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_TURN_RATE, 0x0832},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_WALK_MODE, 0x1865},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_WALK_SPEED, 0x08B2},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_SET_WATER_WALK, 0x1823},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_START_SWIM, 0x0F29},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_STOP_SWIM, 0x1798},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_UNROOT, 0x01E1},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_UNSET_FLYING, 0x0DE2},// SkyFire
            {Opcode.SMSG_SPLINE_MOVE_UNSET_HOVER, 0x0CE1},// SkyFire
            {Opcode.SMSG_STABLE_RESULT, 0x14BE},
            {Opcode.SMSG_STANDSTATE_UPDATE, 0x1C12},// SkyFire
            {Opcode.SMSG_START_MIRROR_TIMER, 0x0E12},
            {Opcode.SMSG_START_TIMER, 0x0E3F},
            {Opcode.SMSG_STOP_MIRROR_TIMER, 0x1026},
            {Opcode.SMSG_STREAMING_MOVIE, 0x1843},// SkyFire
            {Opcode.SMSG_SUMMON_CANCEL, 0x000A},
            {Opcode.SMSG_SUMMON_REQUEST, 0x081F},
            {Opcode.SMSG_SUPERCEDED_SPELL, 0x1943},// SkyFire
            {Opcode.SMSG_SUPPRESS_NPC_GREETINGS, 0x100B},
            {Opcode.SMSG_SUSPEND_COMMS, 0x1D48},
            {Opcode.SMSG_SUSPEND_TOKEN_RESPONSE, 0x18BA},// SkyFire
            {Opcode.SMSG_TABARD_VENDOR_ACTIVATE, 0x0A3E},// SkyFire
            {Opcode.SMSG_TALENTS_INFO, 0x0A9B},// SkyFire
            {Opcode.SMSG_TALENTS_INVOLUNTARILY_RESET, 0x088A},
            {Opcode.SMSG_TAXI_NODE_STATUS, 0x169E},
            {Opcode.SMSG_TEXT_EMOTE, 0x002E},
            {Opcode.SMSG_THREAT_CLEAR, 0x180B},
            {Opcode.SMSG_THREAT_REMOVE, 0x1960},
            {Opcode.SMSG_THREAT_UPDATE, 0x0632},
            {Opcode.SMSG_TIME_ADJUSTMENT, 0x04AA},
            {Opcode.SMSG_TIME_SYNC_REQ, 0x1A8F},// SkyFire
            {Opcode.SMSG_TITLE_EARNED, 0x068E},
            {Opcode.SMSG_TITLE_LOST, 0x12BF},
            {Opcode.SMSG_TOTEM_CREATED, 0x1C8F},
            {Opcode.SMSG_TRADE_STATUS, 0x1963},
            {Opcode.SMSG_TRADE_STATUS_EXTENDED, 0x181E},
            {Opcode.SMSG_TRAINER_BUY_FAILED, 0x042E},
            {Opcode.SMSG_TRAINER_LIST, 0x189F},
            {Opcode.SMSG_TRANSFER_ABORTED, 0x0C8F},
            {Opcode.SMSG_TRANSFER_PENDING, 0x061B},
            {Opcode.SMSG_TRIGGER_CINEMATIC, 0x0B01},
            {Opcode.SMSG_TRIGGER_MOVIE, 0x1C2E},
            {Opcode.SMSG_TURN_IN_PETITION_RESULTS, 0x0E13},// SkyFire
            {Opcode.SMSG_TUTORIAL_FLAGS, 0x1B90},
            {Opcode.SMSG_UPDATE_ACCOUNT_DATA, 0x0AAE},
            {Opcode.SMSG_UPDATE_COMBO_POINTS, 0x082F},
            {Opcode.SMSG_UPDATE_CURRENCY, 0x129E},
            {Opcode.SMSG_UPDATE_CURRENCY_WEEK_LIMIT, 0x0E2A},
            {Opcode.SMSG_UPDATE_DUNGEON_ENCOUNTER_FOR_LOOT, 0x1863},
            {Opcode.SMSG_UPDATE_INSTANCE_OWNERSHIP, 0x10E0},
            {Opcode.SMSG_UPDATE_LAST_INSTANCE, 0x189B},
            {Opcode.SMSG_UPDATE_OBJECT, 0x1792},
            {Opcode.SMSG_UPDATE_WORLD_STATE, 0x121B},
            {Opcode.SMSG_USE_EQUIPMENT_SET_RESULT, 0x0A2B},
            {Opcode.SMSG_USERLIST_ADD, 0x1462},
            {Opcode.SMSG_USERLIST_REMOVE, 0x0AAB},
            {Opcode.SMSG_USERLIST_UPDATE, 0x063A},
            {Opcode.SMSG_VOICE_CHAT_STATUS, 0x10E2},
            {Opcode.SMSG_VOICE_PARENTAL_CONTROLS, 0x04BF},
            {Opcode.SMSG_VOICE_SESSION_LEAVE, 0x15C0},
            {Opcode.SMSG_VOICE_SESSION_ROSTER_UPDATE, 0x000E},
            {Opcode.SMSG_VOID_ITEM_SWAP_RESPONSE, 0x1EBF},
            {Opcode.SMSG_VOID_STORAGE_CONTENTS, 0x008B},
            {Opcode.SMSG_VOID_STORAGE_FAILED, 0x19C2},
            {Opcode.SMSG_VOID_STORAGE_TRANSFER_CHANGES, 0x14BA},
            {Opcode.SMSG_VOID_TRANSFER_RESULT, 0x1C9E},
            {Opcode.SMSG_WAIT_QUEUE_FINISH, 0x060E},
            {Opcode.SMSG_WAIT_QUEUE_UPDATE, 0x0C2F},
            {Opcode.SMSG_WARDEN_DATA, 0x0C0A},
            {Opcode.SMSG_WARGAME_REQUEST_SENT, 0x0CAE},
            {Opcode.SMSG_WEATHER, 0x06AB},
            {Opcode.SMSG_WEEKLY_RESET_CURRENCY, 0x023E},
            {Opcode.SMSG_WEEKLY_SPELL_USAGE, 0x00F9},
            {Opcode.SMSG_WEEKLY_SPELL_USAGE_UPDATE, 0x117A},
            {Opcode.SMSG_WHO, 0x161B},
            {Opcode.SMSG_WHOIS, 0x12BA},// SkyFire
            {Opcode.SMSG_WORLD_SERVER_INFO, 0x0082},
            {Opcode.SMSG_WORLD_STATE_UI_TIMER_UPDATE, 0x0027},// SkyFire
            {Opcode.SMSG_XP_GAIN_ABORTED, 0x1A2B},
            {Opcode.SMSG_ZONE_UNDER_ATTACK, 0x10C2},
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
            {Opcode.MSG_VERIFY_CONNECTIVITY, 0x4F57}
        };
 }
}
