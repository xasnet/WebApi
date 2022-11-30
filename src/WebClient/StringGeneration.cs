namespace WebClient
{
    public static class StringGeneration
    {
        public static string Create()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var wordLength = Random.Shared.Next(4, 10);

            string stringGen = "";

            for (int i = 0; i < wordLength; i++)
            {
                int letterNum = Random.Shared.Next(0, letters.Length - 1);

                stringGen += (i == 0 ? letters[letterNum] : letters[letterNum].ToString().ToLower());
            }

            return stringGen;
        }
    }
}