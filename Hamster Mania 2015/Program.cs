using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace Hamster_Mania_2015
{
    class Program
    {
          public static void Main(string[] args)
        {
            Video.SetVideoMode(320, 240, 32, false, false, false, true);
            Events.Run();
        }
    }
}
