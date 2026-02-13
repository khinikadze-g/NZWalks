namespace NZWalks.api.models.domain
{
    public class Walks
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }


        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }




    }
}
