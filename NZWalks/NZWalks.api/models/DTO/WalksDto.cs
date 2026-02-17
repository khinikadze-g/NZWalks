using NZWalks.api.models.domain;

namespace NZWalks.api.models.DTO
{
    public class WalksDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
      

        public RegionDto Region { get; set; }
        public  Difficulty Difficulty { get; set; }
    }
}
