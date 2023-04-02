namespace MonoAPI.DTOs.FlightLayout
{
    public class NewFlightLayoutDTO
    {
        public string[] EconomyLayout { get; set; }
        public string[] BusinessLayout { get; set; }
        public int NumOfBusiness { get; set; }
        public int NumOfEconomy { get; set; }

        public string Name { get; set; }
        public NewFlightLayoutDTO()
        {

        }

        public NewFlightLayoutDTO(string[] economyLayout, string[] businessLayout, int numOfBusiness, int numOfEconomy, string name)
        {
            EconomyLayout = economyLayout;
            BusinessLayout = businessLayout;
            NumOfBusiness = numOfBusiness;
            NumOfEconomy = numOfEconomy;
            Name = name;
        }
    }
}
