/*
 * This works, but it's still a work in progress. 
 * 
 * Known Issues:
 *  1: If updates are comming in faster than ~20ms the UI stops responding.
 *  2: There is no exception handling for choosing the wrong, or unsupported
 *  baud rate.
 *  3: Not really an issue, but file compression hasn't been implemented yet.
 * 
 * 
 * Usage:
 *  1: Click Aquire to get available COM ports
 *  2: Select COM port and Baud Rate. If logging is desired, set file location and name.
 *  3: Click connect. Use the command window to transmit commands through the com port.
 *  4: When logging is complete, click close to close the connection.
 *  
 * 
 */







using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace SerialLogger//SerialComTestForm
{
    public partial class SerialLogger : Form
    {



        /*************************************************************
        * 
        *          Local Variables
        * 
        *************************************************************/

        // variables
        private SerialPort SerialPort1;
        private delegate void AddDataDelegate(String newBuffer);
        private AddDataDelegate myDelegate;
        StringBuilder sb;

        private loggingState logState;
        private bool isOpen;
        private String com;
        private string[] BAUDRATE = { "115200", "56700", "9600" };
        private int[] _BAUDRATE = { 115200, 56700, 9600 };
        private StreamWriter file;

        // Enumerations
        private enum loggingState
        {
            noLog,
            logCSV,
            logAndCompress
        }

        private enum connectionState
        {
            aquire,
            connect,
            close
        }


        /*************************************************************
        * 
        *          Constructor and form load event handler
        * 
        *************************************************************/
        public SerialLogger()
        {
            InitializeComponent();
        }

        private void SerialLogger_Load(object sender, EventArgs e)
        {
            //initialize some variables.
            for (int i = 0; i < BAUDRATE.Length; i++)
            {
                baudRateCB.Items.Add(BAUDRATE[i]);
            }
            SerialPort1 = new SerialPort();
            baudRateCB.SelectedItem = BAUDRATE[0];
            this.myDelegate = new AddDataDelegate(addText);
            SerialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            isOpen = false;
            logState = loggingState.noLog;
            sb = new StringBuilder();
        }


        /*************************************************************
        * 
        *          Buttons
        * 
        *************************************************************/

        private void aquire_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                availableConnections.Items.Add(ports[i]);
            }

            if (ports.Length > 0)
            {
                availableConnections.SelectedItem = ports[0];
                setFormState(connectionState.aquire);
            }
        }


        private void connect_Click(object sender, EventArgs e)
        {

            com = availableConnections.Text;
            SerialPort1.PortName = com;
            int baudRate_index = baudRateCB.Items.IndexOf(baudRateCB.Text);
            SerialPort1.BaudRate = _BAUDRATE[baudRate_index];
            SerialPort1.Parity = System.IO.Ports.Parity.None;
            SerialPort1.DataBits = 8;
            SerialPort1.StopBits = System.IO.Ports.StopBits.One;
            SerialPort1.Handshake = System.IO.Ports.Handshake.None;
            SerialPort1.RtsEnable = false;

            setFormState(connectionState.connect);
            if (logState == loggingState.logCSV)
            {
                file = new StreamWriter(filePathTB.Text + fileNameTB.Text);
                file.WriteLine("TX\\RX,MM,dd,yyyy,hh,mm,ss,ms,msg");
            }

            try
            {
                SerialPort1.Open();
                SerialPort1.DiscardInBuffer();
                SerialPort1.DiscardOutBuffer();
            }
            catch (UnauthorizedAccessException e1)
            {
                setFormState(connectionState.close);
                communicationTraffic.Text = "Com Port: " + availableConnections.Text  +
                                             " is unavailable.";
            }
            catch (ArgumentException e1)
            {
                setFormState(connectionState.close);
                communicationTraffic.Text = "Com Port: " + availableConnections.Text  +
                                             " does not exist.";
            }

        }


        private void closeConnection_Click(object sender, EventArgs e)
        {
            if (isOpen)
            {
                SerialPort1.DiscardInBuffer();
                SerialPort1.Close();
                isOpen = false;
            }
            if(logState == loggingState.logCSV)
            {
                file.Flush();
                file.Close();
            }
            setFormState(connectionState.close);
        }

        private void command_TextChanged(object sender, EventArgs e)
        {
            char[] stringChars = command.Text.ToCharArray();
            String temp;
            if (stringChars.Length > 0)
            {
                if ((int)stringChars[stringChars.Length - 1] == 10 && stringChars.Length > 2)
                {
                    temp = "TX," + DateTime.Now.ToString("MM','dd','yyyy','hh','mm','ss") + "," + DateTime.Now.Millisecond.ToString() + "," + command.Text.Substring(0, command.Text.Length - 2) + Environment.NewLine;
                    if (logState == loggingState.logCSV)
                    {
                        file.Write(temp);
                    }
                    communicationTraffic.AppendText(temp);
                    SerialPort1.Write(command.Text + (char)13);
                    command.Text = "";
                }
                else if ((int)stringChars[stringChars.Length - 1] == 10)
                {
                    command.Text = "";
                }
            }
        }

        /*************************************************************
        * 
        *          Radio Buttons
        * 
        *************************************************************/
        private void noLog_CheckedChanged(object sender, EventArgs e)
        {
            logState = loggingState.noLog;
            setFilePath.Enabled = false;
            fileNameTB.Enabled = false;
            fileNameTB.Text = "";
            connect.Enabled = true;
        }

        private void logCSV_CheckedChanged(object sender, EventArgs e)
        {
            logState = loggingState.logCSV;
            setFilePath.Enabled = true;
            fileNameTB.Enabled = true;
            fileNameTB.Text = "Log_" + DateTime.Now.ToString("MMddyyyy'_'hhmmss") + ".csv";
            if (filePathTB.Text != "Choose File Location")
            {
                connect.Enabled = true;
            }
            else
            {
                connect.Enabled = false;
            }
        }

        private void logAndCompress_CheckedChanged(object sender, EventArgs e)
        {
            logState = loggingState.logAndCompress;
        }

        /*************************************************************
         * 
         *          Helper Functions
         * 
         *************************************************************/

        private void addText(String newBuffer)
        {
            Char[] charBuffer = newBuffer.ToCharArray();
            for (int i = 0; i < charBuffer.Length; i++)
            {
                if ((int)charBuffer[i] > 31 && (int)charBuffer[i] < 127)
                {
                    sb.Append(charBuffer[i]);
                }

                if ((int)charBuffer[i] == 13)
                {
                    if (logState == loggingState.logCSV)
                    {
                        file.Write(sb.ToString() + Environment.NewLine);
                    }
                    communicationTraffic.AppendText(sb.ToString() + Environment.NewLine);
                    sb = new StringBuilder("RX," + DateTime.Now.ToString("MM','dd','yyyy','hh','mm','ss") + "," + DateTime.Now.Millisecond.ToString() + ",");
                }

            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            String serialBuffer = sp.ReadExisting();
            communicationTraffic.Invoke(this.myDelegate, serialBuffer);
        }

        /*
         * This functions in more about setting the state of the form
         * during different connctions states.
         */
        private void setFormState(connectionState state)
        {
            switch (state)
            {
                case connectionState.aquire:
                    //Enablements
                    loggingGroup.Enabled = true;
                    aquire.Enabled = false;
                    if (noLog.Checked || (logCSV.Checked && filePathTB.Text != "Choose File Location") && (fileNameTB.Text != ""))
                    {
                        connect.Enabled = true;
                    }
                    else
                    {

                        connect.Enabled = false;
                    }
                    if (logCSV.Checked)
                    {
                        fileNameTB.Text = "Log_" + DateTime.Now.ToString("MMddyyyy'_'hhmmss") + ".csv";
                        fileNameTB.Enabled = true;
                    }
                    closeConnection.Enabled = true;
                    availableConnections.Enabled = true;
                    baudRateCB.Enabled = true;

                    break;

                case connectionState.connect:

                    //Clear Log and Command Windown
                    command.Text = "";
                    communicationTraffic.Text = "";

                    //  Enablements
                    aquire.Enabled = false;
                    closeConnection.Enabled = true;
                    connect.Enabled = false;
                    loggingGroup.Enabled = false;
                    communicationTraffic.Enabled = false;
                    command.Enabled = true;
                    availableConnections.Enabled = false;
                    baudRateCB.Enabled = false;
                    fileNameTB.Enabled = false;
                    setFilePath.Enabled = false;
                    //Open Flag
                    isOpen = true;
                    if (noLog.Checked)
                    {
                        logState = loggingState.noLog;
                    }
                    else if (logCSV.Checked)
                    {
                        logState = loggingState.logCSV;
                    }
                    break;


                case connectionState.close:

                    command.Text = "";
                    //  Enablements
                    fileNameTB.Text = "";
                    aquire.Enabled = true;
                    connect.Enabled = false;
                    closeConnection.Enabled = false;
                    loggingGroup.Enabled = false;
                    communicationTraffic.Enabled = true;
                    command.Enabled = false;
                    availableConnections.Items.Clear();
                    availableConnections.Text = "";
                    availableConnections.Enabled = false;
                    baudRateCB.Enabled = false;
                    break;

                default:

                    break;
            }
        }

        private void setFilePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePathTB.Text = ofd.SelectedPath + "\\";
                Console.WriteLine(ofd.SelectedPath);
                if (fileNameTB.Text != "")
                {
                    connect.Enabled = true;
                }
            }


        }

        private void fileNameTB_TextChanged(object sender, EventArgs e)
        {
            if (fileNameTB.Text.Length > 0)
            {
                connect.Enabled = true;
            }
            else
            {
                connect.Enabled = false;
            }
        }
    }
}