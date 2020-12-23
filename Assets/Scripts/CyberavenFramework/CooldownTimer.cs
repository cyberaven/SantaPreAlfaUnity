using System;
using System.Timers;
using System.Collections;

public class CooldownTimer
{
    private bool check = true;
    public bool Check { get => check; private set => check = value; }   
    private float Cooldown = 0;
    private bool Active = false;

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
        Timer timer = new Timer(Cooldown);
        timer.Elapsed += Stop;
        timer.Start();
    }
    private void Stop(Object source, System.Timers.ElapsedEventArgs e)
    {        
        Active = false;
        Check = true;       
    }
}