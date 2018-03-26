using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Time
    {
            public int sec = 0;
            public int min = 0;

            public void Inc()
            {
                sec++;
                if (sec >= 60)
                {
                    min++;
                    sec = 0;
                }
            }
        
    }
}
