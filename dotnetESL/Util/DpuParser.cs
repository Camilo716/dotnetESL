namespace dotnetESL.Util;

public static class DpuParser
{
    public static int GetLineValueFromKey(string dpu, string key)
    {
        string[] lines = dpu.Split('\n');
        foreach (string line in lines)
        {
            if (line.StartsWith($"{key}:"))
            {
                string lengthString = line.Substring($"{key}:".Length).Trim();
                int length;
                if (int.TryParse(lengthString, out length))
                {
                    return length;
                }
                break;
            }
        };

        return -1;
    }
}

