using System;
using System.Timers;
using System.Collections;

public class CooldownTimer
{
    private bool check = true;
    public bool Check { get => check; private set => check = value; }   
    private float Cooldown = 0;
    private bool Active = false;

    private Timer Timer = null;

    public CooldownTimer(float miliSec)
    {
        Cooldown = miliSec;
    }

    public void Go()
    {
        if (!Active)
        {            
            Active = true;
            Check = false;
            Run();
        }
    }
    private void Run()
    {        
        Timer = new Timer(Cooldown);
        Timer.Elapsed += Stop;
        Timer.Start();
    }
    private void Stop(Object source, System.Timers.ElapsedEventArgs e)
    {        
        Active = false;
        Check = true;
        Timer.Stop();
    }
}