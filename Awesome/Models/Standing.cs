namespace Awesome.Models
{
    public class Standing
    {
        public string LoginName { get; set; }
        public string RealName { get; set; }
        public int TotalPoints { get; set; }
        public int NumberOfQualified { get; set; }
        public int NumberOfQuarterFinals { get; set; }
        public int NumberOfSemiFinals { get; set; }
        public int NumberOfFinals { get; set; }

        public int NumberOfOnePoints { get; set; }
        public int NumberOfZeroPoints { get; set; }
        public int NumberOfThreePoints { get; set; }

    }
}