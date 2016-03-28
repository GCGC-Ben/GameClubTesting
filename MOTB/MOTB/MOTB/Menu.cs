using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace MOTB
{
    class Menu
    {
        private List<Rectangle> buttonList;

        static Texture2D buttonTxt;

        public Menu(Vector2 origin, int numButtons, List<Rectangle> buttonNumbers)
        {
            buttonList = new List<Rectangle>();

            // fill in buttonList
            Rectangle temp;
            for (int i = 0; i < numButtons; i++)
            {
                buttonList.Add(new Rectangle(buttonNumbers.ElementAt(i).X, buttonNumbers.ElementAt(i).Y, buttonNumbers.ElementAt(i).Width, buttonNumbers.ElementAt(i).Height));
            }
        }

        public static void loadButton(ContentManager content)
        {
            buttonTxt = content.Load<Texture2D>("whiteTest");
        }

        public static Texture2D getButtonTxt()
        {
            return buttonTxt;
        }

        //finds if a button is clicked and returns the number of that button
        public int update()
        {
            int i = 0;
            foreach (Rectangle rec in buttonList)
            {
                if (rec.Intersects(new Rectangle(Mouse.GetState().Position.X, Mouse.GetState().Position.Y, 10, 10)))
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Rectangle rec in buttonList)
            {
                sb.Draw(buttonTxt, rec, rec, Color.White, 0f, new Vector2(buttonTxt.Width / 2, 0),SpriteEffects.None,.4f);
            }
        }
    }
}
