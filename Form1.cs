namespace galaxy
{
    public partial class Form1 : Form
    {
        private readonly GameCenter _gameCenter;
        public Form1()
        {
            InitializeComponent();
            _gameCenter = new GameCenter(pictureBox1, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            _gameCenter.Play();
        }
    }
}