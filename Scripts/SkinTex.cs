
namespace CustomKnightPlus;

public class SkinTex
{
    public static string[] EnvironmentTypes = Enum.GetNames(typeof(MapZone));
    public class SkinTexData
    {
        public MapZone zone;
        public bool facingLeft;
        public Texture2D tex;
    }
    public List<SkinTexData> texDatas = new List<SkinTexData>();
    public bool HasTex = false;
    private SkinTexData lastTexL;
    private SkinTexData lastTexR;
    private MapZone lastZone;
    public Texture2D GetTex(MapZone zone,bool facingRight)
    {
        if(!HasTex) return null;
        if(lastZone == zone)
        {
            if(facingRight)
            {
                if(lastTexR != null) return lastTexR.tex;
            }
            else
            {
                if(lastTexL != null) return lastTexL.tex;
            }
        }
        else
        {
            lastTexL = lastTexR = null;
        }
        /*foreach(var v in texDatas)
        {
            if(!v.area.HasValue)
            {
                if(last == null)
                {
                    last = v;
                }
                else
                {
                    if(!last.area.HasValue && v.facingLeft == !facingRight)
                    {
                        last = v;
                    }
                }
                continue;
            }
            if(v.area.Value == zone)
            {
                if (last == null)
                {
                    last = v;
                }
                else
                {
                    if (!last.area.HasValue || v.facingLeft == !facingRight)
                    {
                        last = v;
                    }
                }
                if(v.facingLeft == !facingRight) break;
            }
        }*/
        var r = texDatas.Where(x => x.zone == zone);
        var cor = r.FirstOrDefault(x => x.facingLeft == !facingRight);
        if(cor == null)
        {
            cor = r.FirstOrDefault(x => x.facingLeft == facingRight);
        }
        if(cor == null)
        {
            r = texDatas.Where(x => x.zone == MapZone.NONE);
            cor = r.FirstOrDefault(x => x.facingLeft == !facingRight);
            if (cor == null)
            {
                cor = r.FirstOrDefault(x => x.facingLeft == facingRight);
            }
        }
        if(cor != null)
        {
            lastZone = zone;
            if(facingRight)
            {
                lastTexR = cor;
            }
            else
            {
                lastTexL = cor;
            }
        }
        return cor?.tex;
    }
    public void Clear()
    {
        texDatas.Clear();
        HasTex = false;
        lastZone = MapZone.NONE;
        lastTexR = lastTexL = null;
    }
    [Obsolete]
    public void LoadTex(string name, ISelectableSkin skin)
    {
        Clear();
        foreach (var v in EnvironmentTypes)
        {
            if (skin.Exists($"{name}_{v}.png"))
            {
                HasTex = true;
                texDatas.Add(new()
                {
                    zone = (MapZone)Enum.Parse(typeof(MapZone), v),
                    facingLeft = false,
                    tex = skin.GetTexture($"{name}_{v}.png")
                });
            }
            if (skin.Exists($"{name}_left_{v}.png"))
            {
                HasTex = true;
                texDatas.Add(new()
                {
                    zone = (MapZone)Enum.Parse(typeof(MapZone), v),
                    facingLeft = true,
                    tex = skin.GetTexture($"{name}_left_{v}.png")
                });
            }
        }
        if(skin.Exists($"{name}_left.png"))
        {
            HasTex = true;
            texDatas.Add(new()
            {
                zone = MapZone.NONE,
                facingLeft = true,
                tex = skin.GetTexture($"{name}_left.png")
            });
        }
        if(skin.Exists($"{name}.png"))
        {
            HasTex = true;
            texDatas.Add(new()
            {
                zone = MapZone.NONE,
                facingLeft = false,
                tex = skin.GetTexture($"{name}.png")
            });
        }
    }
}
