namespace LISWebApp.Services
{
    public interface ILisService
    {
        public List<int> GetLis(List<int> input);
    }
    public class LisService : ILisService
    {
        public List<int> GetLis(List<int> input)
        {
            try
            {
                if (input == null || input.Count == 0)
                {
                    return new List<int>();
                }

                int currIndx = 0;
                int prevIndx = 0;

                int currLength = 1;
                int maxLength = 1;

                for (int i = 1; i < input.Count; i++)
                {
                    if (input[i] > input[i - 1])
                    {
                        currLength++;
                    }
                    else
                    {
                        currIndx = i;
                        currLength = 1;
                    }

                    if (currLength > maxLength)
                    {
                        maxLength = currLength;
                        prevIndx = currIndx;
                    }
                }

                return input.GetRange(prevIndx, maxLength);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
