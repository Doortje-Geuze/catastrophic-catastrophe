namespace Blok3Game.Engine.JSON
{
    public class MatchData : DataPacket
    {
        public int TotalWavesSurvived { get; set; }

        public string KilledBy { get; set; }
        public int Kills { get; set; }
        public int HealthLeft { get; set; }

        public MatchData() : base()
        {
            EventName = "Example";
        }
    }
}