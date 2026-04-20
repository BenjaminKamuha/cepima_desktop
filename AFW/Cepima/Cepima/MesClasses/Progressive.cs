using System;
using System.Windows.Forms;
using UIFramework.Controls;
using Cepima.MesClasses;

 class ProgressiveDisplay
{
    private Control targetPanel;
    private int currentIndex = 0;
    private Timer timer;

    public ProgressiveDisplay(Control panel, int interval = 500)
    {
        targetPanel = panel;
        timer = new Timer();
        timer.Interval = interval; // délai en millisecondes
        timer.Tick += Timer_Tick;



        
    }

    public void Start()
    {
        // cacher tous les contrôles au départ
        foreach (Control ctrl in targetPanel.Controls)
        {
            ctrl.Visible = false;
        }

        currentIndex = 0;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        if (currentIndex < targetPanel.Controls.Count)
        {
            string tag = (string)targetPanel.Controls[currentIndex].Tag;
            if (tag != "hidden")
            {
                targetPanel.Controls[currentIndex].Visible = true;
            }

            //targetPanel.Controls[currentIndex].FadeIn(400);
            currentIndex++;
        }
        else
        {
            timer.Stop(); // tout est affiché
        }
    }
}

