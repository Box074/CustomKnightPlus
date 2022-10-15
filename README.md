# [Custom Knight Plus](https://github.com/HKLab/CustomKnightPlus)

A mod providing conditional skin support for [Custom Knight](https://github.com/PrashantMohta/HollowKnight.CustomKnight).

Do NOT use together with [Asymmetric Knight](https://github.com/PrashantMohta/HollowKnight.CustomKnight/tree/master/AddonExample/AsymmetricKnight) as some features conflicts with each other.

## Usage

> All suffixes mentioned below are case-insensitive.

### Asymmetric

Attach `-left` after normal skin file name to make asymmetric skin, for example, put `Knight.png` and `Knight-left.png` into the skin folder, then the former will get applied when the knight is facing right, and the latter will get applied when facing left.

## Map zone specific

Attach map zone name after normal skin file name to make map zone specific skin, for example, put `Unn.png` and `Unn-green_path.png` into the skin folder, then the former will get applied when the knight is not in Greenpath, and the latter will get applied when in Greenpath.

### Available map zone strings

- `None`: Stag Nest, Sheo's and Oro's Rooms, and White Palace Workshop
- `KINGS_PASS`: King's Pass
- `CLIFFS`: Howling Cliffs
- `TOWN`: Dirmouth
- `CROSSROADS`: Forgotten/Infected Crossroads
- `GREEN_PATH`: Greenpath
- `ROYAL_GARDENS`: Queen's Gardens
- `FOG_CANYON`: Fog Canyon
- `WASTES`: Fungal Wastes
- `DEEPNEST`: Deepnest
- `HIVE`: Hive
- `PALACE_GROUNDS`: Palace Grounds
- `MINES`: Crystal Peaks
- `RESTING_GROUNDS`: Resting Grounds
- `CITY`: City of Tears
- `DREAM_WORLD`: Dream
- `COLOSSEUM`: Colosseum of the Fools
- `ABYSS`: Ancient Basin
- `WHITE_PALACE`: White Palace
- `SHAMAN_TEMPLE`: Ancestral Mound
- `WATERWAYS`: Royal Waterways
- `QUEENS_STATION`: Queen's Station
- `OUTSKIRTS`: Kingdom's Edge
- `KINGS_STATION`: King's Station
- `TRAM_UPPER`: Upper Tram
- `TRAM_LOWER`: Lower Tram
- `FINAL_BOSS`: Temple of the Black Egg
- `SOUL_SOCIETY`: Soul Sanctum
- `ACID_LAKE`: Lake of Unn
- `NOEYES_TEMPLE`: Stone Sanctuary
- `MONOMON_ARCHIVE`: Teacher's Archives
- `MANTIS_VILLAGE`: Mantis Village
- `RUINED_TRAMWAY`: Failed Tramway
- `DISTANT_VILLAGE`: Distant Village
- `ISMAS_GROVE`: Isma's Grove
- `WYRMSKIN`: Cast-Off Shell
- `LURIENS_TOWER`: Watcher's Spire
- `LOVE_TOWER`: Tower of Love
- `GLADE`: Spirits' Glade
- `BLUE_LAKE`: Blue Lake
- `PEAK`: Hallownest's Crown
- `JONI_GRAVE`: Joni's Repose
- `OVERGROWN_MOUND`: Overgrown Mound
- `CRYSTAL_MOUND`: Crystallised Mound
- `BEASTS_DEN`: Beast's Den
- `GODS_GLORY`: Godhome
- `GODSEEKER_WASTE`: Junk Pit

## Mixed usage

The asymmetric and map zone specific feature can be combined to have more precise control, for example, `Sprint-left-gods_glory.png` only applies when the knight is in Godhome and is facing left.
