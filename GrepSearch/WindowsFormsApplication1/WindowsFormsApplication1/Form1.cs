using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
   

    public partial class Form1 : Form
    {
        public List<string> paths = new List<string>();
        public List<string> pathNames = new List<string>();
        public SearchResult[] SearchResults = new SearchResult[0];

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadDropdownPaths();
            loadDropdownFileTypes();
            loadDropdownSearchTypes();
            this.SearchResults = new SearchResult[0];
            dgvSearchResults.DataSource = this.SearchResults;

            
            ListDirectory(tvCurrentPath, this.paths[cboPaths.SelectedIndex]);
            
        }

        private void loadDropdownPaths()
        {
            int counter = 1;
            string line;

            StreamReader file =
               new StreamReader("C:\\temp\\vb_grep_dropdown_paths.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] pathArr;
                pathArr = line.Split('\t');

                Debug.WriteLine("path: " + pathArr[0]);

                this.paths.Add(pathArr[0]);      // Path
                this.pathNames.Add(pathArr[1]);  // Path Name

                cboPaths.Items.Add(pathArr[1]);
                counter++;
            }
            file.Close();

            cboPaths.SelectedIndex = 0;
        }

        private void loadDropdownFileTypes()
        {
            cboFileTypes.Items.Add("ALL");
            cboFileTypes.Items.Add("PHP");
            cboFileTypes.Items.Add("TWIG");
            cboFileTypes.Items.Add("JS");
            cboFileTypes.Items.Add("HTM");
            cboFileTypes.Items.Add("CSS");
            cboFileTypes.Items.Add("SQL");
            cboFileTypes.Items.Add("PY");
            cboFileTypes.Items.Add("JAVA");
            cboFileTypes.Items.Add("XML");
            cboFileTypes.Items.Add("JSON");
            cboFileTypes.Items.Add("YML");
            cboFileTypes.Items.Add("YAML");




            cboFileTypes.SelectedIndex = 0;
        }

        private void loadDropdownSearchTypes()
        {
            cboSearchType.Items.Add("Text in Files");
            cboSearchType.Items.Add("File Names");

            cboSearchType.SelectedIndex = 0;
        }

        private static void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();

            var stack = new Stack<TreeNode>();
            var rootDirectory = new DirectoryInfo(path);
            var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
            stack.Push(node);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                var directoryInfo = (DirectoryInfo)currentNode.Tag;
                try
                {
                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                    /*foreach (var file in directoryInfo.GetFiles())
                         currentNode.Nodes.Add(new TreeNode(file.Name));*/
                }
                catch (Exception e)
                {

                }
            }

            treeView.Nodes.Add(node);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            if (cboSearchType.SelectedItem.ToString() == "Text in Files")  // if is text search
            {

                if (txtSearchTerm.Text.Trim() != "")  // if entered search keyword
                {
                    lblLoading.Visible = true;
                    lblLoading.Text = "Loading...";
                    this.Update();


                    String cur_path = "";
                    String cur_path2 = this.paths[cboPaths.SelectedIndex];

                   

                    String[] curPathArr;
                    curPathArr = cur_path2.Split('\\');
                    int lastCurPathIndex = curPathArr.Length - 1;

                    Debug.WriteLine("lastpath: " + curPathArr[lastCurPathIndex]);

                   
                    if (tvCurrentPath.SelectedNode != null)
                    {
                       
                        cur_path = cur_path2 + tvCurrentPath.SelectedNode.FullPath.Replace(curPathArr[lastCurPathIndex], "");
                    }
                    else
                    {
                        cur_path = cur_path2;
                    }

                    String cur_file_type = cboFileTypes.SelectedItem.ToString();
                    if (cur_file_type == "ALL")
                    {
                        cur_file_type = "*";
                    }
                    Debug.WriteLine("cur_path: " + cur_path);
                    
                    this.SearchResults = new SearchResult[0];
                    dgvSearchResults.DataSource = this.SearchResults;

                    Debug.WriteLine("cur_path: " + cur_path);

                    List<string> files = Directory.GetFiles(cur_path, "*." + cur_file_type, SearchOption.AllDirectories).ToList();

                    int counter = 1;
                    int lines_count = 1;
                    if (cboJustFiles.Checked == false)  // if only want to see filenames
                    {
                        foreach (String getFile in files)
                        {
                            int lines_count2 = 1;
                            
                            StreamReader file =
                                new StreamReader(getFile);
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                int line_index = counter - 1;
                                if (System.Text.RegularExpressions.Regex.IsMatch(line, txtSearchTerm.Text))
                                {

                                    //if (lines_count > 1)
                                    //{
                                    Array.Resize(ref this.SearchResults, counter);
                                    //}
                                    String get_cur_path = getFile.Replace(cur_path, "");
                                    get_cur_path = get_cur_path.Replace("\\", "/");
                                    this.SearchResults[lines_count - 1] = new SearchResult { Path = get_cur_path + ":" + lines_count2, FullPath = getFile, Results = line, OpenNotePad = "NotePad", OpenPHPStorm = "PHPStorm", OpenPath = "View" };

                                    lines_count2++;
                                    lines_count++;
                                    counter++;
                                }
                                
                            }
                            file.Close();
                        }
                    }
                    else  // if is filename search
                    {
                        int counter3 = 1;
                        int lines_count3 = 1;

                        List<String> foundFiles = new List<String>();
                        foreach (String getFile in files)
                        {
                            
                            int lines_count4 = 1;
                            StreamReader file =
                                new StreamReader(getFile);
                            string line;
                            while ((line = file.ReadLine()) != null)
                            {
                                int line_index = counter - 1;
                                if (System.Text.RegularExpressions.Regex.IsMatch(line, txtSearchTerm.Text))
                                {
                                    String get_cur_path = getFile.Replace(cur_path, "");
                                    get_cur_path = get_cur_path.Replace("\\", "/");

                                    var match = foundFiles.FirstOrDefault(stringToCheck => stringToCheck.Contains(get_cur_path));
                                    if (match == null)
                                    {
                                        //if (lines_count > 1)
                                        //{
                                        Array.Resize(ref this.SearchResults, counter3);
                                        //}

                                        this.SearchResults[lines_count3 - 1] = new SearchResult { Path = get_cur_path, FullPath = getFile, Results = "", OpenNotePad = "Notepad", OpenPHPStorm = "PHPStorm", OpenPath = "Folder" };
                                        foundFiles.Add(get_cur_path);
                                        lines_count3++;
                                        counter3++;
                                    }
                                }
                               
                            }
                            file.Close();
                        }
                    }

                    dgvSearchResults.DataSource = this.SearchResults;
                }
                else
                {
                    this.SearchResults = new SearchResult[0];
                    dgvSearchResults.DataSource = this.SearchResults;
                }
                lblLoading.Visible = false;
                this.Update();
            } 
            else
            {
                lblLoading.Visible = true;
                lblLoading.Text = "Loading...";
                this.Update();

                String cur_path = "";
                String cur_path2 = this.paths[cboPaths.SelectedIndex];


                String[] curPathArr;
                curPathArr = cur_path2.Split('\\');
                int lastCurPathIndex = curPathArr.Length - 1;


                if (tvCurrentPath.SelectedNode != null)
                {
                    String cur_node = tvCurrentPath.SelectedNode.FullPath.ToString();
                    Debug.WriteLine("cur_Node: " + cur_node);
                    
                    cur_path = cur_path2 + cur_node.Replace(curPathArr[lastCurPathIndex], "\\");
                }
                else
                {
                    cur_path = cur_path2;
                }
                Debug.WriteLine("cur_path: " + cur_path);

                String cur_file_type = cboFileTypes.SelectedItem.ToString();
                if (cur_file_type == "ALL")
                {
                    cur_file_type = "*";
                }

                this.SearchResults = new SearchResult[0];
                dgvSearchResults.DataSource = this.SearchResults;
                List<string> files = Directory.GetFiles(cur_path, "*." + cur_file_type, SearchOption.AllDirectories).ToList();

                int counter = 1;
                int lines_count = 1;

                List<String> foundFiles = new List<String>();
                foreach (String getFile in files)
                {



                    String get_cur_path = getFile.Replace(cur_path, "");
                    get_cur_path = get_cur_path.Replace("\\", "/");

                    if (get_cur_path.IndexOf(txtSearchTerm.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var match = foundFiles.FirstOrDefault(stringToCheck => stringToCheck.Contains(get_cur_path));
                        if (match == null)
                        {
                            //if (lines_count > 1)
                            //{
                            Array.Resize(ref this.SearchResults, counter);
                            //}

                            this.SearchResults[lines_count - 1] = new SearchResult { Path = get_cur_path, FullPath = getFile, Results = "", OpenNotePad = "Notepad", OpenPHPStorm = "PHPStorm", OpenPath = "Folder" };
                            foundFiles.Add(get_cur_path);
                            lines_count++;
                            counter++;
                        }

                    }
                    
                }
                

                dgvSearchResults.DataSource = this.SearchResults;


                lblLoading.Visible = false;
                this.Update();
            }
        }

        private void writeLog(String line)
        {
            System.IO.File.AppendAllText(@"C:\temp\wingrep_log.txt", line + "\n");

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboJustFiles.Checked == false)
            {
                if (e.ColumnIndex == 2)
                {
                    this.runCommand("start notepad++", this.SearchResults[e.RowIndex].FullPath);
                    
                }
                else if (e.ColumnIndex == 3)
                {
                    String cur_path = "";
                    String cur_path2 = this.paths[cboPaths.SelectedIndex];

                    String[] curPathArr;
                    curPathArr = cur_path2.Split('\\');
                    int lastCurPathIndex = curPathArr.Length - 1;

                    if (tvCurrentPath.SelectedNode != null)
                    {
                        String cur_node = tvCurrentPath.SelectedNode.FullPath.ToString();
                        Debug.WriteLine("cur_Node: " + cur_node);
                        cur_path = cur_path2 + cur_node.Replace(curPathArr[lastCurPathIndex], "\\");

                        this.runCommand("PhpStorm.exe", cur_path2 + " " + this.SearchResults[e.RowIndex].FullPath);
                    }
                    else
                    {
                        cur_path = cur_path2;



                        this.runCommand("PhpStorm.exe", cur_path2 + " " + this.SearchResults[e.RowIndex].FullPath);
                    }
                    
                }
            }
            if (e.ColumnIndex == 4)
            {
                DirectoryInfo info = new DirectoryInfo(this.SearchResults[e.RowIndex].FullPath);
                String currentDirectoryName = info.Parent.FullName;
                Debug.WriteLine(currentDirectoryName);
                this.runCommand("%windir%\\explorer.exe", "\"" + currentDirectoryName + "\"");

            }

        }

        public void runCommand(String command1, String argument1)
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            Debug.WriteLine("command1: " + command1 + " " + argument1);
            cmd.StandardInput.WriteLine(command1 + " " + argument1);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchTerm_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListDirectory(tvCurrentPath, this.paths[cboPaths.SelectedIndex]);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.dgvSearchResults.ClipboardCopyMode =
            DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            dgvSearchResults.ClearSelection();
            for (int r = 0; r < dgvSearchResults.RowCount; r++)
            {
                dgvSearchResults[0, r].Selected = true;
                dgvSearchResults[1, r].Selected = true;
            }

            Clipboard.SetDataObject(
                    this.dgvSearchResults.GetClipboardContent());
            lblLoading.Text = "Information Copied";
        }
    }

    public class SearchResult
    {
        public String Path { get; set; }
        public String FullPath { get; set; }
        public String Results { get; set; }
        public String OpenNotePad { get; set; }
        public String OpenPHPStorm { get; set; }
        public String OpenPath { get; set; }
    }
}
