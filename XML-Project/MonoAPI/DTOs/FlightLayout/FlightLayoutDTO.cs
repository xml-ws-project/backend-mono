namespace MonoAPI.DTOs.FlightLayout
{
    public class FlightLayoutDTO
    {
        public string[] EconomyLayout { get; set; }
        public string[] BusinessLayout { get; set; }
        public int NumOfBusiness { get; set; }
        public int NumOfEconomy { get; set; }

        public FlightLayoutDTO()
        {

        }

        public FlightLayoutDTO(string[] economyLayout, string[] businessLayout, int numOfBusiness, int numOfEconomy)
        {
            EconomyLayout = economyLayout;
            BusinessLayout = businessLayout;
            NumOfBusiness = numOfBusiness;
            NumOfEconomy = numOfEconomy;
        }
    }
}
