﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nihilus.Logic.Model
{
    public class ServerSettings
    {

        #region Properties
        
        public List<Difficulty> Difficulties { get; } = new List<Difficulty>(Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>());
        public List<Gamemode> Gamemodes { get; } = new List<Gamemode>(Enum.GetValues(typeof(Gamemode)).Cast<Gamemode>());
        public List<LevelType> LevelTypes { get; } = new List<LevelType>(Enum.GetValues(typeof(LevelType)).Cast<LevelType>());

        public Dictionary<string, string> SettingsDictionary { get; set; } = new Dictionary<string, string>();

        public int SpawnProtection
        {
            get => int.Parse(SettingsDictionary["spawn-protection"]);
            set => SettingsDictionary["spawn-protection"] = value.ToString();
        }

        public long MaxTickTime
        {
            get => long.Parse(SettingsDictionary["max-tick-rate"]);
            set => SettingsDictionary["max-tick-rate"] = value.ToString();
        }

        public int QueryPort
        {
            get => int.Parse(SettingsDictionary["query.port"]);
        }

        public string GeneratorSettings
        {
            get => SettingsDictionary["generator-settings"];
            //TODO Builder https://minecraft.gamepedia.com/Superflat
            set => SettingsDictionary["generator-settings"] = value;
        }

        public bool ForceGamemode
        {
            get => bool.Parse(SettingsDictionary["force-gamemode"]);
            set => SettingsDictionary["force-gamemode"] = value.ToString().ToLower();
        }

        public bool AllowNether
        {
            get => bool.Parse(SettingsDictionary["allow-nether"]);
            set => SettingsDictionary["allow-nether"] = value.ToString().ToLower();
        }

        public bool EnforceWhitelist
        {
            get => bool.Parse(SettingsDictionary["enforce-whitelist"]);
            set => SettingsDictionary["enforce-whitelist"] = value.ToString().ToLower();
        }

        public Gamemode CurrGamemode
        {
            get => (Gamemode)Enum.Parse(typeof(Gamemode),SettingsDictionary["gamemode"].First().ToString().ToUpper()+SettingsDictionary["gamemode"].Substring(1));
            set => SettingsDictionary["gamemode"] = value.ToString().ToLower();
        }

        public bool BcastConsoleToOps
        {
            get => bool.Parse(SettingsDictionary["broadcast-console-to-ops"]);
            set => SettingsDictionary["broadcast-console-to-ops"] = value.ToString().ToLower();
        }

        public bool EnableQuery
        {
            get => bool.Parse(SettingsDictionary["enable-query"]);
            set => SettingsDictionary["enable-query"] = value.ToString().ToLower();
        }

        public long PlayerIdleTimeout
        {
            get => long.Parse(SettingsDictionary["player-idle-timeout"]);
            set => SettingsDictionary["player-idle-timeout"] = value.ToString();
        }

        public Difficulty CurrDifficulty
        {
            get => (Difficulty)Enum.Parse(typeof(Difficulty),SettingsDictionary["difficulty"].First().ToString().ToUpper()+SettingsDictionary["difficulty"].Substring(1));
            set => SettingsDictionary["difficulty"] = value.ToString().ToLower();
        }

        public bool SpawnMonsters
        {
            get => bool.Parse(SettingsDictionary["spawn-monsters"]);
            set => SettingsDictionary["spawn-monsters"] = value.ToString().ToLower();
        }

        public bool BcastRconToOps
        {
            get => bool.Parse(SettingsDictionary["broadcast-rcon-to-ops"]);
            set => SettingsDictionary["broadcast-rcon-to-ops"] = value.ToString().ToLower();
        }

        public int OpPermissionLevel
        {
            get => int.Parse(SettingsDictionary["op-permission-level"]);
            set => SettingsDictionary["op-permission-level"] = value.ToString();
        }

        public bool Pvp
        {
            get => bool.Parse(SettingsDictionary["pvp"]);
            set => SettingsDictionary["pvp"] = value.ToString().ToLower();
        }

        public bool SnooperEnabled
        {
            get => bool.Parse(SettingsDictionary["snooper-enabled"]);
            set => SettingsDictionary["snooper-enabled"] = value.ToString().ToLower();
        }

        public LevelType CurrLevelType
        {
            get => (LevelType)Enum.Parse(typeof(LevelType),SettingsDictionary["level-type"].First().ToString().ToUpper()+SettingsDictionary["level-type"].Substring(1));
            set => SettingsDictionary["level-type"] = value.ToString().ToLower();
        }

        public bool Hardcore
        {
            get => bool.Parse(SettingsDictionary["hardcore"]);
            set => SettingsDictionary["hardcore"] = value.ToString().ToLower();
        }

        public bool EnableCommandBlock
        {
            get => bool.Parse(SettingsDictionary["enable-command-block"]);
            set => SettingsDictionary["enable-command-block"] = value.ToString().ToLower();
        }

        public int MaxPlayers
        {
            get => int.Parse(SettingsDictionary["max-players"]);
            set => SettingsDictionary["max-players"] = value.ToString();
        }

        public int NetworkCompressionThreshold
        {
            get => int.Parse(SettingsDictionary["network-compression-threshold"]);
            set => SettingsDictionary["network-compression-threshold"] = value.ToString();
        }

        public string ResourcePackSha1
        {
            get => SettingsDictionary["resource-pack-sha1"];
            set => SettingsDictionary["resource-pack-sha1"] = value;
        }

        public long MaxWorldSize
        {
            get => long.Parse(SettingsDictionary["max-world-size"]);
            set => SettingsDictionary["max-world-size"] = value.ToString();
        }

        public int RconPort
        {
            get => int.Parse(SettingsDictionary["rcon.port"]);
            set => SettingsDictionary["rcon.port"] = value.ToString();
        }

        public int ServerPort
        {
            get => int.Parse(SettingsDictionary["server-port"]);
            set {
                SettingsDictionary["server-port"] = value.ToString();
                SettingsDictionary["query.port"] = value.ToString();
            }
        }

        public string ServerIp
        {
            get => SettingsDictionary["server-ip"];
            set => SettingsDictionary["server-ip"] = value;
        }

        public bool SpawnNpcs
        {
            get => bool.Parse(SettingsDictionary["spawn-npcs"]);
            set => SettingsDictionary["spawn-npcs"] = value.ToString().ToLower();
        }

        public bool AllowFlight
        {
            get => bool.Parse(SettingsDictionary["allow-flight"]);
            set => SettingsDictionary["allow-flight"] = value.ToString().ToLower();
        }

        public string LevelName
        {
            get => SettingsDictionary["level-name"];
            set => SettingsDictionary["level-name"] = value;
        }

        public int ViewDistance
        {
            get => int.Parse(SettingsDictionary["view-distance"]);
            set => SettingsDictionary["view-distance"] = value.ToString();
        }

        public string ResourcePack
        {
            get => SettingsDictionary["resource-pack"];
            set => SettingsDictionary["resource-pack"] = value;
        }

        public bool SpawnAnimals
        {
            get => bool.Parse(SettingsDictionary["spawn-animals"]);
            set => SettingsDictionary["spawn-animals"] = value.ToString().ToLower();
        }

        public bool Whitelist
        {
            get => bool.Parse(SettingsDictionary["white-list"]);
            set => SettingsDictionary["white-list"] = value.ToString().ToLower();
        }

        public string RconPassword
        {
            get => SettingsDictionary["rcon.password"];
            set => SettingsDictionary["rcon.password"] = value;
        }

        public bool GenerateStructures
        {
            get => bool.Parse(SettingsDictionary["generate-structure"]);
            set => SettingsDictionary["generate-structure"] = value.ToString().ToLower();
        }

        public int MaxBuildHeight
        {
            get => int.Parse(SettingsDictionary["max-build-height"]);
            set => SettingsDictionary["max-build-height"] = value.ToString();
        }

        public bool OnlineMode
        {
            get => bool.Parse(SettingsDictionary["online-mode"]);
            set => SettingsDictionary["online-mode"] = value.ToString().ToLower();
        }

        public string LevelSeed
        {
            get => SettingsDictionary["level-seed"];
            set => SettingsDictionary["level-seed"] = value;
        }

        public bool UseNativeTransport
        {
            get => bool.Parse(SettingsDictionary["use-native-transport"]);
            set => SettingsDictionary["use-native-transport"] = value.ToString().ToLower();
        }

        public bool PreventProxyConnections
        {
            get => bool.Parse(SettingsDictionary["prevent-proxy-connections"]);
            set => SettingsDictionary["prevent-proxy-connections"] = value.ToString().ToLower();
        }

        public bool EnableRcon
        {
            get => bool.Parse(SettingsDictionary["enable-rcon"]);
            set => SettingsDictionary["enable-rcon"] = value.ToString().ToLower();
        }

        public string Motd
        {
            get => SettingsDictionary["motd"];
            set => SettingsDictionary["motd"] = value;
        }
        #endregion

        public ServerSettings(string levelname)
        {
            InitializeValues(levelname);
        }

        public ServerSettings(Dictionary<string, string> settingsDictionary)
        {
            SettingsDictionary = settingsDictionary;
        }

        public ServerSettings(ServerSettings serverSettings)
        {
            SettingsDictionary = new Dictionary<string, string>(serverSettings.SettingsDictionary);
        }

        private void InitializeValues(string levelname)
        {
            SpawnProtection = 16;
            SettingsDictionary["query.port"] = "25565";
            OpPermissionLevel = 4;
            MaxPlayers = 20;
            NetworkCompressionThreshold = 256;
            RconPort = 25575;
            ServerPort = 25565;
            ViewDistance = 10;
            MaxBuildHeight = 256;

            MaxTickTime = 60000L;
            PlayerIdleTimeout = 0L;
            MaxWorldSize = 29999984;

            GeneratorSettings = "";
            ResourcePackSha1 = "";
            ServerIp = "";
            LevelName = levelname;
            ResourcePack = "";
            RconPassword = "";
            LevelSeed = "";
            Motd = "Created with nihilus server manager";

            ForceGamemode = false;
            AllowNether = true;
            EnforceWhitelist = false;
            BcastConsoleToOps = true;
            EnableQuery = true;
            SpawnMonsters = true;
            BcastRconToOps = true;
            Pvp = true;
            SnooperEnabled = true;
            Hardcore = false;
            EnableCommandBlock = false;
            SpawnNpcs = true;
            AllowFlight = false;
            SpawnAnimals = true;
            Whitelist = false;
            GenerateStructures = true;
            OnlineMode = true;
            UseNativeTransport = true;
            PreventProxyConnections = false;
            EnableRcon = false;

            CurrGamemode = Gamemode.Survival;
            CurrDifficulty = Difficulty.Easy;
            CurrLevelType = LevelType.Default;
        }

        public enum Gamemode
        {
            Survival,
            Creative,
            Adventure,
            Spectator
        }

        public enum Difficulty
        {
            Peaceful,
            Easy,
            Normal,
            Hard
        }

        public enum LevelType
        {
            Default,
            Flat,
            Largebioms,
            Amplified,
            Buffet
        }
    }
}