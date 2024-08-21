using fxcore2;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;


public class Program
{
    static void Main(string[] args)
    {
    }

    private static O2GSession mSession;


};

public class MySessionStatusListener : IO2GSessionStatus
{
    public void onLoginFailed(string error)
    {
        throw new NotImplementedException();
    }


    public void onSessionStatusChanged(O2GSessionStatusCode status)
    {
        Console.WriteLine("Status: " + status.ToString());
        if (status == O2GSessionStatusCode.Connected)
            mConnected = true;
        else
            mConnected = false;

        if (status == O2GSessionStatusCode.Disconnected)
            mDisconnected = true;
        else
            mDisconnected = false;

        if (status == O2GSessionStatusCode.TradingSessionRequested)
        {
            if (Program.SessionID == "")
                Console.WriteLine("Argument for trading session ID is missing");
            else
                mSession.setTradingSession(Program.SessionID, Program.Pin);
        }
        else if (status == O2GSessionStatusCode.Connected)
        {
            lock (mEvent)
                Monitor.PulseAll(mEvent);
        }

    }

};





