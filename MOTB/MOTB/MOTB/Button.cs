using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MOTB
{
    //button class for menus and hud
    class Button
    {
        Texture2D butTxt;
        Vector2 butPos;
        Color c;
        Rectangle bb;

        public Button(Texture2D txt, Vector2 pos, Color col)
        {
            butTxt = txt;
            butPos = pos;
            c = col;
            bb = new Rectangle((int)pos.X, (int)pos.Y, txt.Width, txt.Height);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(butTxt, butPos, null, c, 0f, new Vector2(butTxt.Width/2, 0), 1f, SpriteEffects.None, .4f);
        }
    }
}