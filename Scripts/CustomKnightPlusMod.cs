
namespace CustomKnightPlus;

class CustomKnightPlusMod : ModBase
{
    public string lastSkin;
    public MapZone lastZone;
    public bool lastFacingR;
    public Dictionary<string, SkinTex> skinTex = new();

    public string[] names = new string[]
    {
        Knight.NAME,
        Fluke.NAME,
        Hud.NAME,
        Baldur.NAME,
        Geo.NAME,
        Grimm.NAME,
        Hatchling.NAME,
        Sprint.NAME,
        Unn.NAME,
        VoidSpells.NAME,
        Weaver.NAME,
        Wraiths.NAME,
        Shade.NAME,
        Shield.NAME
    };

    public override void Initialize()
    {
        SkinManager.OnSetSkin += (_, _1) => {
            var skin = SkinManager.GetCurrentSkin();
            if(skin.GetId() != lastSkin)
            {
                Log($"Change Skin: {skin.GetId()}");
                lastSkin = skin.GetId();
                foreach(var v in names)
                {
                    if(!skinTex.TryGetValue(v, out var st))
                    {
                        st = new();
                        skinTex.Add(v, st);
                    }
                    st.LoadTex(v, skin);
                }
            }
        };
        ModHooks.HeroUpdateHook += () => {
            var fr = HeroController.instance.cState.facingRight;
            MapZone zone = GameManager.instance.sm?.mapZone ?? MapZone.NONE;
            if(lastFacingR == fr && lastZone == zone) return;
            lastFacingR = fr;
            lastZone = zone;
            foreach(var v in skinTex)
            {
                if(!v.Value.HasTex) continue;
                var r = v.Value.GetTex(zone, fr);
                if(r != null) SkinManager.Skinables[v.Key].ApplyTexture(r);
            }
        };
    }
}
