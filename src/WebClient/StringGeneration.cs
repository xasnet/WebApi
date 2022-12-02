using System.Text;

namespace WebClient
{
    public static class StringGeneration
    {
        public static string Create()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var wordLength = Random.Shared.Next(4, 10);

            StringBuilder stringBuilderGen = new StringBuilder();

            for (int i = 0; i < wordLength; i++)
            {
                int letterNum = Random.Shared.Next(0, letters.Length - 1);

                //Capitalize first letter
                var c = i == 0 ? letters[letterNum].ToString() : letters[letterNum].ToString().ToLower();

                stringBuilderGen.Insert(i, c);
            }

            return stringBuilderGen.ToString();
        }
    }
}