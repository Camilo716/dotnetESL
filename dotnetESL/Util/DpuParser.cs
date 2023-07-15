namespace dotnetESL.Util;

public static class DpuParser
{
    public static string GetLineValueFromKey(string dpu, string key)
    {
        string[] lines = dpu.Split('\n');
        foreach (string line in lines)
        {
            if (line.StartsWith($"{key}:"))
            {
                string value = line.Substring($"{key}:".Length).Trim();
                return value;
            }
        }
        throw new Exception("Key Not found");
    }
}

