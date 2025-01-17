namespace WebApplication5.Services
{
    public class RandomNumberGeneratorService
    {
        public string RandomString { get; set; }
       
        public RandomNumberGeneratorService()
        {
            var random = new Random();
            var randomString = random.Next(10000).ToString();
            this.RandomString = randomString;
        }
    }
}
