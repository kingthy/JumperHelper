using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace JumperHelper.Adb
{
    public class Screencap
    {
        private static int Find0DCount(MemoryStream stream)
        {
            int count = 0;
            stream.Position = 0;
            while(stream.Position < 10 && stream.Position < stream.Length)
            {
                int b = stream.ReadByte();
                if(b == '\r')
                {
                    count++;
                }
                else if(b == '\n')
                {
                    return count;
                }else if(count > 0)
                {
                    count = 0;
                }
            }
            return 0;
        }
        public static Bitmap Capture()
        {
            try
            {
                var startInfo = new ProcessStartInfo("adb", "shell screencap -p");
                startInfo.CreateNoWindow = true;
                startInfo.ErrorDialog = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                var process = Process.Start(startInfo);
                process.Start();
                var memoStream = new MemoryStream();
                process.StandardOutput.BaseStream.CopyTo(memoStream);

                var count = Find0DCount(memoStream);

                var newStream = new MemoryStream();
                memoStream.Position = 0;
                while (memoStream.Position != memoStream.Length)
                {
                    var b = memoStream.ReadByte();
                    if (b == '\r')
                    {
                        int c = 1;
                        var b1 = memoStream.ReadByte();
                        while(b1 == '\r' && memoStream.Position != memoStream.Length)
                        {
                            c++;
                            b1 = memoStream.ReadByte();
                        }
                        if(b1 == '\n')
                        {
                            if(c == count)
                            {
                                newStream.WriteByte((byte)'\r');
                            }
                            newStream.WriteByte((byte)b1);
                        }
                        else
                        {
                            for(int i=0; i<c; i++) newStream.WriteByte((byte)'\r');
                            newStream.WriteByte((byte)b1);
                        }
                    }
                    else { 
                        newStream.WriteByte((byte)b);
                    }
                }

                //File.WriteAllBytes(@"screencap_0.png", memoStream.ToArray());
                //File.WriteAllBytes(@"screencap_1.png", newStream.ToArray());
                return new Bitmap(newStream);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
