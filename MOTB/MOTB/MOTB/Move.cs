using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MOTB
{
    class Move
    {
        String name;
        String discription;

        public Move(String nm, String desc)
        {
            name = nm;
            discription = desc;
        }

        public void act(String type, String color)
        {
            switch (type.ToLower())
            {
                case "attack":

                    break;
                case "buff":

                    break;
                case "debuff":

                    break;
                default:
                    break;
            }
        }
    }
}
