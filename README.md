# Solar Flare Revamp
Solar Flare Revamps aims to make Solar Flares behave a little differently. This will generally make them more forgiving but also, hopefully, more interesting. A full list of what is changed can be found on the project's Steam or GitHub pages.

# Features

## Base Game
- Changes the behavior of Solar Flares to allow electricity to continue working if your grid is connected to batteries.
- As a trade off, your batteries will continue to drain during Solar Flares, at an expedited rate.
- In the unfortunate scenario where a Short Circuit (Zzzt) happens during a Solar Flare, everything on that grid will lose power (as normal) since the batteries empty out.

## Vanilla Factions Expanded - Ancients
- Compatibility to not affect how ancient technology works during solar flares, including ancient batteries (they will not drain like normal batteries).

# ChangeLog
## 0.3.2 [08/17/24]
- Changed scope of mod to focus on Solar Flare behavior exclusively. This was done so development can focus on ensuring maximum compabibility with other mods around Solar Flare behavior.
- Updated names in XML files and the assembly as well as the GitHub to reflect the change in focus.

## 0.3.1 [08/15/24]
- Updated battery drain behavior to account for batteries with 0 store energy.

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
- None ATM

## ToDo
- Verify/build compatibility with "Solar Flares affect mechanoids" mod
- Verify/build compatibility with "RT Solar Flare Shield" mod


