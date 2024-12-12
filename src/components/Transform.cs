using Raylib_cs;
using System.Numerics;

namespace Azimuth
{
    public class Transform : Component
    {
        public Vector2 position = new Vector2(0, 0);
        public Vector2 scale    = new Vector2(5, 5);
        public float rotation   = 0;

        public Vector2 pivot    = new Vector2(0.5f, 0.5f);
        
        public void Awake()
        {
            Debug.Log("Transform awake");
        }

        public void Gizmos()
        {
            Texture2D texture = Textures.Load("assets/icons/transform_icon.png", 5);
            
            Rectangle source = new Rectangle(0, 0, texture.Width, texture.Height);
            
            Rectangle dest = new Rectangle(
                position.X - texture.Width * scale.X * pivot.X,
                position.Y - texture.Height * scale.Y * pivot.Y,
                texture.Width * scale.X, 
                texture.Height * scale.Y
            );
            Vector2 origin = new Vector2(
                texture.Width * pivot.X,
                texture.Height * pivot.Y
            );
            
            Raylib.DrawTexturePro(texture, source, dest, origin, rotation, Color.White);
        }

        public void Update()
        {
            Debug.Log("rotation: " + rotation);
            rotation += 100 * Time.DeltaTime;
        }

        public void Render()
        {

        }

        public void GUI()
        {

        }
    }
}
