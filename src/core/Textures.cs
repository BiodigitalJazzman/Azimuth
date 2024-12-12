using Raylib_cs;

namespace Azimuth
{
    public static class Textures
    {
        private class TextureEntry
        {
            public Texture2D texture;
            public float lifeTime;
        }

        private static Dictionary<string, TextureEntry> textures = new Dictionary<string, TextureEntry>();

        public static Texture2D Load(string path, float lifeTime = 10)
        {
            if (textures.ContainsKey(path))
            {
                textures[path].lifeTime = lifeTime;
                return textures[path].texture;
            }

            Texture2D texture = Raylib.LoadTexture(path);
            textures[path] = new TextureEntry { texture = texture, lifeTime = lifeTime };
            return texture;
        }

        public static void Unload(string path)
        {
            if (textures.ContainsKey(path))
            {
                Raylib.UnloadTexture(textures[path].texture);
                textures.Remove(path);
            }
        }

        public static void Update()
        {
            foreach (var texture in textures)
            {
                texture.Value.lifeTime -= Time.DeltaTime;

                if (texture.Value.lifeTime <= 0) Unload(texture.Key);
            }
        }
    }
}