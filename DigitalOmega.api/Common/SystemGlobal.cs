namespace DigitalOmega.api.Common
{
    public class SystemGlobal
    {
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }

        public static int Get4digitOTP()
        {
            return new Random().Next(1000, 9999);
        }

        public decimal DiffrenceInMunites(DateTime startTime, DateTime endTime)
        {
            return Convert.ToDecimal(endTime.Subtract(startTime).TotalMinutes);
        }
    }
}
