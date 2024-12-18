using MelonLoader;
using MelonLoader.Utils;
using Milestones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Milestones
{
    public class StoneManager
    {
        private Dictionary<string, StoneData> registry = new Dictionary<string, StoneData>();
        private string path = MilestonesMod.MilestonesDir;

        public void RegisterStones(string modID, List<Stone> stones)
        {
            if (registry.ContainsKey(modID))
            {
                registry[modID].Stones.AddRange(stones);
            }
            else
            {
                registry[modID] = new StoneData(modID, stones);
            }

            MelonLogger.Msg($"[MILESTONES] Registered stones for mod {modID}.");
        }
        
        public void SaveAllStoneData()
        {
            foreach (var stone in registry)
            {
                SaveToStonesFile(stone.Value);
            }
        }

        private void SaveToStonesFile(StoneData stoneData)
        {
            string json = JsonSerializer.Serialize(stoneData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText($"{path}/{stoneData.ModID}.stones", json);
        }

        public void LoadStones()
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.stones");
                foreach (string file in files)
                {
                    try
                    {
                        string jsonStr = File.ReadAllText(file);
                        StoneData stones = JsonSerializer.Deserialize<StoneData>(jsonStr);
                        if(stones != null)
                        {
                            registry[stones.ModID] = stones;
                            MelonLogger.Msg($"[MILESTONES] Loaded mod data from {file}");
                        }
                    }
                    catch(Exception ex)
                    {
                        MelonLogger.Error($"[MILESTONES] Exception:");
                        MelonLogger.Error(ex.ToString());
                    }
                }
        }
    }
}
