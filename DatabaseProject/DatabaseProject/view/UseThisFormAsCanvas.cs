using DatabaseProject.daos;
using DatabaseProject.database;
using DatabaseProject.model.code;
using DatabaseProject.view.images;

namespace DatabaseProject
{
    public partial class UseThisFormAsCanvas : Form
    {
        public Panel PanelContainer { get; set; }

        public UseThisFormAsCanvas()
        {
            InitializeComponent();
        }

        private void PlayersScreen_Load(object sender, EventArgs e)
        {
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddBuildingToView(Edificio building)
        {
            var imageIndex = ImageLoader.GetIndexFromDatabaseBuildingName(building.Nome);
            var listItem = new ListViewItem
            {
                Text = building.Nome,
                ImageIndex = (int)imageIndex
            };
            BuildingType type = Enum.Parse<BuildingType>(building.Tipo);
            switch (type)
            {
                case BuildingType.Defense:
                    listItem.Group = listView1.Groups[2];
                    break;
                case BuildingType.Resource:
                    listItem.Group = listView1.Groups[1];
                    break;
                case BuildingType.Special:
                    listItem.Group = listView1.Groups[0];
                    break;
            }
            listView1.Items.Add(listItem);
        }

        public void AddTroopToView(Truppa troop)
        {
            var imageIndex = ImageLoader.GetIndexFromDatabaseTroopName(troop.Nome);
            var listItem = new ListViewItem
            {
                Text = troop.Nome,
                ImageIndex = (int)imageIndex
            };
            this.troopsListView.Items.Add(listItem);
        }
    }
}
