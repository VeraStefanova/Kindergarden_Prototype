namespace Kindergarden_WForm
{
     
    public partial class Form1 : Form
    {
        const int SplitterDist = 220;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            splitContainer1.IsSplitterFixed = false;
            splitContainer1.SplitterDistance = SplitterDist;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuCollapse();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            splitContainer1.Panel1Collapsed = false;
            for (int i = 0; i < SplitterDist; i++)
            {
                splitContainer1.SplitterDistance = i;
            }
            
        }
        private void MenuCollapse()
        {
            for (int i = splitContainer1.SplitterDistance; i > 0; i--)
            {
                splitContainer1.SplitterDistance = i;
            }
            splitContainer1.Panel1Collapsed = true;
            button3.Visible = true;
            //TODO: Make labels and buttons visible after collapse
        }
    }
}
