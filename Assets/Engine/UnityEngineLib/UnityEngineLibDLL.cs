using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;

public class UnityEngineLibDLL {
    [DllImport("UnityEngineLib", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr Test();

    //public static void test()
    //   {
    //       byte [] x = new byte[64];
    //       x[0] = 129;
    //       x[1] = 130;
    //       x[2] = 131;
    //       x[3] = 0;
    //       x[4] = 0x33;
    //       string tt = Encoding.ASCII.GetString(x);
    //       Debug.Log(tt);
    //   }
}
  