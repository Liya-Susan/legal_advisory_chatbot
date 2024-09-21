namespace Regression
{
    public class TrainItem
    {
        public string FilePath { get; set; }
        public string Text { get; set; }
        public double[] InputVector { get; set; }
        public int resultClass { get; set; }
    }
}
