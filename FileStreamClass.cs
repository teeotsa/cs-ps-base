using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerShell_Project
{
    class FileStreamClass
    {

        /*
            Make sure to change file's build action to "Embedded Resource" : )
        */

        public Assembly ThisAssembly =
            Assembly.GetExecutingAssembly();

        public string ThisNamespace =
            Assembly.GetExecutingAssembly().GetName().Name;

        public string PowerShellFilePath =
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Appdata\Local\Temp";

        public string ResourceFolderName =
            "PowerShell_Files";

        public List<string> Files = 
            new List<string>();

        public List<string> GetEmbeddedResources()
        {
            List<string> EmbeddedResources = new List<string>();
            foreach (string ResourceName in this.ThisAssembly.GetManifestResourceNames())
                EmbeddedResources.Add(ResourceName);
            return EmbeddedResources;
        }

        public Stream GetResourceStream(string Path)
        {
            try
            {
                return ThisAssembly.GetManifestResourceStream(Path);
            }
            catch { return null; }
        }

        public string GetFileNameFromInternal(string Internal)
        {
            Internal = Internal.Replace(this.ThisNamespace.Replace(' ', '_') + '.', string.Empty);
            return Internal.Replace(this.ResourceFolderName + '.', string.Empty);
        }

        public void CreatePowerShellFiles()
        {
            try
            {
                List<string> Resources = this.GetEmbeddedResources();
                foreach (string Res in Resources)
                {
                    if (Res.ToLower().Contains(".ps1"))
                    {
                        string FilePath = Path.Combine(this.PowerShellFilePath, this.GetFileNameFromInternal(Res));
                        using (var FileStream = File.Create(FilePath))
                        {
                            Stream Str = this.GetResourceStream(Res);
                            Str.CopyTo(FileStream);
                            this.Files.Add(FileStream.Name);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
