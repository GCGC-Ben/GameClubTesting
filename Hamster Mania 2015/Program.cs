using System;
using System.Drawing;
using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Input;

namespace Hamster_Mania_2015
{
    class Program
    {
        private static Surface m_VideoScreen;
        private static Surface m_Background;
        private static Surface m_Foreground;
        private static Point m_ForegroundPosition;
        private static bool[] m_CursorKeys = new bool[4];
        private static int xpos = 0;
        private static int ypos = 0;
        public static void Main(string[] args)
        {
            m_VideoScreen = Video.SetVideoMode(1280, 720, 32, false, false, false, true);
            LoadImages();

            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);
            Events.Tick += new EventHandler<TickEventArgs>(ApplicationTickEventHandler);
            Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(KeyboardEventHandler);
            Events.KeyboardUp += new EventHandler<KeyboardEventArgs>(KeyboardEventHandler);
            Events.Run();

        }
        private static void LoadImages()
        {
            m_Background = (new Surface("Content\\jackson.png")).Convert(m_VideoScreen, true, false);
            m_Foreground = (new Surface("Content\\jackson.png")).Convert(m_VideoScreen, true, false);
            m_Foreground.Transparent = true;
            m_Foreground.TransparentColor = Color.FromArgb(255, 0, 255);
            m_ForegroundPosition = new Point(m_VideoScreen.Width / 2 - m_Foreground.Width / 2,
                                              m_VideoScreen.Height / 2 - m_Foreground.Height / 2);
        }
        private static void KeyboardEventHandler(object sender, KeyboardEventArgs args)
        {
            switch (args.Key)
            {
                case Key.UpArrow:
                    m_CursorKeys[0] = args.Down;
                    break;

                case Key.DownArrow:
                    m_CursorKeys[1] = args.Down;
                    break;

                case Key.LeftArrow:
                    m_CursorKeys[2] = args.Down;
                    break;

                case Key.RightArrow:
                    m_CursorKeys[3] = args.Down;
                    break;

                case Key.Escape:
                    Events.QuitApplication();
                    break;
            }
        }


        private static void ApplicationTickEventHandler(object sender, TickEventArgs args)
        {
            m_VideoScreen.Blit(m_Background,new Rectangle(xpos,ypos,m_Background.Width,m_Background.Height));
            //m_VideoScreen.Blit(m_Foreground, m_ForegroundPosition);
            updatemovement();
            m_VideoScreen.Update();
        }


        private static void updatemovement()
        {
            if( m_CursorKeys[0] )
            {
                ypos -= 1;
            }
            if (m_CursorKeys[1])
            {
                ypos += 1;
            }
            if (m_CursorKeys[2])
            {
                xpos -= 1;
            }
            if (m_CursorKeys[3])
            {
                xpos += 1;
            }
        }

        private static void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }


    }
}
