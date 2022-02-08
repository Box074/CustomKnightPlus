
namespace CustomKnightPlus;

public class SkinTex
{
    public static string[] EnvironmentTypes = Enum.GetNames(typeof(MapZone));
    public class SkinTexData
    {
        public MapZone? area;
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
        SkinTexData last = null;
        foreach(var v in texDatas)
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
        }
        if(last != null)
        {
            lastZone = zone;
            if(facingRight)
            {
                lastTexR = last;
            }
            else
            {
                lastTexL = last;
            }
        }
        return last?.tex;
    }
    public void LoadTex(string name, ISelectableSkin skin)
    {
        texDatas.Clear();
        HasTex = false;
        foreach (var v in EnvironmentTypes)
        {
            if (skin.Exists($"{name}_{v}.png"))
            {
                HasTex = true;
                texDatas.Add(new()
                {
                    area = (MapZone)Enum.Parse(typeof(MapZone), v),
                    facingLeft = false,
                    tex = skin.GetTexture($"{name}_{v}.png")
                });
            }
            if (skin.Exists($"{name}_left_{v}.png"))
            {
                HasTex = true;
                texDatas.Add(new()
                {
                    area = (MapZone)Enum.Parse(typeof(MapZone), v),
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
                area = null,
                facingLeft = true,
                tex = skin.GetTexture($"{name}_left.png")
            });
        }
        if(skin.Exists($"{name}.png"))
        {
            HasTex = true;
            texDatas.Add(new()
            {
                area = null,
                facingLeft = false,
                tex = skin.GetTexture($"{name}.png")
            });
        }
    }
}
