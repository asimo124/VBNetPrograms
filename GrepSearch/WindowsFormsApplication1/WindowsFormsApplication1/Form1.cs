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
            this.SearchResults = new SearchResult[0];
            dgvSearchResults.DataSource = this.SearchResults;
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
            cboFileTypes.Items.Add("JS");
            cboFileTypes.Items.Add("HTM");
            cboFileTypes.Items.Add("CSS");
            cboFileTypes.Items.Add("SQL");
            cboFileTypes.Items.Add("PY");
            cboFileTypes.Items.Add("JAVA");

            cboFileTypes.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtSearchTerm.Text.Trim() != "")
            {

                String cur_path = this.paths[cboPaths.SelectedIndex];

                String cur_file_type = cboFileTypes.SelectedItem.ToString();
                if (cur_file_type == "ALL")
                {
                    cur_file_type = "*";
                }

                this.SearchResults = new SearchResult[0];
                dgvSearchResults.DataSource = this.SearchResults;
                List<string> files = Directory.GetFiles(cur_path, "*." + cur_file_type, SearchOption.AllDirectories).ToList();

                if (cboJustFiles.Checked == false)
                {
                    foreach (String getFile in files)
                    {
                        int counter = 1;
                        int lines_count = 1;
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
                                this.SearchResults[lines_count - 1] = new SearchResult { Path = get_cur_path + ":" + counter, FullPath = getFile, Line = line, OpenNotePad = "View in NotePad" };

                                lines_count++;
                            }
                            counter++;
                        }
                        file.Close();
                    }
                }
                else
                {
                    List<String> foundFiles = new List<String>();
                    foreach (String getFile in files)
                    {
                        int counter = 1;
                        int lines_count = 1;
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
                                    Array.Resize(ref this.SearchResults, counter);
                                    //}

                                    this.SearchResults[lines_count - 1] = new SearchResult { Path = get_cur_path, FullPath = "", Line = "", OpenNotePad = "" };
                                    foundFiles.Add(get_cur_path);
                                    lines_count++;
                                }
                            }
                            counter++;
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
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvSearchResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboJustFiles.Checked == false)
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();

                cmd.StandardInput.WriteLine("start notepad++ " + this.SearchResults[e.RowIndex].FullPath);
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.WaitForExit();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    public class SearchResult
    {
        public String Path { get; set; }
        public String FullPath { get; set; }
        public String Line { get; set; }
        public String OpenNotePad { get; set; }
    }
}
