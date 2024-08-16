# For Science!
For Science! This mod is for those colonists who value science and industry over murder, pillaging, cannibalism, and other low forms of behavior. This is a mod for a more... civilized age. What For Science! aims to do is change existing or provide new functions to the game, DLC, and even other mods that speak to the flavor of furthering scientific progress over combat, mother nature, and father time. This could result in some things becoming easier (or in some cases perhaps harder) but a full list of what is changed or added can be found on the project's Steam or GitHub pages.

# Features

## Base Game
- Changes the behavior of Solar Flares to allow electricity to continue working if your grid is connected to batteries, which also continue to drain during the event (does not effect the operations of ancient technology from Vanilla Factions Expanded - Ancients).
  - This was done to make batteries more useful and to also potentially escape life or death situations due to power outages if you have been planning with batteries.

## Vanilla Races Expanded - Android
- Changes the research requirement of Android Tech to Advanced Fabrication instead of High Mechtech
  - This was done to remove the need for having a mechanitor and fighting boss mechs to access the research.


# ChangeLog
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
- None ATM but need to check how zzzt interacts with with new solar flare battery behavior

## Short Term Goals
- Create mod settings menu with toggles for appropriate patches and adjustable values where applicable.

## Long Term Ideas
- Maybe some BioSculptor behavior like regenerating all parts at once at the tradeoff of dynamically changing the amount of time you spend in the pod.
  - There is other BioSculptor stuff I'd like to change but there are currently other mods that do it well and where do I draw the line on making this a mod that just combines a bunch of functionality of other mods vs my own ideas?
- Short Circuit (Zzzt) less awful.
  - When looking into this I found an older mod not updated to 1.5 with posted source code that I thought about incorporating, but it had notes about incompatibilies with "fuse box" mods which took me down a rabbit hole of power management and short circuit mods that I feel like I should probably not do anything around this behavior then and leave it up to those mods, but we'll see - on the backburner for now.


