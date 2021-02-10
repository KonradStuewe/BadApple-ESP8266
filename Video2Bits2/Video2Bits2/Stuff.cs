using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Video2Bits2
{
    public class Stuff
    {
        //string videoPath = @"C:\Users\Konrad\Videos\BadApple\very_small.avi";
        string videoPath = @"C:\Users\Konrad\Videos\BadApple\BadApple-quite-nofps-4_3.avi";
        string outputPath = @"C:\Users\Konrad\Videos\BadApple\Frames\Array.txt";

        string completeVideo = "{";
        public async void Start()
        {
            //Console.ReadKey();
            FileVideoSource videoSource = new FileVideoSource(videoPath);

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            videoSource.Start();
            //await Task.Delay(60000);
            videoSource.WaitForStop();
            videoSource.SignalToStop();

            completeVideo += "}";
            File.WriteAllText(outputPath, completeVideo);
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            string ASCIIImage = "{";
            Bitmap bitmap = eventArgs.Frame;

            for (int y = 0; y < bitmap.Height; y++)
            {
                uint first = 0;
                uint second = 0;
                uint third = 0;
                //uint fourth = 0;
                ASCIIImage += "{";
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int XX = x - 32;
                    int XXX = x - 64;
                    //int XXXX = x - 96;

                    int pixelValue = Convert.ToInt32(Math.Round(bitmap.GetPixel(x, y).GetBrightness()));
                    if (pixelValue == 1)
                    {
                        if (x < 32)
                        {
                            first |= 1U << x;
                        }
                        else if (x < 64)
                        {
                            second |= 1U << XX;
                        }
                        else// if (x < 96)
                        {
                            third |= 1U << XXX;
                        }
                        //else
                        //{
                        //    fourth |= 1U << XXXX;
                        //}
                    }
                }
                ASCIIImage += first + ",";
                ASCIIImage += second + ",";
                ASCIIImage += third;// + ",";
                //ASCIIImage += fourth;
                ASCIIImage += "},";
            }
            //Console.SetCursorPosition(0, 0);
            //Console.WriteLine(ASCIIImage);
            ASCIIImage += "},";
            completeVideo += ASCIIImage;
        }
    }
}
