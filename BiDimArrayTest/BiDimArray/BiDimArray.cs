namespace BiDimArray
{
    public class BiDimArray
    {
        /// <summary>
        /// Returns an appropriate title based on gender and knighthood.
        /// </summary>
        /// <param name="isWoman">boolean</param>
        /// <param name="isKnighted">boolean</param>
        /// <returns></returns>
        public string Test(bool isWoman, bool isKnighted)
        {
            string[,] title = { { "Mr.", "Ms." }, { "Sir", "Dame" } };
            return title[isKnighted ? 1 : 0, isWoman ? 1 : 0];
        }
    }
}