/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.cs
// Description: 
//
// Name: Logan
// Last Edit: 11/2
/////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class UIForm : Form
    {
        private Marquee MyMarquee = null;
        private Thread myDisplayThread = null;
        private Thread myBorderThread = null;
        private Segment[] mySegmentArray;

        public OpenFileDialog openFileDialog { get; private set; }

        public UIForm()
        {
            InitializeComponent();
        }      

        private void UIForm_Load(object sender, EventArgs e)
        {
            MyMarquee = new Marquee(this.marquee);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (myDisplayThread != null)
            {
                if (myDisplayThread.IsAlive)
                {
                    myDisplayThread.Abort();
                }
            }
            tabControl.Visible = false;
            createNewMessageButton.Visible = false;
            uploadMessageFromFileButton.Visible = false;
            fileLocationTextBox.Visible = false;
            browseButton.Visible = false;
            uploadButton.Visible = false;
            segment1Button.Visible = false;
            addSegmentButton1.Visible = false;
            marquee.Visible = true;
            Segment mySegment = new Segment("TEAM", Color.Red, 0, 0, 0);
            Segment mySecondSegment = new Segment("DISCOVERY", Color.Aqua, 0, 0, 0);
            mySegmentArray = new Segment[] {mySegment, mySecondSegment};
            Message myMessage = new Vision.Message(mySegmentArray, Color.Black, 200, 2000);
            myBorderThread = new Thread(delegate () { MyMarquee.displayBorder(Color.Red, Color.Black); });
            myDisplayThread = new Thread(delegate(){ MyMarquee.displayMessage(myMessage); });
            //Message myMessage = new Vision.Message("DISCOVERY", Color.Aqua, Color.Black, Color.Black, Color.Red, 0, 0, 0);
            //myDisplayThread = new Thread(delegate () {
            //    MyMarquee.displayRandomColorMessage(myMessage);
            //});
            myBorderThread.Start();
            myDisplayThread.Start();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            int size = -1;

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Test result.
            {
                string filename = openFileDialog.SafeFileName;

            }
        }

        private void uploadMessageFromFileButton_CheckedChanged(object sender, EventArgs e)
        {
            if (uploadMessageFromFileButton.Checked)
            {
                fileLocationTextBox.Visible = true;
                browseButton.Visible = true;
                uploadButton.Visible = true;
            }
            else if (!uploadMessageFromFileButton.Checked)
            {
                fileLocationTextBox.Visible = false;
                browseButton.Visible = false;
                uploadButton.Visible = false;
            }
        }

        private void createNewMessageButton_CheckedChanged(object sender, EventArgs e)
        {
            if (createNewMessageButton.Checked)
            {
                createAMessageGroupBox.Visible = true;
                textLabel.Visible = true;
                textTextBox.Visible = true;
                transitionLabel.Visible = true;
                transitionComboBox.Visible = true;
                repeatLabel.Visible = true;
                repeatComboBox.Visible = true;
                colorLabel.Visible = true;
                colorComboBox.Visible = true;
                transitionSpeedLabel.Visible = true;
                transitionSpeedComboBox.Visible = true;
                specialEffectButton.Visible = true;
                scrollingTextButton.Visible = true;
            }
            else if (!createNewMessageButton.Checked)
            {
                createAMessageGroupBox.Visible = false;
                textLabel.Visible = false;
                textTextBox.Visible = false;
                transitionLabel.Visible = false;
                transitionComboBox.Visible = false;
                repeatLabel.Visible = false;
                repeatComboBox.Visible = false;
                colorLabel.Visible = false;
                colorComboBox.Visible = false;
                transitionSpeedLabel.Visible = false;
                transitionSpeedComboBox.Visible = false;
                specialEffectButton.Visible = false;
                scrollingTextButton.Visible = false;
            }
        }
        private void segment1Button_Click(object sender, EventArgs e)
        {
            segment1Button.BackColor = Color.SlateGray;
        }
        private void segment7Button_Click(object sender, EventArgs e)
        {

        }
    }
}
