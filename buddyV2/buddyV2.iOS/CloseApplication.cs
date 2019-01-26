using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using buddyV2.helpers;
using Foundation;
using UIKit;

namespace buddyV2.iOS
{
    public class CloseApplication : ICloseApplication
    {
        public void closeApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}