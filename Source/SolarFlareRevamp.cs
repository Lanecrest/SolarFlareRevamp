using UnityEngine;
using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace SolarFlareRevamp
{

    // For Reflection checks
    public static class ReflectionExtensions
    {
        public static object GetCompByReflection(this ThingWithComps thing, Type compType)
        {
            foreach (var comp in thing.AllComps)
            {
                if (comp.GetType() == compType)
                {
                    return comp;
                }
            }
            return null;
        }
    }

    // Class for new solar flare game condition. Even though with the XML patching a normal SolarFlare will never trigger, I am choosing not to overwrite the vanilla SolarFlare behavior itself.
    // Doing it this way to avoid potential hard conflicts with other mods that may apply changes to solarflares as a part of broader changes they do, but I may change this later.
    // Just note that whatever possible changes those modes provide would not take effect while this mod is active.
    // I am also choosing to do this instead of a Harmony patch to avoid needing the dependancy as there is nothing else this mod would need Harmony for.
    public class GameCondition_SFR_SolarFlare : GameCondition_DisableElectricity
    {
        // Used for Vanilla Factions Expanded - Ancients compatibility
        private Type compSolarPowerUpType = null;

        // In the future, this value will be changeable via mod settings, affects the rate batteries drain
        float drainMultiplier = 0.25f;

        // Checks if mod compatibilities are needed, messages for debug
        public override void Init()
        {
            base.Init();
            if (Prefs.DevMode)
            {
                Log.Message("For Science! Solar Flare initialized.");
            }
            if (ModsConfig.IsActive("VanillaExpanded.VFEA"))
            {
                compSolarPowerUpType = Type.GetType("VFEAncients.CompSolarPowerUp, VFEAncients");
                if (Prefs.DevMode)
                {
                    Log.Message("Vanilla Factions Expanded - Ancients logic patched");
                }
            }
        }

        // Method to check if something is connected to a battery and to stay powered if so
        public void KeepTheLightsOn(Map map)
        {
            foreach (var building in map.listerBuildings.allBuildingsColonist)
            {
                var traderComp = building.TryGetComp<CompPowerTrader>();
                if (traderComp != null)
                {
                    bool isConnectedToBattery = false;
                    foreach (var powerNet in map.powerNetManager.AllNetsListForReading)
                    {
                        if (powerNet.powerComps.Contains(traderComp))
                        {
                            isConnectedToBattery = powerNet.batteryComps.Any(batteryLevelComp => batteryLevelComp.StoredEnergy > 0f);
                            {
                                if (isConnectedToBattery)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (isConnectedToBattery)
                    {
                        traderComp.PowerOn = true;
                    }
                }
            }
        }

        // Drains power based on the number of items in your power network and the number of batteries you have connected to said network
        public override void GameConditionTick()
        {
            base.GameConditionTick();
            Map map = this.SingleMap;
            KeepTheLightsOn(map);
            int batteryCount = 0;
            float totalPowerDraw = 0f;
            float perBatteryDrain = 0f;
            foreach (PowerNet powerNet in map.powerNetManager.AllNetsListForReading)
            {
                List<CompPowerBattery> batteries = powerNet.batteryComps;
                batteries.RemoveAll(battery => battery.StoredEnergy <= 0f);
                if (batteries.Count == 0) continue;
                batteryCount = batteries.Count;
                foreach (CompPowerTrader comp in powerNet.powerComps)
                {
                    if (comp.PowerOn)
                    {
                        totalPowerDraw += Mathf.Abs(comp.EnergyOutputPerTick);
                    }
                }
                perBatteryDrain = (totalPowerDraw * drainMultiplier) / batteries.Count;
                foreach (CompPowerBattery battery in batteries)
                {
                    // This is the VFEA compatibility
                    var ancientComp = battery.parent.GetCompByReflection(compSolarPowerUpType);
                    if (ancientComp == null)
                    {
                        battery.DrawPower(Mathf.Min(perBatteryDrain, battery.StoredEnergy));
                    }
                }
            }
            // Debug logging
            if (Find.TickManager.TicksGame % 1000 == 0)
            {
                if (Prefs.DevMode)
                {
                    Log.Message($"For Science! Solar Flare battery drain values:");
                    Log.Message($"Battery Count: {batteryCount}");
                    Log.Message($"Total Power Draw: {totalPowerDraw}");
                    Log.Message($"Drain Multiplier: {drainMultiplier}");
                    Log.Message($"Per Battery Drain: {perBatteryDrain}");
                }
            }
        }

        // Basically just for debug - may remove in future
        public override void End()
        {
            base.End();
            if (Prefs.DevMode)
            {
                Log.Message("For Science! Solar Flare ended.");
            }
        }
    }
}