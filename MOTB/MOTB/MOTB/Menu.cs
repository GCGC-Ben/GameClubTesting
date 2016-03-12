using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MOTB
{
    class Menu
    {
        List<Button> buttons = new List<Button>();

        //not sure what is all needed for an average menu
        public Menu()
        {

        }

        public void addButton(Texture2D buttonTxt, Vector2 buttonPos, Color col)
        {
            Button button = new Button(buttonTxt, buttonPos, col);
            buttons.Add(button);
        }

        public void Update(){
            

        }

        public void Draw(SpriteBatch sb)
        {
            //draw all the buttons in the ArrayList for buttons
            foreach (Button button in buttons)
            {
                button.Draw(sb);
            }
        }
    }
}
