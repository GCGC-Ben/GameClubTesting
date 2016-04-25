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
    class OverWorldPlayer
    {
        public Vector2 pos;
        static Texture2D txt;
        static SpriteFont font;
        Color c;
        protected Vector2 acc;
        Vector2 vel;
        protected bool onGround;
        Rectangle bb;
        public bool facingRight;
        bool justHitGround;
        Vector2 startPos;
        public string username {get;set;}
        protected bool isControled = true;
        bool iFinshed = false;

        public OverWorldPlayer(Color c, Vector2 startPos,Vector2 cVel)
        {
            this.c = c;
            pos = startPos;
            this.startPos = startPos;
            username = "";
            facingRight = true;
            vel = cVel;
        }

        public static void load(ContentManager content)
        {
            txt = content.Load<Texture2D>("Player\\rat");
            font = content.Load<SpriteFont>("Fonts\\Font1");
        }

        public void makePlayerControled()
        {
            isControled = true;
        }

        public bool update(World world1)
        {

            KeyboardState kb = Keyboard.GetState();

            bb = new Rectangle((int)pos.X-32,(int)pos.Y-16,64,17);
            onGround = false;
            justHitGround = false;
            foreach (Tile t in world1.solidTiles) //super intensive consider a map probally fine though
            {
                if (pos.Y <= t.getBB().Bottom && t.getBB().Intersects(bb)&& vel.Y > 0)
                {
                    pos.Y = t.pos.Y;            
                    onGround = true;
                    vel.Y = 0;
                }

                if (t.getBB().Intersects(bb))
                {
                    vel.Y = 0;
                }
            }

            if (isControled &&!iFinshed)
            {
                if (kb.IsKeyDown(Keys.Right))
                {
                    acc.X += .2f;
                    facingRight = true;
                }
                if (kb.IsKeyDown(Keys.Left))
                {
                    acc.X -= .2f;
                    facingRight = false;
                }

                if ((kb.IsKeyDown(Keys.Space) || kb.IsKeyDown(Keys.Up)) && onGround)
                {
                    acc.Y = -10f;
                    onGround = false;
                }
            }

            if (!onGround)
            {
                acc.Y += .4f;
                onGround = false;
            }

            ResolveForces(world1);

            if (pos.Y > 1600) //you fell off the map reset at start 
            {
                pos = startPos;
            }

            
            return true;
        }
      
        void ResolveForces(World world1)
        {

            if (Math.Abs(vel.X) < 5)
            {
                vel.X += acc.X;
            }

            vel.Y += acc.Y;

            acc = new Vector2(0, 0);
            

            //simulate friction
            if (vel.X > .1f)
            {
                vel.X -= .1f;
            }
            else if (vel.X < -.1f)
            {
                vel.X += .1f;
            }
            else
            {
                vel.X = 0;
            }
            if (vel.Y > .1f)
            {
                vel.Y -= .1f;
            }
            if (vel.Y < -.1f)
            {
                vel.Y += .1f;
            }



            moveHere(pos + vel,world1);
        }

        void moveHere(Vector2 npos,World world1)
        {
            bool iCanMoveHere = true;

            Rectangle nbb = new Rectangle((int)npos.X - 32, (int)npos.Y - 16, 64, 12);

            if (!justHitGround) //skip this for when you hit the ground
            {
                foreach (Tile t in world1.solidTiles) //same as intensive above but it seems to be fine
                {
                    if (nbb.Intersects(t.getBB()))
                    {
                        iCanMoveHere = false;
                        vel = new Vector2(0, 0);
                    }
                }
            }
            if (iCanMoveHere)
            {
                pos = npos;
            }
        }

        public void draw(SpriteBatch sb)
        {
            if (facingRight)
            {
                sb.Draw(txt, pos, null, c, 0f, new Vector2(txt.Width / 2, txt.Height), 1f, SpriteEffects.None, .5f);
            }
            else
            {
                sb.Draw(txt, pos, null, c, 0f, new Vector2(txt.Width / 2, txt.Height), 1f, SpriteEffects.FlipHorizontally, .5f);
            }
            sb.DrawString(font, username, pos + new Vector2(0, -90), Color.White, 0, new Vector2(font.MeasureString(username).X / 2, 0), 1f, SpriteEffects.None, 0);

            //sb.Draw(txt, bb, Color.Red); // debuging bounding box
        }

    }
}
