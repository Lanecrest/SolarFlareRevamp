using Verse;
using RimWorld;
using UnityEngine;
using VFEAncients;

namespace ForScience
{
    public class GameCondition_FS_SolarFlare : GameCondition_DisableElectricity
    {
        private bool vfeaActive;

        public override void Init()
        {
            base.Init();
            vfeaActive = ModsConfig.IsActive("VanillaExpanded.VFEA");
            Log.Message("For Science! Solar Flare initialized. Vanilla Factions Expanded - Ancients found?: " + vfeaActive);
        }

        public override void GameConditionTick()
        {
            float batteryDrain = 500000f * CompPower.WattsToWattDaysPerTick;
            if (Find.TickManager.TicksGame % 1500 == 0)
            {
                foreach (var building in this.SingleMap.listerBuildings.allBuildingsColonist)
                {
                    var traderComp = building.TryGetComp<CompPowerTrader>();
                    var batteryComp = building.TryGetComp<CompPowerBattery>();
                    if (traderComp != null && !traderComp.PowerOn)
                    {
                        traderComp.PowerOn = true;
                    }
                    if (batteryComp != null)
                    {
                        if (vfeaActive)
                        {
                            var ancientComp = building.TryGetComp<CompSolarPowerUp>();
                            if (ancientComp != null)
                            {
                                // Do Nothing
                            }
                            else
                            {
                                batteryComp.DrawPower(Mathf.Min(batteryDrain, batteryComp.StoredEnergy));
                            }
                        }
                        else
                        {
                            batteryComp.DrawPower(Mathf.Min(batteryDrain, batteryComp.StoredEnergy));
                        }
                    }
                }
                Log.Message($"For Science! Solar Flare is draining {batteryDrain} watt-days per tick from batteries.");
            }
        }

        public override void End()
        {
            base.End();
            Log.Message("For Science! Solar Flare ended.");
        }
    }
}