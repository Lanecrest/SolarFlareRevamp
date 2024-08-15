using System;
using Verse;
using RimWorld;
using UnityEngine;

namespace ForScience
{
    public class GameCondition_FS_SolarFlare : GameCondition_DisableElectricity
    {
        private Type compSolarPowerUpType = null;


        public override void Init()
        {
            base.Init();
            Log.Message("For Science! Solar Flare initialized.");
            if (ModsConfig.IsActive("VanillaExpanded.VFEA"))
            {
                Log.Message("Vanilla Factions Expanded - Ancients logic patched");
                compSolarPowerUpType = Type.GetType("VFEAncients.CompSolarPowerUp, VFEAncients");
            }
        }

        public override void GameConditionTick()
        {
            float batteryDrain = 100000f * CompPower.WattsToWattDaysPerTick;
            if (Find.TickManager.TicksGame % 1000 == 0)
            {
                foreach (var building in this.SingleMap.listerBuildings.allBuildingsColonist)
                {
                    var traderComp = building.TryGetComp<CompPowerTrader>();
                    var batteryComp = building.TryGetComp<CompPowerBattery>();
                    if (traderComp != null && !traderComp.PowerOn)
                    {
                        traderComp.PowerOn = true;
                    }
                    if (compSolarPowerUpType != null)
                    {
                        var ancientComp = building.GetCompByReflection(compSolarPowerUpType);
                        if (batteryComp != null && ancientComp == null)
                        {
                            batteryComp.DrawPower(Mathf.Min(batteryDrain, batteryComp.StoredEnergy));
                        }
                    }
                    else
                    {
                        if (batteryComp != null)
                        {
                            batteryComp.DrawPower(Mathf.Min(batteryDrain, batteryComp.StoredEnergy));
                        }
                    }
                }
            }
            Log.Message($"For Science! Solar Flare is draining {batteryDrain} watt-days per tick from batteries.");
        }

        public override void End()
        {
            base.End();
            Log.Message("For Science! Solar Flare ended.");
        }
    }
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
}