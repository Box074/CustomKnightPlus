
namespace CustomKnightPlus;

class CustomKnightPlusMod : ModBase
{
    public string lastSkin;
    public MapZone lastZone;
    public bool lastFacingR;
    public static Dictionary<string, SkinTex> skinTex = new();

    public string[] names = SkinManager.Skinables.Select(x => x.Key).ToArray();
    public override void Initialize()
    {
        ModHooks.HeroUpdateHook += () =>
        {
            var skin = SkinManager.GetCurrentSkin();
            if(skin == null)
            {
                return;
            }
            if (skin.GetId() != lastSkin)
            {
                Log($"Change Skin: {skin.GetId()}");
                lastSkin = skin.GetId();
                LoadSkin(skin.getSwapperPath(), skin);
                return;
            }
            var fr = HeroController.instance.cState.facingRight;
            MapZone zone = GameManager.instance.sm?.mapZone ?? MapZone.NONE;
            if (lastFacingR == fr && lastZone == zone) return;
            lastFacingR = fr;
            lastZone = zone;
            foreach (var v in skinTex)
            {
                if (!v.Value.HasTex) continue;
                var r = v.Value.GetTex(zone, fr);
                if (r != null) SkinManager.Skinables[v.Key].ApplyTexture(r);
            }
        };
    }
    public T? TryParseEnum<T>(string val) where T : struct
    {
        if (Enum.TryParse<T>(val, true, out var result)) return result;
        return null;
    }
    void LoadSkin(string path, ISelectableSkin skin)
    {
        foreach (var v in skinTex) v.Value?.Clear();
        foreach (var v in Directory.EnumerateFiles(path, "*.png"))
        {
            try
            {
                var name = Path.GetFileNameWithoutExtension(v);
                var parts = name.Split('-');
                if(parts.Length == 0) continue;
                var texName = parts[0];
                if (!skinTex.TryGetValue(texName, out var st) || st == null)
                {
                    st = new();
                    skinTex[texName] = st;
                }
                if (parts.Length == 1)
                {
                    st.texDatas.Add(new()
                    {
                        zone = MapZone.NONE,
                        facingLeft = false,
                        tex = skin.GetTexture(Path.GetFileName(v))
                    });
                    continue;
                }
                
                bool isLeft = parts[1].Equals("left", StringComparison.OrdinalIgnoreCase);
                MapZone? zone = parts[1].Equals("left", StringComparison.OrdinalIgnoreCase) ?
                (parts.Length == 2 ? null : TryParseEnum<MapZone>(parts[2])) :
                TryParseEnum<MapZone>(parts[1]);

                st.HasTex = true;
                Log($"Load Texutre2D: {zone} {isLeft} {Path.GetFileName(v)}");
                st.texDatas.Add(new()
                {
                    zone = zone ?? MapZone.NONE,
                    facingLeft = isLeft,
                    tex = skin.GetTexture(Path.GetFileName(v))
                });
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }
    }
}
