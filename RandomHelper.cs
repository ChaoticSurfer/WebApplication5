namespace WebApplication5
{
    public static class RandomHelper
    {
        public static string GenerateString()
        {
            return new Random().Next().ToString();
        }
    }
}
