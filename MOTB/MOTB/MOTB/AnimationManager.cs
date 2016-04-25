using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MOTB
{
    class AnimationManager
    {

        List<Texture2D> txtList = new List<Texture2D>();

        int frameNum;
        int interval;

        public AnimationManager(List<Texture2D> tList)
        {
            txtList = tList;
        }


    }
}
