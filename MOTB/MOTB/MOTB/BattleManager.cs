using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MOTB
{
    class BattleManager
    {
        List<Unit> heroes;
        List<Unit> enemies;

        //maybe a map for this instead?
        //need to comment a key for each button index
       List<Rectangle> heroButtons = new List<Rectangle>();

       Menu battleMenu;

        //indicates whos turn it is 0 = hero 
        //1 = enemy
        int turnToken = 0;
        Unit[] teamOrder = new Unit[4];

        public BattleManager()
        {
            //idk what to do here
        }

        //this is used kinda like a reusable constructor, just call this whenever a new battle starts 
        //that way we only need one battle manager object
        //Need an end battle function
        public void startBattle(List<Unit> hrs, List<Unit> enmys)
        {
            turnToken = 0;
            heroes = hrs;
            enemies = enmys;
            createBattleButtons();
            battleMenu = new Menu(new Vector2(0, 0), 1, heroButtons);
        }

        //move this up into start battle 
        public void createBattleButtons(){
            //create buttons for heroes
            foreach(Unit u in heroes){
                heroButtons.Add(new Rectangle((int)u.getPos().X,(int)u.getPos().Y -25, Menu.getButtonTxt().Width, Menu.getButtonTxt().Height));
            }
        }

        //do battle logic here?
        public void update()
        {
            Rectangle mouseRec = new Rectangle(Mouse.GetState().X,Mouse.GetState().Y, 5,5);
            if (heroButtons[0].Intersects(mouseRec) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                heroes[0].swingSword();
            }
        }

        public void draw(SpriteBatch sb)
        {
            foreach (Unit u in heroes)
            {
                u.Draw(sb);

            }
            foreach (Unit e in enemies)
            {
                e.Draw(sb);
            }
            battleMenu.Draw(sb);
        }
    }
}
