# For Science!
For Science! This mod is for those colonists who value science and industry over murder, pillaging, cannibalism, and other low forms of behavior. This is a mod for a more... civilized age. What For Science! aims to do is change existing or provide new functions to the game, DLC, and even other mods that speak to the flavor of furthering scientific progress over combat, mother nature, and father time. This could result in some things becoming easier (or in some cases perhaps harder) but a full list of what is changed or added can be found on the project's Steam or GitHub pages.

# Features

## Base Game
- Changes the behavior of Solar Flares to allow electricity to continue working if your grid is connected to batteries, which also continue to drain during the event (does not effect the operations ancient technology from Vanilla Factions Expanded - Ancients).
  - This was done to make the game more rewarding for having batteries and to allow potentially life threatening situations be mitigated by planning ahead with batteries.

## Vanilla Races Expanded - Android
- Changes the research requirement of Android Tech to Advanced Fabrication instead of High Mechtech
  - This was done to remove the need for having a mechanitor and fighting boss mechs to access the research.


# ChangeLog
## 0.2.2
- Lowered the tickrate and battery drainage but this behavior will kind of get a complete rework once the logic is implemented for anything connected to a battery to stay on and not "surge."
- VFEA batteries are now no longer drained during solar flares.
- Created GitHub project and added VS Project source to repository

## 0.2.1
- The current implementation resets the power at a certain tick rate (currently 1500, trying to not be a performance hog for users of this mod) and then will start to go back out, before recyling again, during the Solar Flare, creating a sort of "surging" effect.
- Batteries continue to drain at a constant rate at the trade off of the power being on sporadically (however due to the whole thing only refreshing at a certain tick rate, the current stored energy level only updates every few moments).
- This is still compatible with VFE - Ancients however as a side effect due to the current implementation, the ancient batteries also drain (though this is offset if connected to an ancient solar generator, but power generates slower than it would without this draining behavior)
- I went down a rabbit hole of ways to let ancient batteries be ignored, and while it is possible, the "best" way I found effectively makes VFEA required as the method was telling the solar flare to ignore the special property that VFEA assigns to its ancient equipment, and the only way to tell my mod to ignore a that special property that only exists in VFEA is to incorportate VFEA, which is not ideal.

## 0.2.0
- Added initial implementation of SolarFlare event modification. Right now its just an event that inherits the SolarFlare class but a C# solution has been set up and compatibility with SolarFlare Ancient Tech from Vanilla Factions Expanded - Ancients has been confirmed.

## 0.1.1
- Changed implementation of VRE - Android change to be conditional based on whether or not that mod is loaded (to allow this mod to do more things and whether or not certain mods are loaded)
- Updated mod description to outline the scope of what the general purpose of the mod is. Please refer to Steam/GitHub for full list of features/changes.


## 0.1.0
- Initial functionality of changing Vanilla Races Expanded - Android: Android Tech to require Advanced Fabrication research INSTEAD of High Mechtech.

## Bugs
- None known ATM

## Todo
- Create mod settings menu with toggles for appropriate patches
- Actually implement the behavior of equipment staying on if connected to a battery (right now it just kind of cheats and does it anyway)
- Make Zzzt more forgiving

## The Future
- Maybe some BioSculptor behavior like regenerating all parts at once at the tradeoff of dynamically changing the amount of time you spend in the pod
  - There is other BioSculptor stuff I'd like to change but there are currently other mods that do it well and where do I draw the line on making this a mod that just combines a bunch of functionality of other mods vs my own ideas?


