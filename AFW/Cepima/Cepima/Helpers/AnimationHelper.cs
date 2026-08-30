public static class AnimationHelper
{
    public static float Lerp(float start, float end, float speed)
    {
        return start + (end - start) * speed;
    }
}
