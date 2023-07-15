namespace dotnetESL.Util;

public static class DpuParser
{
    public static int GetContentLenght(string dpu)
    {
        string[] lines = dpu.Split('\n');
        foreach (string line in lines)
        {
            if (line.StartsWith("Content-Length:"))
            {
                string lengthString = line.Substring("Content-Length:".Length).Trim();
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

