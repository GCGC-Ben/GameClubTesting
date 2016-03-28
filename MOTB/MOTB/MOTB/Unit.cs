using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MOTB
{
    class Unit
    {
        String name;
        Texture2D hTxt;
        Vector2 pos;
        Color c;
        String statusEffect = "";

        //bool for if the unit has already moved this turn
        bool hasMoved = false;
        //stats
        //
        //

        List<Move> moveList;
        public Unit(String nm, Vector2 unitPos, Texture2D txt, Color currentCol)
        {
            name = nm;
            pos = unitPos;
            hTxt = txt;
            c = currentCol;
        }

        public Vector2 getPos()
        {
            return pos;
        }

        public Texture2D getText()
        {
            return hTxt;
        }

        public void addMove(Move mv)
        {
            moveList.Add(mv);
        }

        public void statusEffectManager()
        {
            //stuff for status effects
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(hTxt, pos, null, c, 0f, new Vector2(hTxt.Width / 2, 0), 1f, SpriteEffects.None, .4f);
        }
    }
}
