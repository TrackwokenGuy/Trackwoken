using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeepwokenChecklist
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // Scuffed, very scuffed... Eh, oh well
        public void ResetTalentsObtained()
        {
            if (!buildLoaded) return;

            foreach (Talent talent in LoadedBuild.talents.Values)
            {
                talent.obtained = false;
            }
        }

        bool buildLoaded = false;
        Build _loadedBuild;
        public Build LoadedBuild { get { return _loadedBuild; } set { ResetTalentsObtained(); _loadedBuild = value; buildLoaded = true; } }
        public Talent[] closestTalents = new Talent[Data.Attributes.Length];

        private void Main_Load(object sender, EventArgs e)
        {
            InfoAPI.Load();

            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\last.twk";
            if (File.Exists(path))
            {
                LoadFile(path);
            }
        }

        public void LoadFromUrl(string url)
        {
            if (!url.Contains("https://deepwoken.co/")) return;

            url = url.Replace("https://deepwoken.co/builder", "build");

            LoadedBuild = InfoAPI.GetBuild(url);

            UpdateTalents();
            UpdateNearestTalents();
        }

        void UpdateTalents()
        {
            TalentCheckList.Items.Clear();
            QuickCheckBox.Items.Clear();
            foreach (Talent talent in LoadedBuild.talents.Values)
            {
                int index = TalentCheckList.Items.Add(talent.name);
                

                if (talent.obtained)
                {
                    TalentCheckList.SetItemChecked(index, true);
                    continue;
                }

                QuickCheckBox.Items.Add(talent.name);
            }
        }

        void UpdateNearestTalents()
        {
            closestTalents = new Talent[Data.Attributes.Length];

            foreach (Talent talent in LoadedBuild.talents.Values)
            {
                if (talent.obtained) continue;

                var requirements = talent.requirements;
                var attrReq = requirements.attributes;

                List<int> candidates = new List<int>();

                for (int i = 0; i < Data.Attributes.Length; i++)
                {
                    if (attrReq[i] == 0) continue;

                    var skip = false;
                    for (int j = 0; j < Data.Attributes.Length; j++)
                    {
                        if (attrReq[j] > attrReq[i])
                        {
                            skip = true;
                            break;
                        }
                    }
                    if (skip) continue;

                    var currentClosest = closestTalents[i];
                    if (currentClosest == null || currentClosest.requirements.attributes[i] > attrReq[i])
                    {
                        candidates.Add(i);
                        continue;
                    }
                    else if (currentClosest.requirements.attributes[i] == attrReq[i])
                    {
                        if (currentClosest.requirements.SumOfAttributes() > requirements.SumOfAttributes())
                        {
                            candidates.Add(i);
                            continue;
                        }
                    }
                }

                int closestCandidate = -1;
                int closestCandidateValue = int.MaxValue;
                foreach (int i in candidates)
                {
                    if (attrReq[i] < closestCandidateValue)
                    {
                        closestCandidate = i;
                        closestCandidateValue = attrReq[i];
                    }
                }

                if (closestCandidate == -1) continue;

                closestTalents[closestCandidate] = talent;
            }

            UpdateRequirementsTree();
        }

        void UpdateRequirementsTree()
        {
            var nodes = RequirementsTree.Nodes;
            nodes.Clear();

            foreach (Talent talent in closestTalents)
            {
                if (talent == null) continue;

                var requirements = talent.requirements;
                var attrReq = requirements.attributes;

                var root = nodes.Add(talent.name);

                for (int i = 0; i < Data.Attributes.Length; i++)
                {
                    if (attrReq[i] == 0) continue;

                    root.Nodes.Add($"{Data.Attributes[i]} - {attrReq[i]}");
                }

                root.Expand();
            }
        }

        private void QuickCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string talentName = QuickCheckBox.Text;
            if (!LoadedBuild.talents.ContainsKey(talentName)) return;

            Talent talent = LoadedBuild.talents[talentName];

            int index = TalentCheckList.Items.IndexOf(talent.name);
            TalentCheckList.SetItemChecked(index, true);
        }

        private void TalentCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string talentName = (string)TalentCheckList.Items[e.Index];
            bool obtained = e.NewValue == CheckState.Checked;

            LoadedBuild.talents[talentName].obtained = obtained;

            if (obtained)
            {
                QuickCheckBox.Items.Remove(talentName);
            }
            else
            {
                QuickCheckBox.Items.Add(talentName);
            }

            UpdateNearestTalents();
        }

        URLDialog urlDialog = new URLDialog();
        private void deepwokenBuilderURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urlDialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = SaveDialog.ShowDialog();
            if (result != DialogResult.OK && result != DialogResult.Yes) return;

            SaveFile(SaveDialog.FileName);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = OpenDialog.ShowDialog();
            if (result != DialogResult.OK && result != DialogResult.Yes) return;

            LoadFile(OpenDialog.FileName);
        }

        JsonSerializer jsonSerializer = new JsonSerializer();
        void SaveFile(string path)
        {
            Build copy = LoadedBuild;
            

            using (FileStream file = File.OpenWrite(path))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    jsonSerializer.Serialize(writer, LoadedBuild);
                }
            }
           
        }
        void LoadFile(string path)
        {
            using (FileStream file = File.OpenRead(path))
            {
                using (JsonReader reader = new JsonTextReader(new StreamReader(file)))
                {
                    LoadedBuild = jsonSerializer.Deserialize<Build>(reader);
                }
            }

            UpdateTalents();
            UpdateNearestTalents();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\last.twk");
        }
    }
}
