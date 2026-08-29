using System;
using System.Windows.Forms;

public class BaseAnimatedControl : BaseControl
{
    protected Timer animationTimer;
    protected float hoverProgress;
    protected bool isHover;

    public float AnimationSpeed = 0.15f;

    public BaseAnimatedControl()
    {
        animationTimer = new Timer();
        animationTimer.Interval = 16;
        animationTimer.Tick += Animate;

        MouseEnter += delegate { isHover = true; animationTimer.Start(); };
        MouseLeave += delegate { isHover = false; animationTimer.Start(); };
    }

    private void Animate(object sender, EventArgs e)
    {
        float target = isHover ? 1f : 0f;
        hoverProgress = AnimationHelper.Lerp(hoverProgress, target, AnimationSpeed);

        if (Math.Abs(hoverProgress - target) < 0.01f)
        {
            hoverProgress = target;
            animationTimer.Stop();
        }

        Invalidate();
    }
}
