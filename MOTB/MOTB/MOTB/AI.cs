using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MOTB
{

    class AIManager
    {
        List<AI> allAIOnMap = new List<AI>();
        public AIManager()
        {
            allAIOnMap.Add(new AI(Color.Red, new Vector2(250, 500), new Vector2(0, 0)));
        }

        public void update(World w1)
        {
            foreach (AI a in allAIOnMap)
            {
                a.AIupdate(w1);
            }
        }

        public void draw(SpriteBatch sb)
        {
            foreach (AI a in allAIOnMap)
            {
                a.draw(sb);
            }
        }
    }

    class AI : OverWorldPlayer 
    {
        protected int timer;
        protected int moveDir;
        static Random rand = new Random();

        enum aiState
        {
            wander,attack
        }

        aiState cState;

        public AI(Color c, Vector2 startPos, Vector2 cVel):base(c,startPos,cVel)
        {
            cState = aiState.wander;
            isControled = false;
        }

        public void AIupdate(World w1)
        {
            switch(cState)
            {
                case aiState.wander:
                    wander();
                    break;
                case aiState.attack:

                    break;
            }

            update(w1);
        }


        void wander()
        {

            if (timer > 60)
            {
                moveDir = rand.Next(-1, 2);
                timer = 0;
            }

            if (moveDir == -1)
            {
                acc.X += .2f;
                facingRight = true;
            }
            if (moveDir == 1)
            {
                acc.X -= .2f;
                facingRight = false;
            }
            if (moveDir == 0 && onGround)
            {
                acc.Y = -10f;
                onGround = false;
            }

            timer++;
        }

    }
}
