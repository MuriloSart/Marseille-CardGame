using System;
using UnityEngine;

namespace Core.CountingTime
{
    public static class CountingTime
    {
        public static DateTime elapseTime;
 
        public static int CoolDown(DateTime startTime, int delay)
        {
            elapseTime = DateTime.Now;
            int time = elapseTime.Second - startTime.Second;
            return time;
        }
    }
}

