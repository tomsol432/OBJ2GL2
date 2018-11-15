using JeremyAnsel.Media.WavefrontObj;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using Assimp;
using HelixToolkit;
using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Utilities;

namespace OBJ2GL2
{
    public partial class MainWindow : Window
    {
        static NVOptimusEnabler nvEnabler = new NVOptimusEnabler();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        #region Variables
        bool FileIsCorrect = false;
        string path;
        ObjFile ObjFile;
        float scale;
        
        float pointx; //objOld
        float pointy; //objOld
        float pointz; //objOld

        float pointx1CAD;
        float pointx2CAD;
        float pointy1CAD;
        float pointy2CAD;

        bool scaleEnabled;
        bool fastscale;
        bool fullOGLCode;
        bool discomode;
        int discoBeatInterval;
        bool offset;
        bool asyncRave;
        bool incomingIsCadOutput;
        bool colorDataOverride;
        string colorOverrideString;
        string savepath;
        

        StreamReader StreamReader;
        #endregion
        #region Encapsulation 
        public string Path { get => path; set => path = value; }
        public ObjFile ObjFile1 { get => ObjFile; set => ObjFile = value; }
        public float Scale { get => scale; set => scale = value; }
        public float Pointx { get => pointx; set => pointx = value; }
        public float Pointy { get => pointy; set => pointy = value; }
        public float Pointz { get => pointz; set => pointz = value; }
        public float Pointx1CAD { get => pointx1CAD; set => pointx1CAD = value; }
        public float Pointx2CAD { get => pointx2CAD; set => pointx2CAD = value; }
        public float Pointy1CAD { get => pointy1CAD; set => pointy1CAD = value; }
        public float Pointy2CAD { get => pointy2CAD; set => pointy2CAD = value; }
        public bool ScaleEnabled { get => scaleEnabled; set => scaleEnabled = value; }
        public bool Fastscale { get => fastscale; set => fastscale = value; }
        public bool FullOGLCode { get => fullOGLCode; set => fullOGLCode = value; }
        public bool Discomode { get => discomode; set => discomode = value; }
        public int DiscoBeatInterval { get => discoBeatInterval; set => discoBeatInterval = value; }
        public bool Offset { get => offset; set => offset = value; }
        public bool AsyncRave { get => asyncRave; set => asyncRave = value; }
        public bool IncomingIsCadOutput { get => incomingIsCadOutput; set => incomingIsCadOutput = value; }
        public bool ColorDataOverride { get => colorDataOverride; set => colorDataOverride = value; }
        public string ColorOverrideString { get => colorOverrideString; set => colorOverrideString = value; }
        public StreamReader StreamReader1 { get => StreamReader; set => StreamReader = value; }
        public bool FileIsCorrect1 { get => FileIsCorrect; set => FileIsCorrect = value; }
        #endregion
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenAndVailidateFile();

        }

