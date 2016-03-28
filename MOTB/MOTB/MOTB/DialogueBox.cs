using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MOTB
{
    class DialogueBox
    {
        String[][] dialogue;
        Texture2D[] heroes;
        Texture2D[] enemies;
        SpriteFont diaFont;
        float typeSpeed;
        float windowLength;

        public DialogueBox(String[][] dia, Texture2D[] heroChars, Texture2D[] enemyChars, SpriteFont font)
        {
            dialogue = dia;
            heroes = heroChars;
            enemies = enemyChars;
            diaFont = font;
        }

        public void splitStringLength(String text)
        {
            //What the hell is in x and y for this vector 2?
            Vector2 textLength = diaFont.MeasureString(text);
            //devide the text length by the length of the window to get the number of lines
        }

        public void draw(SpriteBatch sb)
        {
            bool writing = true;
            string currentlyWritten;
            int currentLocation = 0;
            int dialogueLocation = 0;
            while(writing)
            {
                //currentlyWritten += dialogue[(int)dialogueLocation][(int)currentLocation].ElementAt();
                int x;
            }
        }
    }
}
