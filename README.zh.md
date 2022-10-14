# [Custom Knight Plus](https://github.com/HKLab/CustomKnightPlus)

一个为 [Custom Knight](https://github.com/PrashantMohta/HollowKnight.CustomKnight) 提供条件性皮肤支持的 Mod。

请**勿**与 [Asymmetric Knight](https://github.com/PrashantMohta/HollowKnight.CustomKnight/tree/master/AddonExample/AsymmetricKnight) 一并使用，因一些功能存在冲突。

## 使用方法

> 下述后缀均不区分大小写

### 非对称

在正常皮肤文件名后加 `_left` 来创建非对称皮肤，例如，将 `Knight.png` 和 `Knight_left.png `放入皮肤文件夹，则前者会在小骑士朝左时生效，后者则在朝右时生效。

## 地图区域特定

在正常皮肤文件名后加地图区域名字来创建地图区域特定皮肤，例如，将 `Unn.png` 和 `Unn_green_path.png` 放入皮肤文件夹，则前者会在小骑士在苍绿之径之外的地方时生效，后者则在苍绿之径生效。

### 可用的地图区域字符串

- `None`：鹿角虫巢穴、席奥和奥罗的房间、白宫隐藏工坊
- `KINGS_PASS`：国王山道
- `CLIFFS`：呼啸悬崖
- `TOWN`：德特茅斯
- `CROSSROADS`：遗忘/感染十字路
- `GREEN_PATH`：苍绿之径
- `ROYAL_GARDENS`：王后花园
- `FOG_CANYON`：雾之峡谷
- `WASTES`：真菌荒地
- `DEEPNEST`：深邃巢穴
- `HIVE`：蜂巢
- `PALACE_GROUNDS`：宫殿广场
- `MINES`：水晶山峰
- `RESTING_GROUNDS`：安息之地
- `CITY`：泪水之城
- `DREAM_WORLD`：梦境
- `COLOSSEUM`：愚人斗兽场
- `ABYSS`：古老盆地
- `WHITE_PALACE`：白色宫殿
- `SHAMAN_TEMPLE`：祖先山丘
- `WATERWAYS`：皇家水道
- `QUEENS_STATION`：王后驿站
- `OUTSKIRTS`：王国边缘
- `KINGS_STATION`：国王驿站
- `TRAM_UPPER`：上层电车
- `TRAM_LOWER`：下层电车
- `FINAL_BOSS`：黑卵圣殿
- `SOUL_SOCIETY`：灵魂圣所
- `ACID_LAKE`：乌恩之湖
- `NOEYES_TEMPLE`：石之庇护所
- `MONOMON_ARCHIVE`：教师档案馆
- `MANTIS_VILLAGE`：螳螂村
- `RUINED_TRAMWAY`：废弃电车轨道
- `DISTANT_VILLAGE`：遥远的村庄
- `ISMAS_GROVE`：伊斯玛的树林
- `WYRMSKIN`：遗弃外壳
- `LURIENS_TOWER`：守望者之塔
- `LOVE_TOWER`：爱之塔
- `GLADE`：灵魂沼地
- `BLUE_LAKE`：蓝湖
- `PEAK`：圣巢之冠
- `JONI_GRAVE`：乔尼的长眠处
- `OVERGROWN_MOUND`：长满植物的山丘
- `CRYSTAL_MOUND`：结晶山丘
- `BEASTS_DEN`：野兽巢穴
- `GODS_GLORY`：神居
- `GODSEEKER_WASTE`：垃圾坑

## 混合使用

非对称和地图区域特定功能可以一起使用，以达成更精细的调整，例如，`Sprint_left_gods_glory.png` 仅当小骑士在神居中且朝左时生效。
