using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DukeArt
{
    public class ArtData
    {
        //header
        public int artversion;
        public int numtiles;
        public int localtilestart;
        public int localtileend;
        public Int16[] tilesizex;
        public Int16[] tilesizey;
        public int[] picanm;

        public Bitmap[] bitmaps;
        public List<Color> palette = new List<Color>();
        public List<byte[]> colorData = new List<byte[]>();

        public void LoadArt(string palettePath, string artPath)
        {
            using (BinaryReader bReader = new BinaryReader(File.OpenRead(palettePath)))
            {
                for (int i = 0; i < 256; i++)
                {
                    byte r = Convert.ToByte(bReader.ReadByte() * 4);
                    byte g = Convert.ToByte(bReader.ReadByte() * 4);
                    byte b = Convert.ToByte(bReader.ReadByte() * 4);
                    Color newColor = Color.FromArgb(r, g, b);
                    palette.Add(newColor);
                }
            }

            using (BinaryReader bReader = new BinaryReader(File.OpenRead(artPath)))
            {
                // load header
                artversion = bReader.ReadInt32();
                numtiles = bReader.ReadInt32();
                localtilestart = bReader.ReadInt32();
                localtileend = bReader.ReadInt32();
                int size = localtileend - localtilestart + 1;
                tilesizex = new Int16[size];
                tilesizey = new Int16[size];
                picanm = new Int32[size];
                bitmaps = new Bitmap[size];
                for (int x = 0; x < size; x++)
                {
                    tilesizex[x] = bReader.ReadInt16();
                }
                for (int y = 0; y < size; y++)
                {
                    tilesizey[y] = bReader.ReadInt16();
                }
                for (int pic = 0; pic < size; pic++)
                {
                    picanm[pic] = bReader.ReadInt32();
                }

                // load pixel data
                for (int cur = 0; cur < size; cur++)
                {
                    if (tilesizex[cur] * tilesizey[cur] > 0)
                    {
                        Bitmap tempBmp = new Bitmap(tilesizex[cur], tilesizey[cur]);
                        byte[] tempByteArray = new byte[tilesizex[cur] * tilesizey[cur]];
                        int count = 0;
                        for (int x = 0; x < tilesizex[cur]; x++)
                        {
                            for (int y = 0; y < tilesizey[cur]; y++)
                            {
                                byte tempByte = bReader.ReadByte();
                                tempByteArray[count] = tempByte;
                                tempBmp.SetPixel(x, y, palette[tempByte]);
                                count++;
                            }
                        }
                        colorData.Add(tempByteArray);
                        bitmaps[cur] = tempBmp;
                    }
                    else
                    {
                        colorData.Add(new byte[0]);
                    }
                }
            }
        }

        public void SaveArt(string artPath)
        {
            using (BinaryWriter bWriter = new BinaryWriter(File.OpenWrite(artPath)))
            {
                // write header
                bWriter.Write(artversion);
                bWriter.Write(numtiles);
                bWriter.Write(localtilestart);
                bWriter.Write(localtileend);
                for (int x = 0; x < tilesizex.Length; x++)
                {
                    bWriter.Write(tilesizex[x]);
                }
                for (int y = 0; y < tilesizey.Length; y++)
                {
                    bWriter.Write(tilesizey[y]);
                }
                for (int pic = 0; pic < tilesizey.Length; pic++)
                {
                    bWriter.Write(picanm[pic]);
                }

                // write pixel data
                foreach (byte[] array in colorData)
                {
                    bWriter.Write(array);
                }

                bWriter.Flush();
            }
        }
    }
}
