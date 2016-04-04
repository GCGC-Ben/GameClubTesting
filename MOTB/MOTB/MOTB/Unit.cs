using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


//////
//****** Need to merge ben's class and this unit class most likely
//****** Do animations for attacking here?
//////
namespace MOTB
{
    class Unit
    {
        String name;
        
        //textures
        Texture2D hTxt;
        //might need to change this if we add equipment to the game
        static Texture2D swordTxt;
        float rot = 0f;

        Vector2 pos;
        Vector2 swPos;
        Color c;
        String statusEffect = "";

        //bool for if the unit has already moved this turn
        bool hasMoved = false;
        //stats
        //
        

        List<Move> moveList;
        public Unit(String nm, Vector2 unitPos, Texture2D txt, Color currentCol)
        {
            name = nm;
            pos = unitPos;
            hTxt = txt;
            c = currentCol;
            swPos = new Vector2(unitPos.X+5,unitPos.Y+5);
        }

        public Vector2 getPos()
        {
            return pos;
        }

        //used for loading the content of the heroes
        //should structure for one call at the beginning
        //only handles sword for right now
        public static void loadTxt(ContentManager content)
        {
            swordTxt = content.Load<Texture2D>("sword");
        }

        public Texture2D getText()
        {
            return hTxt;
        }

        public void swingSword()
        {
            //swanging swods
            rot++;
        }

        //adds a battle move to the list
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
            sb.Draw(swordTxt, swPos, null, c, rot, new Vector2(swordTxt.Width / 2, swordTxt.Height/2), 1f, SpriteEffects.None, .3f);
        }
    }
}
