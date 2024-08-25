# Solar Flare Revamp
Solar Flare Revamps aims to make Solar Flares behave a little differently. This will generally make them more forgiving but also, hopefully, more interesting. A full list of what is changed can be found on the project's Steam or GitHub pages.

# Features

## Base Game
- Changes the behavior of Solar Flares to allow electricity to continue working if your grid is connected to batteries.
- As a trade off, your batteries will continue to drain during Solar Flares, at an expedited rate.
- In the unfortunate scenario where a Short Circuit (Zzzt) happens during a Solar Flare, everything on that grid will lose power (as normal) since the batteries empty out.

## Vanilla Factions Expanded - Ancients
- Compatibility to not affect how ancient technology works during Solar Flares, including ancient batteries (they will not drain like normal batteries).

# FAQ
- Is this compatible with [mod name]?
  - This should be compatible with any mod as long as it does not change Solar Flare behavior, and even then, it would still be technically compatible (in that it shouldn't cause any errors) as this doesn't modify the existing Solar Flare game event. Instead, it adds a newly defined event and makes it so this new event triggers _in place of_ of regular Solar Flares (and the implementation was done this way exactly so it would not break any mods that add numerous features and just so happen to do something to Solar Flares as well).
  - For any mods where specific compatibility was accounted for, refer to the "features" section above.
- Does this do anything other than change how Solar Flares work?
  - Yes and no. You can review the source to see exactly how it works and what it does, but plainly speaking, all this mod does is create a new Solar Flare game condition that triggers anytime a regular Solar Flare _would_ trigger, and the event still disables electronics as normal. What it adds, is a check to see if any of your buildings are connected to batteries and if so, they remain powered as long as the batteries have stored energy. It also causes batteries to drain at a quicker rate during Solar Flares. This behavior only occurs while the new Solar Flare game condition is active.

# ChangeLog
## 0.3.3 [08/24/24]
- Updated some typos and references.
- Identified a bug that prevents the custom Solar Flare from triggering during normal gameplay (currently will only trigger via dev mode). This is a serious bug that needs to be fixed before widespread release.

## 0.3.2 [08/17/24]
- Changed scope of mod to focus on Solar Flare behavior exclusively. This was done so development can focus on ensuring maximum compabibility with other mods around Solar Flare behavior.
- Updated names in XML files and the assembly as well as the GitHub to reflect the change in focus.

## 0.3.1 [08/15/24]
- Updated battery drain behavior to account for batteries with 0 stored energy.

## 0.3.0 [08/15/24]
- Overhauled the battery draining system which also allowed me to implement having things connected to batteries stay powered during solar flare. If all batteries are drained, the power goes out.
- Batteries drain based on the number of things in their particular power network and the number of batteries.

## 0.2.2 [08/14/24]
- Lowered the tickrate and battery drainage but this behavior will kind of get a complete rework once the logic is implemented for anything connected to a battery to stay on and not "surge."
- VFEA batteries are now no longer drained during solar flares.
- Created GitHub project and added VS Project source to repository.

## 0.2.1 [08/14/24]
- The current implementation resets the power at a certain tick rate (currently 1500, trying to not be a performance hog for users of this mod) and then will start to go back out, before recyling again, during the Solar Flare, creating a sort of "surging" effect.
- Batteries continue to drain at a constant rate at the trade off of the power being on sporadically (however due to the whole thing only refreshing at a certain tick rate, the current stored energy level only updates every few moments).
- This is still compatible with VFE - Ancients however as a side effect due to the current implementation, the ancient batteries also drain (though this is offset if connected to an ancient solar generator, but power generates slower than it would without this draining behavior)
- I went down a rabbit hole of ways to let ancient batteries be ignored, and while it is possible, the "best" way I found effectively makes VFEA required as the method was telling the solar flare to ignore the special property that VFEA assigns to its ancient equipment, and the only way to tell my mod to ignore a that special property that only exists in VFEA is to incorportate VFEA, which is not ideal.

## 0.2.0 [08/13/24]
- Added initial implementation of SolarFlare event modification. Right now its just an event that inherits the SolarFlare class but a C# solution has been set up and compatibility with SolarFlare Ancient Tech from Vanilla Factions Expanded - Ancients has been confirmed.

## 0.1.1 [08/13/24]
- Changed implementation of VRE - Android change to be conditional based on whether or not that mod is loaded (to allow this mod to do more things and whether or not certain mods are loaded)
- Updated mod description to outline the scope of what the general purpose of the mod is. Please refer to Steam/GitHub for full list of features/changes.

## 0.1.0 [08/13/24]
- Initial functionality of changing Vanilla Races Expanded - Android: Android Tech to require Advanced Fabrication research INSTEAD of High Mechtech.

## Bugs
- Triggers if Solar Flare is invoked via dev mode but not when Solar Flare triggers naturally

## ToDo
- Verify/build compatibility with "Solar Flares affect mechanoids" mod
- Verify/build compatibility with "RT Solar Flare Shield" mod
- Upload to Steam Workshop