        private void OpenAndVailidateFile()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                
                if (openFileDialog.FileName.EndsWith(".obj"))
                {
                    Path = openFileDialog.FileName;
                    ObjFile1 = ObjFile.FromFile(Path);
                    IncomingIsCadOutput = false;
                    FileIsCorrect1 = true;
                }
                if (openFileDialog.FileName.EndsWith(".txt"))
                {
                    Path = openFileDialog.FileName;
                    IncomingIsCadOutput = true;
                    StreamReader1 = new StreamReader(Path);
                    FileIsCorrect1 = true;
                }
                else
                {
                   // MessageBox.Show("Load correct file first! (.obj) or extracted CAD data");
                    //FileIsCorrect1 = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                FileIsCorrect1 = false;
            }
        }

        private void ButtonParse_Click(object sender, RoutedEventArgs e)
        {
            
            ProcessFile();

        }

        private void ProcessFile()
        {
            if (FileIsCorrect1 == true)
            {
                tbdata.Clear();
                CheckProcessVariables();
               
                if (IncomingIsCadOutput == true || IncomingIsCadOutput == false)
                {
                   
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Title = "SAVE DATA";
                        saveFileDialog.ShowDialog();
                        savepath = saveFileDialog.FileName;
                    
                        var savefileVertices = 
                        File.CreateText(savepath + "VERTICLES.txt");
                                  
                        var savefileNormals =
                        File.CreateText(savepath + "NORMALS.txt");

                        var savefileTexture =
                        File.CreateText(savepath + "TEXTURE.txt");

                        var savefileFaces =
                        File.CreateText(savepath + "FACES.txt");

                    Thread threadCad = new Thread(() =>
                        {
                        if (incomingIsCadOutput == true)
                        {
                            ProcessCadFile(savefileVertices);
                        }
                        if(incomingIsCadOutput == false)
                        {
                            ProcessObjFile(savefileVertices, savefileNormals,savefileTexture,savefileFaces);
                        }
                    });
                    threadCad.Start();






                }
            }
        }

        private void ProcessObjFile(StreamWriter savefile, StreamWriter saveFileNormals, StreamWriter saveFileTexture, StreamWriter saveFileFaces)
        {
            
            //Vertex
            long counter = 0;
            int vCounter = 0;
                foreach (var item in ObjFile1.Vertices)
                {
                
                    Pointx = item.Position.X;
                    Pointy = item.Position.Y;
                    Pointz = item.Position.Z;
                    counter++;
                //VectorData[0] = {Vect3::Vect3(0,0,0)};
                //XMFLOAT3(1.0f, 1.0f, 1.0f)},
                // var line = "VectorData["+vCounter+"] = {Vect3::Vect3("+Pointx+","+Pointz+","+Pointy+")};";
                var line = "XMFLOAT3("+Pointx+", "+Pointy+", "+pointz+"),";


                SaveObjData(savefile, line);
                    vCounter++;
                
                
                }
            //Normals
            foreach (var item in ObjFile1.VertexNormals)
            {
                
                    Pointx = item.X + 0.0001f;
                    Pointy = item.Y + 0.0001f;
                    Pointz = item.Z + 0.0001f;
                    counter++;

                    var line = "NORMAL(" + Pointx + "f, " + Pointy + "f," + Pointz + "f);";
                    //XMFLOAT3
                    SaveObjData(saveFileNormals, line);
                
                
            }
            //TextureCoordinates
            foreach (var item in ObjFile1.TextureVertices)
            {
                
                    Pointx = item.X + 0.0001f;
                    Pointy = item.Y + 0.0001f;
                    Pointz = item.Z + 0.0001f;
                    counter++;

                    var line = "TEXCOORD(" + Pointx + "f, " + Pointy + "f," + Pointz + "f);";
                    //XMFLOAT3
                    SaveObjData(saveFileTexture, line);
                
            }
            foreach (var item in ObjFile1.Faces)
            {
                
                    int VertexNumber =0;
                    int NormalNumber =0;
                    int TexCoord =0 ;
                    ObjFace objFace = item;
                    foreach (var item2 in objFace.Vertices)
                    {
                        VertexNumber = item2.Vertex;
                        NormalNumber = item2.Normal;
                        TexCoord = item2.Texture;


                    }
                    
                    var line = "FACE(Vnum " + VertexNumber + ", NorNum " + NormalNumber + " TEXCo, " + TexCoord + ")" ;
                    //XMFLOAT3
                    counter++;
                    SaveObjData(saveFileFaces, line);
                }
                
            

            MWindow.Dispatcher.Invoke(new Action(() =>
            {
                savefile.Close();
                saveFileNormals.Close();
                saveFileTexture.Close();
                saveFileFaces.Close();
                Title += "Done!";
                MessageBox.Show("EOF " + counter);
                


            }));
        }

        private void SaveObjData(StreamWriter savefile, string line)
        {
           
            savefile.WriteLine(line);
            
        }

        private void CheckProcessVariables()
        {
            if (chboxColorOverride.IsChecked == true)
            {
                ColorDataOverride = true;
                ColorOverrideString = tbColorData.Text;
            }
            if (chboxDiscomode_Async.IsChecked == true)
            {
                AsyncRave = true;
            }
            if (chboxOffset.IsChecked == true)
            {
                Offset = true;
            }
            else
            {
                Offset = false;
            }
            if (chboxDiscomode.IsChecked == true)
            {
                Discomode = true;
                try
                {
                    DiscoBeatInterval = Int32.Parse(tbDiscoInterval.Text);
                }
                catch
                {
                    MessageBox.Show("Disco interval error, using 200");
                    DiscoBeatInterval = 200;
                }
            }
            else
            {
                Discomode = false;
            }
            if (chboxFullCode.IsChecked == true)
            {
                FullOGLCode = true;
            }
            else
            {
                FullOGLCode = false;
            }
            if (chboxScale.IsChecked == true)
            {
                try
                {
                    Scale = float.Parse(tbScale.Text);
                    ScaleEnabled = true;
                }
                catch
                {
                    MessageBox.Show("Wrong scale format.");
                    ScaleEnabled = false;
                }
                if (chboxFastscale.IsChecked == true)
                {
                    Fastscale = true;
                    ScaleEnabled = true;
                }

            }
        }

        private void ProcessCadFile(StreamWriter savefile)
        {
            Random r = new Random();
            bool nachama = true;
            int offsetcounter = 0;
            int loopCounter = 0;
            while (nachama)
            {
                try
                {
                    string line = StreamReader1.ReadLine();
                    string[] ssize = line.Split(new char[0]);
                    float offsetsize = 0.0001f;
                    Pointx1CAD = float.Parse(ssize[2]) + 0.0001f;
                    Pointx2CAD = float.Parse(ssize[3]) + 0.0001f;
                    Pointy1CAD = float.Parse(ssize[4]) + 0.0001f;
                    Pointy2CAD = float.Parse(ssize[5]) + 0.0001f;
                    if (Discomode == true)
                    {
                        if (loopCounter % DiscoBeatInterval == 0 || DiscoBeatInterval == 0)
                        {
                            if (AsyncRave == true)
                            {

                                tbdata.Dispatcher.Invoke(new Action(() =>
                                {
                                    SaveAsyncRaveData(savefile, r);

                                }));
                            }
                            else
                            {
                                tbdata.Dispatcher.Invoke(new Action(() =>
                                {
                                    SaveDiscoData(savefile);
                                }));

                            }
                        }

                    }
                    if (Offset)
                    {
                        tbdata.Dispatcher.Invoke(new Action(() =>
                        {


                        }));


                    }
                    tbdata.Dispatcher.Invoke(new Action(SaveCadData(savefile, loopCounter)));
                    loopCounter++;
                }
                catch
                {
                    
                    MessageBox.Show("EOF, " + loopCounter + " lines processed");
                    savefile.Close();
                    nachama = false;
                }
            }
        }

        private static void SaveDiscoData(StreamWriter savefile)
        {
            savefile.WriteLine("(rand() % 254 + 1,rand() % 254 + 1,rand() % 254 + 1);");
        }

        private Action SaveCadData(StreamWriter savefile, int loopCounter)
        {
            return () =>
            {
                if (ColorDataOverride == true && loopCounter == 0)
                {
                    savefile.WriteLine("glColor3ub" + ColorOverrideString + ";");

                }
                savefile.WriteLine("glVertex2f(" + Pointx1CAD + "f," + Pointy1CAD + "f);");
                savefile.WriteLine("glVertex2f(" + Pointx2CAD + "f," + Pointy2CAD + "f);");

            };
        }

        private static void SaveAsyncRaveData(StreamWriter savefile, Random r)
        {
            savefile.WriteLine("if (counter % " + r.Next(60, 240) + " == 0){");
            savefile.WriteLine("glColor3ub(rand() % 254 + 1, rand() % 254 + 1, rand() % 254 + 1);}");

        }


    }
    }

