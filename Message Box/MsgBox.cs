
// Amir Moeini Rad
// September 2025

// Main Concept: MessageBox and ContextMenu in a Windows Forms application


using System;
using System.Windows.Forms;


public class MsgBox : Form
{
    // Declare a Popup Menu shown by right clicking.
    private ContextMenu myPopUp;

    // Declare a Label control.
    private Label myLabel;


    // Constructor
    public MsgBox()
    {
        // Display a Message Box when the application starts.
        MessageBox.Show("The Application is starting...", "Status", MessageBoxButtons.OK , MessageBoxIcon.Information);

        // Set the properties of the main form
        InitializeComponent();

        // Create the Popup Menu
        CreatePopUp();        

        // Display another Message Box when the initialization process has finished and the application is ready.
        MessageBox.Show("Main Form has been initialized.", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    // The method to initialize some properties of the main form and other controls on it.
    private void InitializeComponent()
    {
        // Form properties
        Text = "Main Form";
        StartPosition = FormStartPosition.CenterScreen;

        // Set the properties of the label and add it to the main form.
        // Setting the properties are done in the new C# object initializer syntax.
        myLabel = new Label
        {
            Text = "Right click to see the Popup Menu.",
            AutoSize = true,
            Location = new System.Drawing.Point(1, 1)
        };
        Controls.Add(myLabel);
    }


    // A custom event handler to be executed/called when an item in the Popup/ContextMenu is selected.
    protected void PopUp_Selection(object sender, EventArgs e)
    {
        // Determine menu item was selected/clicked and then do some logic.
        MessageBox.Show(((MenuItem)sender).Text + " selected.", "C# Message Box");
    }


    // Create the Popup Menu
    private void CreatePopUp()
    {
        myPopUp = new ContextMenu();

        myPopUp.MenuItems.Add("First Item", new EventHandler(PopUp_Selection));
        myPopUp.MenuItems.Add("Second Item", new EventHandler(PopUp_Selection));
        myPopUp.MenuItems.Add("-");
        myPopUp.MenuItems.Add("Third Item", new EventHandler(PopUp_Selection));

        // Attaching the created Popup Menu to a ContextMenu on the main form.
        ContextMenu = myPopUp;
    }


    // Main Method
    public static void Main(string[] args)
    {
        Application.Run(new MsgBox());

        // Show a Message Box when the application is exiting.
        MessageBox.Show("The Application is exiting...", "Status", MessageBoxButtons.OK , MessageBoxIcon.Information);
    }
}